using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ortoxela.Reportes.Compras
{
    public partial class XtraReport_x_NoCompra : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport_x_NoCompra()
        {
            InitializeComponent();
        }

        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

    }
}
