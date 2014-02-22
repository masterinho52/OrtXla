using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;


namespace ortoxela.Clientes
{
    public partial class Tipo_cliente : DevExpress.XtraEditors.XtraForm
    {
        public Tipo_cliente()
        {
            InitializeComponent();
        }
        classortoxela logica = new classortoxela();

        DataTable dt = new DataTable();
        string cadena; bool llamadentroform; 
        private void Tipo_Proveedor_Load(object sender, EventArgs e)
        {
            textcliente.Focus();
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
        int bandera;
        
        

       
        private void limpiar()
        {
            textcliente.Text = "";
            textcredito.Text = "";
            textdescuento.Text = "";
            textcliente.Focus();
        }

       

        private void simpleaceptar_Click(object sender, EventArgs e)
        {
            Double creditomax = 0; Double descuentomax = 0;
            if (dxValidationProvider1.Validate())
            {
                if (textcredito.Text == "")
                    creditomax = 0;
                else
                    creditomax = Convert.ToDouble(textcredito.Text);

                if (textdescuento.Text == "")
                    descuentomax = 0;
                else
                    descuentomax = Convert.ToDouble(textdescuento.Text);


                if (bandera == 1)
                {
                    cadena = "INSERT into tipo_cliente (tipo_cliente, descuento_maximo, credito_maximo, estadoid) "+
                            "VALUES ('"+textcliente.Text+"', "+descuentomax+", "+creditomax+", "+gridLookestado.EditValue+")";
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
                        cadena = "update tipo_cliente SET tipo_cliente = '"+textcliente.Text+"' , descuento_maximo = "+descuentomax+", credito_maximo = "+creditomax+", estadoid = "+gridLookestado.EditValue+" "+
                                    "WHERE codigo_tipoc=" + clases.ClassVariables.id_busca;
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

                            cadena = "update tipo_cliente SET estadoid = 2 WHERE codigo_tipoc=" + clases.ClassVariables.id_busca;
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

        private void simpleButton2_Click_1(object sender, EventArgs e)
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
        private void llenacombos()
        {
            cadena = "SELECT estadoid as CODIGO, nombre_status as NOMBRE FROM estado where activo=1";
            gridLookestado.Properties.DataSource = logica.Tabla(cadena);
            gridLookestado.Properties.ValueMember = "CODIGO";
            gridLookestado.Properties.DisplayMember = "NOMBRE";
            gridLookestado.Text = "";
            gridLookestado.EditValue = 1;
        }

        private void busca_mod_eli()
        {
            clases.ClassVariables.cadenabusca = "SELECT codigo_tipoc as CODIGO , tipo_cliente AS CLIENTE  FROM tipo_cliente WHERE estadoid<>2";
            Form busca = new Buscador.Buscador();
            busca.ShowDialog();
            if (clases.ClassVariables.id_busca != "")
            {
                llenacombos();
                groupControl1.Enabled = true;
                simpleaceptar.Enabled = true;
                cadena = "SELECT codigo_tipoc, tipo_cliente, descuento_maximo, credito_maximo, estadoid FROM tipo_cliente WHERE codigo_tipoc=" + clases.ClassVariables.id_busca;
                DataTable dt = new DataTable();
                dt = logica.Tabla(cadena);
                foreach (DataRow fila in dt.Rows)
                {
                    textcliente.Text = fila[1].ToString();
                    textdescuento.Text = fila[2].ToString();
                    textcredito.Text = fila[3].ToString();
                    gridLookestado.EditValue = fila[4].ToString();
                }
            }
            else
            {
                groupControl1.Enabled = false;
                simpleaceptar.Enabled = false;
            }
        }

        private void simpleButtonestado_Click(object sender, EventArgs e)
        {
             
            clases.ClassVariables.bandera = 1;
            clases.ClassVariables.llamadoDentroForm = true;
            Form hijo = new Estado.Estado();
            hijo.WindowState = System.Windows.Forms.FormWindowState.Normal;
            hijo.ShowDialog();
            if (clases.ClassVariables.idnuevo != "")
            {
                cadena = "SELECT estadoid as CODIGO, nombre_status as NOMBRE FROM estado where activo=1";
                gridLookestado.Properties.DataSource = logica.Tabla(cadena);
                gridLookestado.Properties.ValueMember = "CODIGO";
                gridLookestado.Properties.DisplayMember = "NOMBRE";
                gridLookestado.Text = "";
                gridLookestado.EditValue = clases.ClassVariables.idnuevo;
            }
       
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            if (bandera == 1)
            {
                groupControl1.Enabled = true;
                simpleaceptar.Enabled = true;
                limpiar();
            }
            else
            {
                if (bandera == 2)
                {
                    busca_mod_eli();
                }

            }
        }
    }
}
