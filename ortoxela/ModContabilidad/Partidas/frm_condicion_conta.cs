using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ortoxela.ModContabilidad.Partidas
{
    public partial class frm_condicion_conta : DevExpress.XtraEditors.XtraForm
    {
        public frm_condicion_conta()
        {
            InitializeComponent();
        }

        private void frm_condicion_conta_Load(object sender, EventArgs e)
        {
            llenaCombos();
        }
        string cadena = "";
        classortoxela ortoxela = new classortoxela();
        private void llenaCombos()
        {
            try
            {
                cadena = "SELECT codigo_serie CODIGO,CAST(CONCAT(nombre_documento,'[',serie_documento,']')AS CHAR) AS 'DOCUMENTO' " +
                           "FROM ortoxela.series_documentos INNER JOIN tipos_documento ON series_documentos.codigo_tipo = tipos_documento.codigo_tipo where tipos_documento.estado_id=1 " +
                           "ORDER BY nombre_documento";
                gridLookSerie.Properties.DataSource = ortoxela.Tabla(cadena);
                gridLookSerie.Properties.DisplayMember = "DOCUMENTO";
                gridLookSerie.Properties.ValueMember = "CODIGO";
            }
            catch
            { }
            try
            {
                cadena = "SELECT id_tipo_cliente_c AS CODIGO,DESCRIPCION FROM tipo_cliente_contabilidad WHERE activo=1";
                gridLookUpTipoCliente.Properties.DataSource = ortoxela.Tabla(cadena);
                gridLookUpTipoCliente.Properties.DisplayMember = "DESCRIPCION";
                gridLookUpTipoCliente.Properties.ValueMember = "CODIGO";
            }
            catch { }

        }

        private void sbAceptar_Click(object sender, EventArgs e)
        {
            ingresoCondicion();
        }
        private void ingresoCondicion()
        {
            cadena = "INSERT INTO ortoxela.condiciones_contabilidad (nombre_operacion, codigo_serie, tipo_pago, tipo_cliente)"+
                    "VALUES('"+textNombreOperacion.Text+"','"+gridLookSerie.EditValue+"', '"+radioGroup1.SelectedIndex+"', '"+gridLookUpTipoCliente.EditValue+"')";
            if(Convert.ToInt32(ortoxela.nuevoid(cadena))>0)
            {
                clases.ClassMensajes.INSERTO(this);
            }
            else
            {
                clases.ClassMensajes.NoINSERTO(this);
            }
        }

        private void sbCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void sbnuevo_Click(object sender, EventArgs e)
        {
            textNombreOperacion.Text = "";
            gridLookUpTipoCliente.EditValue = null;
            gridLookSerie.EditValue = null;
            radioGroup1.SelectedIndex = 0;
            textNombreOperacion.Focus();
        }
    }
}