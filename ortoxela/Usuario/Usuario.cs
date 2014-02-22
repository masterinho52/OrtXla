using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Security.Cryptography;

namespace ortoxela.Usuario
{
    public partial class Usuario : DevExpress.XtraEditors.XtraForm
    {
        public Usuario()
        {
            InitializeComponent();
        }

        private void sbCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int bandera; string cadena; classortoxela logica = new classortoxela();
        private void simpleaceptar_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider2.Validate())
            {
                 if (dxValidationProvider1.Validate())
                    {
                         if (bandera == 1)
                            {
                   
                               cadena = "INSERT into usuarios (nombre, apellido, username, pasword, email, telefono_casa, telefono_celular, codigo_direccion, estadoid) " +
                                        "VALUES ('" + textNombreusu.Text + "', '" + textapellidousu.Text + "', '" + textusua.Text + "', '" + logica.encripta(textcontrasenia.Text) + "', '" + textemail.Text + "', '" + texttelefono.Text + "', '" + textcelular.Text + "', '" + memoEditdireccion.Text + "', " + gridLookUpEstado.EditValue + ")";
                            clases.ClassVariables.idnuevo = logica.nuevoid(cadena);
                            if (clases.ClassVariables.idnuevo != null)
                            {
                                groupControl1.Enabled = false;
                                simpleaceptar.Enabled = false;
                                clases.ClassMensajes.INSERTO(this);
                                if (llamadentroform == true)
                                {
                                    llamadentroform = false;
                                    this.Close();
                                }
                                limpiar();
                            }
                            else
                            {
                                clases.ClassMensajes.NoINSERTO(this);
                            }
                        
                         }
                      else
                        {
                    if (bandera == 2)
                    {
                        cadena = "update usuarios "+
                                "SET nombre = '"+textNombreusu.Text+"' , apellido = '"+textapellidousu.Text+"', username = '"+textusua.Text+"', pasword = '" + logica.encripta(textcontrasenia.Text) + "', email = '" + textemail.Text + "', telefono_casa = '" + texttelefono.Text + "', telefono_celular = '" + textcelular.Text + "', codigo_direccion = '" + memoEditdireccion.Text + "', estadoid = " + gridLookUpEstado.EditValue + " " +
                                "WHERE userid=" + clases.ClassVariables.id_busca;
                        if (clases.ClassMensajes.MODIFICAR(this, cadena))
                        {
                            groupControl1.Enabled = false;
                            simpleaceptar.Enabled = false;
                        }


                    }

                         
                    else
                    {
                        if (bandera == 3)
                        {

                            cadena = "update usuarios SET estadoid = 2 WHERE userid=" + clases.ClassVariables.id_busca;
                            if (clases.ClassMensajes.ELIMINAR(this, cadena))
                            {
                                groupControl1.Enabled = false;
                                simpleaceptar.Enabled = false;
                            }


                        }
                    }
                     }
                  }
                    else
                        alertControl1.Show(this, "Error", "Las contraseñas no coinciden", Properties.Resources.error);
                    }
                
            else
            {
                clases.ClassMensajes.FaltanDatosEnCampos(this);

            }
        }
        private void llenacombos()
        {
            cadena = "SELECT estadoid as CODIGO, nombre_status as NOMBRE FROM estado where activo=1";
            gridLookUpEstado.Properties.DataSource = logica.Tabla(cadena);
            gridLookUpEstado.Properties.ValueMember = "CODIGO";
            gridLookUpEstado.Properties.DisplayMember = "NOMBRE";
            gridLookUpEstado.Text = "";
            gridLookUpEstado.EditValue = 1;
           
        }

        private void busca_mod_eli()
        {
            clases.ClassVariables.cadenabusca = "SELECT userid AS CODIGO, nombre AS NOMBRE, apellido AS APELLIDO, username AS USUARIO, pasword AS CONTRASEÑA, email AS EMAIL, telefono_casa AS TELEFONO, telefono_celular AS CELULAR "+
                                                "FROM usuarios WHERE estadoid<>2";
            Form busca = new Buscador.Buscador();
            busca.ShowDialog();
            if (clases.ClassVariables.id_busca != "")
            {
                llenacombos();
                groupControl1.Enabled = true;
                simpleaceptar.Enabled = true;
                cadena = "SELECT userid, nombre, apellido, username, pasword, email, telefono_casa, telefono_celular, codigo_direccion, estadoid "+
                            "FROM usuarios where userid=" + clases.ClassVariables.id_busca;
                DataTable dt = new DataTable();
                dt = logica.Tabla(cadena);
                foreach (DataRow fila in dt.Rows)
                {
                    textNombreusu.Text= fila[1].ToString();
                    textapellidousu.Text = fila[2].ToString();
                    textusua.Text = fila[3].ToString();
                    //textcontrasenia.Text = fila[4].ToString();
                    //textconfirmacontrasenia.Text = fila[4].ToString();
                    textemail.Text = fila[5].ToString();
                    texttelefono.Text = fila[6].ToString();
                    textcelular.Text = fila[7].ToString();
                   memoEditdireccion.Text = fila[8].ToString();
                    gridLookUpEstado.EditValue = fila[9].ToString();
                    
                }
            }
            else
            {
                groupControl1.Enabled = false;
                simpleaceptar.Enabled = false;
            }
        }
        private void limpiar()
        {
            textNombreusu.Text = "";
            textapellidousu.Text = "";
            textusua.Text = "";
            textcontrasenia.Text = "";
             textconfirmacontrasenia.Text= "";
             textemail.Text = "";
             texttelefono.Text = "";
             textcelular.Text= "";
             

        }
        bool llamadentroform;
        private void Usuario_Load(object sender, EventArgs e)
        {
            llamadentroform = clases.ClassVariables.llamadoDentroForm;
            if (clases.ClassVariables.bandera == 1)
            {
                bandera = 1;
                simpleaceptar.Text = "Aceptar";
                simpleaceptar.Image = Properties.Resources.database_add_24x24_32;
                simpleButton1.Text = "Nuevo";
                simpleButton1.Image = Properties.Resources.add_32x32_32;
                groupControl1.Enabled = true;
                simpleaceptar.Enabled = true;
                llenacombos();
                limpiar();
            }
            else
            {
                if (clases.ClassVariables.bandera == 2)
                {
                    bandera = 2;

                    simpleaceptar.Text = "Modificar";
                    simpleaceptar.Image = Properties.Resources.database_process_24x24_32;
                    simpleButton1.Text = "Buscar...";
                    simpleButton1.Image = Properties.Resources._027_folder_search;
                    busca_mod_eli();
                }
                else
                {
                    if (clases.ClassVariables.bandera == 3)
                    {
                        bandera = 3;
                        simpleaceptar.Text = "Eliminar";
                        simpleaceptar.Image = Properties.Resources.database_remove_24x24_32;
                        simpleButton1.Text = "Buscar...";
                        simpleButton1.Image = Properties.Resources._027_folder_search;
                        busca_mod_eli();

                    }
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (bandera == 1)
            {
                groupControl1.Enabled = true;
                simpleaceptar.Enabled = true;
                limpiar();
            }
            else
            {
                if (bandera == 2 || bandera == 3)
                {
                    limpiar();
                    busca_mod_eli();
                    
                }


            }
        }

        private void simpleButtonEstado_Click(object sender, EventArgs e)
        {
            clases.ClassVariables.llamadoDentroForm = true;
            clases.ClassVariables.bandera = 1;
            Form hijo = new Estado.Estado();
            hijo.WindowState = System.Windows.Forms.FormWindowState.Normal;
            hijo.ShowDialog();
            if (clases.ClassVariables.idnuevo != "")
            {
                cadena = "SELECT estadoid as CODIGO, nombre_status as NOMBRE FROM estado where activo=1";
                gridLookUpEstado.Properties.DataSource = logica.Tabla(cadena);
                gridLookUpEstado.Properties.ValueMember = "CODIGO";
                gridLookUpEstado.Properties.DisplayMember = "NOMBRE";
                gridLookUpEstado.Text = "";
                gridLookUpEstado.EditValue = clases.ClassVariables.idnuevo;
            }
           
        }
        
        
    }
}