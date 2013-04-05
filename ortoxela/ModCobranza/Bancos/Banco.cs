using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ortoxela.ModCobranza.Bancos
{
    public partial class Banco : DevExpress.XtraEditors.XtraForm
    {
        public Banco()
        {
            InitializeComponent();
        }

        private void limpiar()
        {
            textEditnombre.Text = "";
        }

        classortoxela logica = new classortoxela();
        string cadena;
        
        int bandera;
            

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            clases.ClassVariables.llamadoDentroForm = true;
            clases.ClassVariables.bandera=1;
            Form hijo = new Estado.Estado();
            hijo.WindowState = System.Windows.Forms.FormWindowState.Normal;
            hijo.ShowDialog();
            if (clases.ClassVariables.idnuevo != "")
            {
                cadena = "SELECT estadoid as CODIGO, nombre_status as NOMBRE FROM ortoxela.estado where activo=1";
                gridLookUpEditestado.Properties.DataSource = logica.Tabla(cadena);
                gridLookUpEditestado.Properties.ValueMember = "CODIGO";
                gridLookUpEditestado.Properties.DisplayMember = "NOMBRE";
                gridLookUpEditestado.Text = "";
                gridLookUpEditestado.EditValue = clases.ClassVariables.idnuevo;
            }
        }

        private void llenacombos()
        {
            cadena = "SELECT estadoid as CODIGO, nombre_status as NOMBRE FROM ortoxela.estado where activo=1";
            gridLookUpEditestado.Properties.DataSource = logica.Tabla(cadena);
            gridLookUpEditestado.Properties.ValueMember = "CODIGO";
            gridLookUpEditestado.Properties.DisplayMember = "NOMBRE";
            gridLookUpEditestado.Text = "";
            gridLookUpEditestado.EditValue = 1;
        }
        private void busca_mod_eli()
        {
            clases.ClassVariables.cadenabusca = "SELECT bancos.id_banco AS CODIGO, bancos.nombre_banco AS NOMBRE FROM ortoxela.bancos WHERE estado<>2";
            Form busca = new Buscador.Buscador();
            busca.ShowDialog();
            if (clases.ClassVariables.id_busca != "")
            {
                llenacombos();
                groupControl1.Enabled = true;
                simpleaceptar.Enabled = true;
                cadena = "SELECT bancos.id_banco, bancos.nombre_banco, estado FROM ortoxela.bancos WHERE bancos.id_banco=" + clases.ClassVariables.id_busca;
                DataTable dt = new DataTable();
                dt = logica.Tabla(cadena);
                foreach (DataRow fila in dt.Rows)
                {
                    textEditnombre.Text = fila[1].ToString();
                    gridLookUpEditestado.EditValue = fila[2].ToString();

                }
            }
            else
            {
                groupControl1.Enabled = false;
                simpleaceptar.Enabled = false;
            }
        }
        bool llamadentroform;
        private void Paises_Load(object sender, EventArgs e)
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

        private void simpleaceptar_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                if (bandera == 1)
                {
                    cadena = "INSERT INTO ortoxela.bancos (nombre_banco, estado)  VALUES ('" + textEditnombre.Text + "', " + gridLookUpEditestado.EditValue + ")";
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
                        cadena = "UPDATE ortoxela.bancos SET nombre_banco = '" + textEditnombre.Text + "', estado = " + gridLookUpEditestado.EditValue + " WHERE id_banco=" + clases.ClassVariables.id_busca;
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

                            cadena = "UPDATE ortoxela.bancos SET estado = 2 WHERE id_banco=" + clases.ClassVariables.id_busca;
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

          
        

        private void simplecancelar_Click_1(object sender, EventArgs e)
        {
            
            this.Close();
        
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

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
        }
    }
