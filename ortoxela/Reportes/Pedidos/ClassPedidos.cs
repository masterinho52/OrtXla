using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace ortoxela.Reportes.Pedidos
{
    public class ClassPedidos
    {
        private Reportes.Pedidos.DataSet_PedidosTableAdapters.v_pedidosTableAdapter pedidos;
        private Reportes.Pedidos.DataSet_PedidosTableAdapters.v_pedidosTableAdapter pedido2
        {
            get
            {
                if (pedidos == null)
                    pedidos = new Reportes.Pedidos.DataSet_PedidosTableAdapters.v_pedidosTableAdapter();
                return pedidos;
            }
        }

        public DataTable getDatos()
        {
            return pedido2.GetData();
        }
    }
}
