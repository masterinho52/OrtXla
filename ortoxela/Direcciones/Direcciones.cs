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
    public partial class Direcciones : DevExpress.XtraEditors.XtraForm
    {
        public Direcciones()
        {
            InitializeComponent();
        }
        classortoxela logica = new classortoxela(); string cadena;
        int bandera;
        private void simpleaceptar_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                if (bandera == 1)
                {
                    cadena = "INSERT into direcciones (codigo_muni, Direccion1, direccion2, zona, Barrio, Colonia, estadoid) "+
                                "VALUES ("+gridLookUpEditmuni.EditValue+", '"+textEditdirec1.Text+"','"+textEditdirec2.Text+"', '"+textEditzona.Text+"', '"+textEditbarrio.Text+"', '"+textEditcolonia.Text+"', "+gridLookUpEditestado.EditValue+")";
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
                        cadena = "update direcciones SET codigo_muni = " + gridLookUpEditmuni.EditValue + "  , Direccion1 = '" + textEditdirec1.Text + "', direccion2 = '" + textEditdirec2.Text + "', zona = '" + textEditzona.Text + "', Barrio = '" + textEditbarrio.Text + "', Colonia = '" + textEditcolonia.Text + "', estadoid =" + gridLookUpEditestado.EditValue + "  " +
                                    "WHERE codigo_direccion=" + clases.ClassVariables.id_busca;
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

                            cadena = "update direcciones SET estadoid = 2 WHERE codigo_direccion=" + clases.ClassVariables.id_busca;
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

        private void simpleButton1_Click(object sender, EventArgs e)
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

        private void simpleButtonmuni_Click(object sender, EventArgs e)
        {
            clases.ClassVariables.llamadoDentroForm = true;
            clases.ClassVariables.bandera = 1;
            Form hijo = new Municipios();
            hijo.WindowState = System.Windows.Forms.FormWindowState.Normal;
            hijo.ShowDialog();
            if (clases.ClassVariables.idnuevo != "")
            {
                cadena = "SELECT codigo_muni as CODIGO, nombre_muni AS MUNICIPIO " +
                        "from  municipios " +
                        "where municipios.estadoid<>2 and municipios.codigo_depto=" + gridLookUpEditdepar.EditValue;
                
                gridLookUpEditmuni.Properties.DataSource = logica.Tabla(cadena);
                gridLookUpEditmuni.Properties.ValueMember = "CODIGO";
                gridLookUpEditmuni.Properties.DisplayMember = "MUNICIPIO";
                gridLookUpEditmuni.Text = "";
                gridLookUpEditmuni.EditValue = clases.ClassVariables.idnuevo;
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
            cadena = "SELECT codigo_pais AS CODIGO, nombre_pais AS PAIS FROM paises WHERE estadoid<>2";
            gridLookUppais.Properties.DataSource = logica.Tabla(cadena);
            gridLookUppais.Properties.ValueMember = "CODIGO";
            gridLookUppais.Properties.DisplayMember = "PAIS";
            gridLookUppais.Text = "";
            gridLookUppais.EditValue = 1;
        }
        bool llamadentroform;
        private void Direcciones_Load(object sender, EventArgs e)
        {
            llamadentroform = clases.ClassVariables.llamadoDentroForm;
            clases.ClassVariables.idnuevo = "0";
            if (clases.ClassVariables.bandera == 1)
            {
                bandera = 1;
                simpleaceptar.Text = "Aceptar";
                simpleaceptar.Image = Properties.Resources.database_add_24x24_32;
                simpleButton2.Text = "Nuevo";
                simpleButton2.Image = Properties.Resources.add_32x32_32;
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
                    simpleButton2.Text = "Buscar...";
                    simpleButton2.Image = Properties.Resources._027_folder_search;
                    busca_mod_eli();
                }
                else
                {
                    if (clases.ClassVariables.bandera == 3)
                    {
                        bandera = 3;
                        simpleaceptar.Text = "Eliminar";
                        simpleaceptar.Image = Properties.Resources.database_remove_24x24_32;
                        simpleButton2.Text = "Buscar...";
                        simpleButton2.Image = Properties.Resources._027_folder_search;
                        busca_mod_eli();
                        
                    }
                }
            }
            
        }

        private void busca_mod_eli()
        {
            clases.ClassVariables.cadenabusca = "SELECT direcciones.codigo_direccion as CODIGO,direcciones.Direccion1 AS DIRECCION,direcciones.Colonia as COLONIA,direcciones.zona as ZONA,municipios.nombre_muni AS MUNICIPIO,departamentos.nombre_depto AS DEPARTAMENTO " +
                                                              "FROM direcciones inner join municipios ON direcciones.codigo_muni = municipios.codigo_muni " +
                                                                "inner join departamentos ON municipios.codigo_depto = departamentos.codigo_depto " +
                                                                "inner join paises ON departamentos.codigo_pais = paises.codigo_pais WHERE direcciones.estadoid<>2";
            Form busca = new Buscador.Buscador();
            busca.ShowDialog();
            if (clases.ClassVariables.id_busca != "")
            {
                llenacombos();
                groupControl1.Enabled = true;
                simpleaceptar.Enabled = true;
                cadena = "SELECT direcciones.codigo_direccion, direcciones.codigo_muni, direcciones.Direccion1, direcciones.direccion2, direcciones.zona, direcciones.Barrio, direcciones.Colonia, direcciones.estadoid,departamentos.codigo_depto,paises.codigo_pais "+
                        "FROM direcciones inner join municipios ON direcciones.codigo_muni = municipios.codigo_muni "+
                        "inner join departamentos ON municipios.codigo_depto = departamentos.codigo_depto inner join paises ON departamentos.codigo_pais = paises.codigo_pais "+
                        "where direcciones.codigo_direccion=" + clases.ClassVariables.id_busca;
                DataTable dt = new DataTable();
                dt = logica.Tabla(cadena);
                foreach (DataRow fila in dt.Rows)
                {
                    gridLookUppais.EditValue = fila[9].ToString();
                    gridLookUpEditdepar.EditValue = fila[8].ToString();
                    gridLookUpEditmuni.EditValue = fila[1].ToString();
                    textEditdirec1.Text = fila[2].ToString();
                    textEditdirec2.Text = fila[3].ToString();
                    textEditzona.Text = fila[4].ToString();
                    textEditbarrio.Text = fila[5].ToString();
                    textEditcolonia.Text = fila[6].ToString();
                    gridLookUpEditestado.EditValue = fila[7].ToString();

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
            textEditbarrio.Text = "";
            textEditcolonia.Text = "";
            textEditdirec1.Text = "";
            textEditdirec2.Text = "";
            textEditzona.Text = "";
            
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
                if (bandera == 2 || bandera==3)
                {
                    busca_mod_eli();
                }
                

            }
        }

        private void gridLookUppais_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                gridLookUpEditdepar.Enabled = true;
                simpleButtondepa.Enabled = true;
                cadena = "SELECT codigo_depto as CODIGO, nombre_depto AS DEPARTAMENTO FROM departamentos " +
                        " WHERE departamentos.estadoid<>2 and  departamentos.codigo_pais=" + gridLookUppais.EditValue;

                gridLookUpEditdepar.Properties.DataSource = logica.Tabla(cadena);
                gridLookUpEditdepar.Properties.ValueMember = "CODIGO";
                gridLookUpEditdepar.Properties.DisplayMember = "DEPARTAMENTO";
                gridLookUpEditdepar.Text = "";
                gridLookUpEditdepar.EditValue = 0;
                gridLookUpEditmuni.EditValue = 0;
            }
            catch
            {
                conterror++;
            }
        
        }
        int conterror=0;
        private void simpleButtonPAIS_Click(object sender, EventArgs e)
        {
            clases.ClassVariables.llamadoDentroForm = true;
            clases.ClassVariables.bandera = 1;
            Form hijo = new Paises();
            hijo.WindowState = System.Windows.Forms.FormWindowState.Normal;
            hijo.ShowDialog();
            if (clases.ClassVariables.idnuevo != null)
            {
                cadena = "SELECT codigo_pais AS CODIGO, nombre_pais AS PAIS FROM paises WHERE estadoid<>2";
                gridLookUppais.Properties.DataSource = logica.Tabla(cadena);
                gridLookUppais.Properties.ValueMember = "CODIGO";
                gridLookUppais.Properties.DisplayMember = "PAIS";
                gridLookUppais.Text = "";
                gridLookUppais.EditValue = clases.ClassVariables.idnuevo;
            }
        }

        private void gridLookUpEditdepar_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                gridLookUpEditmuni.Enabled = true;
                simpleButtonmuni.Enabled = true;
                cadena = "SELECT codigo_muni as CODIGO, nombre_muni AS MUNICIPIO " +
                        "from  municipios " +
                        "where municipios.estadoid<>2 and municipios.codigo_depto=" + gridLookUpEditdepar.EditValue;

                gridLookUpEditmuni.Properties.DataSource = logica.Tabla(cadena);
                gridLookUpEditmuni.Properties.ValueMember = "CODIGO";
                gridLookUpEditmuni.Properties.DisplayMember = "MUNICIPIO";
                gridLookUpEditmuni.Text = "";
                gridLookUpEditmuni.EditValue = 0;
            }
            catch
            {
                conterror++;
            }
        
        }

        private void simpleButtondepa_Click(object sender, EventArgs e)
        {
            clases.ClassVariables.llamadoDentroForm = true;
            clases.ClassVariables.bandera = 1;
            Form hijo = new Departamentos();
            hijo.WindowState = System.Windows.Forms.FormWindowState.Normal;
            hijo.ShowDialog();
            if (clases.ClassVariables.idnuevo != null)
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

        private void gridLookUpEditmuni_EditValueChanged(object sender, EventArgs e)
        {
            textEditbarrio.Enabled = true;
            textEditcolonia.Enabled = true;
            textEditdirec1.Enabled = true;
            textEditdirec2.Enabled = true;
            textEditzona.Enabled = true;
            gridLookUpEditestado.Enabled = true;
        }

        
               
        }

        
    }
