using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
namespace ortoxela.ModContabilidad.Partidas
{
    public partial class frm_partida_manual : DevExpress.XtraEditors.XtraForm
    {
        public frm_partida_manual()
        {
            InitializeComponent();
        }

        private void frm_partida_manual_Load(object sender, EventArgs e)
        {
            Numero_partida();
            CreaColumnas();
            
        }
        string cadena;
        string id_condicion, id_cuenta;
        decimal tot_debe, tot_haber;
        classortoxela orto = new classortoxela();
        private void Numero_partida()
        {
            cadena = "SELECT (MAX(no_partida)+1)AS NUMERO FROM partidas_header";
            textNoPartida.Text = orto.Tabla(cadena).Rows[0][0].ToString();
        }
        private void CreaColumnas()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IDCUENTA");
            dt.Columns.Add("CUENTA");
            dt.Columns.Add("DESCRIPCION");
            dt.Columns.Add("DEBE");
            dt.Columns.Add("MONTO DEBE");
            dt.Columns.Add("HABER");
            dt.Columns.Add("MONTO HABER");
            gridControl1.DataSource = dt;
        }

        private void textNombreCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            cadena = "SELECT cnt.idcatalogo_cuentas_nivel3 AS CODIGO, cnt.codigo_cuenta AS 'CODIGO CUENTA',cnt.descripcion AS 'NOMBRE DE CUENTA' " +
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

        private void sBagregar_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //dt.Columns.Add("IDCUENTA");
            //dt.Columns.Add("CUENTA");
            //dt.Columns.Add("DESCRIPCION");
            //dt.Columns.Add("DEBE");
            //dt.Columns.Add("PORCENTAJE DEBE");
            //dt.Columns.Add("HABER");
            //dt.Columns.Add("PORCENTAJE HABER");
            //gridControl1.DataSource = dt;

            gridView1.AddNewRow();
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "IDCUENTA", id_cuenta);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "CUENTA", textNombreCuenta.Text);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "DESCRIPCION", textDescripCuenta.Text);
            if (radioGroup1.SelectedIndex == 0)
            {
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "DEBE", 1);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "MONTO DEBE", textMonto.Text);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "HABER", 0);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "MONTO HABER", "0");
                tot_debe += decimal.Parse(textMonto.Text);
            }
            else
            {
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "DEBE", 0);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "MONTO DEBE", "0");
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "HABER", 1);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "MONTO HABER", textMonto.Text);
                tot_haber += decimal.Parse(textMonto.Text);
            }
            labelTotalesPorcentaje.Text = "DEBE : " + tot_debe.ToString("C") + "   HABER : " + tot_haber.ToString("C");
            gridView1.UpdateCurrentRow();
            textNombreCuenta.Text = textMonto.Text=textDescripCuenta.Text = "";
            radioGroup1.SelectedIndex = 0;
            textNombreCuenta.Focus();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                tot_debe -= decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MONTO DEBE").ToString());
                tot_haber -= decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MONTO HABER").ToString());
                labelTotalesPorcentaje.Text = "DEBE : " + tot_debe.ToString("C") + "   HABER : " + tot_haber.ToString("C");
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
                gridView1.UpdateCurrentRow();
            }
            catch
            { }
        }
        MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.ortoxelaConnectionString);
        MySqlCommand comando = new MySqlCommand();
        MySqlTransaction transac;
        string id_nuevoIngreso;        
        private void inserta_partida()
        {
            try
            {
                conexion.Open();
                transac = conexion.BeginTransaction();
                cadena = "INSERT INTO partidas_header(no_partida, folio, descripcion, fecha, monto_debe, monto_haber, codigo_serie, id_docto, usuario, estado)" +
                        "VALUES("+textNoPartida.Text+", '"+textNoFolio.Text+"', '"+textDescripPartida.Text+"', '" + dateFecha.DateTime.ToString("yyyy-MM-dd") + "', '" + tot_debe+ "', '" + tot_haber+ "', '0', '0', '" + clases.ClassVariables.id_usuario + "', '1');select last_insert_id();";
                comando = new MySqlCommand(cadena, conexion);
                comando.Transaction = transac;
                string id_partida_header = comando.ExecuteScalar().ToString();
                cadena = "";
                for (int x = 0; x < gridView1.DataRowCount;x++)
                {


                    if (gridView1.GetRowCellValue(x, "DEBE").ToString() == "1")
                    {
                        cadena += "INSERT INTO partidas_detalle (id_partidas_header, id_cuenta, monto_debe, monto_haber, descripcion_documento, numero_documento, activo)" +
                      "VALUES('" + id_partida_header + "', '" + gridView1.GetRowCellValue(x, "IDCUENTA") + "', '" + gridView1.GetRowCellValue(x, "MONTO DEBE") + "', '0', '" + gridView1.GetRowCellValue(x, "DESCRIPCION") + "', '0', 1);";
                    }
                    else
                    {
                        cadena += "INSERT INTO partidas_detalle (id_partidas_header, id_cuenta, monto_debe, monto_haber, descripcion_documento, numero_documento, activo)" +
                    "VALUES('" + id_partida_header + "', '" + gridView1.GetRowCellValue(x, "IDCUENTA") + "', '0', '" + gridView1.GetRowCellValue(x, "MONTO HABER") + "', '" + gridView1.GetRowCellValue(x, "DESCRIPCION") + "', '0', 1);";
                    
                    }                
                        
                    
                }
                comando = new MySqlCommand(cadena, conexion);
                comando.Transaction = transac;
                comando.ExecuteNonQuery();
                transac.Commit();
                conexion.Close();
                clases.ClassMensajes.INSERTO(this);
                comando.Dispose();
               
            }
            catch
            {
                transac.Rollback();
                clases.ClassMensajes.NoINSERTO(this);
                comando.Dispose();
                conexion.Close();
            }
        }

        private void sbAceptar_Click(object sender, EventArgs e)
        {
            if (tot_haber ==tot_debe)
            {
                inserta_partida();
            }
            else
                mensaje.Show(this, "INFORMACION", "El total de HABER Y DEBE tiene que ser igual, verifique por favor", Properties.Resources.Advertencia48);
        }
    }
}