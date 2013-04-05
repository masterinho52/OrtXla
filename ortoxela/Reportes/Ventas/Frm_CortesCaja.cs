using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ortoxela.Reportes.Ventas
{
    public partial class Frm_CortesCaja : Form
    {
        public Frm_CortesCaja()
        {
            InitializeComponent();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if ((dateEdit8.EditValue != null) && (dateEdit7.EditValue != null))
            {
                XtraReport_Corte_Caja reportec = new XtraReport_Corte_Caja();
                reportec.Parameters["Fecha_inicio"].Value = dateEdit8.DateTime.ToString("yyyy-MM-dd") + " 00:00:00";
                reportec.Parameters["Fecha_fin"].Value = dateEdit7.DateTime.ToString("yyyy-MM-dd") + " 23:59:59";
                reportec.RequestParameters = false;
                reportec.ShowPreview();
            }
            else MessageBox.Show("Debe ingresar un Rango de Fechas!", "Advertencia");
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if ((dateEdit8.EditValue != null) && (dateEdit7.EditValue != null))
            {
                XtraReport_CorteCajaRecibos reporter = new XtraReport_CorteCajaRecibos();
                reporter.Parameters["Fecha_inicio"].Value = dateEdit8.DateTime.ToString("yyyy-MM-dd") + " 00:00:00";
                reporter.Parameters["Fecha_fin"].Value = dateEdit7.DateTime.ToString("yyyy-MM-dd") + " 23:59:59";
                reporter.RequestParameters = false;
                reporter.ShowPreview();
            }
            else MessageBox.Show("Debe ingresar un Rango de Fechas!", "Advertencia");
        }
    }
}
