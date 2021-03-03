using Aplicacao.WPF.Service;
using Aplicacao.WPF.ViewModel;
using Microsoft.AspNetCore.SignalR.Client;
using System.Windows;

namespace Aplicacao.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private const string URL_SIGNALR_SERVER = "http://localhost:8089/signalr/hubs";
        public MainWindow()
        {
            HubConnection hubConnection = new HubConnectionBuilder()
               .WithUrl(URL_SIGNALR_SERVER)
               .Build();

            ImageSenderViewModel imageSenderViewModel = ImageSenderViewModel.CreatedConnectedViewModel(new SignalRImageSenderService(hubConnection));


            this.DataContext = new MainViewModel(imageSenderViewModel);
            InitializeComponent();
        }
    }
}
