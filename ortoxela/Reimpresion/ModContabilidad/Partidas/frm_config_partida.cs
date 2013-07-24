using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ortoxela.ModContabilidad.Partidas
{
    public partial class frm_config_partida : DevExpress.XtraEditors.XtraForm
    {
        public frm_config_partida()
        {
            InitializeComponent();
        }

        private void frm_config_partida_Load(object sender, EventArgs e)
        {
            CreaColumnas();
        }
        private void CreaColumnas()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IDCUENTA");
            dt.Columns.Add("CUENTA");            
            dt.Columns.Add("DEBE");
            dt.Columns.Add("PORCENTAJE DEBE");
            dt.Columns.Add("HABER");
            dt.Columns.Add("PORCENTAJE HABER");
            gridControl1.DataSource = dt;
        }
        string cadena;
        string id_condicion,id_cuenta;
        decimal tot_debe, tot_haber;
        classortoxela orto = new classortoxela();
        private void textNombreOperacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            cadena = "SELECT cc.idcondiciones_contabilidad AS CODIGO,cc.nombre_operacion AS OPERACION,CONCAT(td.nombre_documento,'[',sd.serie_documento,']')AS DOCUMENTO,tcc.descripcion 'TIPO CLIENTE',"+
"(IF (cc.tipo_pago=0,'CONTADO','CREDITO'))AS 'TIPO PAGO' "+
"FROM condiciones_contabilidad cc INNER JOIN series_documentos sd ON cc.codigo_serie=sd.codigo_serie "+
"INNER JOIN tipos_documento td ON sd.codigo_tipo=td.codigo_tipo INNER JOIN tipo_cliente_contabilidad tcc "+
"ON cc.tipo_cliente=tcc.id_tipo_cliente_c "+
"WHERE cc.activo=1 "+
"ORDER BY OPERACION";
            clases.ClassVariables.cadenabusca = cadena;
            Form nuevo = new Buscador.Buscador();
            nuevo.ShowDialog();
            if (Buscador.Buscador.SeleccionSiNo)
            {
                id_condicion = clases.ClassVariables.id_busca;
                cadena = "SELECT * FROM condiciones_contabilidad cc WHERE cc.idcondiciones_contabilidad="+id_condicion;
                DataTable datos = orto.Tabla(cadena);
                textNombreOperacion.Text=datos.Rows[0]["nombre_operacion"].ToString();
            }
        }

        private void sbAceptar_Click(object sender, EventArgs e)
        {
            if (tot_haber == 100 & tot_debe == 100)
            {
                InsertaCatalog();
            }
            else
                mensaje.Show(this,"INFORMACION","El total de HABER Y DEBE tiene que ser igual a 100%, verifique por favor",Properties.Resources.Advertencia48);
        }

        private void textNombreCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            cadena = "SELECT cnt.idcatalogo_cuentas_nivel3 AS CODIGO, cnt.codigo_cuenta AS 'CODIGO CUENTA',cnt.descripcion AS 'NOMBRE DE CUENTA' "+
"FROM catalogo_cuentas_nivel3 cnt WHERE cnt.activo=1";
            clases.ClassVariables.cadenabusca = cadena;
            Form nuevo = new Buscador.Buscador();
            nuevo.ShowDialog();
            if (Buscador.Buscador.SeleccionSiNo)
            {
                id_cuenta = clases.ClassVariables.id_busca;
                cadena = "SELECT * FROM catalogo_cuentas_nivel3 WHERE idcatalogo_cuentas_nivel3=" + id_cuenta;
                DataTable datos = orto.Tabla(cadena);
                textNombreCuenta.Text = datos.Rows[0]["codigo_cuenta"].ToString() + " - " + datos.Rows[0]["descripcion"].ToString();

            }
        }
        private void InsertaCatalog()
        {
            try
            {
                cadena = "";
                for (int x = 0; x < gridView1.DataRowCount; x++)
                {
                    if (gridView1.GetRowCellValue(x, "DEBE").ToString() == "1")
                    {
                        cadena += "insert into ortoxela.catalogo_partidas(id_cond, id_cuenta_debe,porcentaje) " +
                                "values('" + id_condicion + "', '" + gridView1.GetRowCellValue(x, "IDCUENTA") + "', '" + gridView1.GetRowCellValue(x, "PORCENTAJE DEBE") + "');";
                    }
                    else
                    {
                        cadena += "insert into ortoxela.catalogo_partidas(id_cond,id_cuenta_haber,porcentaje) " +
                               "values('" + id_condicion + "', '" + gridView1.GetRowCellValue(x, "IDCUENTA") + "','" + gridView1.GetRowCellValue(x, "PORCENTAJE HABER") + "');";
                    }
                }
                if (orto.variosservios(cadena) == 1)
                {
                    clases.ClassMensajes.INSERTO(this);
                }
                else
                    clases.ClassMensajes.NoINSERTO(this);
            }
            catch
            {
                clases.ClassMensajes.NoINSERTO(this);
            }
        }
        private void simpleButton7_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //dt.Columns.Add("IDCUENTA");
            //dt.Columns.Add("CUENTA");
            //dt.Columns.Add("DEBE");
            //dt.Columns.Add("PORCENTAJE DEBE");
            //dt.Columns.Add("HABER");
            //dt.Columns.Add("PORCENTAJE HABER");
            //gridControl1.DataSource = dt;

            gridView1.AddNewRow();
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "IDCUENTA", id_cuenta);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "CUENTA", textNombreCuenta.Text);
            if (radioGroup1.SelectedIndex == 0)
            {
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "DEBE", 1);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "PORCENTAJE DEBE", textEdit2.Text);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "HABER", 0);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "PORCENTAJE HABER", "0");
                tot_debe += decimal.Parse(textEdit2.Text);
            }
            else
            {
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "DEBE", 0);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "PORCENTAJE DEBE", "0");
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "HABER", 1);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "PORCENTAJE HABER", textEdit2.Text);
                tot_haber += decimal.Parse(textEdit2.Text);
            }
            labelTotalesPorcentaje.Text = "DEBE : "+tot_debe +"%   HABER : "+tot_haber+"%";
            gridView1.UpdateCurrentRow();
            textNombreCuenta.Text =textEdit2.Text= "";
            radioGroup1.SelectedIndex = 0;
            textNombreCuenta.Focus();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                tot_debe -= decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PORCENTAJE DEBE").ToString());
                tot_haber -= decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PORCENTAJE HABER").ToString());
                labelTotalesPorcentaje.Text = "DEBE : " + tot_debe + "%   HABER : " + tot_haber + "%";
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
                gridView1.UpdateCurrentRow();
            }
            catch
            { }
        }

     
    }
}