using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CrystalDecisions.Shared;

namespace ortoxela.Pedido.Factura
{
    public partial class F_impresion : Form
    {
        public F_impresion()
        {
            InitializeComponent();
        }

        private void F_impresion_Load(object sender, EventArgs e)
        {

        }

        public void facturaA(int header, string totalenletras_, string cadenapiedepagina_, string contado_, string credito_, string tip_)
        {
            //aca hayamos el nombre de usuario del vendedor, por medio del id del encabezado, que ya fue almacenado en la base de datos, en la tabla de encabezado
            string ve = "";
            DataSetFacturaTableAdapters.encontrarvendedorTableAdapter ec = new DataSetFacturaTableAdapters.encontrarvendedorTableAdapter();
            ve = ec.GetData_encontrarvendedor(header).Rows[0][0].ToString();

            DataTable res = new DataTable();
            DataSetFacturaTableAdapters.NFacturaTableAdapter lg = new DataSetFacturaTableAdapters.NFacturaTableAdapter();
            R_NFactura reporte = new R_NFactura();
            res = lg.GetData_NFactura(header);
            
            reporte.SetDataSource(res);
            crystalReportViewer_impresion.ReportSource = reporte;

            //para mandarle valores al crystal en un campo en especifico
                //total en letras
                reporte.SetParameterValue("totalenletras", totalenletras_);

                //cadena completa de no se q cosas q dice hasta abajo
                reporte.SetParameterValue("cadenapiedepagina", cadenapiedepagina_);

                //CREDITO O CONTADO
                reporte.SetParameterValue("contado", contado_);
                reporte.SetParameterValue("credito", credito_);

            //vendedor
                reporte.SetParameterValue("vendedor", ve);

            //tipo de factura
                reporte.SetParameterValue("tipodocumento", tip_);
            //

                
            
            
        }

        public void facturaD(int header,string totalenletras_,string contado_,string credito_)
        {
            //aca hayamos el nombre de usuario del vendedor, por medio del id del encabezado, que ya fue almacenado en la base de datos, en la tabla de encabezado
            string ve = "";
            DataSetFacturaTableAdapters.encontrarvendedorTableAdapter ec = new DataSetFacturaTableAdapters.encontrarvendedorTableAdapter();
            ve = ec.GetData_encontrarvendedor(header).Rows[0][0].ToString();

            DataTable res = new DataTable();
            DataSetFacturaTableAdapters.NFacturaTableAdapter lg = new DataSetFacturaTableAdapters.NFacturaTableAdapter();
            R_NFacturaD reporte = new R_NFacturaD();
            res = lg.GetData_NFactura(header);

            reporte.SetDataSource(res);
            crystalReportViewer_impresion.ReportSource = reporte;

            //para mandarle valores al crystal en un campo en especifico
            //total en letras
            reporte.SetParameterValue("totalenletras", totalenletras_);


            //CREDITO O CONTADO
            reporte.SetParameterValue("contado", contado_);
            reporte.SetParameterValue("credito", credito_);

            //vendedor
            reporte.SetParameterValue("vendedor", ve);
            //

                
            
            
        }

        public void facturaOtroTipo(int header, string totalenletras_, string cadenapiedepagina_, string contado_, string credito_, int tip_)
        {
            DataSetFacturaTableAdapters.series_documentosTableAdapter lg1 = new DataSetFacturaTableAdapters.series_documentosTableAdapter();
            string ti = lg1.GetData_obtenernombredeserie(tip_).Rows[0][0].ToString();

            string ve = "";
            DataSetFacturaTableAdapters.encontrarvendedorTableAdapter ec = new DataSetFacturaTableAdapters.encontrarvendedorTableAdapter();
            ve = ec.GetData_encontrarvendedor(header).Rows[0][0].ToString();

            DataTable res = new DataTable();
            DataSetFacturaTableAdapters.NFacturaTableAdapter lg = new DataSetFacturaTableAdapters.NFacturaTableAdapter();
            R_NFactura reporte = new R_NFactura();
            res = lg.GetData_NFactura(header);

            reporte.SetDataSource(res);
            crystalReportViewer_impresion.ReportSource = reporte;

            //para mandarle valores al crystal en un campo en especifico
            //total en letras
            reporte.SetParameterValue("totalenletras", totalenletras_);

            //cadena completa de no se q cosas q dice hasta abajo
            reporte.SetParameterValue("cadenapiedepagina", cadenapiedepagina_);

            //CREDITO O CONTADO
            reporte.SetParameterValue("contado", contado_);
            reporte.SetParameterValue("credito", credito_);

            //vendedor
            reporte.SetParameterValue("vendedor", ve);

            //tipo de factura
            reporte.SetParameterValue("tipodocumento", ti);
            //

        }
    }
}
