using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ortoxela.Proveedores
{
    public partial class Proveedor : DevExpress.XtraEditors.XtraForm
    {
        public Proveedor()
        {
            InitializeComponent();
        }
        classortoxela logica = new classortoxela();
        DataTable dt = new DataTable();
        string cadena;
        bool llamadentroform;
        private void Proveedor_Load(object sender, EventArgs e)
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
        
        private void busca_mod_eli()
        {
            clases.ClassVariables.cadenabusca = "SELECT codigo_proveedor as CODIGO, nombre_proveedor AS NOMBRE,nit AS NIT FROM ortoxela.proveedores where estadoid<>2";
                                                         
            Form busca = new Buscador.Buscador();
            busca.ShowDialog();
            if (clases.ClassVariables.id_busca != "")
            {
                llenacombos();
                groupControl1.Enabled = true;
                simpleaceptar.Enabled = true;
                cadena = "SELECT codigo_proveedor, nombre_proveedor, contacto,telefono_principal, telefono_celular, fax_otro_tel, nit, dias_credito,  " +
                "email,codigo_tipo_prov, direccion,estadoid FROM ortoxela.proveedores where codigo_proveedor=" + clases.ClassVariables.id_busca;
                DataTable dt = new DataTable();
                dt = logica.Tabla(cadena);
                foreach (DataRow fila in dt.Rows)
                {
                    textNombreProv.Text = fila[1].ToString();
                    textContacto.Text = fila[2].ToString();
                    textTelefono.Text = fila[3].ToString();
                    textCelular.Text = fila[4].ToString();
                    textFax.Text = fila[5].ToString();
                    textNit.Text = fila[6].ToString();
                    spinEditdiascredito.Text = fila[7].ToString();
                    textEmail.Text = fila[8].ToString();
                    gridLookTipo_Prov.EditValue = fila[9].ToString();
                   memoEditdireccion.Text = fila[10].ToString();
                    gridLookUpEstado.EditValue = fila[11].ToString();
                    
                }
            }
            else
            {
                groupControl1.Enabled = false;
                simpleaceptar.Enabled = false;
            }
        }
        public void limpiar()
        {
            textNombreProv.Text = "";
            textContacto.Text = "";
            memoEditdireccion.Text = "";
            spinEditdiascredito.Text = "";
            textTelefono.Text = "";
            textCelular.Text = "";
            textEmail.Text = "";
            textFax.Text = "";
            textNit.Text = "";
            textNombreProv.Focus();
        }
                

        private void simpleButtonTipo_prov_Click(object sender, EventArgs e)
        {
            clases.ClassVariables.bandera = 1;
            clases.ClassVariables.llamadoDentroForm = true;
                Form prov=new Proveedores.Tipo_Proveedor();
                prov.WindowState = System.Windows.Forms.FormWindowState.Normal;
            prov.ShowDialog();
            if (clases.ClassVariables.idnuevo != "")
            {
                cadena = "SELECT codigo_tipo_prov as CODIGO, tipo_proveedor as TIPO_PROVEEDOR FROM ortoxela.tipo_proveedor WHERE estadoid<>2";
                gridLookTipo_Prov.Properties.DataSource = logica.Tabla(cadena);
                gridLookTipo_Prov.Properties.ValueMember = "CODIGO";
                gridLookTipo_Prov.Properties.DisplayMember = "TIPO_PROVEEDOR";
                gridLookTipo_Prov.Text = "";
                gridLookTipo_Prov.EditValue = clases.ClassVariables.idnuevo;
            }
        }

        private void simpleButtonEstado_Click(object sender, EventArgs e)
        {
            clases.ClassVariables.llamadoDentroForm = true;
            clases.ClassVariables.bandera = 1;
            Form prov = new Estado.Estado();
            prov.WindowState = System.Windows.Forms.FormWindowState.Normal;
            prov.ShowDialog();
            if (clases.ClassVariables.idnuevo != "")
            {
                cadena = "SELECT estadoid as CODIGO, nombre_status as NOMBRE FROM ortoxela.estado where activo=1";
                gridLookUpEstado.Properties.DataSource = logica.Tabla(cadena);
                gridLookUpEstado.Properties.ValueMember = "CODIGO";
                gridLookUpEstado.Properties.DisplayMember = "NOMBRE";
                gridLookUpEstado.Text = "";
                gridLookUpEstado.EditValue = clases.ClassVariables.idnuevo;
            }
        }

        private void sbCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        int bandera;
        private void simpleaceptar_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                if (bandera == 1)
                {
                      cadena = "INSERT INTO ortoxela.proveedores " +
                                "(nombre_proveedor, contacto,dias_credito,nit, telefono_principal, telefono_celular, fax_otro_tel, email, fecha_ingreso, usuario_ingreso,estadoid, codigo_tipo_prov, direccion) " +
                            "VALUES ('" + textNombreProv.Text + "', '" + textContacto.Text + "',"+spinEditdiascredito.Text+", '" + textNit.Text + "', '" + textTelefono.Text + "', '" + textCelular.Text + "', '" + textFax.Text + "', '" + textEmail.Text + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', " + clases.ClassVariables.id_usuario + "," + gridLookUpEstado.EditValue + ", " + gridLookTipo_Prov.EditValue + ", '" + memoEditdireccion.Text + "')";
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
                        cadena = "UPDATE ortoxela.proveedores SET nombre_proveedor = '" + textNombreProv.Text + "' , contacto = '" + textContacto.Text + "',dias_credito = "+spinEditdiascredito.Text+", nit = '" + textNit.Text + "', telefono_principal = '" + textTelefono.Text + "', telefono_celular = '" + textCelular.Text + "', fax_otro_tel = '" + textFax.Text + "', email = '" + textEmail.Text + "',fecha_modificacion = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',usuario_modifica = " + clases.ClassVariables.id_usuario + ", estadoid = " + gridLookUpEstado.EditValue + ", codigo_tipo_prov = " + gridLookTipo_Prov.EditValue + ", direccion = '" + memoEditdireccion.Text + "' " +
                                    "WHERE proveedores.codigo_proveedor=" + clases.ClassVariables.id_busca;
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

                            cadena = "UPDATE ortoxela.proveedores SET  estadoid = 2 WHERE proveedores.codigo_proveedor=" + clases.ClassVariables.id_busca;
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
            cadena = "SELECT estadoid as CODIGO, nombre_status as NOMBRE FROM ortoxela.estado where activo=1";
            gridLookUpEstado.Properties.DataSource = logica.Tabla(cadena);
            gridLookUpEstado.Properties.ValueMember = "CODIGO";
            gridLookUpEstado.Properties.DisplayMember = "NOMBRE";
            gridLookUpEstado.Text = "";
            gridLookUpEstado.EditValue = 1;
            cadena = "SELECT codigo_tipo_prov as CODIGO, tipo_proveedor as TIPO_PROVEEDOR FROM ortoxela.tipo_proveedor WHERE estadoid<>2";
            gridLookTipo_Prov.Properties.DataSource = logica.Tabla(cadena);
            gridLookTipo_Prov.Properties.ValueMember = "CODIGO";
            gridLookTipo_Prov.Properties.DisplayMember = "TIPO_PROVEEDOR";
            gridLookTipo_Prov.Text = "";
            cadena = "SELECT id_tipo_proveedor_conta AS CODIGO, descripcion AS TIPO FROM ortoxela.tipo_proveedor_contabilidad WHERE activo=1";
            gridLookUpTipoProveedorConta.Properties.DataSource = logica.Tabla(cadena);
            gridLookUpTipoProveedorConta.Properties.DisplayMember = "TIPO";
            gridLookUpTipoProveedorConta.Properties.ValueMember = "CODIGO";
            gridLookUpTipoProveedorConta.EditValue = 0; 
            limpiar();
        }

        private void textTelefono_EditValueChanged(object sender, EventArgs e)
        {

        }

        
    }
}