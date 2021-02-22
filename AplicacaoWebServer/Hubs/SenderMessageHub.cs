using AplicacaoWebServer.Domain;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace AplicacaoWebServer.Hubs
{
    public class SenderMessageHub: Hub
    {
        public async Task SendMessage(ImagemDto imagemDto)
        {
            await Clients.All.SendAsync("ReceiveImage",  imagemDto);
        }
    }
}
