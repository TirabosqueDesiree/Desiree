using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesisWeb.Models.MaestroDetalle
{
    public class VMPedido
    {
        public List<Clientes> ListaClientes  { get; set; }

        List<Concepto> conceptos { get; set; }
    }

    public class Concepto
    {
        List<Productos> ListaProductos { get; set; }
        public int Cantidad { get; set; }

    }
}