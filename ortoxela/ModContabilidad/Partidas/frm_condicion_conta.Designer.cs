namespace ortoxela.ModContabilidad.Partidas
{
    partial class frm_condicion_conta
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridLookUpTipoCliente = new DevExpress.XtraEditors.GridLookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.gridLookSerie = new DevExpress.XtraEditors.GridLookUpEdit();
            this.labelControl39 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textNombreOperacion = new DevExpress.XtraEditors.TextEdit();
            this.sbnuevo = new DevExpress.XtraEditors.SimpleButton();
            this.sbCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.sbAceptar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpTipoCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookSerie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNombreOperacion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Controls.Add(this.gridLookUpTipoCliente);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.radioGroup1);
            this.panelControl1.Controls.Add(this.gridLookSerie);
            this.panelControl1.Controls.Add(this.labelControl39);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.textNombreOperacion);
            this.panelControl1.Location = new System.Drawing.Point(248, 97);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(501, 272);
            this.panelControl1.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.sbnuevo);
            this.panelControl2.Controls.Add(this.sbCancelar);
            this.panelControl2.Controls.Add(this.sbAceptar);
            this.panelControl2.Location = new System.Drawing.Point(23, 187);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(454, 67);
            this.panelControl2.TabIndex = 1;
            // 
            // gridLookUpTipoCliente
            // 
            this.gridLookUpTipoCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gridLookUpTipoCliente.Location = new System.Drawing.Point(133, 121);
            this.gridLookUpTipoCliente.Name = "gridLookUpTipoCliente";
            this.gridLookUpTipoCliente.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpTipoCliente.Size = new System.Drawing.Size(337, 20);
            this.gridLookUpTipoCliente.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Location = new System.Drawing.Point(14, 124);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(113, 13);
            this.labelControl3.TabIndex = 85;
            this.labelControl3.Text = "Seleccione Tipo Cliente:";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Location = new System.Drawing.Point(23, 90);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(104, 13);
            this.labelControl2.TabIndex = 83;
            this.labelControl2.Text = "Seleccione Tipo Pago:";
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(133, 85);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Contado"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Crédito")});
            this.radioGroup1.Size = new System.Drawing.Size(337, 21);
            this.radioGroup1.TabIndex = 2;
            // 
            // gridLookSerie
            // 
            this.gridLookSerie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gridLookSerie.Location = new System.Drawing.Point(133, 49);
            this.gridLookSerie.Name = "gridLookSerie";
            this.gridLookSerie.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookSerie.Size = new System.Drawing.Size(337, 20);
            this.gridLookSerie.TabIndex = 1;
            // 
            // labelControl39
            // 
            this.labelControl39.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl39.Location = new System.Drawing.Point(16, 52);
            this.labelControl39.Name = "labelControl39";
            this.labelControl39.Size = new System.Drawing.Size(111, 13);
            this.labelControl39.TabIndex = 81;
            this.labelControl39.Text = "Seleccione Documento:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(34, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(93, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Nombre Operacion:";
            // 
            // textNombreOperacion
            // 
            this.textNombreOperacion.Location = new System.Drawing.Point(133, 15);
            this.textNombreOperacion.Name = "textNombreOperacion";
            this.textNombreOperacion.Size = new System.Drawing.Size(337, 20);
            this.textNombreOperacion.TabIndex = 0;
            // 
            // sbnuevo
            // 
            this.sbnuevo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.sbnuevo.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbnuevo.Appearance.Options.UseFont = true;
            this.sbnuevo.Image = global::ortoxela.Properties.Resources.Nuevo42;
            this.sbnuevo.Location = new System.Drawing.Point(14, 10);
            this.sbnuevo.Name = "sbnuevo";
            this.sbnuevo.Size = new System.Drawing.Size(134, 49);
            this.sbnuevo.TabIndex = 6;
            this.sbnuevo.Text = "NUEVO";
            this.sbnuevo.Click += new System.EventHandler(this.sbnuevo_Click);
            // 
            // sbCancelar
            // 
            this.sbCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.sbCancelar.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbCancelar.Appearance.Options.UseFont = true;
            this.sbCancelar.Image = global::ortoxela.Properties.Resources.window_remove_32x32_32;
            this.sbCancelar.Location = new System.Drawing.Point(299, 10);
            this.sbCancelar.Name = "sbCancelar";
            this.sbCancelar.Size = new System.Drawing.Size(138, 49);
            this.sbCancelar.TabIndex = 5;
            this.sbCancelar.Text = "CANCELAR";
            this.sbCancelar.Click += new System.EventHandler(this.sbCancelar_Click);
            // 
            // sbAceptar
            // 
            this.sbAceptar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.sbAceptar.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbAceptar.Appearance.Options.UseFont = true;
            this.sbAceptar.Image = global::ortoxela.Properties.Resources.accept_32x32_32;
            this.sbAceptar.Location = new System.Drawing.Point(156, 10);
            this.sbAceptar.Name = "sbAceptar";
            this.sbAceptar.Size = new System.Drawing.Size(129, 49);
            this.sbAceptar.TabIndex = 4;
            this.sbAceptar.Text = "ACEPTAR";
            this.sbAceptar.Click += new System.EventHandler(this.sbAceptar_Click);
            // 
            // frm_condicion_conta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 499);
            this.Controls.Add(this.panelControl1);
            this.Name = "frm_condicion_conta";
            this.Text = "CONDICION CONTABILIDAD";
            this.Load += new System.EventHandler(this.frm_condicion_conta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpTipoCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookSerie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNombreOperacion.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textNombreOperacion;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookSerie;
        private DevExpress.XtraEditors.LabelControl labelControl39;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpTipoCliente;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraEditors.SimpleButton sbCancelar;
        private DevExpress.XtraEditors.SimpleButton sbAceptar;
        private DevExpress.XtraEditors.SimpleButton sbnuevo;
    }
}