namespace ortoxela.Articulos
{
	partial class Categorias
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButtonESTADO = new DevExpress.XtraEditors.SimpleButton();
            this.gridLookUpEditestado = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEditnombre = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleaceptar = new DevExpress.XtraEditors.SimpleButton();
            this.simplecancelar = new DevExpress.XtraEditors.SimpleButton();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditestado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditnombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Controls.Add(this.simpleaceptar);
            this.panelControl1.Controls.Add(this.simplecancelar);
            this.panelControl1.Location = new System.Drawing.Point(15, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(664, 232);
            this.panelControl1.TabIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Image = global::ortoxela.Properties.Resources.add_32x32_32;
            this.simpleButton1.Location = new System.Drawing.Point(71, 166);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(122, 40);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "NUEVO";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.simpleButtonESTADO);
            this.groupControl1.Controls.Add(this.gridLookUpEditestado);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.textEditnombre);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(36, 16);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(550, 130);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Categorias";
            // 
            // simpleButtonESTADO
            // 
            this.simpleButtonESTADO.Image = global::ortoxela.Properties.Resources.add_16x16_32;
            this.simpleButtonESTADO.Location = new System.Drawing.Point(421, 72);
            this.simpleButtonESTADO.Name = "simpleButtonESTADO";
            this.simpleButtonESTADO.Size = new System.Drawing.Size(28, 23);
            this.simpleButtonESTADO.TabIndex = 2;
            this.simpleButtonESTADO.Click += new System.EventHandler(this.simpleButtonESTADO_Click);
            // 
            // gridLookUpEditestado
            // 
            this.gridLookUpEditestado.Location = new System.Drawing.Point(196, 74);
            this.gridLookUpEditestado.Name = "gridLookUpEditestado";
            this.gridLookUpEditestado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEditestado.Properties.View = this.gridLookUpEdit1View;
            this.gridLookUpEditestado.Size = new System.Drawing.Size(221, 20);
            this.gridLookUpEditestado.TabIndex = 1;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Seleccione un estado";
            this.dxValidationProvider1.SetValidationRule(this.gridLookUpEditestado, conditionValidationRule1);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(130, 76);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 18);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Estado";
            // 
            // textEditnombre
            // 
            this.textEditnombre.Location = new System.Drawing.Point(196, 40);
            this.textEditnombre.Name = "textEditnombre";
            this.textEditnombre.Size = new System.Drawing.Size(324, 20);
            this.textEditnombre.TabIndex = 0;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Ingrese nombre de categoria";
            this.dxValidationProvider1.SetValidationRule(this.textEditnombre, conditionValidationRule2);
            this.textEditnombre.Validated += new System.EventHandler(this.textEditnombre_Validated);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(50, 39);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(130, 18);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Nombre Categoria";
            // 
            // simpleaceptar
            // 
            this.simpleaceptar.Appearance.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleaceptar.Appearance.Options.UseFont = true;
            this.simpleaceptar.Image = global::ortoxela.Properties.Resources.accept_32x32_32;
            this.simpleaceptar.Location = new System.Drawing.Point(251, 166);
            this.simpleaceptar.Name = "simpleaceptar";
            this.simpleaceptar.Size = new System.Drawing.Size(122, 40);
            this.simpleaceptar.TabIndex = 0;
            this.simpleaceptar.Text = "Agregar";
            this.simpleaceptar.Click += new System.EventHandler(this.simpleaceptar_Click);
            // 
            // simplecancelar
            // 
            this.simplecancelar.Appearance.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simplecancelar.Appearance.Options.UseFont = true;
            this.simplecancelar.Image = global::ortoxela.Properties.Resources.window_remove_32x32_32;
            this.simplecancelar.Location = new System.Drawing.Point(417, 166);
            this.simplecancelar.Name = "simplecancelar";
            this.simplecancelar.Size = new System.Drawing.Size(125, 40);
            this.simplecancelar.TabIndex = 1;
            this.simplecancelar.Text = "Cancelar/Salir";
            this.simplecancelar.Click += new System.EventHandler(this.simplecancelar_Click);
            // 
            // Categorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 302);
            this.Controls.Add(this.panelControl1);
            this.Name = "Categorias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Categorias";
            this.Load += new System.EventHandler(this.Departamentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditestado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditnombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonESTADO;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpEditestado;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textEditnombre;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleaceptar;
        private DevExpress.XtraEditors.SimpleButton simplecancelar;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
	}
}