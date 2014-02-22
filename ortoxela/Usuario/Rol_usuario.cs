using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ortoxela.Usuario
{
    public partial class Rol_usuario : DevExpress.XtraEditors.XtraForm
    {
        public Rol_usuario()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            clases.ClassVariables.bandera = 1;
            clases.ClassVariables.llamadoDentroForm = true;
            Form hijo = new Usuario();
            hijo.WindowState = System.Windows.Forms.FormWindowState.Normal;
            hijo.ShowDialog();
            if (clases.ClassVariables.idnuevo != "")
            {
                cadena = "SELECT userid AS CODIGO, concat(nombre,' ',apellido) AS NOMBRE, username AS USUARIO " +
                                                    "FROM usuarios WHERE estadoid<>2";
                gridLookUpusuario.Properties.DataSource = logica.Tabla(cadena);
                gridLookUpusuario.Properties.ValueMember = "CODIGO";
                gridLookUpusuario.Properties.DisplayMember = "NOMBRE";
                gridLookUpusuario.Text = "";
                gridLookUpusuario.EditValue = clases.ClassVariables.idnuevo;
            }

        }
        string cadena;
        classortoxela logica = new classortoxela();
        int bandera;
        private void simpleaceptar_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                if (bandera == 1)
                {
                    cadena = "INSERT into rol_usuario (codigo_rol, userid, estadoid, descripcion) "+
                   "VALUES ("+gridLookUprol.EditValue+","+gridLookUpusuario.EditValue+", "+gridLookUpestado.EditValue+", '"+memoEditdescripcion.Text+"')";
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
                        cadena = "update rol_usuario "+
                                "SET codigo_rol = "+gridLookUprol.EditValue+" , userid = "+gridLookUpusuario.EditValue+", estadoid = "+gridLookUpestado.EditValue+", descripcion = '"+memoEditdescripcion.Text+"' "+
                                "WHERE id_ru=" + clases.ClassVariables.id_busca;
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

                            cadena = "update rol_usuario SET estadoid = 2 WHERE id_ru=" + clases.ClassVariables.id_busca;
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
            {
                clases.ClassMensajes.FaltanDatosEnCampos(this);

            }


        }
        private void llenacombos()
        {
            cadena = "SELECT estadoid as CODIGO, nombre_status as NOMBRE FROM estado where activo=1";
            gridLookUpestado.Properties.DataSource = logica.Tabla(cadena);
            gridLookUpestado.Properties.ValueMember = "CODIGO";
            gridLookUpestado.Properties.DisplayMember = "NOMBRE";
            gridLookUpestado.Text = "";
            gridLookUpestado.EditValue = 1;
            cadena = "SELECT userid AS CODIGO, concat(nombre,' ',apellido) AS NOMBRE, username AS USUARIO " +
                                                "FROM usuarios WHERE estadoid<>2";
            gridLookUpusuario.Properties.DataSource = logica.Tabla(cadena);
            gridLookUpusuario.Properties.ValueMember = "CODIGO";
            gridLookUpusuario.Properties.DisplayMember = "NOMBRE";
            gridLookUpusuario.Text = "";
            cadena = "SELECT codigo_rol AS CODIGO, nombre_rol AS NOMBRE, codigo_modulo AS MODULO FROM roles WHERE estadoid<>2";
            gridLookUprol.Properties.DataSource = logica.Tabla(cadena);
            gridLookUprol.Properties.ValueMember = "CODIGO";
            gridLookUprol.Properties.DisplayMember = "NOMBRE";
            gridLookUprol.Text = "";
        }
        private void busca_mod_eli()
        {
            clases.ClassVariables.cadenabusca = "SELECT rol_usuario.id_ru as CODIGO,roles.nombre_rol AS ROL, concat(usuarios.nombre,' ',usuarios.apellido) AS USUARIO  " +
                                                "FROM rol_usuario INNER JOIN roles ON rol_usuario.codigo_rol = roles.codigo_rol " +
                                                "INNER JOIN usuarios ON rol_usuario.userid = usuarios.userid WHERE rol_usuario.estadoid<>2";
            Form busca = new Buscador.Buscador();
            busca.ShowDialog();
            if (clases.ClassVariables.id_busca != "")
            {
                llenacombos();
                groupControl1.Enabled = true;
                simpleaceptar.Enabled = true;
                cadena = "SELECT id_ru, codigo_rol, userid, estadoid, descripcion FROM rol_usuario WHERE  id_ru=" + clases.ClassVariables.id_busca;
                DataTable dt = new DataTable();
                dt = logica.Tabla(cadena);
                foreach (DataRow fila in dt.Rows)
                {
                    gridLookUprol.EditValue = fila[1].ToString();
                    gridLookUpusuario.EditValue = fila[2].ToString();
                   gridLookUpestado.EditValue = fila[3].ToString();
                   memoEditdescripcion.Text = fila[4].ToString();

                }
            }
            else
            {
                groupControl1.Enabled = false;
                simpleaceptar.Enabled = false;
            }
        }
        bool llamadentroform;
        private void Departamentos_Load(object sender, EventArgs e)
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

        private void simplecancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void limpiar()
        {
            memoEditdescripcion.Text = "";
        }

             

        private void simpleButtonESTADO_Click(object sender, EventArgs e)
        {
            clases.ClassVariables.llamadoDentroForm = true; 
            clases.ClassVariables.bandera = 1;
            Form hijo = new Estado.Estado();
            hijo.ShowDialog();
            if (clases.ClassVariables.idnuevo != "")
            {
                cadena = "SELECT estadoid as CODIGO, nombre_status as NOMBRE FROM estado where activo=1";
                gridLookUpestado.Properties.DataSource = logica.Tabla(cadena);
                gridLookUpestado.Properties.ValueMember = "CODIGO";
                gridLookUpestado.Properties.DisplayMember = "NOMBRE";
                gridLookUpestado.Text = "";
                gridLookUpestado.EditValue = clases.ClassVariables.idnuevo;
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
                    busca_mod_eli();
                }

            }
        
        }

        private void simpleButtonrol_Click(object sender, EventArgs e)
        {
            clases.ClassVariables.bandera = 1;
            clases.ClassVariables.llamadoDentroForm = true;
            Form hijo = new Roles();
            hijo.WindowState = System.Windows.Forms.FormWindowState.Normal;
            hijo.ShowDialog();
            if (clases.ClassVariables.idnuevo != "")
            {
                cadena = "SELECT codigo_rol AS CODIGO, nombre_rol AS NOMBRE, codigo_modulo AS MODULO FROM roles WHERE estadoid<>2";
                gridLookUprol.Properties.DataSource = logica.Tabla(cadena);
                gridLookUprol.Properties.ValueMember = "CODIGO";
                gridLookUprol.Properties.DisplayMember = "NOMBRE";
                gridLookUprol.Text = "";
                gridLookUprol.EditValue = clases.ClassVariables.idnuevo;
            }
        }
    }
}