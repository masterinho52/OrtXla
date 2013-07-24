using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Controls;
using MySql.Data.MySqlClient;
using System.Globalization;


namespace ortoxela.ModCobranza
{
    public partial class frm_pagos_proveedores : Form
    {
        public frm_pagos_proveedores()
        {
            InitializeComponent();
        }

        private void frm_pagos_proveedores_Load(object sender, EventArgs e)
        {
            try
            {
                dateEdit1.DateTime = DateTime.Now;
                cargaProveedores();
                CargaTipoDoc();
                CargaTipoPago();
                CreaColumnasGV();
                CargaBancos();
                xtraTabPage2.PageEnabled = false;
                groupControl2.Enabled = true;
                panelControl3.Enabled = false;
                Sbimprimir.Enabled = false;
                simpleButton4.Enabled = true;
                textTotal.Text = "";
                textNombreProveedor.Text = "";
                lbSaldoTotal.Text = "Q0.00";
                lbTotalSaldo.Text = "Q0.00";
                labelCantidadRestante.Text = labelCantRestante.Text = "Q0.00";
                memoEdit1.Text = "";
                gridLookProveedor.EditValue = 0;                
            }
            catch { }            
        }


        string cadena;
        classortoxela ortoxela = new classortoxela();

        private void CargaTipoPago()
        {
            cadena = "SELECT tp.tipo_pago AS CODIGO,tp.nombre_tipo_pago AS 'TIPO PAGO' FROM tipo_pago tp WHERE tp.estadoid=1";
            gridLookTipoPago.Properties.DataSource = ortoxela.Tabla(cadena);
            gridLookTipoPago.Properties.DisplayMember = "TIPO PAGO";
            gridLookTipoPago.Properties.ValueMember = "CODIGO";
            gridLookTipoPago.EditValue = null; 
           
        }
        private void CargaBancos()
        {
            cadena = "SELECT bancos.id_banco AS CODIGO,bancos.nombre_banco AS NOMBRE FROM bancos WHERE bancos.estado=1";
            gridLookBanco.Properties.DataSource = ortoxela.Tabla(cadena);
            gridLookBanco.Properties.DisplayMember = "NOMBRE";
            gridLookBanco.Properties.ValueMember = "CODIGO";
            gridLookBanco.EditValue = null;
            
        }
        private void CargaTipoDoc()
        {
            cadena = "SELECT sd.codigo_serie AS CODIGO, concat(td.nombre_documento, '[',sd.serie_documento,']') AS NOMBRE FROM tipos_documento td inner join series_documentos sd on td.codigo_tipo=sd.codigo_tipo WHERE td.estado_id=1 AND td.documento_cobro=1 and sd.codigo_modulo=2";
            gridLookTipoDoc.Properties.DataSource = ortoxela.Tabla(cadena);
            gridLookTipoDoc.Properties.DisplayMember = "NOMBRE";
            gridLookTipoDoc.Properties.ValueMember = "CODIGO";
            gridLookTipoDoc.EditValue = null;            
        }

        private void cargaProveedores()
        {
            cadena = "SELECT DISTINCT c.codigo_proveedor AS CODIGO,c.nombre_proveedor AS NOMBRE FROM header_doctos_inv hd INNER JOIN proveedores c ON hd.codigo_proveedor=c.codigo_proveedor WHERE hd.contado_credito=1 AND hd.estadoid=4";
            gridLookProveedor.Properties.DataSource = ortoxela.Tabla(cadena);
            gridLookProveedor.Properties.DisplayMember = "NOMBRE";
            gridLookProveedor.Properties.ValueMember = "CODIGO";
        }

        private void CreaColumnasGV()
        {
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("IDTIPOPAGO");
            dtTemp.Columns.Add("TIPO PAGO");
            dtTemp.Columns.Add("NO DOCUMENTO");
            dtTemp.Columns.Add("IDBANCO");
            dtTemp.Columns.Add("BANCO");
            dtTemp.Columns.Add("MONTO");
            dtTemp.Columns.Add("SALDO");
            gridControl2.DataSource = dtTemp;
            gridView4.Columns["IDTIPOPAGO"].Visible = false;
            gridView4.Columns["IDBANCO"].Visible = false;
            gridView4.Columns["TIPO PAGO"].OptionsColumn.ReadOnly = true;
            gridView4.Columns["NO DOCUMENTO"].OptionsColumn.ReadOnly = true;
            gridView4.Columns["BANCO"].OptionsColumn.ReadOnly = true;
            gridView4.Columns["MONTO"].OptionsColumn.ReadOnly = true;
            gridView4.Columns["SALDO"].OptionsColumn.ReadOnly = true;
        }




        string id_proveedor;

        private void textNombreProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            cadena = "SELECT DISTINCT c.codigo_proveedor AS CODIGO,c.nombre_proveedor AS 'NOMBRE DE PROVEEDOR',c.nit AS 'NIT',c.telefono_principal AS 'TELEFONO DE OFICINA' FROM header_doctos_inv hd INNER JOIN proveedores c ON hd.codigo_proveedor=c.codigo_proveedor WHERE hd.contado_credito=1 AND hd.estadoid=4";
            clases.ClassVariables.cadenabusca = cadena;
            Form nuevo = new Buscador.Buscador();
            nuevo.ShowDialog();
            if (Buscador.Buscador.SeleccionSiNo)
            {
                id_proveedor = clases.ClassVariables.id_busca;
                gridLookProveedor.EditValue = Convert.ToInt32(id_proveedor);
                textNombreProveedor.Text = gridLookProveedor.Text;
            }
            e.KeyChar = Convert.ToChar(13);
        }

        private void gridLookTipoDoc_EditValueChanged(object sender, EventArgs e)
        {
            xtraTabPage2.PageEnabled = false;
            if ((gridLookTipoDoc.EditValue.ToString() != "0") && (gridLookTipoDoc.EditValue != null) && ((gridLookTipoDoc.EditValue != string.Empty)))
                textTotal.Enabled = true;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (dxValidationEncabezado.Validate())
            {
                panelControl3.Enabled = true;
            }
            else
                clases.ClassMensajes.FaltanDatosEnCampos(this);
        }

        classortoxela logicaorto = new classortoxela();
        //lbTotalSaldo obtiene es salto total acumulado de todas las facturas pendiente del proveedor seleccionado
        private void gridLookProveedor_EditValueChanged(object sender, EventArgs e)
        {
            labelNombreProveedor.Text = "[Codigo:" + gridLookProveedor.EditValue + "]- " + gridLookProveedor.Text;
            xtraTabPage2.PageEnabled = false;
            cadena = "SELECT COALESCE(SUM(SALDO),0)AS TotalSaldo FROM(SELECT (monto_neto-COALESCE(TotAbono,0))AS 'SALDO' " +
"FROM ortoxela.header_doctos_inv h LEFT JOIN  ortoxela.v_abonos_factura f ON (h.id_documento=f.id_factura) " +
"INNER JOIN series_documentos sd ON h.codigo_serie=sd.codigo_serie " +
"WHERE h.codigo_proveedor=" + gridLookProveedor.EditValue + " AND h.estadoid=4 AND h.contado_credito=1)TablaSaldo";
            lbTotalSaldo.Text = Convert.ToDouble(logicaorto.Tabla(cadena).Rows[0][0].ToString()).ToString("C");
            labelCodigoProveedor.Text = labelCodidoProveedorAcreditar.Text = gridLookProveedor.EditValue.ToString();
        }


        private void agregaTipoPagoaGV(string id_bancos)
        {

            gridView4.AddNewRow();
            gridView4.SetRowCellValue(gridView4.FocusedRowHandle, "IDTIPOPAGO", gridLookTipoPago.EditValue.ToString());
            gridView4.SetRowCellValue(gridView4.FocusedRowHandle, "TIPO PAGO", gridLookTipoPago.Text.ToString());
            gridView4.SetRowCellValue(gridView4.FocusedRowHandle, "NO DOCUMENTO", textNoDoc.Text);
            gridView4.SetRowCellValue(gridView4.FocusedRowHandle, "IDBANCO", id_bancos);
            gridView4.SetRowCellValue(gridView4.FocusedRowHandle, "BANCO", gridLookBanco.Text);
            gridView4.SetRowCellValue(gridView4.FocusedRowHandle, "MONTO", Convert.ToDouble(textMonto.Text).ToString("C"));
            gridView4.SetRowCellValue(gridView4.FocusedRowHandle, "SALDO", (Convert.ToDouble(labelCantRestante.Text.Replace("Q", "")) - Convert.ToDouble(textMonto.Text)).ToString("C"));
            gridView4.UpdateCurrentRow();
            try
            {
                gridLookTipoPago.EditValue = null;
            }
            catch { }
            labelCantRestante.Text = (Convert.ToDouble(labelCantRestante.Text.Replace("Q", "")) - Convert.ToDouble(textMonto.Text)).ToString("C");
            textMonto.Text = textNoDoc.Text = gridLookBanco.Text = "";
            textNombreProveedor.Enabled = false;
            dateEdit1.Enabled = false;
            textTotal.Enabled = false;
            gridLookTipoDoc.Enabled = false;
            simpleButton3.Enabled = false;
            gridLookTipoPago.Focus();
        }

        private void SbAgregaTP_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridLookTipoPago.EditValue.ToString() == "1" | gridLookTipoPago.EditValue.ToString() == "4" | gridLookTipoPago.EditValue.ToString() == "5" | gridLookTipoPago.EditValue.ToString() == "6")
                {
                    if (dxValidationTipoPago.Validate() & (Convert.ToDouble(textMonto.Text) <= Convert.ToDouble(labelCantRestante.Text.Replace("Q", ""))))
                    {
                        if (Convert.ToDouble(textMonto.Text) > 0)
                            agregaTipoPagoaGV("0");
                        else
                            Mensajes.Show(this, "Informacion", "El monto tiene que ser positivo.", Properties.Resources.Advertencia48);
                    }
                    else
                        Mensajes.Show(this, "Informacion", "Faltad Datos, o el monto es demsiado grande.", Properties.Resources.Advertencia48);
                }
                else
                {

                    if (dxValidationTipoPago.Validate() & (Convert.ToDouble(textMonto.Text) <= Convert.ToDouble(labelCantRestante.Text.Replace("Q", ""))))
                    {
                        if (dxValidationBancos.Validate())
                        {
                            if (Convert.ToDouble(textMonto.Text) >= 0)
                                agregaTipoPagoaGV(gridLookBanco.EditValue.ToString());
                            else
                                Mensajes.Show(this, "Informacion", "El monto tiene que ser positivo.", Properties.Resources.Advertencia48);
                        }
                        else
                        {
                            clases.ClassMensajes.FaltanDatosEnCampos(this);
                            textNoDoc.Focus();
                        }
                    }
                    else
                        Mensajes.Show(this, "Informacion", "Faltad Datos, o el monto es demsiado grande.", Properties.Resources.Advertencia48);
                }
            }
            catch
            {
                Mensajes.Show(this, "Error de datos", "Verifique los datos porfavor", Properties.Resources.error_64);
            }
        }

        private void textTotal_Validating(object sender, CancelEventArgs e)
        {
            if (decimal.Parse(textTotal.Text.Replace("Q", "")) > decimal.Parse(lbTotalSaldo.Text.Replace("Q", "")))
            {
                Mensajes.Show(this, "Error", "MONTO NO PUEDE SER MAYOR A SALDO!, MONTO HA SIDO CAMBIADO.", Properties.Resources.Advertencia64);
                textTotal.Text = lbTotalSaldo.Text.Replace("Q", "");
            }
        }

        private void textTotal_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                labelCantRestante.Text = Convert.ToDouble(textTotal.Text.Replace("Q", "")).ToString("C");
            }
            catch
            { }
        }

        private void gridView4_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                labelCantRestante.Text = (Convert.ToDouble(labelCantRestante.Text.Replace("Q", "")) + Convert.ToDouble(gridView4.GetFocusedRowCellValue("MONTO").ToString().Replace("Q", ""))).ToString("C");
                gridView4.DeleteSelectedRows();
            }
            catch
            { }
        }


        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frm_pagos_proveedores_Load(sender, e);
            textNombreProveedor.Enabled = true;
            dateEdit1.Enabled = true;
            gridLookTipoDoc.Enabled = true;
            gridLookProveedor.EditValue = 0;
            textNombreProveedor.Focus();
        }

        private void LlenaFacturas()
        {
            cadena = "SELECT h.fecha AS 'FECHA',sd.serie_documento AS 'SERIE',h.id_documento,h.refer_documento AS 'NO. FACTURA',h.monto_neto AS 'TOTAL FACTURA',(monto_neto-COALESCE(TotAbono,0)) " +
                        "AS 'SALDO ACTUAL',0.00 AS 'ABONO',(monto_neto-COALESCE(TotAbono,0))AS 'SALDO' " +
                        "FROM ortoxela.header_doctos_inv h LEFT JOIN  ortoxela.v_abonos_factura f ON (h.id_documento=f.id_factura) " +
                        "inner join series_documentos sd on h.codigo_serie=sd.codigo_serie " +
                        "WHERE h.codigo_proveedor=" + gridLookProveedor.EditValue + " and h.estadoid=4 ANd h.contado_credito=1";
            gridControl1.DataSource = ortoxela.Tabla(cadena);
            gridView1.Columns["id_documento"].Visible = false;
            gridView1.Columns["NO. FACTURA"].OptionsColumn.ReadOnly = true;

            gridView1.Columns["TOTAL FACTURA"].OptionsColumn.ReadOnly = true;
            gridView1.Columns["SALDO ACTUAL"].OptionsColumn.ReadOnly = true;
            gridView1.Columns["SALDO"].OptionsColumn.ReadOnly = true;
            gridView1.Columns["FECHA"].OptionsColumn.ReadOnly = true;
            gridView1.Columns["SERIE"].OptionsColumn.ReadOnly = true;

            gridView1.Columns["ABONO"].AppearanceCell.BackColor2 = Color.LightBlue;
            gridView1.Columns["ABONO"].AppearanceCell.BackColor = Color.Coral;
            gridView1.Columns["ABONO"].AppearanceHeader.ForeColor = Color.Red;            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (dxValidationEncabezado.Validate() && Convert.ToDouble(labelCantRestante.Text.Replace("Q", "")) == 0)
            {
                xtraTabPage2.PageEnabled = true;
                labelTotalDoc.Text = "TOTAL " + gridLookTipoDoc.Text.ToUpper() + ": " + Convert.ToDouble(textTotal.Text).ToString("C");
                labelCantidadRestante.Text = Convert.ToDouble(textTotal.Text).ToString("C");
                xtraTabControl1.SelectedTabPageIndex = 1;
                LlenaFacturas();
                cadena = "SELECT (MAX(recibos.no_recibo)+1)AS 'NORECIBO' FROM recibos where codigo_serie=24";
                textNoRecibo.Text = logicaorto.Tabla(cadena).Rows[0]["NORECIBO"].ToString();
                lbSaldoTotal.Text = lbTotalSaldo.Text;
                lbRestoSaldo.Text = (Convert.ToDouble(lbTotalSaldo.Text.Replace("Q", "")) - Convert.ToDouble(textTotal.Text)).ToString("C");
            }
            else
                Mensajes.Show(this, "INFORMACION", "VERIFICAR CANTIDAD RESTANTE O FALTAN DATOS", Properties.Resources.Advertencia64);
        }

        double Total = 0;// esta variable tendra el total de recibo....

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name == "colABONO")
            {                
                if (Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["ABONO"])) >= 0.00)
                {
                    

                    if ((Convert.ToDouble(gridView1.GetFocusedRowCellValue("SALDO ACTUAL")) - Convert.ToDouble(e.Value)) >= 0)
                    {
                        
                        if (Convert.ToDouble(e.Value) <= Convert.ToDouble(labelCantidadRestante.Text.Replace("Q", "")))
                        {
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "SALDO", (Convert.ToDouble(gridView1.GetFocusedRowCellValue("SALDO ACTUAL")) - Convert.ToDouble(e.Value)).ToString("n"));
                            Total = 0;
                            for (int x = 0; x < gridView1.DataRowCount; x++)
                            {
                                if (Convert.ToDouble(gridView1.GetRowCellValue(x, "ABONO")) > 0)
                                {
                                    Total = Total + Convert.ToDouble(gridView1.GetRowCellValue(x, "ABONO"));
                                }
                            }
                            labelCantidadRestante.Text = (Convert.ToDouble(textTotal.Text.Replace("Q", "")) - Total).ToString("C");
                        }
                        else
                        {
                            Mensajes.Show(this, "Información", "El valor no puede ser mayor a la cantidad restante", Properties.Resources.Advertencia64);
                            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["ABONO"], "0.00");                           
                        }
                    }
                    else
                    {
                        Mensajes.Show(this, "Información", "El valor no puede ser mayor al saldo actual", Properties.Resources.Advertencia64);
                        gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["ABONO"], "0.00");
                    }
                }
                else
                {
                    Mensajes.Show(this, "Información", "El valor no puede ser menor a cero", Properties.Resources.Advertencia64);
                    gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["ABONO"], "0.00");
                }
            }
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //ColumnView col = sender as ColumnView;
            //if (Convert.ToDouble(col.GetRowCellValue(e.RowHandle, col.Columns["ABONO"])) < 0)
            //{
            //    e.Valid = false;
            //    col.SetColumnError(gridView1.Columns["ABONO"], "El Abono no puede menor a cero");
            //}
        }

        MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.ortoxelaConnectionString);
        MySqlCommand comando = new MySqlCommand();
        MySqlTransaction transaccion;
        int id_recibos;
        private void InsertaDatos()
        {
            try
            {
                conexion.Open();
                transaccion = conexion.BeginTransaction();

                cadena = "INSERT INTO ortoxela.recibos(no_recibo, codigo_serie, codigo_proveedor, fecha_creacion, no_pedido, tipo_pago, monto, usuario_creador, estadoid,descripcion)" +
                       "VALUES	('" + textNoRecibo.Text + "', '" + gridLookTipoDoc.EditValue + "', '" + gridLookProveedor.EditValue + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '0', '0', '" + textTotal.Text + "', '" + clases.ClassVariables.id_usuario + "', '4','" + memoEdit1.Text + "');select last_insert_id();";
                comando = new MySqlCommand(cadena, conexion);
                comando.Transaction = transaccion;
                id_recibos = int.Parse(comando.ExecuteScalar().ToString());
                cadena = "";
                for (int x = 0; x < gridView4.DataRowCount; x++)
                {
                    cadena += "INSERT INTO ortoxela.detalle_recibos (id_recibos, codigo_serie, tipo_pago, monto,fecha_operacion, id_banco, no_documento, observaciones, activo)" +
                                "  VALUES	('" + id_recibos + "', '" + gridLookTipoDoc.EditValue + "', '" + gridView4.GetRowCellValue(x, "IDTIPOPAGO").ToString() + "', '" + gridView4.GetRowCellValue(x, "MONTO").ToString().Replace("Q", "").Replace(",", "") + "', '" + dateEdit1.DateTime.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + gridView4.GetRowCellValue(x, "IDBANCO").ToString() + "', '" + gridView4.GetRowCellValue(x, "NO DOCUMENTO").ToString() + "', '" + memoEdit1.Text + "', '1');";

                }
                comando = new MySqlCommand(cadena, conexion);
                comando.Transaction = transaccion;
                comando.ExecuteNonQuery();
                cadena = "";
                for (int y = 0; y < gridView1.DataRowCount; y++)
                {
                    if (Convert.ToDouble(gridView1.GetRowCellValue(y, "ABONO")) > 0)
                    {
                        cadena += "insert into ortoxela.relacion_pagos (no_transaccion, codigo_proveedor, id_factura, saldo_factura, fecha_operacion, id_docto_abono, monto_abono, comentarios, activo)" +
                                    "values	('" + DateTime.Now.ToString("yyyyMMddHHmmss") + "', '" + gridLookProveedor.EditValue + "', '" + gridView1.GetRowCellValue(y, "id_documento") + "', '" + gridView1.GetRowCellValue(y, "SALDO").ToString().Replace(",", "") + "', '" + dateEdit1.DateTime.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + id_recibos + "', '" + gridView1.GetRowCellValue(y, "ABONO").ToString().Replace(",", "") + "', '" + memoEdit1.Text + "', '1');";
                        if (Convert.ToDouble(gridView1.GetRowCellValue(y, "SALDO").ToString()) == 0)
                        {
                            cadena += "UPDATE header_doctos_inv h SET h.estadoid=10 WHERE h.id_documento=" + gridView1.GetRowCellValue(y, "id_documento") + ";";
                        }
                    }
                }
                comando = new MySqlCommand(cadena, conexion);
                comando.Transaction = transaccion;
                comando.ExecuteNonQuery();
                transaccion.Commit();
                clases.ClassMensajes.INSERTO(this);
                Sbimprimir.Enabled = true;
                simpleButton4.Enabled = false;
                groupControl2.Enabled = false;
            }
            catch
            {
                transaccion.Rollback();
                clases.ClassMensajes.NoINSERTO(this);
            }
            finally
            {
                conexion.Close();

            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (dxValidationGuardar.Validate() & Convert.ToDouble(labelCantidadRestante.Text.Replace("Q", "")) == 0)
            {
                cadena = "SELECT * FROM recibos WHERE recibos.codigo_serie=" + gridLookTipoDoc.EditValue + " AND recibos.no_recibo=" + textNoRecibo.Text;
                if (logicaorto.ExisteRegistro(cadena) == false)
                    InsertaDatos();
                else
                    Mensajes.Show(this, "Informacion", "El Documento ya existe en el sistema.", Properties.Resources.Advertencia64);
            }
            else
                Mensajes.Show(this, "Informacion", "Faltan datos ó la cantidad restante no ha llegado a 0", Properties.Resources.Advertencia64);
        }



        private void gridLookTipoPago_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(gridLookTipoPago.EditValue) == 1)
            {
                textNoDoc.Enabled = false;
                gridLookBanco.Enabled = false;
            }
            else
            {
                textNoDoc.Enabled = true;
                gridLookBanco.Enabled = true;
            }
        }

        private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "ABONO")
                if ((Convert.ToDecimal(e.Value) == 0) | (Convert.ToString(e.Value) == ""))
                    e.DisplayText = "0.00"; 
        }

    }
}