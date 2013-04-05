using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ortoxela.Buscador
{
    public partial class Buscador : DevExpress.XtraEditors.XtraForm
    {
        public Buscador()
        {
            InitializeComponent();
        }
        public static bool SeleccionSiNo;
        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    clases.ClassVariables.id_busca = gridView1.GetFocusedRowCellValue("CODIGO").ToString();
                    SeleccionSiNo = true;
                    this.Close();
                }
            }
            catch
            { }
        }

        classortoxela logica = new classortoxela();
        public static int cantidad = 50;
        private void Buscador_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource= logica.Tabla(clases.ClassVariables.cadenabusca);
            clases.ClassVariables.id_busca = "";
            SeleccionSiNo = false;
            gridView1.Columns["CODIGO"].Width = cantidad;
            try
            {
                gridView1.Columns["CODIGO"].OptionsColumn.ReadOnly = true;
                gridView1.Columns[1].OptionsColumn.ReadOnly = true;
                gridView1.Columns[2].OptionsColumn.ReadOnly = true;
                gridView1.Columns[3].OptionsColumn.ReadOnly = true;
            }
            catch
            { }
           
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clases.ClassVariables.id_busca = gridView1.GetFocusedRowCellValue("CODIGO").ToString();
                SeleccionSiNo = true;
                this.Close();
            }
            catch
            { }
            
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}