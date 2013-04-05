using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ortoxela.ModCobranza.TipoDocs
{
    public partial class TipoDoc : DevExpress.XtraEditors.XtraForm
    {
        public TipoDoc()
        {
            InitializeComponent();
        }

        private void limpiar()
        {
            memoEditcomentario.Text = "";
            textEditnombre.Text = "";
            textEditnombre.Focus();
        }

        classortoxela logica = new classortoxela();
        string cadena;
        
        int bandera;
            

              
        private void busca_mod_eli()
        {
            clases.ClassVariables.cadenabusca = "SELECT codigo_tipo as CODIGO, nombre_documento AS NOMBRE FROM ortoxela.tipos_documento where documento_cobro=1";
            Form busca = new Buscador.Buscador();
            busca.ShowDialog();
            if (clases.ClassVariables.id_busca != "")
            {
                llenacombos();
                groupControl1.Enabled = true;
                simpleaceptar.Enabled = true;
                cadena = "SELECT codigo_tipo, nombre_documento,signo, actualiza_precios, comentario_docto, estado_id "+
                            "FROM ortoxela.tipos_documento where codigo_tipo=" + clases.ClassVariables.id_busca;
                DataTable dt = new DataTable();
                dt = logica.Tabla(cadena);
                foreach (DataRow fila in dt.Rows)
                {
                    textEditnombre.Text = fila[1].ToString();
                    gridLookmovimiento.EditValue = fila[2].ToString();
                    if (Convert.ToBoolean(fila[3].ToString()) == true)
                        radioGroupactuprecios.SelectedIndex = 1;
                    else
                        radioGroupactuprecios.SelectedIndex = 0;
                   
                    memoEditcomentario.Text = fila[4].ToString();
                    gridLookUpEstado.EditValue = fila[5].ToString();

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
            DataTable temporal = new DataTable();
            temporal.Columns.Add("CODIGO");
            temporal.Columns.Add("MOVIMIENTO");
            temporal.Rows.Add("0","Sin Movimientos");
            temporal.Rows.Add("1", "Ingreso");
            temporal.Rows.Add("2", "Salida");
            gridLookmovimiento.Properties.DataSource = temporal;
            gridLookmovimiento.Properties.DisplayMember = "MOVIMIENTO";
            gridLookmovimiento.Properties.ValueMember = "CODIGO";
            gridLookmovimiento.Text = "";
            gridLookmovimiento.EditValue = 0;
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

        private void simpleaceptar_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                if (bandera == 1)
                {
                    cadena = "INSERT INTO ortoxela.tipos_documento (nombre_documento, fecha_creacion, usuario_creacion, signo, actualiza_precios, comentario_docto, estado_id,documento_cobro)  " +
                            "VALUES ('" + textEditnombre.Text + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', " + clases.ClassVariables.id_usuario + "," + gridLookmovimiento.EditValue + "," + radioGroupactuprecios.SelectedIndex + ",'" + memoEditcomentario.Text + "'," + gridLookUpEstado.EditValue + ",1)";
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
                        cadena = "UPDATE ortoxela.tipos_documento SET nombre_documento = '" + textEditnombre.Text + "' , signo = " + gridLookmovimiento.EditValue + ", actualiza_precios = " + radioGroupactuprecios.SelectedIndex + ", comentario_docto = '" + memoEditcomentario.Text + "', estado_id = " + gridLookUpEstado.EditValue + " " +
                                "WHERE tipos_documento.codigo_tipo=" + clases.ClassVariables.id_busca;
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
                            cadena = "UPDATE ortoxela.tipos_documento SET estado_id = 2 " +
                                    "WHERE tipos_documento.codigo_tipo=" + clases.ClassVariables.id_busca;
                            if (clases.ClassMensajes.MODIFICAR(this, cadena))
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
                    limpiar();
                    busca_mod_eli();

                }


            }
        
        }

        private void gridLookUpEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            clases.ClassVariables.llamadoDentroForm = true;
            clases.ClassVariables.bandera = 1;
            Form hijo = new Estado.Estado();
            hijo.WindowState = System.Windows.Forms.FormWindowState.Normal;
            hijo.ShowDialog();
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
        }
    }
