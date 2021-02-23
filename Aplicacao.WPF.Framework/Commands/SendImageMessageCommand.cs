using Aplicacao.WPF.Framework.Service;
using Aplicacao.WPF.Framework.ViewModel;
using AplicacaoWebServer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Aplicacao.WPF.Framework.Commands
{
    public class SendImageMessageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly ImageSenderViewModel _viewModel;
        private readonly SignalRImageSenderService _imageSenderService;

        public SendImageMessageCommand(ImageSenderViewModel viewModel, SignalRImageSenderService imageSenderService)
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
                await _imageSenderService.SendImageMessage(new ImagemDto
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
