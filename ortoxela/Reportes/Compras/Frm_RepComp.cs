using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql;
using MySql.Data.MySqlClient;

namespace ortoxela.Reportes.Compras
{
    public partial class Frm_RepComp : DevExpress.XtraEditors.XtraForm
    {
        public Frm_RepComp()
        {
            InitializeComponent();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            XtraReport_x_NoCompra reporte = new XtraReport_x_NoCompra();
            reporte.Parameters["Fecha_inicio"].Value = dateEdit1.DateTime.ToString("yyyy-MM-dd") + " 00:00:00";
            reporte.Parameters["Fecha_fin"].Value = dateEdit2.DateTime.ToString("yyyy-MM-dd") + " 23:59:59";
            reporte.Parameters["Empresa"].Value = clases.ClassVariables.nombreEmpresa;
            reporte.RequestParameters = false;
            reporte.ShowPreview();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            XtraReport_x_Compra_X_Arti reporte2 = new XtraReport_x_Compra_X_Arti();
            reporte2.Parameters["Fecha_inicio"].Value = dateEdit3.DateTime.ToString("yyyy-MM-dd") + " 00:00:00";
            reporte2.Parameters["Fecha_fin"].Value = dateEdit4.DateTime.ToString("yyyy-MM-dd") + " 23:59:59";
            reporte2.Parameters["Empresa"].Value = clases.ClassVariables.nombreEmpresa;
            reporte2.RequestParameters = false;
            reporte2.ShowPreview();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            ortoxela.Reportes.Proveedores.XtraReport_RepProveedores reporteP = new ortoxela.Reportes.Proveedores.XtraReport_RepProveedores();
            reporteP.Parameters["Fecha_inicio"].Value = dateEdit5.DateTime.ToString("yyyy-MM-dd") + " 00:00:00";
            reporteP.Parameters["Fecha_fin"].Value = dateEdit6.DateTime.ToString("yyyy-MM-dd") + " 23:59:59";
            //reporteP.Parameters["Empresa"].Value = clases.ClassVariables.nombreEmpresa;
            reporteP.RequestParameters = false;
            reporteP.ShowPreview();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Reportes.Proveedores.XtraReport_RepUnProveedor Reporteu = new Reportes.Proveedores.XtraReport_RepUnProveedor();
            Reporteu.Parameters["Fecha_inicio"].Value = dateEdit7.DateTime.ToString("yyyy-MM-dd") + " 00:00:00";
            Reporteu.Parameters["Fecha_fin"].Value = dateEdit8.DateTime.ToString("yyyy-MM-dd") + " 23:59:59";
            Reporteu.Parameters["Codigo_proveedor"].Value = gridLookProveedor.EditValue;
            //Reporteu.Parameters["Empresa"].Value = clases.ClassVariables.nombreEmpresa;
            Reporteu.RequestParameters = false;
            Reporteu.ShowPreview();
        }
        
        classortoxela logicaxela = new classortoxela();
        
        private void Frm_RepComp_Load(object sender, EventArgs e)
        {
            try
            {
                string ssql = "SELECT codigo_proveedor AS CODIGO,nombre_proveedor AS NOMBRE FROM proveedores WHERE estadoid<>2";
                gridLookProveedor.Properties.DataSource = logicaxela.Tabla(ssql);
                gridLookProveedor.Properties.DisplayMember = "NOMBRE";
                gridLookProveedor.Properties.ValueMember = "CODIGO";

            }
            catch
            { }

            try
            {
                string ssql;

                /* jramirez 2013.07.24 */
                ssql = "SELECT distinct codigo_bodega, nombre_bodega FROM v_bodegas_series_usuarios  WHERE estadoid_bodega<>2 AND userid=" + clases.ClassVariables.id_usuario;

                listBox2.DataSource = logicaxela.Tabla(ssql);
                listBox2.DisplayMember = "nombre_bodega";
                listBox2.ValueMember = "codigo_bodega";
            }
            catch
            { }
            
            try
            {
                string ssql;

                /* jramirez 2013.07.24 */
                ssql = "SELECT distinct codigo_bodega, nombre_bodega FROM v_bodegas_series_usuarios  WHERE estadoid_bodega<>2 AND userid=" + clases.ClassVariables.id_usuario;

                listBox2.DataSource = logicaxela.Tabla(ssql);
                listBox2.DisplayMember = "nombre_bodega";
                listBox2.ValueMember = "codigo_bodega";

            }
            catch
            { }
            
            //Listando bodegas
            string ListaBods = "0";
            string ListaNombBods = "";

            for (int cnt = 0; cnt < listBox2.Items.Count; cnt++)
            {
                DataRowView srs = listBox2.Items[cnt] as DataRowView;
                ListaBods += "," + srs["codigo_bodega"].ToString();
                ListaNombBods += srs["nombre_bodega"].ToString() + " ,";
            }

            try
            {
                string getsers = "SELECT distinct codigo_serie, CONCAT(nombre_documento,' [', serie_documento,']')  AS DOCUMENTO  FROM v_bodegas_series_usuarios  WHERE codigo_tipo=6 AND userid=" + clases.ClassVariables.id_usuario + " and codigo_bodega in (" + ListaBods + ")";
                listBox1.DataSource = logicaxela.Tabla(getsers);
                listBox1.DisplayMember = "DOCUMENTO";
                listBox1.ValueMember = "codigo_serie";
            }
            catch
            {}              
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            XtraReport_Requisiciones_Detalle reporteRQ = new XtraReport_Requisiciones_Detalle();
            reporteRQ.Parameters["Fecha_inicio"].Value = dateEdit9.DateTime.ToString("yyyy-MM-dd") + " 00:00:00";
            reporteRQ.Parameters["Fecha_fin"].Value = dateEdit10.DateTime.ToString("yyyy-MM-dd") + " 23:59:59";
            reporteRQ.Parameters["Empresa"].Value = clases.ClassVariables.nombreEmpresa;
            /*
            * int no_req1=0,no_req2=99999999999999;
            if (trim(textEdit1.Text) != "")
            {
                no_req1= no_req2 = int.Parse(textEdit1.Text.ToString());
            }
            reporteRQ.Parameters["No_inicio"].Value =
            reporteRQ.Parameters["No_fin"].Value 
            */
            reporteRQ.RequestParameters = false;
            reporteRQ.ShowPreview();
        }

        private void labelControl17_Click(object sender, EventArgs e)
        {
        }

        private string getSelCodBods()
        {
            string ListaBods = "0";
            string ListaNombBods = "";

            for (int cnt = 0; cnt < listBox2.SelectedItems.Count; cnt++)
            {
                DataRowView srs = listBox2.SelectedItems[cnt] as DataRowView;
                ListaBods += "," + srs["codigo_bodega"].ToString();
                ListaNombBods += srs["nombre_bodega"].ToString() + " ,";
            }
            return (ListaBods);
        }

        private string getSelCodSers()
        {
            string ListaSers = "0";
            string ListaNombSers = "";

            for (int cnt = 0; cnt < listBox1.SelectedItems.Count; cnt++)
            {
                DataRowView srs = listBox1.SelectedItems[cnt] as DataRowView;
                ListaSers += "," + srs["codigo_serie"].ToString();
                ListaNombSers += srs["Documento"].ToString() + " ,";
            }
            return (ListaSers);
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {  
            /*
            XtraReport_Compras_por_Categoria  reportecat = new XtraReport_Compras_por_Categoria();
            reportecat.Parameters["Fecha_inicio"].Value = dateEdit11.DateTime.ToString("yyyy-MM-dd") + " 00:00:00";
            reportecat.Parameters["Fecha_fin"].Value = dateEdit12.DateTime.ToString("yyyy-MM-dd") + " 23:59:59";
            reportecat.RequestParameters = false;
            reportecat.ShowPreview();
            */

            if (getSelCodBods() == "0" || getSelCodSers() == "0")
            {
                MessageBox.Show("Por favor seleccione la bodega y la serie para generar el reporte");
            }
            
            string QueryCompras = "SELECT " +
                                  "d.codigo_articulo     AS codigo_articulo, " +
                                  "a.descripcion         AS Articulo, " +
                                  "d.cantidad_enviada    AS cantidad_enviada, " +
                                  "(d.precio_unitario / 1.12) AS precio_sin_iva, " +
                                  "d.precio_unitario     AS precio_iva, " +
                                  "(d.cantidad_enviada * (d.precio_unitario / 1.12)) AS precio_unidades_sin_iva, " +
                                  "(d.cantidad_enviada * d.precio_unitario) AS precio_unidades_iva, " +
                                  "d.codigo_bodega       AS codigo_bodega, " +
                                  "b.nombre_bodega       AS nombre_bodega, " +
                                  "h.fecha               AS fecha_compra, " +
                                  "IF((h.contado_credito = 0),_utf8'Contado',_utf8'Credito') AS Tipo_Pago, " +
                                  "p.nombre_proveedor    AS nombre_proveedor, " +
                                  "h.no_documento        AS no_documento, " +
                                  "(h.descuento / h.monto_neto) AS descuentoPct, " +
                                  "h.descuento           AS DescuentoQ, " +
                                  "h.monto_neto          AS total_iva, " +
                                  "(h.monto_neto / 1.12) AS Total_sin_iva, " +
                                  "COALESCE(h.refer_documento,_latin1'--') AS refer_documento, " +
                                  "CONCAT(CONVERT(t.nombre_documento USING utf8),_utf8'[',CONVERT(t.serie_documento USING utf8),_utf8']') AS documento, " +
                                  "a.costo               AS costo_iva, " +
                                  "(a.costo / 1.12)      AS costo_sin_iva, " +
                                  "COALESCE(g.nombre_tipo_pago,_latin1'Efectivo') AS forma_pago, " +
                                  "s.codigo_subcat       AS codigo_subcat, " +
                                  "s.nombre_subcategoria AS nombre_subcategoria " +
                                  "FROM (((((((header_doctos_inv h " +
                                  "       JOIN detalle_doctos_inv d " +
                                  "         ON ((h.id_documento = d.id_documento))) " +
                                  "      JOIN proveedores p " +
                                  "        ON ((h.codigo_proveedor = p.codigo_proveedor))) " +
                                  "     JOIN v_tipos_documentos t " +
                                  "       ON ((h.codigo_serie = t.codigo_serie))) " +
                                  "    LEFT JOIN tipo_pago g " +
                                  "      ON ((h.tipo_pago = g.tipo_pago))) " +
                                  "   JOIN articulos a " +
                                  "     ON ((d.codigo_articulo = a.codigo_articulo))) " +
                                  "  JOIN sub_categorias s " +
                                  "    ON ((a.codigo_categoria = s.codigo_subcat))) " +
                                  " JOIN bodegas_header b " +
                                  "   ON ((d.codigo_bodega = b.codigo_bodega))) " +
                                  "WHERE ((t.codigo_tipo = 6) " +
                                  "     AND (h.estadoid IN(4,5,8,9,10))) " +
                                  "     AND d.codigo_bodega IN ("+ getSelCodBods() +") " +
                                  "AND t.codigo_serie IN ("+getSelCodSers()+ ") " +
                                  " and fecha between '" + dateEdit11.DateTime.ToString("yyyy-MM-dd") + " 00:00:00'  and '" +
                                  dateEdit12.DateTime.ToString("yyyy-MM-dd") + " 23:59:59' " + 
                                  "ORDER BY h.fecha DESC ";

            MySqlDataAdapter adaptadorx = new MySqlDataAdapter(QueryCompras, Properties.Settings.Default.ortoxelaConnectionString);
            // DataSet_VentasGeneral dataset = new DataSet_VentasGeneral();
            DataSet datasetx = new DataSet();
            adaptadorx.Fill(datasetx, "v_compras_detalle_proveedor_categoria");
            XtraReport_Compras_por_Categoria  reportecat = new XtraReport_Compras_por_Categoria();
            reportecat.DataSource = datasetx;
            reportecat.DataMember = datasetx.Tables["v_compras_detalle_proveedor_categoria"].TableName;
            reportecat.Parameters["Fecha_inicio"].Value = dateEdit11.DateTime.ToString("yyyy-MM-dd") + " 00:00:00";
            reportecat.Parameters["Fecha_fin"].Value = dateEdit12.DateTime.ToString("yyyy-MM-dd") + " 23:59:59";
            reportecat.Parameters["Empresa"].Value = clases.ClassVariables.nombreEmpresa;
            //clases.ClassVariables.nombreEmpresa;
            reportecat.RequestParameters = false;
            reportecat.ShowPreview();
            
        }

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}