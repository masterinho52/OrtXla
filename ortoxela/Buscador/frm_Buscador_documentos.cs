using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ortoxela.Buscador
{
    public partial class frm_Buscador_documentos : DevExpress.XtraEditors.XtraForm
    {
        public frm_Buscador_documentos()
        {
            InitializeComponent();
        }

        private void frm_Buscador_documentos_Load(object sender, EventArgs e)
        {
            CargaListado();
        }
        classortoxela orto = new classortoxela();
        private void CargaListado()
        {
            string cadena = "SELECT * FROM ( " +
"SELECT hd.id_documento,rv.id_vale,hd.codigo_serie,c.nombre_cliente AS 'CLIENTE',c.nombre_paciente AS 'PACIENTE',td.nombre_documento AS 'DOCUMENTO',CAST(CONCAT(sd.serie_documento,' [',hd.no_documento,']')AS CHAR)AS 'NO DOCUMENTO' FROM header_doctos_inv hd INNER JOIN clientes c ON hd.codigo_cliente=c.codigo_cliente  " +
"INNER JOIN relacion_venta rv ON hd.id_documento=rv.id_documento INNER JOIN series_documentos sd ON hd.codigo_serie=sd.codigo_serie " +
"INNER JOIN tipos_documento td ON sd.codigo_tipo=td.codigo_tipo and rv.codigo_cliente=c.codigo_cliente  " +
"UNION " +
"SELECT rb.id_recibos AS id_documento,rv.id_vale,rb.codigo_serie,c.nombre_cliente AS 'CLIENTE',c.nombre_paciente AS 'PACIENTE',td.nombre_documento AS 'DOCUMENTO',CAST(CONCAT(sd.serie_documento,' [',rb.no_recibo,']')AS CHAR)AS 'NO DOCUMENTO'  " +
"FROM recibos rb INNER JOIN relacion_venta rv ON rb.id_recibos=rv.id_documento INNER JOIN clientes c ON c.codigo_cliente=rv.codigo_cliente " +
"INNER JOIN series_documentos sd ON rb.codigo_serie=sd.codigo_serie INNER JOIN tipos_documento td ON sd.codigo_tipo=td.codigo_tipo " +
"GROUP BY rv.id_vale " +
") AS datos " +
"WHERE CLIENTE LIKE '%" + textNombreCliente.Text + "%' AND PACIENTE LIKE '%" + textNombrePaciente.Text + "%' ";
            if (textNoFactura.Text != "")
            {
                if (checkEdit1.Checked)
                {
                    cadena += "and id_vale in(select rv.id_vale from header_doctos_inv hd inner join series_documentos sd on hd.codigo_serie=sd.codigo_serie inner join relacion_venta rv on hd.id_documento=rv.id_documento where sd.codigo_tipo=1 and hd.no_documento like '"+textNoFactura.Text+"') ";
                }
                else
                {
                    cadena += "and id_vale in(select rv.id_vale from header_doctos_inv hd inner join series_documentos sd on hd.codigo_serie=sd.codigo_serie inner join relacion_venta rv on hd.id_documento=rv.id_documento where sd.codigo_tipo=1 and hd.no_documento like '%" + textNoFactura.Text + "%') ";
                }
            }
            if (textNoVale.Text != "")
            {
                if (checkEdit2.Checked)
                {
                    cadena += "and id_vale in(select rv.id_vale from header_doctos_inv hd inner join series_documentos sd on hd.codigo_serie=sd.codigo_serie inner join relacion_venta rv on hd.id_documento=rv.id_documento where sd.codigo_tipo=3 and hd.no_documento like '" + textNoVale.Text + "') ";
                }
                else
                {
                    cadena += "and id_vale in(select rv.id_vale from header_doctos_inv hd inner join series_documentos sd on hd.codigo_serie=sd.codigo_serie inner join relacion_venta rv on hd.id_documento=rv.id_documento where sd.codigo_tipo=3 and hd.no_documento like '%" + textNoVale.Text + "%') ";
                }
            }
            if (textNoPedido.Text != "")
            {
                if (checkEdit3.Checked)
                {
                    cadena += "and id_vale in(select rv.id_vale from header_doctos_inv hd inner join series_documentos sd on hd.codigo_serie=sd.codigo_serie inner join relacion_venta rv on hd.id_documento=rv.id_documento where sd.codigo_tipo=5 and hd.no_documento like '" + textNoPedido.Text + "') ";
                }
                else
                {
                    cadena += "and id_vale in(select rv.id_vale from header_doctos_inv hd inner join series_documentos sd on hd.codigo_serie=sd.codigo_serie inner join relacion_venta rv on hd.id_documento=rv.id_documento where sd.codigo_tipo=5 and hd.no_documento like '%" + textNoPedido.Text + "%') ";
                }
            }
            if (textNoRecibo.Text != "")
            {
                if (checkEdit4.Checked)
                {
                    cadena += "and id_vale in(SELECT rv.id_vale FROM recibos r INNER JOIN series_documentos sd ON r.codigo_serie=sd.codigo_serie INNER JOIN relacion_venta rv ON r.id_recibos=rv.id_documento WHERE sd.codigo_tipo=2 AND r.no_recibo LIKE '" + textNoRecibo.Text + "')";
                }
                else
                {
                    cadena += "and id_vale in(SELECT rv.id_vale FROM recibos r INNER JOIN series_documentos sd ON r.codigo_serie=sd.codigo_serie INNER JOIN relacion_venta rv ON r.id_recibos=rv.id_documento WHERE sd.codigo_tipo=2 AND r.no_recibo LIKE '%" + textNoRecibo.Text + "%')";
                }
            }
cadena+= "ORDER BY id_vale";

            gridControl1.DataSource = orto.Tabla(cadena);
            gridView1.Columns["id_documento"].Visible = false;
            gridView1.Columns["id_vale"].Visible = false;
            gridView1.Columns["codigo_serie"].Visible = false;

        }

        private void sb_Buscar_Click(object sender, EventArgs e)
        {
            CargaListado();
        }

        private void textNombreCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                sb_Buscar.PerformClick();
        }

        private void textNombrePaciente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                sb_Buscar.PerformClick();
        }

        private void textNoFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                sb_Buscar.PerformClick();
        }

        private void textNoVale_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                sb_Buscar.PerformClick();
        }

        private void textNoPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                sb_Buscar.PerformClick();
        }

        private void textNoRecibo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                sb_Buscar.PerformClick();
        }
    }
}