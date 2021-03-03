using Aplicacao.WPF.Server.Service;
using Aplicacao.WPF.Server.ViewModel;
using AplicacaoWebServer.Domain;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Aplicacao.WPF.Server.Commands
{
    public class SendImageMessageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly ImageSenderViewModel _viewModel;
        private readonly IHubContext _imageSenderService;

        public SendImageMessageCommand(ImageSenderViewModel viewModel, IHubContext imageSenderService)
        {
            _viewModel = viewModel;
            _imageSenderService = imageSenderService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                await _imageSenderService.Clients.All.SendMessage(new ImagemDto
                {
                    Sender = _viewModel.Sender,
                    Message = _viewModel.Message,
                    Imagem = _viewModel.Imagem
                });
            }
            catch (Exception ex)
            {

                _viewModel.ErrorMessage = "Unable to send Image message." + ex.Message;
            }

        }
    }
}
