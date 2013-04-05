using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;

namespace ortoxela.Reportes.Ventas
{
    public partial class Frm_RepVentas : DevExpress.XtraEditors.XtraForm
    {
        public Frm_RepVentas()
        {
            InitializeComponent();
        }
         classortoxela bandera = new classortoxela();

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string codigo_bodega;
            string consulta = "";
            codigo_bodega = bodegas.SelectedValue.ToString();            
            Cursor.Current = Cursors.WaitCursor;
            if (codigo_bodega=="0")
                consulta = "CALL sp_estadistica_mes_fechas_nb('" + dateEdit6.DateTime.ToString("yyyy-MM-dd") + " 00:00:00','" + dateEdit5.DateTime.ToString("yyyy-MM-dd") + " 23:59:59'); ";    
            else consulta = "CALL sp_estadistica_mes_fechas('" + dateEdit6.DateTime.ToString("yyyy-MM-dd") + " 00:00:00','" + dateEdit5.DateTime.ToString("yyyy-MM-dd") + " 23:59:59'," + codigo_bodega + "); ";
            
              MySqlDataAdapter adaptador1 = new MySqlDataAdapter(consulta, Properties.Settings.Default.ortoxelaConnectionString);
              DataSet dataset1 = new DataSet();
              adaptador1.Fill(dataset1, "v_estadistica_mes");
             XtraReport_Estadistica_Mes reporteem = new XtraReport_Estadistica_Mes();
             reporteem.DataSource = dataset1;
             reporteem.DataMember = dataset1.Tables["v_estadistica_mes"].TableName;
             reporteem.Parameters["Fecha_inicio"].Value = dateEdit6.DateTime.ToString("yyyy-MM-dd") + " 00:00:00";
             reporteem.Parameters["Fecha_fin"].Value = dateEdit5.DateTime.ToString("yyyy-MM-dd") + " 23:59:59";
             reporteem.Parameters["Bodega"].Value = bodegas.Text;
             reporteem.RequestParameters = false;
             reporteem.ShowPreview();
             Cursor.Current = Cursors.Default;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            string consulta = "select  fecha, Tipo_Pago, nombre_cliente, descuentoPct, DescuentoQ, total_iva, Total_sin_iva, no_documento, refer_documento, nombre_tipo_pago, documento,  "+
                         "nombre_estado, fecha_anula, usuario_anula, tipo_cliente, nitCliente, codigo_cliente from ortoxela.v_ventas_general where 1=1 " +
                " and fecha between '" + dateEdit6.DateTime.ToString("yyyy-MM-dd")+" 00:00:00" + "' and '" + dateEdit5.DateTime.ToString("yyyy-MM-dd")+" 23:59:59" + "' ";
           
            string estadoid = comboBox3.Text;
            string estado = "";
                if (estadoid == "Activas")
                    {
                        consulta = consulta + " and nombre_estado='Activo' ";
                        estado = "Activo";
                    }
                    else
                    {
                        if (estadoid == "Anuladas")
                        {
                            consulta = consulta + " and nombre_estado = 'Anulado' ";
                            estado = "Anulado";
                        }
                    }
            
            MySqlDataAdapter adaptador1 = new MySqlDataAdapter(consulta, Properties.Settings.Default.ortoxelaConnectionString);
            // DataSet_VentasGeneral dataset = new DataSet_VentasGeneral();
            DataSet dataset1 = new DataSet();
            adaptador1.Fill(dataset1, "v_ventas_general");
            XtraReport_VentasGeneral reportev = new XtraReport_VentasGeneral();            
            reportev.DataSource = dataset1;
            reportev.DataMember = dataset1.Tables["v_ventas_general"].TableName;
            reportev.Parameters["Fecha_inicio"].Value = dateEdit6.DateTime.ToString("yyyy-MM-dd")+" 00:00:00";
            reportev.Parameters["Fecha_fin"].Value = dateEdit5.DateTime.ToString("yyyy-MM-dd")+" 23:59:59";
            reportev.Parameters["nombre_estado"].Value = estado;
            reportev.RequestParameters = false;
            reportev.ShowPreviewDialog();
            Cursor.Current = Cursors.Default;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            if (textEditNo.Text.Trim() != "")
            {
                string consultax = "select codigo_articulo, Articulo, cantidad_enviada, precio_sin_iva, precio_iva, nombre_bodega, fecha_compra, Tipo_Pago, nombre_cliente, no_documento, descuentoPct, "+
                "DescuentoQ, total_iva, Total_sin_iva, refer_documento, documento, costo_iva, costo_sin_iva, forma_pago from v_ventas_de_costo where documento = '" + comboBox4.Text.ToString() + "' and no_documento =" + textEditNo.EditValue.ToString();

                MySqlDataAdapter adaptadorx = new MySqlDataAdapter(consultax, Properties.Settings.Default.ortoxelaConnectionString);
                // DataSet_VentasGeneral dataset = new DataSet_VentasGeneral();
                DataSet datasetx = new DataSet();
                adaptadorx.Fill(datasetx, "v_ventas_de_costo");
                XtraReport_Ventas_Detalle reported = new XtraReport_Ventas_Detalle();
                reported.DataSource = datasetx;
                reported.DataMember = datasetx.Tables["v_ventas_de_costo"].TableName;
                reported.Parameters["Fecha_inicio"].Value = dateEdit6.DateTime.ToString("yyyy-MM-dd") + " 00:00:00";
                reported.Parameters["Fecha_fin"].Value = dateEdit5.DateTime.ToString("yyyy-MM-dd") + " 23:59:59";
                reported.RequestParameters = false;
                reported.ShowPreview();
            }
            else
            {

                XtraReport_Ventas_Detalle reported = new XtraReport_Ventas_Detalle();
                reported.Parameters["Fecha_inicio"].Value = dateEdit6.DateTime.ToString("yyyy-MM-dd") + " 00:00:00";
                reported.Parameters["Fecha_fin"].Value = dateEdit5.DateTime.ToString("yyyy-MM-dd") + " 23:59:59";
                reported.RequestParameters = false;
                reported.ShowPreview();
            }
            Cursor.Current = Cursors.Default;
            
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            XtraReport_VentasTotalesPorMes reportef = new XtraReport_VentasTotalesPorMes();
            reportef.Parameters["Fecha_inicio"].Value = dateEdit6.DateTime.ToString("yyyy-MM-dd") + " 00:00:00";
            reportef.Parameters["Fecha_fin"].Value = dateEdit5.DateTime.ToString("yyyy-MM-dd")+" 23:59:59";
            
            reportef.RequestParameters = false;
            reportef.ShowPreview();
            Cursor.Current = Cursors.Default;

        }
        classortoxela logicaxela = new classortoxela();
        private void Frm_RepVentas_Load(object sender, EventArgs e)
        {
            try
            {
                string ssql = "select 0 as estadoid,'Todas' as ESTADO from dual union select 1 as estadoid,'Activas' as ESTADO from dual union select 2 as estadoid,'Anuladas' as ESTADO from dual";
                comboBox3.DataSource = logicaxela.Tabla(ssql);
                comboBox3.DisplayMember = "ESTADO";
                comboBox3.ValueMember = "estadoid";
                                              
            }
            catch
            { }

            try
            {
                string ssql = "select codigo_serie,concat(nombre_documento,'[',serie_documento,']') as documento from v_tipos_documentos where codigo_tipo=1";
                comboBox4.DataSource = logicaxela.Tabla(ssql);
                comboBox4.DisplayMember = "documento";
                comboBox4.ValueMember = "codigo_serie";

            }
            catch
            { }
            try
            {
                string ssql = "(select 0 as codigo,'Todas' as categoria from dual) union all (select  codigo_subcat as codigo,nombre_subcategoria as categoria from sub_categorias where estadoid=1 order by nombre_subcategoria asc)";
                comboBox5.DataSource = logicaxela.Tabla(ssql);
                comboBox5.DisplayMember = "categoria";
                comboBox5.ValueMember = "codigo";

            }
            catch
            { }

            try
            {
                string ssql = "  Select 0 as codigo_bodega, 'Todas' as nombre_bodega from dual " +
                            " union all  " +
                            " select codigo_bodega,nombre_bodega from bodegas_header where estadoid=1";
                bodegas.DataSource = logicaxela.Tabla(ssql);
                bodegas.DisplayMember = "nombre_bodega";
                bodegas.ValueMember = "codigo_bodega";

            }
            catch
            { }
        }

    

        private void panelControl5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl18_Click(object sender, EventArgs e)
        {

        }

   

        private void labelControl11_Click(object sender, EventArgs e)
        {

        }

        private void labelControl21_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            XtraReport_VentasPorTipoCliente reported = new XtraReport_VentasPorTipoCliente();
            // XtraReport_Ventas_por_Cliente reported = new XtraReport_Ventas_por_Cliente();
            reported.Parameters["Fecha_inicio"].Value = dateEdit6.DateTime.ToString("yyyy-MM-dd") + " 00:00:00";
            reported.Parameters["Fecha_fin"].Value = dateEdit5.DateTime.ToString("yyyy-MM-dd") + " 23:59:59";            
            reported.RequestParameters = false;
            reported.ShowPreview();
            Cursor.Current = Cursors.Default;
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            XtraReport_Ventas_por_cliente_sc reported = new XtraReport_Ventas_por_cliente_sc();
            reported.Parameters["Fecha_inicio"].Value = dateEdit6.DateTime.ToString("yyyy-MM-dd") + " 00:00:00"; ;
            reported.Parameters["Fecha_fin"].Value = dateEdit5.DateTime.ToString("yyyy-MM-dd") + " 23:59:59"; ;
            if (comboBox5.SelectedValue.ToString() == "0")
            {
                reported.Parameters["codigo_subcat"].Value = 1;
                reported.Parameters["codigo_subcat2"].Value = 1000;
            }
            else
            {
                reported.Parameters["codigo_subcat"].Value = comboBox5.SelectedValue;    
                reported.Parameters["codigo_subcat2"].Value = comboBox5.SelectedValue;           
            }
            
            reported.RequestParameters = false;
            reported.ShowPreview();
            

                //string consultax = " select codigo_articulo, Articulo, cantidad_enviada, precio_sin_iva, precio_iva, nombre_bodega, fecha_compra, Tipo_Pago, nombre_cliente, codigo_tipoc, nombre_cliente1, " +
                //         "no_documento, descuentoPct, DescuentoQ, total_iva, Total_sin_iva, refer_documento, documento, costo_iva, costo_sin_iva, forma_pago, codigo_subcat, " +
                //         "nombre_subcategoria, tipo_cliente from v_ventas_detalle_cliente_categoria where fecha_compra between '" + dateEdit64.DateTime.ToString("yyyy-MM-dd") + "' and '" + dateEdit63.DateTime.ToString("yyyy-MM-dd") + "' ";
                //if (comboBox5.SelectedValue.ToString() != "0")
                //{
                //    consultax = consultax + " and codigo_subcat = " + comboBox5.SelectedValue.ToString();
                //}

                //MySqlDataAdapter adaptadorx = new MySqlDataAdapter(consultax, Properties.Settings.Default.ortoxelaConnectionString);                
                //DataSet datasetx = new DataSet();
                //adaptadorx.Fill(datasetx, "v_ventas_detalle_cliente_categoria");
                //XtraReport_Ventas_por_cliente_sc reported = new XtraReport_Ventas_por_cliente_sc();
                //reported.DataSource = datasetx;
                //reported.DataMember = datasetx.Tables["v_ventas_detalle_cliente_categoria"].TableName;
                //reported.Parameters["Fecha_inicio"].Value = dateEdit64.EditValue;
                //reported.Parameters["Fecha_fin"].Value = dateEdit63.EditValue;
                ////reported.Parameters["codigo_subcat"].Value = 0;
                //reported.RequestParameters = false;
                //reported.ShowPreview();
            
            // }

            Cursor.Current = Cursors.Default;
        }

        private void panelControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor; 
            XtraReport_Ventas_categoria reported = new XtraReport_Ventas_categoria();
            reported.Parameters["Fecha_inicio"].Value = dateEdit6.DateTime.ToString("yyyy-MM-dd") + " 00:00:00"; ;
            reported.Parameters["Fecha_fin"].Value = dateEdit5.DateTime.ToString("yyyy-MM-dd") + " 23:59:59"; ;
            reported.RequestParameters = false;
            reported.ShowPreview();
            Cursor.Current = Cursors.Default;
        }

        private void labelControl32_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (textEdit1.Text.Trim() != "")
            {
                string consultax = "SELECT        codigo_articulo, Articulo, nombre_bodega, cantidad_enviada, precio_maximo_sin_iva, precio_maximo_iva, precio_minimo_sin_iva, precio_minimo_iva,  "+
                                " precio_promedio_iva, precio_promedio_sin_iva, total_facturado_iva, Total_facturado_sin_iva, descuentoPct, DescuentoQ, documento, costo_iva, costo_sin_iva,  "+
                                " categoria, fecha, fecha_1era_venta, fecha_ultima_venta  "+
                                " FROM    ortoxela.v_ventas_articulo_mas where fecha between '" + dateEdit6.DateTime.ToString("yyyy-MM-dd") + " 00:00:00" + "' and '" + dateEdit5.DateTime.ToString("yyyy-MM-dd") + " 23:59:59" + "' limit " + textEdit1.Text; 

                MySqlDataAdapter adaptadorx = new MySqlDataAdapter(consultax, Properties.Settings.Default.ortoxelaConnectionString);
                // DataSet_VentasGeneral dataset = new DataSet_VentasGeneral();
                DataSet datasetx = new DataSet();
                adaptadorx.Fill(datasetx, "v_ventas_articulo_mas");
                XtraReport_ProductosMasVendidos reported = new XtraReport_ProductosMasVendidos();
                reported.DataSource = datasetx;
                reported.DataMember = datasetx.Tables["v_ventas_articulo_mas"].TableName;
                reported.Parameters["Fecha_inicio"].Value = dateEdit6.DateTime.ToString("yyyy-MM-dd") + " 00:00:00"; ;
                reported.Parameters["Fecha_fin"].Value = dateEdit5.DateTime.ToString("yyyy-MM-dd") + " 23:59:59"; ;
                reported.RequestParameters = false;
                reported.ShowPreview();
            }
            else
            {

                XtraReport_ProductosMasVendidos reported = new XtraReport_ProductosMasVendidos();
                reported.Parameters["Fecha_inicio"].Value = dateEdit6.DateTime.ToString("yyyy-MM-dd") + " 00:00:00"; ;
                reported.Parameters["Fecha_fin"].Value = dateEdit5.DateTime.ToString("yyyy-MM-dd") + " 23:59:59"; ;
                reported.RequestParameters = false;
                reported.ShowPreview();
            }
            Cursor.Current = Cursors.Default;
        }

        /*Reporte de Ventas por Socio Comercial*/
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            XtraReport_Ventas_por_SocioComercial reported = new XtraReport_Ventas_por_SocioComercial();
            reported.Parameters["Fecha_inicio"].Value = dateEdit6.DateTime.ToString("yyyy-MM-dd") + " 00:00:00"; ;
            reported.Parameters["Fecha_fin"].Value = dateEdit5.DateTime.ToString("yyyy-MM-dd") + " 23:59:59"; ;
           
            reported.RequestParameters = false;
            reported.ShowPreview();
            Cursor.Current = Cursors.Default;
        }

                      
        
    }
}