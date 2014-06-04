using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ortoxela
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        public Login()
        {
            InitializeComponent();
        }

        

        classortoxela logica = new classortoxela();
        string cadena;
        
           
        private void simplecancelar_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }
        DataTable tabla=new DataTable();
        private void simpleaceptar_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                cadena = "SELECT userid, nombre, apellido " +
                            "FROM usuarios where username='" + textEditnombre.Text + "' and pasword='" + logica.encripta(textEditcontraseña.Text) + "' and estadoid<>2";
                tabla = logica.Tabla(cadena);
                if (tabla.Rows.Count == 1)
                {
                    foreach (DataRow fila in tabla.Rows)
                    {
                        clases.ClassVariables.id_usuario = fila[0].ToString();
                        clases.ClassVariables.NombreComple = fila[1].ToString() + " " + fila[2].ToString();
                    }
                    cadena = "SELECT r.codigo_rol FROM rol_usuario r WHERE r.estadoid=1 and r.userid=" + clases.ClassVariables.id_usuario;
                    DataTable dt_rol = new DataTable();
                    dt_rol = logica.Tabla(cadena);
                    clases.ClassVariables.id_rol = dt_rol.Rows[0][0].ToString();

                    // cadena = " SELECT Sucursal  FROM master.sucursales  WHERE IDSuc=1 ";
                    // DataTable dt_empresa = new DataTable();
                    // dt_empresa = logica.Tabla(cadena);
                    clases.ClassVariables.nombreEmpresa = "OrtoXela"; //dt_empresa.Rows[0][0].ToString();
                    
                    textEditcontraseña.Text = "";
                    textEditnombre.Text = "";
                    textEditnombre.Focus();
                    labelControl3.Text = "";
                    this.Hide();
                    alertControl1.Show(this, "Inicio Sesión", "Usted es " + clases.ClassVariables.NombreComple, Properties.Resources.sesion);
                    Form nuevo = new Principal.Principal();
                    nuevo.Show();                    
                }
                else
                {
                    labelControl3.Text = "El Usuario o La Contraseña son incorrectos";
                    textEditnombre.Focus();
                }
            }
            else
            {
                clases.ClassMensajes.FaltanDatosEnCampos(this);
            }            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textEditnombre.Focus();
        }

        private void textEditcontraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                simpleaceptar.PerformClick();
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
       
        }
    }
