using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ortoxela.Direcciones
{
    public partial class Municipios : DevExpress.XtraEditors.XtraForm
    {
        public Municipios()
        {
            InitializeComponent();
        }
        string cadena;
        classortoxela logica = new classortoxela();
        private void simplecancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        int bandera;
        
        private void llenacombos()
        {
            cadena = "SELECT estadoid as CODIGO, nombre_status as NOMBRE FROM estado where activo=1";
            gridLookUpEditestado.Properties.DataSource = logica.Tabla(cadena);
            gridLookUpEditestado.Properties.ValueMember = "CODIGO";
            gridLookUpEditestado.Properties.DisplayMember = "NOMBRE";
            gridLookUpEditestado.Text = "";
            gridLookUpEditestado.EditValue = 1;
            cadena = "SELECT codigo_pais AS CODIGO, nombre_pais AS PAIS FROM paises WHERE estadoid<>2";
            gridLookUppais.Properties.DataSource = logica.Tabla(cadena);
            gridLookUppais.Properties.ValueMember = "CODIGO";
            gridLookUppais.Properties.DisplayMember = "PAIS";
            gridLookUppais.Text = "";
        }
        private void busca_mod_eli()
        {
            clases.ClassVariables.cadenabusca = "SELECT codigo_muni as CODIGO, nombre_muni AS MUNICIPIO,departamentos.nombre_depto AS DEPARTAMENTO, paises.nombre_pais AS PAIS " +
                                                 "FROM municipios inner join departamentos ON municipios.codigo_depto = departamentos.codigo_depto " +
                                                    "INNER JOIN paises ON departamentos.codigo_pais = paises.codigo_pais";
            Form busca = new Buscador.Buscador();
            busca.ShowDialog();
            if (clases.ClassVariables.id_busca != "")
            {
                llenacombos();
                groupControl1.Enabled = true;
                simpleaceptar.Enabled = true;
                cadena = "SELECT  municipios.codigo_muni, municipios.codigo_depto, municipios.nombre_muni, municipios.estadoid,paises.codigo_pais "+
                            "FROM municipios inner join departamentos ON municipios.codigo_depto = departamentos.codigo_depto "+
                            "inner join paises ON departamentos.codigo_pais = paises.codigo_pais "+
                            "WHERE municipios.codigo_muni=" + clases.ClassVariables.id_busca;
                DataTable dt = new DataTable();
                dt = logica.Tabla(cadena);
                foreach (DataRow fila in dt.Rows)
                {
                    gridLookUppais.EditValue = fila[4].ToString();
                    gridLookUpEditdepar.EditValue = fila[1].ToString();
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
        private void simpleaceptar_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                if (bandera == 1)
                {
                    cadena = "INSERT into municipios (codigo_depto, nombre_muni, estadoid) VALUES ("+gridLookUpEditdepar.EditValue+", '"+textEditnombre.Text+"', "+gridLookUpEditestado.EditValue+")";
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
                        cadena = "update municipios SET codigo_depto = "+gridLookUpEditdepar.EditValue+" , nombre_muni = '"+textEditnombre.EditValue+"', estadoid = "+gridLookUpEditestado.EditValue+" WHERE codigo_muni=" + clases.ClassVariables.id_busca;
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

                            cadena = "update municipios SET estadoid = 2 WHERE codigo_muni=" + clases.ClassVariables.id_busca;
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

       private void limpiar()
        {
            textEditnombre.Text = "";
            textEditnombre.Focus();
        }

       bool llamadentroform;
        private void Municipios_Load(object sender, EventArgs e)
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

        private void simpleButtonestado_Click(object sender, EventArgs e)
        {
            clases.ClassVariables.llamadoDentroForm = true;
            clases.ClassVariables.bandera = 1;
            Form hijo = new Estado.Estado();
            hijo.WindowState = System.Windows.Forms.FormWindowState.Normal;
            hijo.ShowDialog();
            if (clases.ClassVariables.idnuevo != "")
            {
                cadena = "SELECT estadoid as CODIGO, nombre_status as NOMBRE FROM estado where activo=1";
                gridLookUpEditestado.Properties.DataSource = logica.Tabla(cadena);
                gridLookUpEditestado.Properties.ValueMember = "CODIGO";
                gridLookUpEditestado.Properties.DisplayMember = "NOMBRE";
                gridLookUpEditestado.Text = "";
                gridLookUpEditestado.EditValue = clases.ClassVariables.idnuevo;
            }
        
        }

        private void simpleButtonpais_Click_1(object sender, EventArgs e)
        {
            clases.ClassVariables.llamadoDentroForm = true;
            clases.ClassVariables.bandera = 1;
            Form hijo = new Paises();
            hijo.WindowState = System.Windows.Forms.FormWindowState.Normal;
            hijo.ShowDialog();
            if (clases.ClassVariables.idnuevo != "")
            {
                cadena = "SELECT codigo_pais AS CODIGO, nombre_pais AS PAIS FROM paises WHERE estadoid<>2";
                gridLookUppais.Properties.DataSource = logica.Tabla(cadena);
                gridLookUppais.Properties.ValueMember = "CODIGO";
                gridLookUppais.Properties.DisplayMember = "PAIS";
                gridLookUppais.Text = "";
                gridLookUppais.EditValue = clases.ClassVariables.idnuevo;
            }
        
        }

        private void simpleButtondepa_Click(object sender, EventArgs e)
        {
            clases.ClassVariables.llamadoDentroForm = true;
            clases.ClassVariables.bandera = 1;
            Form hijo = new Departamentos();
            hijo.WindowState = System.Windows.Forms.FormWindowState.Normal;
            hijo.ShowDialog();
            if (clases.ClassVariables.idnuevo != "")
            {
                cadena = "SELECT codigo_depto as CODIGO, nombre_depto AS DEPARTAMENTO, paises.nombre_pais AS PAIS FROM departamentos " +
                           " inner join paises ON departamentos.codigo_pais = paises.codigo_pais " +
                            "WHERE departamentos.estadoid<>2 and  departamentos.codigo_pais=" + gridLookUppais.EditValue;

                gridLookUpEditdepar.Properties.DataSource = logica.Tabla(cadena);
                gridLookUpEditdepar.Properties.ValueMember = "CODIGO";
                gridLookUpEditdepar.Properties.DisplayMember = "DEPARTAMENTO";
                gridLookUpEditdepar.Text = "";
                gridLookUpEditdepar.EditValue = clases.ClassVariables.idnuevo;
            }
           
       
        }


        int conterror=0;
        private void gridLookUppais_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                gridLookUpEditdepar.Enabled = true;
                simpleButtondepa.Enabled = true;
                cadena = "SELECT codigo_depto as CODIGO, nombre_depto AS DEPARTAMENTO, paises.nombre_pais AS PAIS FROM departamentos " +
                        " inner join paises ON departamentos.codigo_pais = paises.codigo_pais " +
                         "WHERE departamentos.estadoid<>2 and  departamentos.codigo_pais=" + gridLookUppais.EditValue;

                gridLookUpEditdepar.Properties.DataSource = logica.Tabla(cadena);
                gridLookUpEditdepar.Properties.ValueMember = "CODIGO";
                gridLookUpEditdepar.Properties.DisplayMember = "DEPARTAMENTO";
                gridLookUpEditdepar.Text = "";
            }
            catch
            {
                conterror++;
            }
        }

        private void gridLookUpEditdepar_EditValueChanged(object sender, EventArgs e)
        {
            textEditnombre.Enabled = true;
        }

        
        
    }
}