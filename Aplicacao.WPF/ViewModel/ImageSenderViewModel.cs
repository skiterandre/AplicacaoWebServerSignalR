using Aplicacao.WPF.Commands;
using Aplicacao.WPF.Service;
using AplicacaoWebServer.Domain;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Aplicacao.WPF.ViewModel
{
    public class ImageSenderViewModel: ViewModelBase
    {
        public ICommand SendImageMessageCommand { get; }
        public ICommand ImportarImagemCommand { get; set; }
        private string _imagemSelecionada;
        public string ImagemSelecionada
        {
            get
            {
                return _imagemSelecionada;
            }
            set
            {
                _imagemSelecionada = value;
                OnPropertyChanged(nameof(ImagemSelecionada));
            }
        }


        private string _sender;
        private string _message;
        private byte[] _imagem;
        private string _senderReceived;
        private string _messageReceived;
        private byte[] _imagemReceived;
        private bool _isConnected;

        public string Sender
        {
            get
            {
                return _sender;
            }
            set
            {
                _sender = value;
                OnPropertyChanged(nameof(Sender));
            }
        }
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }
        public byte[] Imagem
        {
            get { return _imagem; }
            set
            {
                _imagem = value;
                OnPropertyChanged(nameof(Imagem));
            }
        }

        public string SenderReceived
        {
            get
            {
                return _senderReceived;
            }
            set
            {
                _senderReceived = value;
                OnPropertyChanged(nameof(SenderReceived));
            }
        }
        public string MessageReceived
        {
            get { return _messageReceived; }
            set
            {
                _messageReceived = value;
                OnPropertyChanged(nameof(MessageReceived));
            }
        }
        public byte[] ImagemReceived
        {
            get { return _imagemReceived; }
            set
            {
                _imagemReceived = value;
                OnPropertyChanged(nameof(ImagemReceived));
            }
        }
        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }
            set
            {
                _isConnected = value;
                OnPropertyChanged(nameof(IsConnected));
            }
        }


        private string _errorMessage = string.Empty;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

        public string ImageName { get; set; }

        public ImageSenderViewModel(SignalRImageSenderService signalRImageSenderService)
        {

            SendImageMessageCommand = new SendImageMessageCommand(this, signalRImageSenderService);
            ImportarImagemCommand = new RelayCommand(a => ImportarImagem_Click());
            signalRImageSenderService.ImageMessageReceived += SignalRImageSenderService_ImageMessageReceived;

        }

        private void ImportarImagem_Click()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;
            dlg.Multiselect = false;

            if (!dlg.ShowDialog().Value)
                return;

            ImagemSelecionada = dlg.FileName;   
            Imagem = File.ReadAllBytes(dlg.FileName);
        }

        private void SignalRImageSenderService_ImageMessageReceived(ImagemDto obj)
        {
            SenderReceived = obj.Sender;
            MessageReceived = obj.Message;
            ImagemReceived = obj.Imagem;
        }


        public static ImageSenderViewModel CreatedConnectedViewModel(SignalRImageSenderService chatService)
        {
            ImageSenderViewModel viewModel = new ImageSenderViewModel(chatService);

            chatService.Connect().ContinueWith(task =>
            {
                if (task.Exception != null)
                {
                    viewModel.ErrorMessage = "Unable to connect to color chat hub";
                }
            });

            return viewModel;
        }
    }
}
