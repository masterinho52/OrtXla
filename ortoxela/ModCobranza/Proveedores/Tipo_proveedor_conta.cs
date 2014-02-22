using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ortoxela.ModCobranza.Proveedores
{
    public partial class Tipo_proveedor_conta : DevExpress.XtraEditors.XtraForm
    {
        public Tipo_proveedor_conta()
        {
            InitializeComponent();
        }

        classortoxela logica = new classortoxela();
        DataTable dt = new DataTable();
        string cadena; bool llamadentroform;
        int bandera;
        private void Tipo_proveedor_conta_Load(object sender, EventArgs e)
        {
            textproveedorconta.Focus();
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
                //llenacombos();
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

        private void limpiar()
        {
            textproveedorconta.Text = "";
            textporcentaje.Text = "";
        }

        private void busca_mod_eli()
        {
            clases.ClassVariables.cadenabusca = "SELECT id_tipo_proveedor_conta AS CODIGO , descripcion AS TIPO_PROVEEDOR FROM tipo_proveedor_contabilidad WHERE activo=1";
            Form busca = new Buscador.Buscador();
            busca.ShowDialog();
            if (clases.ClassVariables.id_busca != "")
            {
                //llenacombos();
                groupControl1.Enabled = true;
                simpleaceptar.Enabled = true;
                cadena = "SELECT descripcion,porcentaje_ret FROM tipo_proveedor_contabilidad WHERE id_tipo_proveedor_conta=" + clases.ClassVariables.id_busca;
                DataTable dt = new DataTable();
                dt = logica.Tabla(cadena);
                foreach (DataRow fila in dt.Rows)
                {
                    textproveedorconta.Text = fila[0].ToString();
                    textporcentaje.Text = fila[1].ToString();
                }
            }
            else
            {
                groupControl1.Enabled = false;
                simpleaceptar.Enabled = false;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
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

        private void simpleaceptar_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                if (bandera == 1)
                {
                    cadena = "INSERT into tipo_proveedor_contabilidad (descripcion,porcentaje_ret) " +
                            "VALUES ('" + textproveedorconta.Text + "', '" + Convert.ToDecimal(textporcentaje.Text) + "')";
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
                }//fin bandera 1
                else if (bandera == 2)
                {
                    cadena = "update tipo_proveedor_contabilidad SET descripcion = '" + textproveedorconta.Text + "' , porcentaje_ret = " + Convert.ToDecimal(textporcentaje.Text) + " WHERE id_tipo_proveedor_conta=" + clases.ClassVariables.id_busca;
                    if (clases.ClassMensajes.MODIFICAR(this, cadena))
                    {
                        groupControl1.Enabled = false;
                        simpleaceptar.Enabled = false;
                    }
                }
                else if (bandera == 3)
                {
                    cadena = "update tipo_proveedor_contabilidad SET activo = 0 WHERE id_tipo_proveedor_conta=" + clases.ClassVariables.id_busca;
                    if (clases.ClassMensajes.ELIMINAR(this, cadena))
                    {
                        groupControl1.Enabled = false;
                        simpleaceptar.Enabled = false;
                    }
                }
            }
            else //fin if principal
            {
                clases.ClassMensajes.FaltanDatosEnCampos(this);
            }
        }


    }
}