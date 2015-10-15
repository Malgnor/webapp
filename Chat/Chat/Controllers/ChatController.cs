using Microsoft.Web.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Chat.Controllers
{
    public class ChatController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage Aceitar(string usuario)
        {
            var mc = new ManipuladorChat(usuario);
            HttpContext.Current.AcceptWebSocketRequest( mc );
            return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
        }


        class ManipuladorChat : WebSocketHandler
        {
            public string Usuario { get; set; }
            public static WebSocketCollection Clientes { get; set; }

            static ManipuladorChat()
            {
                Clientes = new WebSocketCollection();
            }

            public ManipuladorChat(string usuario)
            {
                this.Usuario = usuario;
            }

            public override void OnOpen()
            {
                Clientes.Add(this);
            }

            public override void OnMessage(string messagem)
            {
                Clientes.Broadcast(this.Usuario + " - " + messagem);
            }

        }
    }
}
