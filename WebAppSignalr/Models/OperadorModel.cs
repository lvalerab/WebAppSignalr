using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppSignalr.Models
{
    public class OperadorModel
    {
        public string ConexionID { get; set; }
        public string Numa { get; set; }
        public string CodUsuario { get; set; }
        public string Nombre { get; set; }
        public IList<ServiciosModel> ServiciosRegistrados { get; set; }
        public ClienteModel ClienteActual { get; set; }
        public DateTime tiempoInicio { get; set; }
        public DateTime tiempoInicioCliente { get; set; }

    }
}