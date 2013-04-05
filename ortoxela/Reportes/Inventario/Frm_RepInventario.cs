using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
namespace ortoxela.Reportes.Inventario
{
    public partial class Frm_RepInventario : DevExpress.XtraEditors.XtraForm
    {
        public Frm_RepInventario()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
                this.Cursor = Cursors.WaitCursor;
                Int32 bodega1 = 0;
                Int32 bodega2 = 100;
                string botittle = "Todas";
                string consulta = "SELECT codigo_articulo, articulo, Ult_compra, Ult_venta, Ult_precio, nombre_bodega, categoria, codigo_categoria, existencia_articulo, codigo_bodega  " +
                                   " FROM ortoxela.v_inventario where 1=1 ";
                if (bodegas.SelectedValue.ToString() != "0")
                {
                    consulta = "SELECT `a`.`codigo_articulo` AS `codigo_articulo`,REPLACE(a.descripcion,'\"','') AS articulo,SUM(COALESCE(`b`.`existencia_articulo`,0)) AS `existencia_articulo`, " +
                    " DATE_FORMAT((SELECT f_ultima_compra(b.codigo_articulo) FROM DUAL),'%d-%m-%Y') AS Ult_compra, " +
                    " DATE_FORMAT((SELECT f_ultima_venta(b.codigo_articulo) FROM DUAL),'%d-%m-%Y') AS Ult_venta, " +
                    " (`a`.`costo` / 1.12) AS `Ult_precio`, "+
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
                DataSet_Inventario dataseti = new DataSet_Inventario();
                adaptadori.Fill(dataseti, "v_inventario");                
                XtraReport_Inventario1 reportei = new XtraReport_Inventario1();
                //  XtraReport_TomaInventario reportet = new XtraReport_TomaInventario();            
                reportei.DataSource = dataseti;
                reportei.DataMember = dataseti.Tables["v_inventario"].TableName;
                reportei.Parameters["Fecha_inicio"].Value = dateEdit1.EditValue;
                reportei.Parameters["Fecha_fin"].Value = dateEdit2.EditValue;
                reportei.Parameters["existencia"].Value = 0;
                reportei.Parameters["codigo_bodega1"].Value = bodega1;
                reportei.Parameters["codigo_bodega2"].Value = bodega2;
                reportei.Parameters["bodega"].Value = botittle;
                reportei.RequestParameters = false;
                reportei.ShowPreview();
                this.Cursor = Cursors.Default ;
                    // ShowPreviewDialog();
            /*}
            else
            {

                XtraReport_Inventario1 reporteI = new XtraReport_Inventario1();
                reporteI.Parameters["Fecha_inicio"].Value = dateEdit1.EditValue;
                reporteI.Parameters["Fecha_fin"].Value = dateEdit2.EditValue;                
                reporteI.Parameters["existencia"].Value = 0;
                reporteI.RequestParameters = false;
                reporteI.ShowPreview();
            }; */
        }
        
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Int32 bodega1 = 0;
            Int32 bodega2 = 100;
            string botittle = "Todas";
            string consulta = "SELECT codigo_articulo, articulo, Ult_compra, Ult_venta, Ult_precio, nombre_bodega, categoria, codigo_categoria, existencia_articulo, codigo_bodega  " +
                                   " FROM ortoxela.v_inventario where existencia_articulo >0 ";  
                    if (bodegas.SelectedValue.ToString() != "0")
                    {
                        consulta = String.Format("{0} and codigo_bodega = {1}", consulta, bodegas.SelectedValue);
                        bodega1 = Int32.Parse(bodegas.SelectedValue.ToString());
                        bodega2 = Int32.Parse(bodegas.SelectedValue.ToString());
                        botittle = bodegas.Text;
                    }
                    if (comboBoxCategorias.SelectedValue.ToString() != "0")
                    {
                        consulta = consulta + "  and codigo_categoria = " + comboBoxCategorias.SelectedValue;
                    }
                    else
                    {
                        if ((textEdit2.Text.Trim() != "") || (textEdit3.Text.Trim() != ""))
                        {
                            if ((textEdit2.Text.Trim() != "") && (textEdit3.Text.Trim() == ""))
                            {
                                consulta = consulta + " and  codigo_articulo like '%" + textEdit2.Text + "%'";
                            }
                            else
                            {
                                if ((textEdit2.Text.Trim() == "") && (textEdit3.Text.Trim() != ""))
                                {
                                    consulta = consulta + " and codigo_articulo like '%" + textEdit3.Text + "%'";
                                }
                                else
                                {
                                    consulta = consulta + " and codigo_articulo between '" + textEdit2.Text + "' and '" + textEdit3.Text + "' ";
                                }
                            }

                        }
                    }
            // XtraReport_TomaInventario reportet = new XtraReport_TomaInventario();
            // reportet.RequestParameters = false;
            // reportet.ShowPreview();
             
            MySqlDataAdapter adaptador1 = new MySqlDataAdapter(consulta, Properties.Settings.Default.ortoxelaConnectionString);
            DataSet_Inventario dataset = new DataSet_Inventario();
            adaptador1.Fill(dataset, "v_inventario");
            XtraReport_InventarioExistencia reportee = new XtraReport_InventarioExistencia();
            //  XtraReport_TomaInventario reportet = new XtraReport_TomaInventario();            
            reportee.DataSource = dataset;
            reportee.DataMember = dataset.Tables["v_inventario"].TableName;
            reportee.Parameters["codigo_bodega1"].Value = bodega1;
            reportee.Parameters["codigo_bodega2"].Value = bodega2;
            reportee.Parameters["bodega"].Value = botittle;
            this.Cursor = Cursors.Default ;
            reportee.RequestParameters = false;
            reportee.ShowPreviewDialog();

        }

      
        classortoxela ortoxela = new classortoxela();
        private void simpleButton4_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            Int32 codigo_bodega = 1;
            string co_bo = "", botittle="" ;
            Int16 cat1 = 0, cat2 = 10000;
            string consulta = "SELECT codigo_articulo, Articulo, cantidad, costo_sin_iva, costo_iva, codigo_bodega, nombre_bodega, fecha, Tipo_Pago, nombre_proveedor, nombre_cliente, dias_credito, "+
                             "signo, tipo_docto, no_documento, refer_documento, bodega_destino, codigo_categoria, categoria "+
                            "FROM ortoxela.v_kardex  where 1=1 ";

            if (bodegas.SelectedValue.ToString() != "0")
            {
                co_bo = " and codigo_bodega =" + bodegas.SelectedValue.ToString();
                consulta = consulta + co_bo;
                codigo_bodega = Int32.Parse(bodegas.SelectedValue.ToString());
                botittle = bodegas.Text;

                if (comboBoxCategorias.SelectedValue.ToString() != "0")
                {
                    consulta = consulta + "  and codigo_categoria = " + comboBoxCategorias.SelectedValue;
                    cat1 = Convert.ToInt16(comboBoxCategorias.SelectedValue.ToString());
                    cat2 = cat1;
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Bodega para este Reporte.", "Reporte Kardex");
                return;
            };

            if ((textEdit1.Text.Trim() != "") || (textEdit4.Text.Trim() != ""))
            {
                if ((textEdit1.Text.Trim() != "") && (textEdit4.Text.Trim() == ""))
                {
                    consulta = consulta + " and codigo_articulo like '%" + textEdit1.Text + "%'";
                }
                else
                {
                    if ((textEdit1.Text.Trim() == "") && (textEdit4.Text.Trim() != ""))
                    {
                        consulta = consulta + " and codigo_articulo like '%" + textEdit4.Text + "%'";
                    }
                    else
                    {
                        consulta = consulta + " and codigo_articulo between '" + textEdit1.Text + "' and '" + textEdit4.Text + "' ";
                    }
                }

            }
            string fechaInicialx = "2011-12-01";
            
            if ((dateEdit4.EditValue != null) && (dateEdit3.EditValue != null))
            {
                fechaInicialx = dateEdit4.DateTime.ToString("yyyy-MM-dd");
                consulta = consulta + " and fecha between '" + dateEdit4.DateTime.ToString("yyyy-MM-dd") + " 00:00:00' ";
                consulta = consulta + " and '" + dateEdit3.DateTime.ToString("yyyy-MM-dd") + " 23:59:59' ";
            }
            

            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, Properties.Settings.Default.ortoxelaConnectionString);
            DataSet_Inventario dataset = new DataSet_Inventario();
            adaptador.Fill(dataset, "v_kardex");
            XtraReport_Kardex reporteP = new XtraReport_Kardex();
            reporteP.DataSource = dataset;
            reporteP.DataMember = dataset.Tables["v_kardex"].TableName;
            reporteP.Parameters["codigo_bodega"].Value = codigo_bodega;
            reporteP.Parameters["bodega"].Value = botittle;
            reporteP.Parameters["Fecha_inicio"].Value = Convert.ToDateTime(fechaInicialx);
            reporteP.Parameters["Fecha_fin"].Value = dateEdit3.EditValue;
            reporteP.Parameters["categoria1"].Value = cat1;
            reporteP.Parameters["categoria2"].Value = cat2;
            this.Cursor = Cursors.Default;
            reporteP.RequestParameters = false;
            reporteP.ShowPreviewDialog();            
        }

        classortoxela logicaxela = new classortoxela();
        private void Frm_RepInventario_Load(object sender, EventArgs e)
        {
            try
            {
                string ssql = "  Select 0 as codigo_bodega, 'Todas' as nombre_bodega from dual " +
                            " union all  "+
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

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string consulta = "SELECT        codigo_articulo, articulo, Ult_compra, Ult_venta, Ult_precio, nombre_bodega, categoria, codigo_categoria, existencia_articulo, codigo_bodega FROM v_inventario where 1=1 ";


            if (comboBoxCategorias.SelectedValue.ToString() == "0")
            {
                if ((textEdit6.Text.Trim() != "") || (textEdit5.Text.Trim() != ""))
                {
                    if ((textEdit6.Text.Trim() != "") && (textEdit5.Text.Trim() == ""))
                    {
                        consulta = consulta + " and  codigo_articulo like '%" + textEdit6.Text + "%'";
                    }
                    else
                    {
                        if ((textEdit6.Text.Trim() == "") && (textEdit5.Text.Trim() != ""))
                        {
                            consulta = consulta + " and codigo_articulo like '%" + textEdit5.Text + "%'";
                        }
                        else
                        {
                            consulta = consulta + " and codigo_articulo between '" + textEdit6.Text + "' and '" + textEdit5.Text + "' ";
                        }
                    }

                }
            }
            else
            {
                consulta = consulta + " and codigo_categoria = " + comboBoxCategorias.SelectedValue;
            }
            // XtraReport_TomaInventario reportet = new XtraReport_TomaInventario();
            // reportet.RequestParameters = false;
            // reportet.ShowPreview();

            MySqlDataAdapter adaptador1 = new MySqlDataAdapter(consulta, Properties.Settings.Default.ortoxelaConnectionString);
            DataSet_Inventario dataset = new DataSet_Inventario();
            adaptador1.Fill(dataset, "v_inventario");
            XtraReport_TomaInventario reportet = new XtraReport_TomaInventario();
            reportet.DataSource = dataset;
            reportet.DataMember = dataset.Tables["v_inventario"].TableName;
            this.Cursor = Cursors.Default;
            reportet.RequestParameters = false;
            reportet.ShowPreviewDialog();
        }

        private void panelControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void dateEdit4_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl19_Click(object sender, EventArgs e)
        {

        }

       

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            XtraReport_InventarioResumen reporte = new XtraReport_InventarioResumen();
            reporte.Parameters["Fecha_inicio"].Value = dateEdit6.EditValue;
            reporte.Parameters["Fecha_fin"].Value = dateEdit5.EditValue;
            reporte.RequestParameters = false;
            reporte.ShowPreview();
        
            this.Cursor = Cursors.Default;
        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Int32 bodega1 = 0;
            Int32 bodega2 = 100;
            string botittle = "Todas";
            string consulta = "SELECT precio_venta,codigo_articulo, articulo, Ult_compra, Ult_venta, Ult_precio, nombre_bodega, categoria, codigo_categoria, existencia_articulo, codigo_bodega  " +
                               " FROM ortoxela.v_inventario2h where 1=1 ";
            if (bodegas.SelectedValue.ToString() != "0")
            {
                consulta = "SELECT `a`.`precio_venta` AS `precio_venta`,`a`.`codigo_articulo` AS `codigo_articulo`,REPLACE(a.descripcion,'\"','') AS articulo,SUM(COALESCE(`b`.`existencia_articulo`,0)) AS `existencia_articulo`, " +
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
            DataSet_Inventario2H dataseti = new DataSet_Inventario2H();
            adaptadori.Fill(dataseti, "v_inventario2h");
            XtraReport_Inventario2H reportei = new XtraReport_Inventario2H();
            //  XtraReport_TomaInventario reportet = new XtraReport_TomaInventario();            
            reportei.DataSource = dataseti;
            reportei.DataMember = dataseti.Tables["v_inventario2h"].TableName;
            reportei.Parameters["Fecha_inicio"].Value = dateEdit8.EditValue;
            reportei.Parameters["Fecha_fin"].Value = dateEdit7.EditValue;
            reportei.Parameters["existencia"].Value = 0;
            reportei.Parameters["codigo_bodega1"].Value = bodega1;
            reportei.Parameters["codigo_bodega2"].Value = bodega2;
            reportei.Parameters["bodega"].Value = botittle;
            reportei.RequestParameters = false;
            reportei.ShowPreview();
            this.Cursor = Cursors.Default;
            // ShowPreviewDialog();
            /*}
            else
            {

                XtraReport_Inventario1 reporteI = new XtraReport_Inventario1();
                reporteI.Parameters["Fecha_inicio"].Value = dateEdit1.EditValue;
                reporteI.Parameters["Fecha_fin"].Value = dateEdit2.EditValue;                
                reporteI.Parameters["existencia"].Value = 0;
                reporteI.RequestParameters = false;
                reporteI.ShowPreview();
            }; */
        }


                                           
    }
}