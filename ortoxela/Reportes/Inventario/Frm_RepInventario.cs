using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
namespace ortoxela.Reportes.Inventario
{
    public partial class Frm_RepInventario : DevExpress.XtraEditors.XtraForm
    {
        public Frm_RepInventario()
        {
            InitializeComponent();
        }

        /* TRASLADOS DE BODEGA */       
        private void simpleButton1_Click(object sender, EventArgs e)
        {                
                this.Cursor = Cursors.WaitCursor;
                if ((FechaInicio.EditValue == null) || (FechaFin.EditValue == null))
                {
                    MessageBox.Show("Faltan Fechas", "Error");
                    this.Cursor = Cursors.Default;
                    return;
                }
                Int32 Bodega_origen_int,Bodega_destino_int ;                
                string consulta = "";
                Bodega_origen_int = Int32.Parse(bodegas.SelectedValue.ToString());
                Bodega_destino_int = Int32.Parse(BodegaDestino.SelectedValue.ToString());       
                consulta = "CALL sp_traslados_bodegas('" + FechaInicio.DateTime.ToString("yyyy-MM-dd") + " 00:00:00','" + FechaFin.DateTime.ToString("yyyy-MM-dd") + " 23:59:59'," + Bodega_origen_int + ","+ Bodega_destino_int +"); ";
                
                MySqlDataAdapter adaptadori = new MySqlDataAdapter(consulta, Properties.Settings.Default.ortoxelaConnectionString);

                DataSet dataseti = new DataSet();
                adaptadori.Fill(dataseti, "v_traslados");
                XtraReport_Traslados reportei = new XtraReport_Traslados();

                reportei.DataSource = dataseti;
                reportei.DataMember = dataseti.Tables["v_traslados"].TableName;
                reportei.Parameters["Fecha_inicial"].Value = FechaInicio.EditValue;
                reportei.Parameters["Fecha_final"].Value = FechaFin.EditValue;
                reportei.Parameters["Texto_bodega"].Value = bodegas.Text.ToString();
                reportei.Parameters["codigo_bodegai"].Value = Bodega_origen_int;
                reportei.Parameters["codigo_bodegaf"].Value = Bodega_destino_int;
                reportei.Parameters["nombreEmpresa"].Value = clases.ClassVariables.nombreEmpresa;
                reportei.RequestParameters = false;
                reportei.ShowPreview();
                this.Cursor = Cursors.Default ;


        }
        /* TOMA INVENTARIO EXISTENCIA */
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Int32 bodega1 = 0;
            Int32 bodega2 = 100;
            string botittle = "Todas";
            string consulta = "SELECT codigo_articulo, articulo, Ult_compra, Ult_venta, Ult_precio, nombre_bodega, categoria, codigo_categoria, existencia_articulo, codigo_bodega  " +
                                   " FROM ortoxela.v_inventario where existencia_articulo >0 ";  
                    if (bodegas.SelectedValue.ToString() != "0")
                    {
                        consulta = String.Format("{0} and codigo_bodega = {1}", consulta, bodegas.SelectedValue);
                        bodega1 = Int32.Parse(bodegas.SelectedValue.ToString());
                        bodega2 = Int32.Parse(bodegas.SelectedValue.ToString());
                        botittle = bodegas.Text;
                    }
                    if (comboBoxCategorias.SelectedValue.ToString() != "0")
                    {
                        consulta = consulta + "  and codigo_categoria = " + comboBoxCategorias.SelectedValue;
                    }
                    else
                    {
                        if ((textEdit2.Text.Trim() != "") || (textEdit3.Text.Trim() != ""))
                        {
                            if ((textEdit2.Text.Trim() != "") && (textEdit3.Text.Trim() == ""))
                            {
                                consulta = consulta + " and  codigo_articulo like '%" + textEdit2.Text + "%'";
                            }
                            else
                            {
                                if ((textEdit2.Text.Trim() == "") && (textEdit3.Text.Trim() != ""))
                                {
                                    consulta = consulta + " and codigo_articulo like '%" + textEdit3.Text + "%'";
                                }
                                else
                                {
                                    consulta = consulta + " and codigo_articulo between '" + textEdit2.Text + "' and '" + textEdit3.Text + "' ";
                                }
                            }

                        }
                    }
         
             
            MySqlDataAdapter adaptador1 = new MySqlDataAdapter(consulta, Properties.Settings.Default.ortoxelaConnectionString);
            DataSet_Inventario dataset = new DataSet_Inventario();
            adaptador1.Fill(dataset, "v_inventario");
            XtraReport_InventarioExistencia reportee = new XtraReport_InventarioExistencia();

            reportee.DataSource = dataset;
            reportee.DataMember = dataset.Tables["v_inventario"].TableName;
            reportee.Parameters["codigo_bodega1"].Value = bodega1;
            reportee.Parameters["codigo_bodega2"].Value = bodega2;
            reportee.Parameters["bodega"].Value = botittle;
            reportee.Parameters["nombreEmpresa"].Value = clases.ClassVariables.nombreEmpresa;

            this.Cursor = Cursors.Default ;
            reportee.RequestParameters = false;
            reportee.ShowPreviewDialog();

        }

        /* KARDEX */
        classortoxela ortoxela = new classortoxela();
        private void simpleButton4_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            Int32 codigo_bodega = 1;
            string co_bo = "", botittle="" ;
            Int16 cat1 = 0, cat2 = 10000;
            string consulta = "SELECT codigo_articulo, Articulo, cantidad, costo_sin_iva, costo_iva, codigo_bodega, nombre_bodega, fecha, Tipo_Pago, nombre_proveedor, nombre_cliente, dias_credito, "+
                             "signo, tipo_docto, no_documento, refer_documento, bodega_destino, codigo_categoria, categoria "+
                            "FROM ortoxela.v_kardex  where 1=1 ";

            if (bodegas.SelectedValue.ToString() != "0")
            {
                co_bo = " and codigo_bodega =" + bodegas.SelectedValue.ToString();
                consulta = consulta + co_bo;
                codigo_bodega = Int32.Parse(bodegas.SelectedValue.ToString());
                botittle = bodegas.Text;

                if (comboBoxCategorias.SelectedValue.ToString() != "0")
                {
                    consulta = consulta + "  and codigo_categoria = " + comboBoxCategorias.SelectedValue;
                    cat1 = Convert.ToInt16(comboBoxCategorias.SelectedValue.ToString());
                    cat2 = cat1;
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Bodega para este Reporte.", "Reporte Kardex");
                return;
            };

            if ((textEdit1.Text.Trim() != "") || (textEdit4.Text.Trim() != ""))
            {
                if ((textEdit1.Text.Trim() != "") && (textEdit4.Text.Trim() == ""))
                {
                    consulta = consulta + " and codigo_articulo like '%" + textEdit1.Text + "%'";
                }
                else
                {
                    if ((textEdit1.Text.Trim() == "") && (textEdit4.Text.Trim() != ""))
                    {
                        consulta = consulta + " and codigo_articulo like '%" + textEdit4.Text + "%'";
                    }
                    else
                    {
                        consulta = consulta + " and codigo_articulo between '" + textEdit1.Text + "' and '" + textEdit4.Text + "' ";
                    }
                }

            }
            string fechaInicialx = "2011-12-01";
            
            if ((FechaInicio.EditValue != null) && (FechaFin.EditValue != null))
            {
                fechaInicialx = FechaInicio.DateTime.ToString("yyyy-MM-dd");
                consulta = consulta + " and fecha between '" + FechaInicio.DateTime.ToString("yyyy-MM-dd") + " 00:00:00' ";
                consulta = consulta + " and '" + FechaFin.DateTime.ToString("yyyy-MM-dd") + " 23:59:59' ";
            }
            

            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, Properties.Settings.Default.ortoxelaConnectionString);
            DataSet_Inventario dataset = new DataSet_Inventario();
            adaptador.Fill(dataset, "v_kardex");
            XtraReport_Kardex reporteP = new XtraReport_Kardex();
            reporteP.DataSource = dataset;
            reporteP.DataMember = dataset.Tables["v_kardex"].TableName;
            reporteP.Parameters["codigo_bodega"].Value = codigo_bodega;
            reporteP.Parameters["bodega"].Value = botittle;
            reporteP.Parameters["Fecha_inicio"].Value = Convert.ToDateTime(fechaInicialx);
            reporteP.Parameters["Fecha_fin"].Value = FechaFin.EditValue;
            reporteP.Parameters["categoria1"].Value = cat1;
            reporteP.Parameters["categoria2"].Value = cat2;
            reporteP.Parameters["nombreEmpresa"].Value = clases.ClassVariables.nombreEmpresa;

            this.Cursor = Cursors.Default;
            reporteP.RequestParameters = false;
            reporteP.ShowPreviewDialog();            
        }

        classortoxela logicaxela = new classortoxela();
        private void Frm_RepInventario_Load(object sender, EventArgs e)
        {
            this.Text = "Reportes de Inventario - " + clases.ClassVariables.nombreEmpresa; 
            try
            {
                string ssql = "SELECT distinct codigo_bodega, nombre_bodega FROM ortoxela.v_bodegas_series_usuarios  WHERE estadoid_bodega<>2 AND userid=" + clases.ClassVariables.id_usuario;
                    // "  Select 0 as codigo_bodega, 'Todas' as nombre_bodega from dual " +
                            // " union all  "+
                            // " select codigo_bodega,nombre_bodega from bodegas_header where estadoid=1";
                            
                bodegas.DataSource = logicaxela.Tabla(ssql);
                bodegas.DisplayMember = "nombre_bodega";
                bodegas.ValueMember = "codigo_bodega";
                //
                //BodegaOrigen.DataSource = logicaxela.Tabla(ssql);
                //BodegaOrigen.DisplayMember = "nombre_bodega";
                //BodegaOrigen.ValueMember = "codigo_bodega";
                //
                
                BodegaDestino.DataSource = logicaxela.Tabla(ssql);
                BodegaDestino.DisplayMember = "nombre_bodega";
                BodegaDestino.ValueMember = "codigo_bodega";
                 

            }
            catch
            { }
            /* Se llena Combo de Categoarias*/
            try
            {
                string ssql = "(select 0 as codigo,'Todas' as categoria from dual) union all (select  codigo_subcat as codigo,nombre_subcategoria as categoria from sub_categorias where estadoid=1 order by nombre_subcategoria asc)";
                comboBoxCategorias.DataSource = logicaxela.Tabla(ssql);
                comboBoxCategorias.DisplayMember = "categoria";
                comboBoxCategorias.ValueMember = "codigo";

            }
            catch
            { }

            /* FECHAS */
            try
            {

                /* jramirez 2014.01.20 */

                DateTime now = DateTime.Now;

                string date = now.GetDateTimeFormats('d')[0];
                this.FechaFin.EditValue = date;

                DateTime now2 = DateTime.Now.AddMonths(-6);

                string date2 = now2.ToShortDateString();
                this.FechaInicio.EditValue = date2;

            }
            catch
            { }
        }
        /* TOMA INVENTARIO */
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string consulta = "SELECT        codigo_articulo, articulo, Ult_compra, Ult_venta, Ult_precio, nombre_bodega, categoria, codigo_categoria, existencia_articulo, codigo_bodega FROM v_inventario where 1=1 ";


            if (comboBoxCategorias.SelectedValue.ToString() == "0")
            {
                if ((textEdit6.Text.Trim() != "") || (textEdit5.Text.Trim() != ""))
                {
                    if ((textEdit6.Text.Trim() != "") && (textEdit5.Text.Trim() == ""))
                    {
                        consulta = consulta + " and  codigo_articulo like '%" + textEdit6.Text + "%'";
                    }
                    else
                    {
                        if ((textEdit6.Text.Trim() == "") && (textEdit5.Text.Trim() != ""))
                        {
                            consulta = consulta + " and codigo_articulo like '%" + textEdit5.Text + "%'";
                        }
                        else
                        {
                            consulta = consulta + " and codigo_articulo between '" + textEdit6.Text + "' and '" + textEdit5.Text + "' ";
                        }
                    }

                }
            }
            else
            {
                consulta = consulta + " and codigo_categoria = " + comboBoxCategorias.SelectedValue;
            }

            MySqlDataAdapter adaptador1 = new MySqlDataAdapter(consulta, Properties.Settings.Default.ortoxelaConnectionString);
            DataSet_Inventario dataset = new DataSet_Inventario();
            adaptador1.Fill(dataset, "v_inventario");
            XtraReport_TomaInventario reportet = new XtraReport_TomaInventario();
            reportet.DataSource = dataset;
            reportet.DataMember = dataset.Tables["v_inventario"].TableName;
            this.Cursor = Cursors.Default;
            reportet.Parameters["nombreEmpresa"].Value = clases.ClassVariables.nombreEmpresa;
            reportet.RequestParameters = false;
            reportet.ShowPreviewDialog();
        }

                                                   
    }
}