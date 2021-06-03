using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesisWeb.Models.clasesClientes
{
    public class VMCliente
    {
       

        public Cliente ClienteModel{ get; set; }
        public List<Provincia> ListaProvincias  { get; set; }
       
        
    }

}