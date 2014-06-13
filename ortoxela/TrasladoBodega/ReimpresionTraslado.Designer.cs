namespace ortoxela.TrasladoBodega
{
    partial class ReimpresionTraslado
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
            this.sbCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.dataGridView_traslados = new System.Windows.Forms.DataGridView();
            this.no_traslado_bodega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.no_documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serie_documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_bodega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_bodega1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_creacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_traslados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // sbCancelar
            // 
            this.sbCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbCancelar.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbCancelar.Appearance.Options.UseFont = true;
            this.sbCancelar.Image = global::ortoxela.Properties.Resources.window_remove_32x32_32;
            this.sbCancelar.Location = new System.Drawing.Point(961, 504);
            this.sbCancelar.Name = "sbCancelar";
            this.sbCancelar.Size = new System.Drawing.Size(181, 49);
            this.sbCancelar.TabIndex = 7;
            this.sbCancelar.Text = "CANCELAR/SALIR";
            this.sbCancelar.Click += new System.EventHandler(this.sbCancelar_Click);
            // 
            // dataGridView_traslados
            // 
            this.dataGridView_traslados.AllowUserToAddRows = false;
            this.dataGridView_traslados.AllowUserToDeleteRows = false;
            this.dataGridView_traslados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_traslados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_traslados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no_traslado_bodega,
            this.no_documento,
            this.serie_documento,
            this.nombre_bodega,
            this.nombre_bodega1,
            this.fecha_creacion,
            this.username});
            this.dataGridView_traslados.Location = new System.Drawing.Point(12, 182);
            this.dataGridView_traslados.Name = "dataGridView_traslados";
            this.dataGridView_traslados.ReadOnly = true;
            this.dataGridView_traslados.Size = new System.Drawing.Size(1110, 316);
            this.dataGridView_traslados.TabIndex = 4;
            // 
            // no_traslado_bodega
            // 
            this.no_traslado_bodega.DataPropertyName = "no_traslado_bodega";
            this.no_traslado_bodega.HeaderText = "ID";
            this.no_traslado_bodega.Name = "no_traslado_bodega";
            this.no_traslado_bodega.ReadOnly = true;
            // 
            // no_documento
            // 
            this.no_documento.DataPropertyName = "no_documento";
            this.no_documento.HeaderText = "No. de Traslado";
            this.no_documento.Name = "no_documento";
            this.no_documento.ReadOnly = true;
            // 
            // serie_documento
            // 
            this.serie_documento.DataPropertyName = "serie_documento";
            this.serie_documento.HeaderText = "Serie";
            this.serie_documento.Name = "serie_documento";
            this.serie_documento.ReadOnly = true;
            // 
            // nombre_bodega
            // 
            this.nombre_bodega.DataPropertyName = "nombre_bodega";
            this.nombre_bodega.HeaderText = "Bodega Destino";
            this.nombre_bodega.Name = "nombre_bodega";
            this.nombre_bodega.ReadOnly = true;
            // 
            // nombre_bodega1
            // 
            this.nombre_bodega1.DataPropertyName = "nombre_bodega1";
            this.nombre_bodega1.HeaderText = "Bodega Origen";
            this.nombre_bodega1.Name = "nombre_bodega1";
            this.nombre_bodega1.ReadOnly = true;
            // 
            // fecha_creacion
            // 
            this.fecha_creacion.DataPropertyName = "fecha_creacion";
            this.fecha_creacion.HeaderText = "Fecha del traslado";
            this.fecha_creacion.Name = "fecha_creacion";
            this.fecha_creacion.ReadOnly = true;
            // 
            // username
            // 
            this.username.DataPropertyName = "username";
            this.username.HeaderText = "Usuario Creador";
            this.username.Name = "username";
            this.username.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Image = global::ortoxela.Properties.Resources._027_folder_search;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(139, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(282, 49);
            this.button1.TabIndex = 3;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Image = global::ortoxela.Properties.Resources.printer64;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(799, 36);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(253, 93);
            this.button2.TabIndex = 5;
            this.button2.Text = "Imprimir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(61, 35);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(173, 20);
            this.dateEdit1.TabIndex = 1;
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(294, 35);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit2.Size = new System.Drawing.Size(182, 20);
            this.dateEdit2.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(108, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 13);
            this.labelControl1.TabIndex = 15;
            this.labelControl1.Text = "Fecha inicial";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(351, 16);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 13);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "Fecha final";
            // 
            // ReimpresionTraslado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 565);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dateEdit2);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView_traslados);
            this.Controls.Add(this.sbCancelar);
            this.Name = "ReimpresionTraslado";
            this.Text = "Reimpresion de Traslados";
            this.Load += new System.EventHandler(this.ReimpresionTraslado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_traslados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton sbCancelar;
        private System.Windows.Forms.DataGridView dataGridView_traslados;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.DataGridViewTextBoxColumn no_traslado_bodega;
        private System.Windows.Forms.DataGridViewTextBoxColumn no_documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn serie_documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_bodega;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_bodega1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_creacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
    }
}