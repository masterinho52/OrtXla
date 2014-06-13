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


        public void facturaA(int header, string totalenletras_, string contado_, string credito_, int tip_, string so)
        {
            DataSetFacturaTableAdapters.series_documentosTableAdapter lg1 = new DataSetFacturaTableAdapters.series_documentosTableAdapter();
            string ti = lg1.GetData_obtenernombredeserie(tip_).Rows[0][0].ToString();

            string ve = "";
            DataSetFacturaTableAdapters.encontrarvendedorTableAdapter ve1 = new DataSetFacturaTableAdapters.encontrarvendedorTableAdapter();
            if(ve1.GetData_encontrarvendedor(header).Count>0)
            ve = ve1.GetData_encontrarvendedor(header).Rows[0][0].ToString();

            string creador = "";
            DataSetFacturaTableAdapters.encontrarcreadorTableAdapter creador1 = new DataSetFacturaTableAdapters.encontrarcreadorTableAdapter();
            if (creador1.GetData_encontrarcreador(header).Count > 0)
                creador = creador1.GetData_encontrarcreador(header).Rows[0][0].ToString();

            string nombre_paci="";
            string afiliacion_paci="";
            DataSetFacturaTableAdapters.pacienteTableAdapter pa1 = new DataSetFacturaTableAdapters.pacienteTableAdapter();
            if (pa1.GetData_datospaciente(header).Count > 0)
            {
                nombre_paci = pa1.GetData_datospaciente(header).Rows[0][0].ToString();
                afiliacion_paci = pa1.GetData_datospaciente(header).Rows[0][1].ToString();
            }


            //string so = "";
            //DataSetFacturaTableAdapters.encontrarsociocomercialTableAdapter so1 = new DataSetFacturaTableAdapters.encontrarsociocomercialTableAdapter();
            //so = so1.GetData_encontrarsociocomercial(header).Rows[0][0].ToString();

            DataTable res = new DataTable();
            DataSetFacturaTableAdapters.NFacturaTableAdapter lg = new DataSetFacturaTableAdapters.NFacturaTableAdapter();
            R_NFacturaA reporte = new R_NFacturaA();
            res = lg.GetData_NFactura(header);

            reporte.SetDataSource(res);
            crystalReportViewer_impresion.ReportSource = reporte;

            //para mandarle valores al crystal en un campo en especifico
            //total en letras
            reporte.SetParameterValue("totalenletras", totalenletras_);

            //socio comercial
            reporte.SetParameterValue("sociocomercial", so);

            //CREDITO O CONTADO
            reporte.SetParameterValue("contado", contado_);
            reporte.SetParameterValue("credito", credito_);

            //vendedor
            reporte.SetParameterValue("vendedor", ve);

            //tipo de factura
            reporte.SetParameterValue("tipodocumento", ti);

            //nombre del paciente y su numero de afiliacion
            reporte.SetParameterValue("nombrepaciente", nombre_paci);
            reporte.SetParameterValue("afiliacionpaciente", afiliacion_paci);


            //usuario creador
            reporte.SetParameterValue("usuariocreador", creador);
            //

        }

        public void facturaB(int header, string totalenletras_, string contado_, string credito_, int tip_, string so)
        {
            DataSetFacturaTableAdapters.series_documentosTableAdapter lg1 = new DataSetFacturaTableAdapters.series_documentosTableAdapter();
            string ti = lg1.GetData_obtenernombredeserie(tip_).Rows[0][0].ToString();

            string ve = "";
            DataSetFacturaTableAdapters.encontrarvendedorTableAdapter ve1 = new DataSetFacturaTableAdapters.encontrarvendedorTableAdapter();
            if (ve1.GetData_encontrarvendedor(header).Count > 0)
            ve = ve1.GetData_encontrarvendedor(header).Rows[0][0].ToString();

            string creador = "";
            DataSetFacturaTableAdapters.encontrarcreadorTableAdapter creado1 = new DataSetFacturaTableAdapters.encontrarcreadorTableAdapter();
            if (creado1.GetData_encontrarcreador(header).Count > 0)
                creador = creado1.GetData_encontrarcreador(header).Rows[0][0].ToString();

            //string so = "";
            //DataSetFacturaTableAdapters.encontrarsociocomercialTableAdapter so1 = new DataSetFacturaTableAdapters.encontrarsociocomercialTableAdapter();
            //so = so1.GetData_encontrarsociocomercial(header).Rows[0][0].ToString();

            DataTable res = new DataTable();
            DataSetFacturaTableAdapters.NFacturaTableAdapter lg = new DataSetFacturaTableAdapters.NFacturaTableAdapter();
            R_NFacturaB reporte = new R_NFacturaB();
            res = lg.GetData_NFactura(header);

            reporte.SetDataSource(res);
            crystalReportViewer_impresion.ReportSource = reporte;

            //para mandarle valores al crystal en un campo en especifico
            //total en letras
            reporte.SetParameterValue("totalenletras", totalenletras_);

            //socio comercial
            reporte.SetParameterValue("sociocomercial", so);

            //CREDITO O CONTADO
            reporte.SetParameterValue("contado", contado_);
            reporte.SetParameterValue("credito", credito_);

            //vendedor
            reporte.SetParameterValue("vendedor", ve);

            //tipo de factura
            reporte.SetParameterValue("tipodocumento", ti);

            //usuario creador
            reporte.SetParameterValue("usuariocreador", creador);
            //

        }

        public void facturaC(int header, string totalenletras_, string contado_, string credito_, int tip_, string so)
        {
            DataSetFacturaTableAdapters.series_documentosTableAdapter lg1 = new DataSetFacturaTableAdapters.series_documentosTableAdapter();
            string ti = lg1.GetData_obtenernombredeserie(tip_).Rows[0][0].ToString();

            string ve = "";
            DataSetFacturaTableAdapters.encontrarvendedorTableAdapter ve1 = new DataSetFacturaTableAdapters.encontrarvendedorTableAdapter();
            if (ve1.GetData_encontrarvendedor(header).Count > 0)
            ve = ve1.GetData_encontrarvendedor(header).Rows[0][0].ToString();

            string creador = "";
            DataSetFacturaTableAdapters.encontrarcreadorTableAdapter creado1 = new DataSetFacturaTableAdapters.encontrarcreadorTableAdapter();
            if (creado1.GetData_encontrarcreador(header).Count > 0)
                creador = creado1.GetData_encontrarcreador(header).Rows[0][0].ToString();

            DataTable res = new DataTable();
            DataSetFacturaTableAdapters.NFacturaTableAdapter lg = new DataSetFacturaTableAdapters.NFacturaTableAdapter();
            R_NFacturaC reporte = new R_NFacturaC();
            res = lg.GetData_NFactura(header);

            reporte.SetDataSource(res);
            crystalReportViewer_impresion.ReportSource = reporte;

            //para mandarle valores al crystal en un campo en especifico
            //total en letras
            reporte.SetParameterValue("totalenletras", totalenletras_);

            //socio comercial
            reporte.SetParameterValue("sociocomercial", so);

            //CREDITO O CONTADO
            reporte.SetParameterValue("contado", contado_);
            reporte.SetParameterValue("credito", credito_);

            //vendedor
            reporte.SetParameterValue("vendedor", ve);

            //tipo de factura
            reporte.SetParameterValue("tipodocumento", ti);

            //usuario creador
            reporte.SetParameterValue("usuariocreador", creador);
            //

        }

        public void facturaD(int header, string totalenletras_, string contado_, string credito_, int tip_, string so)
        {
            DataSetFacturaTableAdapters.series_documentosTableAdapter lg1 = new DataSetFacturaTableAdapters.series_documentosTableAdapter();
            string ti = lg1.GetData_obtenernombredeserie(tip_).Rows[0][0].ToString();

            string ve = "";
            DataSetFacturaTableAdapters.encontrarvendedorTableAdapter ve1 = new DataSetFacturaTableAdapters.encontrarvendedorTableAdapter();
            if (ve1.GetData_encontrarvendedor(header).Count > 0)
            ve = ve1.GetData_encontrarvendedor(header).Rows[0][0].ToString();

            string creador = "";
            DataSetFacturaTableAdapters.encontrarcreadorTableAdapter creado1 = new DataSetFacturaTableAdapters.encontrarcreadorTableAdapter();
            if (creado1.GetData_encontrarcreador(header).Count > 0)
                creador = creado1.GetData_encontrarcreador(header).Rows[0][0].ToString();

            DataTable res = new DataTable();
            DataSetFacturaTableAdapters.NFacturaTableAdapter lg = new DataSetFacturaTableAdapters.NFacturaTableAdapter();
            R_NFacturaD reporte = new R_NFacturaD();
            res = lg.GetData_NFactura(header);

            reporte.SetDataSource(res);
            crystalReportViewer_impresion.ReportSource = reporte;

            //para mandarle valores al crystal en un campo en especifico
            //total en letras
            reporte.SetParameterValue("totalenletras", totalenletras_);

            //socio comercial
            reporte.SetParameterValue("sociocomercial", so);

            //CREDITO O CONTADO
            reporte.SetParameterValue("contado", contado_);
            reporte.SetParameterValue("credito", credito_);

            //vendedor
            reporte.SetParameterValue("vendedor", ve);

            //tipo de factura
            reporte.SetParameterValue("tipodocumento", ti);

            //usuario creador
            reporte.SetParameterValue("usuariocreador", creador);
            //

        }

        public void facturaE(int header, string totalenletras_, string contado_, string credito_, int tip_, string so)
        {
            DataSetFacturaTableAdapters.series_documentosTableAdapter lg1 = new DataSetFacturaTableAdapters.series_documentosTableAdapter();
            string ti = lg1.GetData_obtenernombredeserie(tip_).Rows[0][0].ToString();

            string ve = "";
            DataSetFacturaTableAdapters.encontrarvendedorTableAdapter ve1 = new DataSetFacturaTableAdapters.encontrarvendedorTableAdapter();
            if (ve1.GetData_encontrarvendedor(header).Count > 0)
            ve = ve1.GetData_encontrarvendedor(header).Rows[0][0].ToString();

            string creador = "";
            DataSetFacturaTableAdapters.encontrarcreadorTableAdapter creado1 = new DataSetFacturaTableAdapters.encontrarcreadorTableAdapter();
            if (creado1.GetData_encontrarcreador(header).Count > 0)
                creador = creado1.GetData_encontrarcreador(header).Rows[0][0].ToString();

            DataTable res = new DataTable();
            DataSetFacturaTableAdapters.NFacturaTableAdapter lg = new DataSetFacturaTableAdapters.NFacturaTableAdapter();
            R_NFacturaE reporte = new R_NFacturaE();
            res = lg.GetData_NFactura(header);

            reporte.SetDataSource(res);
            crystalReportViewer_impresion.ReportSource = reporte;

            //para mandarle valores al crystal en un campo en especifico
            //total en letras
            reporte.SetParameterValue("totalenletras", totalenletras_);

            //socio comercial
            reporte.SetParameterValue("sociocomercial", so);

            //CREDITO O CONTADO
            reporte.SetParameterValue("contado", contado_);
            reporte.SetParameterValue("credito", credito_);

            //vendedor
            reporte.SetParameterValue("vendedor", ve);

            //tipo de factura
            reporte.SetParameterValue("tipodocumento", ti);

            //usuario creador
            reporte.SetParameterValue("usuariocreador", creador);
            //

        }
    }
}
