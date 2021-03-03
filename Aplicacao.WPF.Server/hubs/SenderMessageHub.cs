using AplicacaoWebServer.Domain;
using Microsoft.AspNet.SignalR;
using System;
using System.Threading.Tasks;

namespace Aplicacao.WPF.Server.hubs
{
    public class SenderMessageHub : Hub
    {
        public async Task SendMessage(ImagemDto imagemDto)
        {
            await Clients.All.sendMessage(imagemDto);
        }
      
    }
}
