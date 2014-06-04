namespace ortoxela.Reportes.Ventas
{
    partial class Frm_Estadistica
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.listBoxSeries = new System.Windows.Forms.ListBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.listBoxBodegas = new System.Windows.Forms.ListBox();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.FechaFin = new DevExpress.XtraEditors.DateEdit();
            this.FechaInicio = new DevExpress.XtraEditors.DateEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.gcEstadistica = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.FechaFin.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaInicio.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaInicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcEstadistica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxSeries
            // 
            this.listBoxSeries.FormattingEnabled = true;
            this.listBoxSeries.Location = new System.Drawing.Point(405, 36);
            this.listBoxSeries.Name = "listBoxSeries";
            this.listBoxSeries.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxSeries.Size = new System.Drawing.Size(188, 82);
            this.listBoxSeries.TabIndex = 36;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(432, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(123, 20);
            this.labelControl2.TabIndex = 35;
            this.labelControl2.Text = "Seleccione Serie:";
            // 
            // listBoxBodegas
            // 
            this.listBoxBodegas.FormattingEnabled = true;
            this.listBoxBodegas.Location = new System.Drawing.Point(242, 36);
            this.listBoxBodegas.Name = "listBoxBodegas";
            this.listBoxBodegas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxBodegas.Size = new System.Drawing.Size(120, 82);
            this.listBoxBodegas.TabIndex = 34;
            this.listBoxBodegas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listBoxBodegas_MouseUp);
            // 
            // labelControl17
            // 
            this.labelControl17.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl17.Location = new System.Drawing.Point(242, 10);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(60, 20);
            this.labelControl17.TabIndex = 33;
            this.labelControl17.Text = "Bodega:";
            // 
            // FechaFin
            // 
            this.FechaFin.EditValue = null;
            this.FechaFin.Location = new System.Drawing.Point(70, 59);
            this.FechaFin.Name = "FechaFin";
            this.FechaFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FechaFin.Properties.Mask.EditMask = "dd-mm-yyyy";
            this.FechaFin.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.FechaFin.Size = new System.Drawing.Size(103, 20);
            this.FechaFin.TabIndex = 32;
            // 
            // FechaInicio
            // 
            this.FechaInicio.EditValue = null;
            this.FechaInicio.Location = new System.Drawing.Point(70, 16);
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FechaInicio.Properties.Mask.EditMask = "dd-mm-yyyy";
            this.FechaInicio.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.FechaInicio.Size = new System.Drawing.Size(103, 20);
            this.FechaInicio.TabIndex = 31;
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl10.Location = new System.Drawing.Point(29, 15);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(29, 23);
            this.labelControl10.TabIndex = 30;
            this.labelControl10.Text = "Del:";
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl12.Location = new System.Drawing.Point(30, 58);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(20, 23);
            this.labelControl12.TabIndex = 29;
            this.labelControl12.Text = "Al:";
            // 
            // simpleButton4
            // 
            this.simpleButton4.Location = new System.Drawing.Point(635, 58);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(75, 27);
            this.simpleButton4.TabIndex = 37;
            this.simpleButton4.Text = "Consultar";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // groupControl4
            // 
            this.groupControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl4.Controls.Add(this.gcEstadistica);
            this.groupControl4.Location = new System.Drawing.Point(43, 157);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(971, 251);
            this.groupControl4.TabIndex = 63;
            this.groupControl4.Text = "Reporte Estadistica";
            // 
            // gcEstadistica
            // 
            this.gcEstadistica.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.gcEstadistica.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gcEstadistica.Location = new System.Drawing.Point(4, 19);
            this.gcEstadistica.MainView = this.gridView3;
            this.gcEstadistica.MaximumSize = new System.Drawing.Size(1200, 0);
            this.gcEstadistica.Name = "gcEstadistica";
            this.gcEstadistica.Size = new System.Drawing.Size(963, 227);
            this.gcEstadistica.TabIndex = 0;
            this.gcEstadistica.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.gcEstadistica;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // Frm_Estadistica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 564);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.listBoxSeries);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.listBoxBodegas);
            this.Controls.Add(this.labelControl17);
            this.Controls.Add(this.FechaFin);
            this.Controls.Add(this.FechaInicio);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.labelControl12);
            this.Name = "Frm_Estadistica";
            this.Text = "Frm_Estadistica";
            this.Load += new System.EventHandler(this.Frm_Estadistica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FechaFin.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaInicio.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaInicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcEstadistica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxSeries;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ListBox listBoxBodegas;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.DateEdit FechaFin;
        private DevExpress.XtraEditors.DateEdit FechaInicio;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraGrid.GridControl gcEstadistica;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
    }
}