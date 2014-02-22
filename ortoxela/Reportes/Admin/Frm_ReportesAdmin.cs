using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;

namespace ortoxela.Reportes.Admin
{
    public partial class Frm_ReportesAdmin : Form
    {
        public Frm_ReportesAdmin()
        {
            InitializeComponent();
            
        }

        private void labelControl25_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            Reportes.Inventario.XtraReport_InventarioResumen reporte = new Reportes.Inventario.XtraReport_InventarioResumen();
            reporte.Parameters["Fecha_inicio"].Value = dateEdit6.EditValue;
            reporte.Parameters["Fecha_fin"].Value = dateEdit5.EditValue;
            reporte.Parameters["nombreEmpresa"].Value = clases.ClassVariables.nombreEmpresa; 
            reporte.RequestParameters = false;
            reporte.ShowPreview();

            this.Cursor = Cursors.Default;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Int32 bodega1 = 0;
            Int32 bodega2 = 100;
            string botittle = "Todas";
            string consulta = "SELECT codigo_articulo, articulo, Ult_compra, Ult_venta, Ult_precio, nombre_bodega, categoria, codigo_categoria, existencia_articulo, codigo_bodega  " +
                               " FROM v_inventario where 1=1 ";
            if (bodegas.SelectedValue.ToString() != "0")
            {
                consulta = "SELECT `a`.`codigo_articulo` AS `codigo_articulo`,REPLACE(a.descripcion,'\"','') AS articulo,SUM(COALESCE(`b`.`existencia_articulo`,0)) AS `existencia_articulo`, " +
                " DATE_FORMAT((SELECT f_ultima_compra(b.codigo_articulo) FROM DUAL),'%d-%m-%Y') AS Ult_compra, " +
                " DATE_FORMAT((SELECT f_ultima_venta(b.codigo_articulo) FROM DUAL),'%d-%m-%Y') AS Ult_venta, " +
                " (`a`.`costo` / 1.12) AS `Ult_precio`, " +
                    // " (SUM(COALESCE(`b`.`existencia_articulo`,0))*(`a`.`costo` / 1.12)) AS costo_total, "
                " `bh`.`codigo_bodega` AS `codigo_bodega`,`bh`.`nombre_bodega` AS `nombre_bodega`,`a`.`codigo_categoria` AS `codigo_categoria`,`s`.`nombre_subcategoria` AS `categoria`  " +
                " FROM `bodegas_header` `bh` JOIN `bodegas` `b` ON(`bh`.`codigo_bodega` = `b`.`codigo_bodega` ) " +
                " JOIN `articulos` `a` ON(`b`.`codigo_articulo` = `a`.`codigo_articulo`) " +
                " JOIN `sub_categorias` `s` ON (`a`.`codigo_categoria` = `s`.`codigo_subcat`) " +
                " WHERE bh.codigo_bodega= " + bodegas.SelectedValue.ToString();
                if (comboBoxCategorias.SelectedValue.ToString() != "0")
                {
                    consulta = consulta + "  and a.codigo_categoria = " + comboBoxCategorias.SelectedValue;
                }
                consulta = consulta + " GROUP BY b.codigo_articulo ORDER BY a.descripcion";
                // consulta = consulta + " and codigo_bodega =" + bodegas.SelectedValue.ToString();
                bodega1 = Int32.Parse(bodegas.SelectedValue.ToString());
                bodega2 = Int32.Parse(bodegas.SelectedValue.ToString());
                botittle = bodegas.Text;
            }
            else
            {
                if (comboBoxCategorias.SelectedValue.ToString() != "0")
                {
                    consulta = consulta + "  and a.codigo_categoria = " + comboBoxCategorias.SelectedValue;
                }
            };
            MySqlDataAdapter adaptadori = new MySqlDataAdapter(consulta, Properties.Settings.Default.ortoxelaConnectionString);
            Reportes.Inventario.DataSet_Inventario dataseti = new Reportes.Inventario.DataSet_Inventario();
            adaptadori.Fill(dataseti, "v_inventario");
            Reportes.Inventario.XtraReport_Inventario1 reportei = new Reportes.Inventario.XtraReport_Inventario1();
                 
            reportei.DataSource = dataseti;
            reportei.DataMember = dataseti.Tables["v_inventario"].TableName;
            reportei.Parameters["Fecha_inicio"].Value = dateEdit6.EditValue;
            reportei.Parameters["Fecha_fin"].Value = dateEdit5.EditValue;
            reportei.Parameters["existencia"].Value = 0;
            reportei.Parameters["codigo_bodega1"].Value = bodega1;
            reportei.Parameters["codigo_bodega2"].Value = bodega2;
            reportei.Parameters["bodega"].Value = botittle;
            reportei.Parameters["nombreEmpresa"].Value = clases.ClassVariables.nombreEmpresa; 
            reportei.RequestParameters = false;
            reportei.ShowPreview();
            this.Cursor = Cursors.Default;
        }

        classortoxela ortoxela = new classortoxela();
        classortoxela logicaxela = new classortoxela();
        private void Frm_ReportesAdmin_Load(object sender, EventArgs e)
        {
            this.Text = "Reportes de Administracion - " + clases.ClassVariables.nombreEmpresa; 
            try
            {
                string ssql = "  Select 0 as codigo_bodega, 'Todas' as nombre_bodega from dual " +
                            " union all  " +
                            " select codigo_bodega,nombre_bodega from bodegas_header where estadoid=1";
                bodegas.DataSource = logicaxela.Tabla(ssql);
                bodegas.DisplayMember = "nombre_bodega";
                bodegas.ValueMember = "codigo_bodega";

            }
            catch
            { }
            /* Se llena Combo de Categoarias*/
            try
            {
                string ssql = "(select 0 as codigo,'Todas' as categoria from dual) union all (select  codigo_subcat as codigo,nombre_subcategoria as categoria from sub_categorias where estadoid=1 order by nombre_subcategoria asc)";
                comboBoxCategorias.DataSource = logicaxela.Tabla(ssql);
                comboBoxCategorias.DisplayMember = "categoria";
                comboBoxCategorias.ValueMember = "codigo";

            }
            catch
            { }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {

        }
    }
}
