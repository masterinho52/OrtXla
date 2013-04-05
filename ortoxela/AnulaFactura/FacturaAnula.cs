using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Controls;
namespace ortoxela.AnulaFactura
{
    public partial class FacturaAnula : DevExpress.XtraEditors.XtraForm
    {
        public FacturaAnula()
        {
            InitializeComponent();
        }
        classortoxela logicaxela = new classortoxela();
        string ssql;
        public static string id_usuario_mod;
        private void CargaDatos()
        {
            try
            {
                cadena = "SELECT codigo_serie CODIGO,CONCAT(tipos_documento.nombre_documento,' - ',serie_documento) AS DOCUMENTO FROM ortoxela.series_documentos INNER JOIN tipos_documento ON series_documentos.codigo_tipo = tipos_documento.codigo_tipo WHERE tipos_documento.codigo_tipo=1";
                gridLookDocFactura.Properties.DataSource = logicaorto.Tabla(cadena);
                gridLookDocFactura.Properties.DisplayMember = "DOCUMENTO";
                gridLookDocFactura.Properties.ValueMember = "CODIGO";
                gridLookDocFactura.EditValue = 1;
            }
            catch
            { }

        }
        private void CreaColumnas()
        {
            DataTable temporal = new DataTable();
            temporal.Columns.Add("IDBODEGA");
            temporal.Columns.Add("BODEGA");
            temporal.Columns.Add("CODIGO");
            temporal.Columns.Add("DESCRIPCION");
            temporal.Columns.Add("CANTIDAD");
            temporal.Columns.Add("VENTA");
            temporal.Columns.Add("SUBTOTAL");
            temporal.Columns.Add("DESCUENTO");                        
            temporal.Columns.Add("ACTUALIZA_PRECIO");
            temporal.Columns.Add("INGRESO_EGRESO");
            temporal.Columns.Add("EXISTENCIA");
            gridControl1.DataSource = temporal;
            gridView1.Columns["DESCRIPCION"].Width=200;
            gridView1.Columns["IDBODEGA"].Visible = false;
            gridView1.Columns["ACTUALIZA_PRECIO"].Visible = false;
            gridView1.Columns["INGRESO_EGRESO"].Visible = false;
            gridView1.Columns["EXISTENCIA"].Visible = false;
            gridView1.Columns["DESCUENTO"].Visible = false;
            gridView1.Columns["BODEGA"].OptionsColumn.ReadOnly = true;
            gridView1.Columns["DESCRIPCION"].OptionsColumn.ReadOnly = true;
            gridView1.Columns["SUBTOTAL"].OptionsColumn.ReadOnly = true;
            gridView1.Columns["DESCUENTO"].OptionsColumn.ReadOnly = true;           

        }   
        private void frm_compras_Load(object sender, EventArgs e)
        {            
            CargaDatos();        
            CreaColumnas();            
        }
        
        
        DataTable tempTabla = new DataTable();
        
        MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.ortoxelaConnectionString);
        MySqlCommand comando = new MySqlCommand();
        MySqlTransaction transa;

        string id_vale;
        private void registraIngreso()
        {
            string id_pedido;
            try
            {
                try
                {
                    cadena = "SELECT header_doctos_inv.id_documento FROM header_doctos_inv INNER JOIN series_documentos  ON header_doctos_inv.codigo_serie=series_documentos.codigo_serie WHERE header_doctos_inv.id_documento IN (SELECT relacion_venta.id_documento FROM relacion_venta WHERE relacion_venta.id_vale=(SELECT relacion_venta.id_vale FROM relacion_venta WHERE relacion_venta.id_documento=" + id_factura_doc + ")) AND series_documentos.codigo_tipo=5";
                    tempTabla = logicaorto.Tabla(cadena);
                     id_pedido = tempTabla.Rows[0][0].ToString();
                }
                catch
                {
                    id_pedido = "0";
                }
                try
                {
                    cadena = "SELECT relacion_venta.id_vale FROM relacion_venta WHERE relacion_venta.id_documento="+id_factura_doc+" AND relacion_venta.codigo_cliente="+textEditCODIGO.Text;
                    tempTabla = logicaorto.Tabla(cadena);
                    id_vale = tempTabla.Rows[0][0].ToString();
                }
                catch
                {
                    id_vale = "0";
                }
                conexion.Open();
                transa = conexion.BeginTransaction();
                for (int x = 0; x < gridView1.DataRowCount; x++)
                {                   
                    cadena = "UPDATE bodegas SET bodegas.existencia_articulo=bodegas.existencia_articulo+" + gridView1.GetRowCellValue(x,"CANTIDAD") + " WHERE bodegas.codigo_articulo='" + gridView1.GetRowCellValue(x, "CODIGO") + "' AND bodegas.codigo_bodega=" + gridView1.GetRowCellValue(x, "IDBODEGA");
                    comando = new MySqlCommand(cadena, conexion);
                    comando.Transaction = transa;
                    comando.ExecuteNonQuery();
                }
                cadena = "UPDATE header_doctos_inv SET header_doctos_inv.estadoid=6,header_doctos_inv.usuario_modifica="+id_usuario_mod+",header_doctos_inv.fecha_modificacion='"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"' WHERE header_doctos_inv.id_documento=" + id_factura_doc;
                comando = new MySqlCommand(cadena, conexion);
                comando.Transaction = transa;
                comando.ExecuteNonQuery();
                cadena = "UPDATE header_doctos_inv SET header_doctos_inv.estadoid=6,header_doctos_inv.usuario_modifica=" + id_usuario_mod + ",header_doctos_inv.fecha_modificacion='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE header_doctos_inv.id_documento=" + id_pedido;
                comando = new MySqlCommand(cadena, conexion);
                comando.Transaction = transa;
                comando.ExecuteNonQuery();
                cadena = "UPDATE header_doctos_inv SET header_doctos_inv.estadoid=8,header_doctos_inv.usuario_modifica=" + id_usuario_mod + ",header_doctos_inv.fecha_modificacion='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE header_doctos_inv.id_documento=" +id_vale;
                comando = new MySqlCommand(cadena, conexion);
                comando.Transaction = transa;
                comando.ExecuteNonQuery();
                transa.Commit();
                clases.ClassMensajes.INSERTO(this);
                sbAceptar.Enabled = false;
                groupControl1.Enabled =groupControl2.Enabled= false;
            }
            catch
            {
                transa.Rollback();
                clases.ClassMensajes.NoINSERTO(this);
            }
            finally
            {
                conexion.Close();
            }
        }
        private void sbAceptar_Click(object sender, EventArgs e)
        {
            if(dxValidationProvider2.Validate() & gridView1.DataRowCount>0)
            {
                registraIngreso();
               
            }
            else
            clases.ClassMensajes.FaltanDatosEnCampos(this);
        }
        private void Limpia()
        {
            //gridLookBodega.EditValue = null;
            //gridLookProveedor.EditValue = null;
            //gridLookTipoDocumento.EditValue = null;
            textEditCODIGO.Text = "";
            textClienteFactura.Text = "";
            textDireccionFactura.Text = "";
            textEditVENDEDOR.Text = "";
            textNumeroDocFactura.Text = "";
            dateEdit1.Text = "";
            textNitFactura.Text = "";
       
          

            textTotalIva.Text = "Q0.00";         
            
            textPrecioTotal.Text = "Q0.00";
            CreaColumnas();            
            simplePrinter.Enabled = false;
            sbAceptar.Enabled = true;
            groupControl1.Enabled = true;
            groupControl2.Enabled = true;             
            //CargaDatos();
        }
        string cadena;
        string id_factura_doc;
        DataTable tablaDatos=new DataTable();
        private void sbnuevo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿DESEA BORRAR LO DATOS?", "INFORMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Limpia();
                cadena = "SELECT header_doctos_inv.id_documento AS CODIGO,CONCAT(tipos_documento.nombre_documento,' ',series_documentos.serie_documento)AS DOCUMENTO ,header_doctos_inv.no_documento AS 'No DOCUMENTO',header_doctos_inv.fecha AS 'FECHA',clientes.nombre_cliente AS 'NOMBRE CLIENTE' FROM header_doctos_inv INNER JOIN series_documentos ON header_doctos_inv.codigo_serie=series_documentos.codigo_serie INNER JOIN tipos_documento ON tipos_documento.codigo_tipo=series_documentos.codigo_tipo LEFT JOIN clientes ON header_doctos_inv.codigo_cliente=clientes.codigo_cliente WHERE series_documentos.codigo_serie="+gridLookDocFactura.EditValue+" and header_doctos_inv.estadoid IN (4,5,8,9)";
                clases.ClassVariables.cadenabusca = cadena;
                Form nuevo = new Buscador.Buscador();
                nuevo.ShowDialog();
                if (Buscador.Buscador.SeleccionSiNo)
                {
                    id_factura_doc = clases.ClassVariables.id_busca;
                    cadena = "SELECT header_doctos_inv.monto_neto,header_doctos_inv.id_documento AS CODIGO,CONCAT(tipos_documento.nombre_documento,' ',series_documentos.serie_documento)AS DOCUMENTO ,header_doctos_inv.no_documento AS 'No DOCUMENTO',header_doctos_inv.fecha AS 'FECHA',clientes.nombre_cliente AS 'NOMBRE CLIENTE',clientes.nit,clientes.codigo_cliente,clientes.direccion,usuarios.nombre,header_doctos_inv.contado_credito FROM header_doctos_inv INNER JOIN series_documentos ON header_doctos_inv.codigo_serie=series_documentos.codigo_serie INNER JOIN tipos_documento ON tipos_documento.codigo_tipo=series_documentos.codigo_tipo LEFT JOIN clientes ON header_doctos_inv.codigo_cliente=clientes.codigo_cliente INNER JOIN usuarios ON header_doctos_inv.usuario_creador=usuarios.userid WHERE header_doctos_inv.id_documento=" + id_factura_doc;
                    tablaDatos = logicaorto.Tabla(cadena);
                    textEditCODIGO.Text=tablaDatos.Rows[0]["codigo_cliente"].ToString();
                    textClienteFactura.Text = tablaDatos.Rows[0]["NOMBRE CLIENTE"].ToString();
                    textDireccionFactura.Text= tablaDatos.Rows[0]["direccion"].ToString();
                    textEditVENDEDOR.Text= tablaDatos.Rows[0]["nombre"].ToString();
                    textNumeroDocFactura.Text= tablaDatos.Rows[0]["No DOCUMENTO"].ToString();
                    dateEdit1.DateTime=Convert.ToDateTime(tablaDatos.Rows[0]["FECHA"].ToString());
                    textNitFactura.Text= tablaDatos.Rows[0]["nit"].ToString();
                    textPrecioTotal.Text = tablaDatos.Rows[0]["monto_neto"].ToString();
                   cadena="SELECT bodegas_header.codigo_bodega AS 'IDBODEGA',bodegas_header.nombre_bodega BODEGA,articulos.codigo_articulo AS 'CODIGO',articulos.descripcion AS 'DESCRIPCION',detalle_doctos_inv.cantidad_enviada AS 'CANTIDAD',detalle_doctos_inv.precio_unitario AS 'VENTA',detalle_doctos_inv.precio_total AS 'SUBTOTAL' FROM detalle_doctos_inv INNER JOIN articulos ON detalle_doctos_inv.codigo_articulo=articulos.codigo_articulo INNER JOIN bodegas_header ON bodegas_header.codigo_bodega=detalle_doctos_inv.codigo_bodega WHERE detalle_doctos_inv.id_documento="+id_factura_doc;
                   gridControl1.DataSource = logicaorto.Tabla(cadena);
                }
            }

        }     

        private void sbCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simplePrinter_Click(object sender, EventArgs e)
        {
            try
            {
                //PrintIngresoProd.XtraReportIngresoProd reporte = new PrintIngresoProd.XtraReportIngresoProd();
                //reporte.Parameters["ID"].Value=id_nuevoIngreso;
                //reporte.RequestParameters = false;
                //reporte.ShowPreviewDialog();
            }
            catch
            {
            
            }
        }        
        
        
        classortoxela logicaorto = new classortoxela();

        private void gridLookDocFactura_EditValueChanged(object sender, EventArgs e)
        {
            
                Limpia();
            
        }                      
    }
}