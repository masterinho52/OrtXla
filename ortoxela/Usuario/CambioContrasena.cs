using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ortoxela.Usuario
{
    public partial class CambioContrasena : DevExpress.XtraEditors.XtraForm        
    {
        public CambioContrasena()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        classortoxela logica = new classortoxela();
        string consulta;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                if (textEdit1.Text == textEdit2.Text)
                {
                    consulta = "UPDATE ortoxela.usuarios SET pasword='" + logica.encripta(textEdit1.Text) + "'where userid='" + clases.ClassVariables.id_usuario + "'";
                    clases.ClassMensajes.MODIFICAR(this, consulta);
                    this.Close();
                }
                else
                {
                    clases.ClassMensajes.customessage(this, "No Coniciden las Contraseñas");
                    textEdit2.Text=textEdit1.Text="";
                    textEdit1.Focus();
                }
            }
            else
            {
                clases.ClassMensajes.FaltanDatosEnCampos(this);
                textEdit1.Focus();
            }
        }
    }
}
