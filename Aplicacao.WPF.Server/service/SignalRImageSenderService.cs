using AplicacaoWebServer.Domain;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.WPF.Server.Service
{
    public class SignalRImageSenderService
    {
        private readonly IHubContext _hubConnection;
        public event Action<ImagemDto> ImageMessageReceived;
        public SignalRImageSenderService(IHubContext hubConnection)
        {
            _hubConnection = hubConnection;           
        }

        public async Task SendImageMessage(ImagemDto imagem)
        {
            ImageMessageReceived?.Invoke(imagem);
            //await _hubConnection.SendAsync("SendMessage", imagem);
            _hubConnection.Clients.All.SendMessage(imagem);
        }
    }
}
