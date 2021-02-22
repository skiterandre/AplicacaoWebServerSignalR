using AplicacaoWebServer.Domain;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.WPF.Service
{
    public class SignalRImageSenderService
    {
        private readonly HubConnection _hubConnection;
        public event Action<ImagemDto> ImageMessageReceived;
        public SignalRImageSenderService(HubConnection hubConnection)
        {
            _hubConnection = hubConnection;
            _hubConnection.On<ImagemDto>("ReceiveImage", (imagemDto) => ImageMessageReceived?.Invoke(imagemDto));
        }

        public async Task Connect()
        {
            await _hubConnection.StartAsync();
        }

        public async Task SendImageMessage(ImagemDto imagem)
        {
            await _hubConnection.SendAsync("SendMessage", imagem);
        }
    }
}
