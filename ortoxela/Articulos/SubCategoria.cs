using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ortoxela.Articulos
{
    public partial class SubCategoria : DevExpress.XtraEditors.XtraForm
    {
        public SubCategoria()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            clases.ClassVariables.bandera = 1;
            clases.ClassVariables.llamadoDentroForm = true;
            Form hijo = new Categorias();
            hijo.WindowState = System.Windows.Forms.FormWindowState.Normal;
            hijo.ShowDialog();
            if (clases.ClassVariables.idnuevo != null)
            {
                cadena = "SELECT codigo_categoria AS CODIGO, nombre_categoria AS CATEGORIA FROM categorias WHERE estadoid<>2";
                gridLookUpcategoria.Properties.DataSource = logica.Tabla(cadena);
                gridLookUpcategoria.Properties.ValueMember = "CODIGO";
                gridLookUpcategoria.Properties.DisplayMember = "CATEGORIA";
                gridLookUpcategoria.Text = "";
                gridLookUpcategoria.EditValue = clases.ClassVariables.idnuevo;
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
                    cadena = "INSERT into sub_categorias "+
                            "(codigo_categoria, nombre_subcategoria, fecha_creacion, usuario_creador, estadoid) "+
                            "VALUES ("+gridLookUpcategoria.EditValue+", '"+textEditnombre.Text+"', '"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"', "+clases.ClassVariables.id_usuario+", "+gridLookUpEditestado.EditValue+")";
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
                        cadena = "update sub_categorias "+
                                    "SET codigo_categoria = "+gridLookUpcategoria.EditValue+" , nombre_subcategoria ='"+textEditnombre.EditValue+"', estadoid = "+gridLookUpEditestado.EditValue+" "+
                                    "WHERE codigo_subcat=" + clases.ClassVariables.id_busca;
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

                            cadena = "update sub_categorias SET estadoid = 2 WHERE codigo_subcat=" + clases.ClassVariables.id_busca;
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
            gridLookUpEditestado.Properties.DataSource = logica.Tabla(cadena);
            gridLookUpEditestado.Properties.ValueMember = "CODIGO";
            gridLookUpEditestado.Properties.DisplayMember = "NOMBRE";
            gridLookUpEditestado.Text = "";
            gridLookUpEditestado.EditValue = 1;
            if (clases.ClassVariables.id_traido != "")
            {
                cadena = "SELECT codigo_categoria AS CODIGO, nombre_categoria AS CATEGORIA FROM categorias WHERE estadoid<>2";
                gridLookUpcategoria.Properties.DataSource = logica.Tabla(cadena);
                gridLookUpcategoria.Properties.ValueMember = "CODIGO";
                gridLookUpcategoria.Properties.DisplayMember = "CATEGORIA";
                gridLookUpcategoria.Text = "";
                gridLookUpcategoria.EditValue = clases.ClassVariables.id_traido;
            }
            else
            {
                cadena = "SELECT codigo_categoria AS CODIGO, nombre_categoria AS CATEGORIA FROM categorias WHERE estadoid<>2";
                gridLookUpcategoria.Properties.DataSource = logica.Tabla(cadena);
                gridLookUpcategoria.Properties.ValueMember = "CODIGO";
                gridLookUpcategoria.Properties.DisplayMember = "CATEGORIA";
                gridLookUpcategoria.Text = "";
            }
            }
        private void busca_mod_eli()
        {
            clases.ClassVariables.cadenabusca = "SELECT sub_categorias.codigo_subcat AS CODIGO,sub_categorias.nombre_subcategoria AS SUBCATEGORIA, categorias.nombre_categoria AS CATEGORIA "+
                                                "FROM sub_categorias INNER JOIN categorias ON sub_categorias.codigo_categoria = categorias.codigo_categoria WHERE sub_categorias.estadoid<>2";
            Form busca = new Buscador.Buscador();
            busca.ShowDialog();
            if (clases.ClassVariables.id_busca != "")
            {
                llenacombos();
                groupControl1.Enabled = true;
                simpleaceptar.Enabled = true;
                cadena = "SELECT codigo_subcat, codigo_categoria, nombre_subcategoria,estadoid FROM sub_categorias WHERE codigo_subcat=" + clases.ClassVariables.id_busca;
                DataTable dt = new DataTable();
                dt = logica.Tabla(cadena);
                foreach (DataRow fila in dt.Rows)
                {
                    gridLookUpcategoria.EditValue = fila[1].ToString();
                    textEditnombre.Text = fila[2].ToString();
                    gridLookUpEditestado.EditValue = fila[3].ToString();

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
            textEditnombre.Text = "";
            textEditnombre.Focus();
        }


       

        

        private void simpleButtonESTADO_Click(object sender, EventArgs e)
        {
            clases.ClassVariables.llamadoDentroForm = true;
            clases.ClassVariables.bandera = 1;
            Form hijo = new Estado.Estado();
            hijo.WindowState = System.Windows.Forms.FormWindowState.Normal;
            hijo.ShowDialog();
            if (clases.ClassVariables.idnuevo != null)
            {
                cadena = "SELECT estadoid as CODIGO, nombre_status as NOMBRE FROM estado where activo=1";
                gridLookUpEditestado.Properties.DataSource = logica.Tabla(cadena);
                gridLookUpEditestado.Properties.ValueMember = "CODIGO";
                gridLookUpEditestado.Properties.DisplayMember = "NOMBRE";
                gridLookUpEditestado.Text = "";
                gridLookUpEditestado.EditValue = clases.ClassVariables.idnuevo;
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
    }
}