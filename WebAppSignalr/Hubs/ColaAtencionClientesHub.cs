using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppSignalr.Models;

namespace WebAppSignalr.Hubs
{
    public class ColaAtencionClientesHub:Hub
    {

        public List<OperadorModel> operadores { get; set; }
        
        public void ValidarUsuario(string codUsuario, string nombre)
        {
            //Buscamos el usuario
            OperadorModel opActual=(from op in operadores
                                  where op.ConexionID==Context.ConnectionId && op.CodUsuario==codUsuario                                   
                                  select op).FirstOrDefault();
            if(opActual == null)
            {
                //Aqui registramos los datos del operador
                //Buscamos en la base de datos, etc..
                opActual = new OperadorModel
                {
                    ConexionID = Context.ConnectionId,
                    CodUsuario = "",
                    Nombre = nombre
                };
                operadores.Add(opActual);
            }
            //Aqui obtenemos la sesion guardada por la api, y registramos el codigo de usuario con el id de sesion
            Clients.Caller.RespuestaValidarUsuario(opActual);
        }
    
        public void GetServiciosDisponibles()
        {
            //Buscamos al operador
            OperadorModel operadorActual=(from op in operadores
                                          where op.ConexionID==Context.ConnectionId
                                          select op).FirstOrDefault();
            if(operadorActual == null)
            {
                Clients.Caller.NoValidado();
            } else
            {
                //Obtenemos las colas que estan en marcha, desde la base de datos
                List<ServiciosModel> serviciosDisponibles = new List<ServiciosModel>();

                Clients.Caller.RespuestaColasDisponibles(serviciosDisponibles);
            }
        }
    
        public void SuscribirmeServicios(List<ServiciosModel> servicios)
        {
            //Buscamos al operador
            OperadorModel op = (from opr in operadores
                                where opr.ConexionID == Context.ConnectionId
                                select opr).FirstOrDefault();
            if(op==null)
            {
                Clients.Caller.NoValidado();
            } else
            {
                //Registramos los servicios disponibles
                op.ServiciosRegistrados.Clear();
                foreach(ServiciosModel srv in servicios)
                {
                    op.ServiciosRegistrados.Add(srv);
                }
                Clients.Caller.RespuestaServiciosRegistrados();
            }
        }

        public void GetCliente()
        {
            //Buscamos al operador
            OperadorModel op = (from opr in operadores
                                where opr.ConexionID == Context.ConnectionId
                                select opr).FirstOrDefault();
            if (op == null)
            {
                Clients.Caller.NoValidado();
            }
            else
            {
                //Obtenemos la cola de clientes del origen de datos, y le enviamos el primero que encuentre
                ClienteModel cliente = new ClienteModel();

                Clients.Caller.ClienteParaAtender(cliente);
            }
        }
    }
}