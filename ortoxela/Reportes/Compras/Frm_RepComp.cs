using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

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
            reporte.RequestParameters = false;
            reporte.ShowPreview();
        }

             private void simpleButton2_Click(object sender, EventArgs e)
        {
            XtraReport_x_Compra_X_Arti reporte2 = new XtraReport_x_Compra_X_Arti();
            reporte2.Parameters["Fecha_inicio"].Value = dateEdit3.DateTime.ToString("yyyy-MM-dd") + " 00:00:00";
            reporte2.Parameters["Fecha_fin"].Value = dateEdit4.DateTime.ToString("yyyy-MM-dd") + " 23:59:59";
            reporte2.RequestParameters = false;
            reporte2.ShowPreview();
        }

             private void simpleButton3_Click(object sender, EventArgs e)
             {
                 ortoxela.Reportes.Proveedores.XtraReport_RepProveedores reporteP = new ortoxela.Reportes.Proveedores.XtraReport_RepProveedores();
                 reporteP.Parameters["Fecha_inicio"].Value = dateEdit5.DateTime.ToString("yyyy-MM-dd") + " 00:00:00";
                 reporteP.Parameters["Fecha_fin"].Value = dateEdit6.DateTime.ToString("yyyy-MM-dd") + " 23:59:59";
                 reporteP.RequestParameters = false;
                 reporteP.ShowPreview();
             }

             private void simpleButton4_Click(object sender, EventArgs e)
             {
                 Reportes.Proveedores.XtraReport_RepUnProveedor Reporteu = new Reportes.Proveedores.XtraReport_RepUnProveedor();
                 Reporteu.Parameters["Fecha_inicio"].Value = dateEdit7.DateTime.ToString("yyyy-MM-dd") + " 00:00:00";
                 Reporteu.Parameters["Fecha_fin"].Value = dateEdit8.DateTime.ToString("yyyy-MM-dd") + " 23:59:59";
                 Reporteu.Parameters["Codigo_proveedor"].Value = gridLookProveedor.EditValue;
                 Reporteu.RequestParameters = false;
                 Reporteu.ShowPreview();
             }
             classortoxela logicaxela = new classortoxela();
             private void Frm_RepComp_Load(object sender, EventArgs e)
             {
                 try
                 {
                     string ssql = "SELECT codigo_proveedor AS CODIGO,nombre_proveedor AS NOMBRE FROM ortoxela.proveedores WHERE estadoid<>2";
                     gridLookProveedor.Properties.DataSource = logicaxela.Tabla(ssql);
                     gridLookProveedor.Properties.DisplayMember = "NOMBRE";
                     gridLookProveedor.Properties.ValueMember = "CODIGO";

                 }
                 catch
                 { }
             }

             private void simpleButton5_Click(object sender, EventArgs e)
             {
                 XtraReport_Requisiciones_Detalle reporteRQ = new XtraReport_Requisiciones_Detalle();
                 reporteRQ.Parameters["Fecha_inicio"].Value = dateEdit9.DateTime.ToString("yyyy-MM-dd") + " 00:00:00";
                 reporteRQ.Parameters["Fecha_fin"].Value = dateEdit10.DateTime.ToString("yyyy-MM-dd") + " 23:59:59";
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

             private void simpleButton6_Click(object sender, EventArgs e)
             {
                 XtraReport_Compras_por_Categoria  reportecat = new XtraReport_Compras_por_Categoria();
                 reportecat.Parameters["Fecha_inicio"].Value = dateEdit11.DateTime.ToString("yyyy-MM-dd") + " 00:00:00";
                 reportecat.Parameters["Fecha_fin"].Value = dateEdit12.DateTime.ToString("yyyy-MM-dd") + " 23:59:59";
                 reportecat.RequestParameters = false;
                 reportecat.ShowPreview();
             }
        
    }
}