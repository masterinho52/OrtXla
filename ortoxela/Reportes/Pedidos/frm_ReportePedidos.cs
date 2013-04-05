using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ortoxela.Reportes.Pedidos
{
    public partial class frm_ReportePedidos : DevExpress.XtraEditors.XtraForm
    {
        public frm_ReportePedidos()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            XtraReport_x_SocioComercial reportesc = new XtraReport_x_SocioComercial();
            reportesc.RequestParameters = false;
            reportesc.ShowPreview();
        }

          }
}