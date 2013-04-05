namespace ortoxela.Pedido.Vale
{
    partial class XtraReportVale
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary8 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary9 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary10 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary11 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary12 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary13 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.SOCIO = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.dataSetVale1 = new ortoxela.Pedido.Vale.DataSetVale();
            this.encabezadoTableAdapter = new ortoxela.Pedido.Vale.DataSetValeTableAdapters.EncabezadoTableAdapter();
            this.ID = new DevExpress.XtraReports.Parameters.Parameter();
            this.RECIBO = new DevExpress.XtraReports.Parameters.Parameter();
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.detalle_manualTableAdapter = new ortoxela.Pedido.Vale.DataSetValeTableAdapters.detalle_manualTableAdapter();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetVale1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel13,
            this.xrLabel7,
            this.xrLabel6});
            this.Detail.HeightF = 185F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.None;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel13
            // 
            this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Encabezado.contacto")});
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(248.9583F, 83.29166F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(228.125F, 23F);
            xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.Sum;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.None;
            this.xrLabel13.Summary = xrSummary1;
            this.xrLabel13.Text = "xrLabel13";
            // 
            // xrLabel7
            // 
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.SOCIO, "Text", "")});
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(32.29168F, 33.29166F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(358.3333F, 23F);
            xrSummary2.Func = DevExpress.XtraReports.UI.SummaryFunc.Sum;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.None;
            this.xrLabel7.Summary = xrSummary2;
            this.xrLabel7.Text = "xrLabel7";
            // 
            // SOCIO
            // 
            this.SOCIO.Name = "SOCIO";
            this.SOCIO.Value = "";
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Encabezado.fecha", "{0:d\'               \'MMMM\'                               \'yyyy}")});
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(185.4165F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(367.0833F, 23F);
            xrSummary3.Func = DevExpress.XtraReports.UI.SummaryFunc.Sum;
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.None;
            this.xrLabel6.Summary = xrSummary3;
            this.xrLabel6.Text = "xrLabel6";
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 115F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.PageBreak = DevExpress.XtraReports.UI.PageBreak.None;
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.PageBreak = DevExpress.XtraReports.UI.PageBreak.None;
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // dataSetVale1
            // 
            this.dataSetVale1.DataSetName = "DataSetVale";
            this.dataSetVale1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // encabezadoTableAdapter
            // 
            this.encabezadoTableAdapter.ClearBeforeFill = true;
            // 
            // ID
            // 
            this.ID.Name = "ID";
            this.ID.ParameterType = DevExpress.XtraReports.Parameters.ParameterType.Int32;
            this.ID.Value = 0;
            // 
            // RECIBO
            // 
            this.RECIBO.Name = "RECIBO";
            this.RECIBO.Value = "";
            // 
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1});
            this.DetailReport.DataAdapter = this.detalle_manualTableAdapter;
            this.DetailReport.DataMember = "Encabezado.Encabezado_detalle_manual";
            this.DetailReport.DataSource = this.dataSetVale1;
            this.DetailReport.Level = 0;
            this.DetailReport.Name = "DetailReport";
            this.DetailReport.PageBreak = DevExpress.XtraReports.UI.PageBreak.None;
            // 
            // Detail1
            // 
            this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1});
            this.Detail1.HeightF = 23F;
            this.Detail1.Name = "Detail1";
            this.Detail1.PageBreak = DevExpress.XtraReports.UI.PageBreak.None;
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Encabezado.Encabezado_detalle_manual.precio_total", "{0:c2}")});
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(390.625F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(71.875F, 23F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            xrSummary4.Func = DevExpress.XtraReports.UI.SummaryFunc.Sum;
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.None;
            this.xrLabel4.Summary = xrSummary4;
            this.xrLabel4.Text = "xrLabel4";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Encabezado.Encabezado_detalle_manual.precio_unitario", "{0:c2}")});
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(312.5F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(78.12506F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            xrSummary5.Func = DevExpress.XtraReports.UI.SummaryFunc.Sum;
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.None;
            this.xrLabel3.Summary = xrSummary5;
            this.xrLabel3.Text = "xrLabel3";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Encabezado.Encabezado_detalle_manual.cantidad")});
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(248.9583F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(63.54167F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            xrSummary6.Func = DevExpress.XtraReports.UI.SummaryFunc.Sum;
            xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.None;
            this.xrLabel2.Summary = xrSummary6;
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Encabezado.Encabezado_detalle_manual.descripcion")});
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(248.9583F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            xrSummary7.Func = DevExpress.XtraReports.UI.SummaryFunc.Sum;
            xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.None;
            this.xrLabel1.Summary = xrSummary7;
            this.xrLabel1.Text = "xrLabel1";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // detalle_manualTableAdapter
            // 
            this.detalle_manualTableAdapter.ClearBeforeFill = true;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel12,
            this.xrLabel11,
            this.xrLabel10,
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel5});
            this.PageFooter.HeightF = 577F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.PageBreak = DevExpress.XtraReports.UI.PageBreak.None;
            this.PageFooter.PrintOn = DevExpress.XtraReports.UI.PrintOnPages.AllPages;
            // 
            // xrLabel12
            // 
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Encabezado.telefono_celular")});
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(43.75005F, 78.37499F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(152.0833F, 23F);
            xrSummary8.Func = DevExpress.XtraReports.UI.SummaryFunc.Sum;
            xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.None;
            this.xrLabel12.Summary = xrSummary8;
            this.xrLabel12.Text = "xrLabel12";
            // 
            // xrLabel11
            // 
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Encabezado.nit")});
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(43.75005F, 55.37503F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(152.0833F, 23F);
            xrSummary9.Func = DevExpress.XtraReports.UI.SummaryFunc.Sum;
            xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.None;
            this.xrLabel11.Summary = xrSummary9;
            this.xrLabel11.Text = "xrLabel11";
            // 
            // xrLabel10
            // 
            this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Encabezado.nombre_cliente")});
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(43.75005F, 32.37505F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(248.9583F, 23F);
            xrSummary10.Func = DevExpress.XtraReports.UI.SummaryFunc.Sum;
            xrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.None;
            this.xrLabel10.Summary = xrSummary10;
            this.xrLabel10.Text = "xrLabel10";
            // 
            // xrLabel9
            // 
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.RECIBO, "Text", "")});
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(167.7082F, 119.9583F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(100F, 23F);
            xrSummary11.Func = DevExpress.XtraReports.UI.SummaryFunc.Sum;
            xrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.None;
            this.xrLabel9.Summary = xrSummary11;
            this.xrLabel9.Text = "xrLabel9";
            // 
            // xrLabel8
            // 
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Encabezado.nombre_paciente")});
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(167.7082F, 161.7917F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(309.3751F, 23.00002F);
            xrSummary12.Func = DevExpress.XtraReports.UI.SummaryFunc.Sum;
            xrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.None;
            this.xrLabel8.Summary = xrSummary12;
            this.xrLabel8.Text = "xrLabel8";
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Encabezado.Encabezado_detalle_manual.precio_total")});
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(390.625F, 109.5417F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(71.87503F, 23F);
            this.xrLabel5.StylePriority.UseFont = false;
            xrSummary13.FormatString = "{0:c2}";
            xrSummary13.Func = DevExpress.XtraReports.UI.SummaryFunc.Sum;
            xrSummary13.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel5.Summary = xrSummary13;
            this.xrLabel5.Text = "xrLabel5";
            // 
            // XtraReportVale
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.DetailReport,
            this.PageFooter});
            this.DataAdapter = this.encabezadoTableAdapter;
            this.DataMember = "Encabezado";
            this.DataSource = this.dataSetVale1;
            this.FilterString = "[id_documento] = ?ID";
            this.Margins = new System.Drawing.Printing.Margins(64, 100, 115, 100);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.ID,
            this.RECIBO,
            this.SOCIO});
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.dataSetVale1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DataSetVale dataSetVale1;
        private DataSetValeTableAdapters.EncabezadoTableAdapter encabezadoTableAdapter;
        private DevExpress.XtraReports.Parameters.Parameter ID;
        private DevExpress.XtraReports.Parameters.Parameter RECIBO;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.DetailReportBand DetailReport;
        private DevExpress.XtraReports.UI.DetailBand Detail1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DataSetValeTableAdapters.detalle_manualTableAdapter detalle_manualTableAdapter;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.Parameters.Parameter SOCIO;
    }
}
