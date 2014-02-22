using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace ortoxela.Permisos
{
    public partial class Permisos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Permisos()
        {
            InitializeComponent();
        }

        BarButtonItem botoningresa;
        string cadena;
        classortoxela logica = new classortoxela();

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (object boton in ribbon.Items)
                {
                    if (boton is BarButtonItem)
                    {
                        botoningresa = (BarButtonItem)boton;
                        cadena = "INSERT into permisos (nombre_permiso)VALUES ('" + botoningresa.Name + "')";
                        logica.variosservios(cadena);                     


                    }
                }
                clases.ClassMensajes.INSERTO(this);
            }
            catch
            { 
                clases.ClassMensajes.NoINSERTO(this);
            }
        }

        Dictionary<string, string> dicboton = new Dictionary<string, string>();
        private void controlboton(object sender, ItemClickEventArgs e)
        {
            if (dicboton.ContainsValue(e.Item.Name)==false)
            {
                dicboton.Add(e.Item.Name, e.Item.Name);
            }
            else
            {
                dicboton.Remove(e.Item.Name);
            }
                    
        }

        private void Permisos_Load(object sender, EventArgs e)
        {
            barStaticItem1.Caption = "Usted esta en el sistema como " + clases.ClassVariables.NombreComple;
            cadena = "SELECT codigo_rol as CODIGO,nombre_rol AS NOMBRE FROM roles where estadoid<>2";
            gridControl1.DataSource = logica.Tabla(cadena);
        }

        string codigo;
        string nombre;
        DataTable dt = new DataTable();

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            ListBox lista = new ListBox();
            foreach (string fila in dicboton.Values)
            {
                lista.Items.Add(fila);
            }

            for (int x = 0; x < lista.Items.Count;x++)
            {
                foreach (object boton in ribbon.Items)
                {
                    if (boton is BarButtonItem)
                    {
                        botoningresa = (BarButtonItem)boton;
                        if (botoningresa.Name.ToString() == lista.Items[x].ToString())
                        {
                            botoningresa.PerformClick();
                        }
                    }
                }
            }
            
            codigo = gridView1.GetFocusedRowCellValue("CODIGO").ToString();
            nombre = gridView1.GetFocusedRowCellValue("NOMBRE").ToString();
            labelControl3.Text = nombre;
            ribbon.Enabled = true;
            cadena = "SELECT roles_permisos.codigo_rol,  permisos.nombre_permiso "+
                        "FROM roles_permisos inner join permisos ON roles_permisos.permisoid = permisos.permisoid "+
                        "where roles_permisos.codigo_rol="+codigo;
            dt=logica.Tabla(cadena);
            foreach (DataRow fila in dt.Rows)
            {
                foreach (object boton in ribbon.Items)
                {
                    if (boton is BarButtonItem)
                    { 
                        botoningresa=(BarButtonItem)boton;
                        if (botoningresa.Name == fila[1].ToString())
                        {
                            if (dicboton.ContainsValue(fila[1].ToString()) == false)
                            {
                                 botoningresa.PerformClick();
                            }
                        }
                    }
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {            
            try
            {
                cadena = "DELETE FROM roles_permisos WHERE codigo_rol="+codigo;
                logica.variosservios(cadena);
                foreach (string permiso in dicboton.Values)
                {
                    cadena = "INSERT into roles_permisos (usuario_creador, codigo_rol, permisoid) " +
                                "VALUES (" + clases.ClassVariables.id_usuario + ", " + codigo + ", (SELECT permisoid FROM permisos where nombre_permiso='" + permiso + "'))";
                    logica.variosservios(cadena);
                }
                clases.ClassMensajes.INSERTO(this);
            }
            catch
            {
                clases.ClassMensajes.NoINSERTO(this);
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

       

       

              
    }
}
