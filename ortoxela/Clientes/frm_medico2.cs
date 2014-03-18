using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ortoxela.Clientes
{
    public partial class frm_medico : Form
    {
        string ssql;
        classortoxela logicaxela = new classortoxela();
        bool llamadentroform;

        public frm_medico()
        {
            InitializeComponent();
        }

        private void sbCancelar_Click(object sender, EventArgs e)
        {
            clases.ClassVariables.sociocomercial = false;
            this.Close();
        }

        private void frm_medico2_Load(object sender, EventArgs e)
        {
            llamadentroform = clases.ClassVariables.llamadoDentroForm;
            llenacombos();
        }

        private void llenacombos()
        {
            ssql = "SELECT codigo_tipoc as CODIGO, tipo_cliente AS TIPO FROM tipo_cliente where codigo_tipoc=7";
            gridLookUpTipoClie.Properties.DataSource = logicaxela.Tabla(ssql);
            gridLookUpTipoClie.Properties.DisplayMember = "TIPO";
            gridLookUpTipoClie.Properties.ValueMember = "CODIGO";
            gridLookUpTipoClie.EditValue = 7;
            ssql = "SELECT id_tipo_cliente_c AS CODIGO, descripcion AS TIPO FROM tipo_cliente_contabilidad WHERE activo=1";
            gridLookUpTipoClienteConta.Properties.DataSource = logicaxela.Tabla(ssql);
            gridLookUpTipoClienteConta.Properties.DisplayMember = "TIPO";
            gridLookUpTipoClienteConta.Properties.ValueMember = "CODIGO";
            gridLookUpTipoClienteConta.EditValue = 1;
            ssql = "SELECT estadoid as CODIGO, nombre_status AS ESTADO FROM estado where estadoid=1";
            gridLookUpEstado.Properties.DataSource = logicaxela.Tabla(ssql);
            gridLookUpEstado.Properties.DisplayMember = "ESTADO";
            gridLookUpEstado.Properties.ValueMember = "CODIGO";
            gridLookUpEstado.EditValue = 1;

        }

        private void simpleaceptar_Click(object sender, EventArgs e)
        {
            insertaMedico();
        }

        private void insertaMedico()
        {
            ssql = "INSERT into clientes(nombre_cliente, contacto, nit, telefono_casa, telefono_celular, email, fecha_ingreso, usuario_creador, direccion, socio_comercial, estadoid, codigo_tipoc,tipo_cliente_conta) " +
            "VALUES ('" + textNombreClie.Text + "', '" + textNombreClie.Text + "', '" + textNit.Text + "', '" + textTelefono.Text + "', '" + textCelular.Text + "', '" + textEmail.Text + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', " + clases.ClassVariables.id_usuario + ", '" + memoEditdireccion.Text + "', " + radioGroup1.SelectedIndex + ", " + gridLookUpEstado.EditValue + ", " + gridLookUpTipoClie.EditValue + ", " + gridLookUpTipoClienteConta.EditValue + ")";

            clases.ClassVariables.idnuevo = logicaxela.nuevoid(ssql);
            if (clases.ClassVariables.idnuevo != null)
            {
                groupControl1.Enabled = false;
                simpleaceptar.Enabled = false;
                clases.ClassMensajes.INSERTO(this);
                if (llamadentroform == true)
                {
                    clases.ClassVariables.sociocomercial = false;
                    llamadentroform = false;
                    this.Close();
                }
            }
            else
            {
                clases.ClassMensajes.NoINSERTO(this);
            }

        }
    }
}
