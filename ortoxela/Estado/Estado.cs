using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ortoxela.Estado
{
    public partial class Estado : DevExpress.XtraEditors.XtraForm
    {
        public Estado()
        {
            InitializeComponent();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
        private void limpiar()
        {
            textEditnombre.Text="";
           
        }

        classortoxela logica = new classortoxela();
        string cadena; 
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {            
                if (bandera == 1)
                {
                   cadena = "INSERT INTO ortoxela.estado "+
                            "(nombre_status, activo, subcat_status, cat_status) "+
                            "VALUES ('"+textEditnombre.Text+"', "+checkEditestado.Checked+", '"+textEditsubcategoria.Text+"', '"+textEditcategoria.Text+"')";
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
                    cadena = "UPDATE ortoxela.estado SET nombre_status = '" + textEditnombre.Text + "' , activo = " + checkEditestado.Checked + ",subcat_status = '"+textEditsubcategoria.Text+"', cat_status = '" + textEditcategoria.Text + "' WHERE estadoid=" + clases.ClassVariables.id_busca;
                     if (clases.ClassMensajes.MODIFICAR(this,cadena))
                     {
                         groupControl1.Enabled = false;
                         simpleaceptar.Enabled = false;
                     }
                                           

                    }
                   
            
                    else
                {
                    if (bandera == 3)
                    {
                        
                            cadena = "UPDATE ortoxela.estado SET activo = 0  WHERE estadoid=" + clases.ClassVariables.id_busca;
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

       
        private void simplecancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        int bandera; bool llamadentroform;
        private void Estado_Load(object sender, EventArgs e)
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
            clases.ClassVariables.cadenabusca = "SELECT estadoid AS CODIGO, nombre_status AS NOMBRE,cat_status AS CATEGORIA FROM ortoxela.estado where activo=1";
            Form busca = new Buscador.Buscador();
            busca.ShowDialog();
            if (clases.ClassVariables.id_busca != "")
            {
                
                groupControl1.Enabled = true;
                simpleaceptar.Enabled = true;
                cadena = "SELECT estadoid , nombre_status, activo,subcat_status,cat_status FROM ortoxela.estado where estadoid=" + clases.ClassVariables.id_busca;
                DataTable dt = new DataTable();
                dt = logica.Tabla(cadena);
                foreach (DataRow fila in dt.Rows)
                {
                    textEditnombre.Text = fila[1].ToString();
                    checkEditestado.Checked = Convert.ToBoolean(fila[2].ToString());
                    textEditsubcategoria.Text = fila[3].ToString();
                   textEditcategoria.Text = fila[4].ToString();
                }
            }
            else
            {
                groupControl1.Enabled = false;
                simpleaceptar.Enabled = false;
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
                if (bandera == 2 || bandera == 3)
                {
                    busca_mod_eli();
                }

            }
        }

        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        
    }
}