using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraBars.Alerter;
using System.Windows.Forms;
namespace ortoxela.clases
{
    class ClassMensajes
    {
        
        public static bool INSERTO(Form ventana,string cadena)
        {
            AlertControl ControlAlerta = new AlertControl();
            classortoxela TodoLogica = new classortoxela();
            if (TodoLogica.variosservios(cadena) == 1)
            {
                ControlAlerta.Show(ventana, "EXITO!", "SE ALMACENO CORRECTAMENTE EN EL SISTEMA", Properties.Resources.OK72);
                return true;
            }
            else
            {
                ControlAlerta.Show(ventana, "ERROR!", "NO SE ALMACENARON LOS DATOS EN EL SISTEMA", Properties.Resources.error_64);
                return false;
            }
        }
        public static bool INSERTO(Form ventana)
        {
            AlertControl ControlAlerta = new AlertControl();
            ControlAlerta.Show(ventana, "EXITO!", "SE ALMACENO CORRECTAMENTE EN EL SISTEMA", Properties.Resources.OK72);
                return true;          
        }
        public static bool NoINSERTO(Form ventana)
        {
            AlertControl ControlAlerta = new AlertControl();
            ControlAlerta.Show(ventana, "ERROR!", "NO SE ALMACENARON LOS DATOS EN EL SISTEMA", Properties.Resources.error_64);
            return false;
        }
        public static bool MODIFICAR(Form ventana, string cadena)
        {
            AlertControl ControlAlerta = new AlertControl();
            classortoxela TodoLogica = new classortoxela();
            if (TodoLogica.variosservios(cadena) == 1)
            {
                ControlAlerta.Show(ventana, "EXITO!", "LOS DATOS SE ACTUALIZARON CORRECTAMENTE EN EL SISTEMA", Properties.Resources.OK72);
                return true;
            }
            else
            {
                ControlAlerta.Show(ventana, "ERROR!", "NO SE ACTUALIZARON LOS DATOS EN EL SISTEMA", Properties.Resources.error_64);
                return false;
            }
        }
        public static bool ELIMINAR(Form ventana, string cadena)
        {
            AlertControl ControlAlerta = new AlertControl();
            classortoxela TodoLogica = new classortoxela();
            if (TodoLogica.variosservios(cadena) == 1)
            {
                ControlAlerta.Show(ventana, "EXITO!", "LOS DATOS SE ELIMINARON CORRECTAMENTE DEL SISTEMA", Properties.Resources.OK72);
                return true;
            }
            else
            {
                ControlAlerta.Show(ventana, "ERROR!", "NO SE ELIMINARON LOS DATOS DEL SISTEMA", Properties.Resources.error_64);
                return false;
            }
        }
        public static void FaltanDatosEnCampos(Form ventana)
        {
                AlertControl ControlAlerta = new AlertControl();                        
                ControlAlerta.Show(ventana, "INFORMACION", "FALTAN DATOS NECESARIOS EN LOS CAMPOS", Properties.Resources.Advertencia64);
         
        }
        public static void FaltanDatosEnCamposNombre(Form ventana,string campo)
        {
            AlertControl ControlAlerta = new AlertControl();
            ControlAlerta.Show(ventana, "INFORMACION", "FALTAN DATOS NECESARIOS EN EL(LOS) CAMPO(S) :"+campo, Properties.Resources.Advertencia64);

        }
        public static void NoHayExistenciaProd(Form ventana)
        {
            AlertControl ControlAlerta = new AlertControl();
            ControlAlerta.Show(ventana, "INFORMACION", "NO HAY PRODUCTO EN EXISTENCIA, VERIFIQUE POR FAVOR", Properties.Resources.Advertencia64);

        }
        public static void ProdYaExisteEnListado(Form ventana)
        {
            AlertControl ControlAlerta = new AlertControl();
            ControlAlerta.Show(ventana, "INFORMACION", "PRODUCTO EXISTE EN EL LISTADO, VERIFIQUE POR FAVOR", Properties.Resources.Advertencia64);

        }

        public static void NoHayInformacionCriterio(Form ventana)
        {
            AlertControl ControlAlerta = new AlertControl();
            ControlAlerta.Show(ventana, "INFORMACION", "NO EXISTE INFORMACION CON ESTE CRITERIO", Properties.Resources.Advertencia64);

        }

        public static void customessage(Form ventana,string mensaje)
        {
            AlertControl ControlAlerta = new AlertControl();
            ControlAlerta.Show(ventana, "INFORMACION", mensaje, Properties.Resources.Advertencia64);

        }

    }
}
