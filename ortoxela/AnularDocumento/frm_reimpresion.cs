using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
namespace ortoxela.AnularDocumento
{
    public partial class frm_reimpresion : DevExpress.XtraEditors.XtraForm
    {
        public frm_reimpresion()
        {
            InitializeComponent();
        }
        string cadena;
        classortoxela ortoxela = new classortoxela();
        private void CargaDatos()
        {
            cadena = "SELECT tipos_documento.codigo_tipo AS CODIGO,tipos_documento.nombre_documento AS'TIPO DOCUMENTO' FROM tipos_documento WHERE tipos_documento.codigo_tipo<>2 AND tipos_documento.codigo_tipo<>4";
            gridLookSerieVale.Properties.DataSource = ortoxela.Tabla(cadena);
            gridLookSerieVale.Properties.DisplayMember = "TIPO DOCUMENTO";
            gridLookSerieVale.Properties.ValueMember = "CODIGO";
            //gridLookSerieVale.Properties.View.Columns["CODIGO"].Visible = false;
            gridLookSerieVale.Properties.NullText = "Seleccione un documento";
        }
        private void frm_reimpresion_Load(object sender, EventArgs e)
        {
            CargaDatos();
            radioGroup1.SelectedIndex = 1;
            radioGroup1.SelectedIndex = 0;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable td = new DataTable();
            gridControl1.DataSource = td;
            if (radioGroup1.SelectedIndex == 0)
            {
                gridLookSerieVale.Enabled = false;

            }
            else
            {
                gridLookSerieVale.Enabled = true;
            }
        }

        private void llenagridview()
        {
            DataTable dt = new DataTable();
            gridControl1.DataSource = dt;
            gridView1.Columns.Clear();
            if (Convert.ToInt32(gridLookSerieVale.EditValue) == 6)
            {
                cadena = "SELECT h.id_documento,h.no_documento AS 'NO DOCUMENTO',CONCAT(t.nombre_documento,' [',s.serie_documento,']')AS 'SERIE DOCUMENTO' ,h.fecha AS 'FECHA',c.nombre_proveedor AS 'NOMBRE PROVEEDOR',h.monto_neto AS 'MONTO',h.refer_documento as 'NO FACTURA' FROM header_doctos_inv h INNER JOIN series_documentos s ON h.codigo_serie=s.codigo_serie INNER JOIN tipos_documento t ON t.codigo_tipo=s.codigo_tipo LEFT JOIN proveedores c ON h.codigo_proveedor=c.codigo_proveedor WHERE t.codigo_tipo=" + gridLookSerieVale.EditValue + " AND (h.fecha BETWEEN '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "' AND '" + dateEdit2.DateTime.ToString("yyyy-MM-dd") + "') and h.estadoid<>6 ORDER BY h.fecha DESC ";
            }
            else
            {
                cadena = "SELECT h.id_documento,h.no_documento AS 'NO DOCUMENTO',CONCAT(t.nombre_documento,' [',s.serie_documento,']')AS 'SERIE DOCUMENTO' ,h.fecha AS 'FECHA',c.nombre_cliente AS 'NOMBRE CLIENTE',h.monto_neto AS 'MONTO' FROM header_doctos_inv h INNER JOIN series_documentos s ON h.codigo_serie=s.codigo_serie INNER JOIN tipos_documento t ON t.codigo_tipo=s.codigo_tipo LEFT JOIN clientes c ON h.codigo_cliente=c.codigo_cliente WHERE t.codigo_tipo=" + gridLookSerieVale.EditValue + " AND (h.fecha BETWEEN '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "' AND '" + dateEdit2.DateTime.ToString("yyyy-MM-dd") + "') and h.estadoid<>6 ORDER BY h.fecha DESC ";
            }
            gridControl1.DataSource = ortoxela.Tabla(cadena);
            gridView1.Columns["id_documento"].Visible = false;
            gridView1.Columns["NO DOCUMENTO"].Width = 60;
            gridView1.Columns["SERIE DOCUMENTO"].Width = 75;
            gridView1.Columns["FECHA"].Width = 75;
            gridView1.Columns["MONTO"].Width = 60;
        }
        private void llenaRecibos()
        {

            DataTable dt = new DataTable();
            gridControl1.DataSource = dt;
            gridView1.Columns.Clear();
            cadena = "SELECT r.no_recibo AS 'NO RECIBO',r.fecha_creacion AS 'FECHA',c.nombre_cliente AS 'NOMBRE CLIENTE',r.monto AS 'MONTO' FROM recibos r INNER JOIN clientes c ON r.codigo_cliente=c.codigo_cliente WHERE (r.fecha_creacion BETWEEN '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "' AND '" + dateEdit2.DateTime.ToString("yyyy-MM-dd") + "') and r.estadoid<>6 ORDER BY r.fecha_creacion DESC";
            gridControl1.DataSource = ortoxela.Tabla(cadena);
            gridView1.Columns["NO RECIBO"].Width = 60;
            gridView1.Columns["FECHA"].Width = 60;
        }
        private void llenagridview1()
        {
            DataTable dt = new DataTable();
            gridControl1.DataSource = dt;
            gridView1.Columns.Clear();
            if (Convert.ToInt32(gridLookSerieVale.EditValue) == 6)
            {
                cadena = "SELECT h.id_documento,h.no_documento AS 'NO DOCUMENTO',CONCAT(t.nombre_documento,' [',s.serie_documento,']')AS 'SERIE DOCUMENTO' ,h.fecha AS 'FECHA',c.nombre_proveedor AS 'NOMBRE PROVEEDOR',h.monto_neto AS 'MONTO',h.refer_documento AS 'NO FACTURA' FROM header_doctos_inv h INNER JOIN series_documentos s ON h.codigo_serie=s.codigo_serie INNER JOIN tipos_documento t ON t.codigo_tipo=s.codigo_tipo LEFT JOIN proveedores c ON h.codigo_proveedor=c.codigo_proveedor WHERE t.codigo_tipo=" + gridLookSerieVale.EditValue + " AND h.no_documento='" + textEdit1.Text + "' and h.estadoid<>6 ORDER BY h.fecha DESC";
            }
            else
            {
                cadena = "SELECT h.id_documento,h.no_documento AS 'NO DOCUMENTO',CONCAT(t.nombre_documento,' [',s.serie_documento,']')AS 'SERIE DOCUMENTO' ,h.fecha AS 'FECHA',c.nombre_cliente AS 'NOMBRE CLIENTE',h.monto_neto AS 'MONTO' FROM header_doctos_inv h INNER JOIN series_documentos s ON h.codigo_serie=s.codigo_serie INNER JOIN tipos_documento t ON t.codigo_tipo=s.codigo_tipo LEFT JOIN clientes c ON h.codigo_cliente=c.codigo_cliente WHERE t.codigo_tipo=" + gridLookSerieVale.EditValue + " AND h.no_documento='" + textEdit1.Text + "' and h.estadoid<>6 ORDER BY h.fecha DESC";
            }
            gridControl1.DataSource = ortoxela.Tabla(cadena);
            gridView1.Columns["id_documento"].Visible = false;
            gridView1.Columns["NO DOCUMENTO"].Width = 60;
            gridView1.Columns["SERIE DOCUMENTO"].Width = 75;
            gridView1.Columns["FECHA"].Width = 75;
            gridView1.Columns["MONTO"].Width = 60;
        }
        private void llenaRecibos1()
        {

            DataTable dt = new DataTable();
            gridControl1.DataSource = dt;
            gridView1.Columns.Clear();
            cadena = "SELECT r.no_recibo AS 'NO RECIBO',r.fecha_creacion AS 'FECHA',c.nombre_cliente AS 'NOMBRE CLIENTE',r.monto AS 'MONTO' FROM recibos r INNER JOIN clientes c ON r.codigo_cliente=c.codigo_cliente WHERE r.no_recibo='" + textEdit1.Text + "' and r.estadoid<>6 ORDER BY r.fecha_creacion DESC";
            gridControl1.DataSource = ortoxela.Tabla(cadena);
            gridView1.Columns["NO RECIBO"].Width = 60;
            gridView1.Columns["FECHA"].Width = 60;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (textEdit1.Text != "")
            {
                if (radioGroup1.SelectedIndex == 0)
                {
                    llenaRecibos1();
                }
                else
                {
                    llenagridview1();
                }
            }
            else
                if(textEdit1.Text=="")
                {
            if (dxValidationProvider1.Validate())
            {
                if (radioGroup1.SelectedIndex == 0)
                {
                    llenaRecibos();
                }
                else
                {
                    llenagridview();
                }
            }
                }
        }
        MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.ortoxelaConnectionString);
        MySqlCommand comando = new MySqlCommand();
        MySqlTransaction transac;
        string id_nuevoIngreso;
        int id_proveedor;
        string ssql;
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {

                conexion.Open();
                transac = conexion.BeginTransaction();
                comando.Transaction = transac;
                if (gridView1.DataRowCount > 0)
                {
                    if (MessageBox.Show("¿ESTA SEGUR@ DE ANULAR EL DOCUMENTO?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        if (radioGroup1.SelectedIndex == 0)
                        {
                            cadena = "UPDATE recibos SET recibos.estadoid=6 WHERE recibos.no_recibo=" + gridView1.GetFocusedRowCellValue("NO RECIBO");
                            clases.ClassMensajes.MODIFICAR(this, cadena);
                            simpleButton1.PerformClick();
                        }
                        else
                        {
                            bandera_ingreso_egreso = "0";
                            if (Convert.ToInt32(gridLookSerieVale.EditValue) == 1 | Convert.ToInt32(gridLookSerieVale.EditValue) == 5 | Convert.ToInt32(gridLookSerieVale.EditValue) == 9 | Convert.ToInt32(gridLookSerieVale.EditValue) == 11)
                                bandera_ingreso_egreso = "1";
                            else
                                if (Convert.ToInt32(gridLookSerieVale.EditValue) == 6 | Convert.ToInt32(gridLookSerieVale.EditValue) == 8 | Convert.ToInt32(gridLookSerieVale.EditValue) == 10)
                                    bandera_ingreso_egreso = "2";


                                ssql = "SELECT (d.cantidad_enviada- IF(d.cantidad_devuelta IS NULL, 0, d.cantidad_devuelta)) AS CANTIDAD,d.codigo_articulo AS CODIGO,d.codigo_bodega AS 'IDBODEGA' FROM detalle_doctos_inv d WHERE d.id_documento=" + gridView1.GetFocusedRowCellValue("id_documento");
                            gridControl2.DataSource = ortoxela.Tabla(ssql);
                            for (int x = 0; x < gridView2.DataRowCount; x++)
                            {
                                if (bandera_ingreso_egreso == "2")
                                {
                                    ssql = "update bodegas SET  existencia_articulo = existencia_articulo -" + gridView2.GetRowCellValue(x, "CANTIDAD") + " WHERE codigo_bodega=" + gridView2.GetRowCellValue(x, "IDBODEGA") + " and codigo_articulo='" + gridView2.GetRowCellValue(x, "CODIGO") + "'";
                                    comando = new MySqlCommand(ssql, conexion);
                                    comando.Transaction = transac;
                                    comando.ExecuteNonQuery();
                                }
                                else
                                {
                                    if (bandera_ingreso_egreso == "1")
                                    {
                                        ssql = "SELECT * FROM bodegas WHERE bodegas.codigo_articulo='" + gridView2.GetRowCellValue(x, "CODIGO") + "' AND bodegas.codigo_bodega=" + gridView2.GetRowCellValue(x, "IDBODEGA");
                                        if (ortoxela.ExisteRegistro(ssql))
                                        {
                                            ssql = "update bodegas SET  existencia_articulo = existencia_articulo +" + gridView2.GetRowCellValue(x, "CANTIDAD") + " WHERE codigo_bodega=" + gridView2.GetRowCellValue(x, "IDBODEGA") + " and codigo_articulo='" + gridView2.GetRowCellValue(x, "CODIGO") + "'";
                                            comando = new MySqlCommand(ssql, conexion);
                                            comando.Transaction = transac;
                                            comando.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            ssql = "INSERT into bodegas(codigo_bodega, codigo_articulo, existencia_articulo) " +
                                                  "VALUES (" + gridView2.GetRowCellValue(x, "IDBODEGA") + ", '" + gridView2.GetRowCellValue(x, "CODIGO") + "', '" + gridView2.GetRowCellValue(x, "CANTIDAD") + "')";
                                            comando = new MySqlCommand(ssql, conexion);
                                            comando.Transaction = transac;
                                            comando.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                            cadena = "UPDATE header_doctos_inv SET header_doctos_inv.estadoid=6 WHERE header_doctos_inv.id_documento=" + gridView1.GetFocusedRowCellValue("id_documento");
                            comando = new MySqlCommand(cadena, conexion);
                            comando.Transaction = transac;
                            comando.ExecuteNonQuery();
                        }

                    }
                }
                transac.Commit();
                clases.ClassMensajes.INSERTO(this);
            }
            catch
            {
                transac.Rollback();
                clases.ClassMensajes.NoINSERTO(this);
            }
            finally
            {
                conexion.Close();
            }
        }
        string bandera_actualiza_precio, bandera_ingreso_egreso;
        DataTable tempTabla = new DataTable();
        private void gridLookSerieVale_EditValueChanged(object sender, EventArgs e)
        {

            cadena = "SELECT tipos_documento.actualiza_precios,tipos_documento.signo FROM tipos_documento INNER JOIN series_documentos ON tipos_documento.codigo_tipo=series_documentos.codigo_tipo WHERE series_documentos.codigo_tipo=" + gridLookSerieVale.EditValue;
            tempTabla = ortoxela.Tabla(cadena);
            bandera_actualiza_precio = tempTabla.Rows[0][0].ToString();
            bandera_ingreso_egreso = tempTabla.Rows[0][1].ToString();
        }
    }
}