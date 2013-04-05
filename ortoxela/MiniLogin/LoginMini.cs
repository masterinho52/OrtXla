using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ortoxela.MiniLogin
{
    public partial class LoginMini : DevExpress.XtraEditors.XtraForm
    {
        public LoginMini()
        {
            InitializeComponent();
        }

        private void textEditnombre_EditValueChanged(object sender, EventArgs e)
        {

        }
        classortoxela logica = new classortoxela();
        string cadena;
        DataTable tabla = new DataTable();
        public static string id_UsuarioModifica;        
        private void simpleaceptar_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {              
                    cadena = "SELECT userid, nombre, apellido " +
                                "FROM ortoxela.usuarios where username='" + textEditnombre.Text + "' and pasword='" + logica.encripta(textEditcontraseña.Text) + "' and estadoid<>2";
                    tabla = logica.Tabla(cadena);
                    if (tabla.Rows.Count == 1)
                    {
                        foreach (DataRow fila in tabla.Rows)
                        {
                            id_UsuarioModifica = fila[0].ToString();
                        }
                        cadena = "SELECT r.codigo_rol FROM rol_usuario r WHERE r.estadoid=1 and r.userid=" + id_UsuarioModifica;
                        DataTable dt_rol = new DataTable();
                        dt_rol = logica.Tabla(cadena);
                        if (dt_rol.Rows[0][0].ToString() == "1")
                        {
                            alertControl1.Show(this, "ACCESO PERMITIDO", "Usted es " + clases.ClassVariables.NombreComple, Properties.Resources.sesion);
                            this.Close();
                        }
                        else
                        {
                            alertControl1.Show(this, "INFORMACION", "Solo se permiten Administradores", Properties.Resources.advertencia);
                            textEditnombre.Focus();
                            id_UsuarioModifica = "";
                        }
                    }
                    else
                    {
                        alertControl1.Show(this, "INFORMACION", "Usuario ó Contraseña no validas,Verifique por favor", Properties.Resources.advertencia);
                        textEditnombre.Focus();
                    }               
            }
            else
            {
                clases.ClassMensajes.FaltanDatosEnCampos(this);
            }
        }

        private void simplecancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void textEditcontraseña_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void LoginMini_Load(object sender, EventArgs e)
        {

        }
    }
}