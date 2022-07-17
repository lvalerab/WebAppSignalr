using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppSignalr.Models
{
    public class ClienteModel
    {
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public IList<SesionModel> Sesiones { get; set; }
    }
}