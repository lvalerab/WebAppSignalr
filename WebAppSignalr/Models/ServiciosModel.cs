using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppSignalr.Models
{
    public class ServiciosModel
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public IList<CitaClienteModel> ColaCitas { get; set; }
    }
}