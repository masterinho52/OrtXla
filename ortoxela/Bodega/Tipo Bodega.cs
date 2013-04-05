using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ortoxela.Bodega
{
    public partial class Tipobodega : DevExpress.XtraEditors.XtraForm
    {
        public Tipobodega()
        {
            InitializeComponent();
        }
        int bandera; classortoxela logica = new classortoxela();
        string cadena;
        private void simpleaceptar_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                if (bandera == 1)
                {

                    
                        cadena = "INSERT INTO ortoxela.bodegas_header (usuario_creador, nombre_bodega, direccion, telefono1, telefono2, descripcion, fecha_creacion, estadoid) " +
                                    "VALUES (" + clases.ClassVariables.id_usuario + ", '" + textEditbodega.Text + "', '" + memoEditdireccion.Text + "', '" + texttelefono1.Text + "', '" + texttelefono2.Text + "', '" + memoEditdescripcion.Text + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," + gridLookUpEstado.EditValue + ")";
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
                        cadena = "UPDATE ortoxela.bodegas_header "+
                                    "SET nombre_bodega = '" + textEditbodega.Text + "', direccion = '" + memoEditdireccion.Text + "', telefono1 = '" + texttelefono1.Text + "', telefono2 = '" + texttelefono2.Text + "', descripcion = '" + memoEditdescripcion.Text + "',estadoid="+gridLookUpEstado.EditValue+" " +
                                    "WHERE codigo_bodega=" + clases.ClassVariables.id_busca;
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
                            cadena = "SELECT bodegas.existencia_articulo FROM ortoxela.bodegas_header inner join bodegas on bodegas.codigo_bodega = bodegas_header.codigo_bodega " +
                                    "where bodegas.existencia_articulo>0 and bodegas_header.codigo_bodega=" + clases.ClassVariables.id_busca;
                            if (logica.ExisteRegistro(cadena) == false)
                            {
                                cadena = "UPDATE ortoxela.bodegas_header SET estadoid=2 WHERE codigo_bodega=" + clases.ClassVariables.id_busca;
                                if (clases.ClassMensajes.ELIMINAR(this, cadena))
                                {
                                    groupControl1.Enabled = false;
                                    simpleaceptar.Enabled = false;
                                }
                            }
                            else
                            {
                                alertControl1.Show(this, "Cuidado", "No se puede eliminar esta bodega ya que aun tiene productos", Properties.Resources.Advertencia48);
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

        private void simplecancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
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
            
        }
        
        private void busca_mod_eli()
        {
            clases.ClassVariables.cadenabusca = "SELECT codigo_bodega as CODIGO,nombre_bodega AS BODEGA, direccion AS DIRECCION, telefono1 AS TELEFONO,descripcion AS DESCRIPCION FROM ortoxela.bodegas_header where estadoid<>2";
            Form busca = new Buscador.Buscador();
            busca.ShowDialog();
            if (clases.ClassVariables.id_busca != "")
            {
                llenacombos();
                groupControl1.Enabled = true;
                simpleaceptar.Enabled = true;
                cadena = "SELECT codigo_bodega, nombre_bodega, direccion, telefono1, telefono2, descripcion,estadoid "+
                            "FROM ortoxela.bodegas_header WHERE codigo_bodega=" + clases.ClassVariables.id_busca;
                DataTable dt = new DataTable();
                dt = logica.Tabla(cadena);
                foreach (DataRow fila in dt.Rows)
                {
                    textEditbodega.Text= fila[1].ToString();
                    memoEditdireccion.Text = fila[2].ToString();
                    texttelefono1.Text = fila[3].ToString();
                    texttelefono2.Text = fila[4].ToString();
                    memoEditdescripcion.Text= fila[5].ToString();
                    gridLookUpEstado.EditValue = fila[6].ToString();
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
            textEditbodega.Text = "";
            texttelefono2.Text = "";
            texttelefono1.Text = "";
            memoEditdescripcion.Text = "";
            memoEditdireccion.Text = "";
                    
        }
        bool llamadentroform;
        private void Bodega_Load(object sender, EventArgs e)
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

        private void simpleButtonEstado_Click(object sender, EventArgs e)
        {
            clases.ClassVariables.bandera = 1;
            clases.ClassVariables.llamadoDentroForm = true;
            Form hijo = new Estado.Estado();
            hijo.WindowState = System.Windows.Forms.FormWindowState.Normal;
            hijo.ShowDialog();
            if (clases.ClassVariables.idnuevo != null)
            {
                cadena = "SELECT estadoid as CODIGO, nombre_status as NOMBRE FROM ortoxela.estado where activo=1";
                gridLookUpEstado.Properties.DataSource = logica.Tabla(cadena);
                gridLookUpEstado.Properties.ValueMember = "CODIGO";
                gridLookUpEstado.Properties.DisplayMember = "NOMBRE";
                gridLookUpEstado.Text = "";
                gridLookUpEstado.EditValue = clases.ClassVariables.idnuevo;
            }
        }

         
    }
}