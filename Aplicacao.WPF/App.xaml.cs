using Aplicacao.WPF.Service;
using Aplicacao.WPF.ViewModel;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Aplicacao.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private const string URL_SIGNALR_SERVER = "http://localhost:5000/sendMessageHub";

        protected override void OnStartup(StartupEventArgs e)
        {

            HubConnection hubConnection = new HubConnectionBuilder()
                .WithUrl(URL_SIGNALR_SERVER)
                .Build();

            ImageSenderViewModel imageSenderViewModel = ImageSenderViewModel.CreatedConnectedViewModel(new SignalRImageSenderService(hubConnection));


            MainWindow window = new MainWindow
            {
                DataContext = new MainViewModel(imageSenderViewModel)
            };


            window.Show();
        }
    }
}
