using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;

using System.Drawing;
using System.Text;

using System.Collections.Generic;
using System.ComponentModel;

namespace ortoxela.Reportes.Ventas
{
    public partial class Frm_Estadistica : Form
    {
        public Frm_Estadistica()
        {
            InitializeComponent();
        }

        string ListaSeries = "";
        string ListaNombresSeries = "";
        string ListaBodegas = "";
        /* Mensaje de error al validar Fechas. */
        string datoMensajeError = "FECHA(S) INVALIDA(S)";
        /* Mensaje de error al validar Series. */
        string datoMensajeErrorSeries = "DEBE SELECCIONAR AL MENOS UNA SERIE ";

        classortoxela logicaxela = new classortoxela();

        private Boolean validarFechas()
        {
            if ((FechaInicio.DateTime.ToString("yyyy-MM-dd") == "0001-01-01") || (FechaFin.DateTime.ToString("yyyy-MM-dd") == "0001-01-01"))
            {
                clases.ClassMensajes.customessage(this, datoMensajeError);
                return false;
            }
            else
                return true;
        }

        private Boolean validarSeries()
        {
            if (this.listBoxSeries.SelectedItems.Count > 0)
            {
                return true;
            }
            else
            {
                clases.ClassMensajes.customessage(this, datoMensajeErrorSeries);
                return false;
            }
        }

        private void Frm_Estadistica_Load(object sender, EventArgs e)
        {
            this.Text = "Reportes de Ventas - " + clases.ClassVariables.nombreEmpresa;

            /* BODEGAS */
            try
            {
                string ssql;

                /* jramirez 2013.07.24 */
                ssql = "SELECT distinct codigo_bodega, nombre_bodega FROM v_bodegas_series_usuarios  WHERE estadoid_bodega<>2 AND userid=" + clases.ClassVariables.id_usuario;

                listBoxBodegas.DataSource = logicaxela.Tabla(ssql);
                listBoxBodegas.DisplayMember = "nombre_bodega";
                listBoxBodegas.ValueMember = "codigo_bodega";

            }
            catch
            { }
            /* FECHAS */
            try
            {

                /* jramirez 2014.01.20 */

                DateTime now = DateTime.Now;

                string date = now.GetDateTimeFormats('d')[0];
                this.FechaFin.EditValue = date;

                DateTime now2 = DateTime.Now.AddMonths(-6);

                string date2 = now2.ToShortDateString();
                this.FechaInicio.EditValue = date2;

            }
            catch
            { }
        }

        private void Reporte()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (this.validarFechas())
            {
                if (validarSeries())
                {
                    string consulta;
                    ListaSeries = "0";
                    ListaNombresSeries = "";
                    for (int cnt = 0; cnt < listBoxSeries.SelectedItems.Count; cnt++)
                    {
                        DataRowView srs = listBoxSeries.SelectedItems[cnt] as DataRowView;
                        ListaSeries += "," + srs["codigo_serie"].ToString();
                        ListaNombresSeries += srs["documento"].ToString() + " ,";
                    }

                    if (ListaSeries == "0")
                        ListaSeries = "";

                    string documentos = " AND (e.cat_status = 'Documentos') AND (e.subcat_status = 'Activo') ";
                    string documentos2 = " AND (e.cat_status = ''','Documentos',''') AND (e.subcat_status = ''','Activo',''') ";
                    string consultaFinal = " SELECT * FROM v_estadistica; ";

                    string consulta_base = " FROM header_doctos_inv h JOIN detalle_doctos_inv d  ON (h.id_documento = d.id_documento) JOIN clientes c " +
                    " ON (h.codigo_cliente = c.codigo_cliente)  LEFT JOIN clientes c2 ON (h.socio_comercial = c2.codigo_cliente) JOIN articulos a " +
                    " ON (d.codigo_articulo = a.codigo_articulo) JOIN sub_categorias sc ON (a.codigo_categoria = sc.codigo_subcat) JOIN bodegas_header b " +
                    " ON (d.codigo_bodega = b.codigo_bodega) JOIN v_tipos_documentos t ON (h.codigo_serie = t.codigo_serie) JOIN estado e ON (h.estadoid = e.estadoid) " +
                    " WHERE (t.codigo_tipo = 1)  " ; 

                   

                    string consulta_fecha = " AND h.fecha BETWEEN '" +  FechaInicio.DateTime.ToString("yyyy-MM-dd") + " 00:00:00' AND '" + FechaFin.DateTime.ToString("yyyy-MM-dd") + " 23:59:59' ";
                    string consulta_fecha2 = " AND h.fecha BETWEEN ''','" + FechaInicio.DateTime.ToString("yyyy-MM-dd") + " 00:00:00',''' AND ''','" + FechaFin.DateTime.ToString("yyyy-MM-dd") + " 23:59:59',''' ";

                    consulta = "USE ortoxela; DROP VIEW IF EXISTS v_estadistica;" +
                    " SET SESSION group_concat_max_len = 1000000; SELECT  GROUP_CONCAT( distinct CONCAT( " +
                    "  'sum(if (sc.codigo_subcat = ''',sc.codigo_subcat,''',d.cantidad_enviada * (d.precio_unitario / 1.12),0))',REPLACE(REPLACE(REPLACE(REPLACE(sc.nombre_subcategoria, ' ', '_'),'.','_'),'[',''),']','') )  ) INTO @sql " +
                   consulta_base + documentos + consulta_fecha + ";";

                    consulta = consulta + " SET @sql= CONCAT(' create view v_estadistica as select c2.nombre_cliente AS Socio_Comercial, MONTH(h.fecha) AS mes, YEAR(h.fecha) AS año, " +
                     " SUM((d.cantidad_enviada * (d.precio_unitario / 1.12))) AS Total_Venta, ', @sql, ' " + consulta_base + documentos2 + consulta_fecha2 +
                     " GROUP BY h.socio_comercial;'); ";

                    consulta = consulta + " PREPARE stmt FROM @sql; EXECUTE stmt;   SELECT * FROM v_estadistica;";
                    //if (logicaxela.variosservios(consulta) != 1)
                    //{
                    //    MessageBox.Show("Por favor intente nuevamente.", "Alerta");
                    //}
                   

                    DataTable DTEstadistica = new DataTable();
                    DTEstadistica = logicaxela.Tabla(consulta);

                    //MySqlDataAdapter adaptador1 = new MySqlDataAdapter(consulta, Properties.Settings.Default.ortoxelaConnectionString);
                    //DataSet dataset1 = new DataSet();
                    //adaptador1.Fill(dataset1);
                    
                    //foreach (DataRow fila in DTEstadistica.Rows)
                    //{
                    //    gcEstadistica.DataSource = 
 
                    //}

                    gcEstadistica.DataSource = DTEstadistica;
                    gcEstadistica.Refresh();
                }
            }


            Cursor.Current = Cursors.Default;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Reporte();
        }

        private void listBoxBodegas_MouseUp(object sender, MouseEventArgs e)
        {
            ListaBodegas = "0";
            if (listBoxBodegas.SelectedItems.Count > 0)
            {

                for (int cnt = 0; cnt < listBoxBodegas.SelectedItems.Count; cnt++)
                {
                    DataRowView bdgs = listBoxBodegas.SelectedItems[cnt] as DataRowView;
                    ListaBodegas += "," + bdgs["codigo_bodega"].ToString();

                }
            }
            string ssql = " SELECT distinct codigo_serie,CONCAT(nombre_documento,'[',serie_documento,']',' Bod: ',nombre_bodega) AS documento FROM v_bodegas_series_usuarios b " +
                        " WHERE codigo_tipo=1 AND codigo_bodega IN (" + ListaBodegas + " )";
            this.listBoxSeries.DataSource = logicaxela.Tabla(ssql);
            this.listBoxSeries.DisplayMember = "documento";
            this.listBoxSeries.ValueMember = "codigo_serie";
        }

      

    }
}
