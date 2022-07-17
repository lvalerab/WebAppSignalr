using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppSignalr.Models
{
    public class CitaClienteModel
    {
        public DateTime Cuando { get; set; }
        public ClienteModel Cliente { get; set; }
    }
}