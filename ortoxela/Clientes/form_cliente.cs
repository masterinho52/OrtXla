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
    public partial class form_cliente : DevExpress.XtraEditors.XtraForm
    {
        public form_cliente()
        {
            InitializeComponent();
        }
        string ssql;
        classortoxela logicaxela = new classortoxela();

        bool llamadentroform;        
        int bandera;
        private void form_cliente_Load(object sender, EventArgs e)
        {
            if (clases.ClassVariables.sociocomercial == true)
            {
                labelControl1.Text = "Nombre Socio:";
                radioGroup1.SelectedIndex = 1;
                radioGroup1.Enabled = false;
            }
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
        public void limpiar()
        {
            textNombreClie.Text = "";
            textContacto.Text = "";
            textTelefono.Text = "";
            textCelular.Text = "";
            textEmail.Text = "";
            textFax.Text = "";
            textNit.Text = "";
            textIgss.Text = "";
            memoEditdireccion.Text = "";
            
            textNombrePaciente.Text="";
            textNombreClie.Focus();
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
            ssql = "SELECT codigo_tipoc as CODIGO, tipo_cliente AS TIPO FROM tipo_cliente";
            gridLookUpTipoClie.Properties.DataSource = logicaxela.Tabla(ssql);
            gridLookUpTipoClie.Properties.DisplayMember = "TIPO";
            gridLookUpTipoClie.Properties.ValueMember = "CODIGO";
            gridLookUpTipoClie.Text = "";
            ssql = "SELECT id_tipo_cliente_c AS CODIGO, descripcion AS TIPO FROM tipo_cliente_contabilidad WHERE activo=1";
            gridLookUpTipoClienteConta.Properties.DataSource = logicaxela.Tabla(ssql);
            gridLookUpTipoClienteConta.Properties.DisplayMember = "TIPO";
            gridLookUpTipoClienteConta.Properties.ValueMember = "CODIGO";
            gridLookUpTipoClienteConta.EditValue = 0;            
            ssql = "SELECT estadoid as CODIGO, nombre_status AS ESTADO FROM estado";
            gridLookUpEstado.Properties.DataSource = logicaxela.Tabla(ssql);
            gridLookUpEstado.Properties.DisplayMember = "ESTADO";
            gridLookUpEstado.Properties.ValueMember = "CODIGO";
            gridLookUpEstado.Text = "";
            gridLookUpEstado.EditValue = 1;
           
        }
        
        private void busca_mod_eli()
        {
            clases.ClassVariables.cadenabusca = "SELECT codigo_cliente as CODIGO, nombre_cliente AS CLIENTE, contacto AS CONTACTO, nombre_paciente AS PACIENTE, telefono_casa AS TELEFONO "+
                                                "FROM clientes where estadoid<>2";
            Form BUSCA = new Buscador.Buscador();
            BUSCA.ShowDialog();
            if (clases.ClassVariables.id_busca != "")
            {
                llenacombos();
                groupControl1.Enabled = true;
                simpleaceptar.Enabled = true;
                ssql = "SELECT codigo_cliente, nombre_cliente, contacto, nombre_paciente, nit, telefono_casa, telefono_celular, fax_otro_tel, email,direccion,socio_comercial, afiliacion_igss, estadoid, codigo_tipoc, tipo_cliente_conta " +  
                    "FROM clientes where codigo_cliente=" + clases.ClassVariables.id_busca ;
                DataTable dt = new DataTable();
                dt = logicaxela.Tabla(ssql);
                foreach (DataRow fila in dt.Rows)
                {
                    try
                    {
                        textNombreClie.Text = fila[1].ToString();
                        textContacto.Text = fila[2].ToString();
                        textNombrePaciente.Text = fila[3].ToString();
                        textNit.Text = fila[4].ToString();
                        textTelefono.Text = fila[5].ToString();
                        textCelular.Text = fila[6].ToString();
                        textFax.Text = fila[7].ToString();
                        textEmail.Text = fila[8].ToString();
                        memoEditdireccion.Text = fila[9].ToString();
                        if (Convert.ToBoolean(fila[10].ToString()) == true)
                            radioGroup1.SelectedIndex = 1;
                        else
                            radioGroup1.SelectedIndex = 0;
                        textIgss.Text = fila[11].ToString();
                        gridLookUpEstado.EditValue = fila[12].ToString();
                        gridLookUpTipoClie.EditValue = fila[13].ToString();
                        gridLookUpTipoClienteConta.EditValue = fila[14].ToString();
                    }
                    catch
                    { }
                }
            }
            else
            {
                groupControl1.Enabled = false;
                simpleaceptar.Enabled = false;
            }
        }
        private void insertaCliente()
        {
            ssql = "INSERT into clientes(nombre_cliente, contacto, nombre_paciente, nit, telefono_casa, telefono_celular, fax_otro_tel, email, fecha_ingreso, usuario_creador, direccion, socio_comercial, afiliacion_igss, estadoid, codigo_tipoc,tipo_cliente_conta) " +
            "VALUES ('" + textNombreClie.Text + "', '" + textContacto.Text + "', '" + textNombrePaciente.Text + "', '" + textNit.Text + "', '" + textTelefono.Text + "', '" + textCelular.Text + "', '" + textFax.Text + "', '" + textEmail.Text + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', " + clases.ClassVariables.id_usuario + ", '" + memoEditdireccion.Text + "', " + radioGroup1.SelectedIndex + ", '" + textIgss.Text + "', " + gridLookUpEstado.EditValue + ", " + gridLookUpTipoClie.EditValue + ", " + gridLookUpTipoClienteConta.EditValue + ")";

            clases.ClassVariables.idnuevo = logicaxela.nuevoid(ssql);
            if (clases.ClassVariables.idnuevo != null)
            {
                groupControl1.Enabled = false;
                simpleaceptar.Enabled = false;
                clases.ClassMensajes.INSERTO(this);
                if (llamadentroform == true)
                {
                    clases.ClassVariables.sociocomercial = false;
                    llamadentroform = false;
                    this.Close();
                }
            }
            else
            {
                clases.ClassMensajes.NoINSERTO(this);
            }
        
        }
        private void simpleaceptar_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                if (bandera == 1)
                {
                    if(textNit.Text.Contains("C"))
                    {
                        insertaCliente();
                    }
                    else
                    {
                        string consulta = "SELECT * FROM clientes WHERE clientes.nit='"+textNit.Text+"'";
                        if (logicaxela.ExisteRegistro(consulta))
                        {
                            alertControl1.Show(this, "ADVERTENCIA", "EL CLIENTE YA EXISTE, VERIFIQUE POR FAVOR", Properties.Resources.Advertencia64);
                        }
                        else
                            insertaCliente();
                    }
                    
                }
                else
                {
                    if (bandera == 2)
                    {
                        ssql= "update clientes SET nombre_cliente = '"+textNombreClie.Text+"' , contacto = '"+textContacto.Text+"', nombre_paciente = '"+textNombrePaciente.Text+"', "+
                                "nit = '"+textNit.Text+"', telefono_casa = '"+textTelefono.Text+"', telefono_celular = '"+textCelular.Text+"', fax_otro_tel = '"+textFax.Text+"', "+
                                "email = '" + textEmail.Text + "',fecha_modificacion = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',usuario_modifica = " + clases.ClassVariables.id_usuario + ",direccion ='" + memoEditdireccion.Text + "', " +
                               " socio_comercial = "+radioGroup1.SelectedIndex+", afiliacion_igss = '"+textIgss.Text+"', estadoid = "+gridLookUpEstado.EditValue+", codigo_tipoc = "+gridLookUpTipoClie.EditValue+" "+
                                    "WHERE codigo_cliente=" + clases.ClassVariables.id_busca;
                        if (clases.ClassMensajes.MODIFICAR(this, ssql))
                        {
                            groupControl1.Enabled = false;
                            simpleaceptar.Enabled = false;
                        }


                    }


                    else
                    {
                        if (bandera == 3)
                        {

                            ssql = "update clientes SET  estadoid = 2 WHERE codigo_cliente=" + clases.ClassVariables.id_busca;
                            if (clases.ClassMensajes.ELIMINAR(this, ssql))
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

        
        private void simpleButtonEstado_Click(object sender, EventArgs e)
        {
            clases.ClassVariables.bandera = 1;
            clases.ClassVariables.llamadoDentroForm = true;
            Form prov = new Estado.Estado();
            prov.WindowState = System.Windows.Forms.FormWindowState.Normal;
            prov.ShowDialog();
            if (clases.ClassVariables.idnuevo != null)
            {
                ssql = "SELECT estadoid as CODIGO, nombre_status as NOMBRE FROM estado where activo=1";
                gridLookUpEstado.Properties.DataSource = logicaxela.Tabla(ssql);
                gridLookUpEstado.Properties.ValueMember = "CODIGO";
                gridLookUpEstado.Properties.DisplayMember = "NOMBRE";
                gridLookUpEstado.Text = "";
                gridLookUpEstado.EditValue = clases.ClassVariables.idnuevo;
            }
        }

       

        private void sbCancelar_Click(object sender, EventArgs e)
        {
            clases.ClassVariables.sociocomercial = false;
            this.Close();
        }

        private void simpleButtonTipo_cliente_Click(object sender, EventArgs e)
        {
            
            clases.ClassVariables.bandera = 1;
            clases.ClassVariables.llamadoDentroForm = true;
            clases.ClassVariables.idnuevo = "";
            Form prov = new Clientes.Tipo_cliente();
            prov.WindowState = System.Windows.Forms.FormWindowState.Normal;
            prov.ShowDialog();
            if (clases.ClassVariables.idnuevo != "")
            {
               
                ssql = "SELECT codigo_tipoc as CODIGO, tipo_cliente AS TIPO FROM tipo_cliente WHERE estadoid<>2";
                gridLookUpTipoClie.Properties.DataSource = logicaxela.Tabla(ssql);
                gridLookUpTipoClie.Properties.ValueMember = "CODIGO";
                gridLookUpTipoClie.Properties.DisplayMember = "TIPO";
                gridLookUpTipoClie.Text = "";
                gridLookUpTipoClie.EditValue = clases.ClassVariables.idnuevo;
            }
        }

        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            clases.ClassVariables.bandera = 1;
            clases.ClassVariables.llamadoDentroForm = true;
            clases.ClassVariables.idnuevo = "";
            Form nuevo = new Clientes.Tipo_cliente_conta();
            nuevo.WindowState = System.Windows.Forms.FormWindowState.Normal;
            nuevo.ShowDialog();
            if (clases.ClassVariables.idnuevo != "")
            {

                ssql = "SELECT id_tipo_cliente_c AS CODIGO , descripcion AS TIPO FROM tipo_cliente_contabilidad WHERE activo=1";
                gridLookUpTipoClienteConta.Properties.DataSource = logicaxela.Tabla(ssql);
                gridLookUpTipoClienteConta.Properties.ValueMember = "CODIGO";
                gridLookUpTipoClienteConta.Properties.DisplayMember = "TIPO";
                gridLookUpTipoClienteConta.Text = "";
                gridLookUpTipoClienteConta.EditValue = clases.ClassVariables.idnuevo;
            }
        }

       
        
    }
}