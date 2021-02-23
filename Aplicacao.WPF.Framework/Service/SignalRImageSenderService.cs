using AplicacaoWebServer.Domain;
using Microsoft.AspNet.SignalR.Client;
using System;

using System.Threading.Tasks;

namespace Aplicacao.WPF.Framework.Service
{
    public class SignalRImageSenderService
    {
        private readonly HubConnection _hubConnection;
        private readonly IHubProxy _hubProxy;
        public event Action<ImagemDto> ImageMessageReceived;
        public SignalRImageSenderService(HubConnection hubConnection)
        {
            _hubConnection = hubConnection;
            _hubProxy = _hubConnection.CreateHubProxy("sendMessageHub");            
            _hubProxy.On<ImagemDto>("ReceiveImage", (imagemDto) => ImageMessageReceived?.Invoke(imagemDto));
        }

        public async Task Connect()
        {
           await  _hubConnection.Start();
        }

        public async Task SendImageMessage(ImagemDto imagem)
        {
            await _hubConnection.Start();
            await _hubProxy.Invoke("SendMessage", imagem);
        }
    }
}
