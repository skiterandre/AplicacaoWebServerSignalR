using Aplicacao.WPF.Framework.Service;
using Aplicacao.WPF.Framework.ViewModel;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Aplicacao.WPF.Framework
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string URL_SIGNALR_SERVER = "http://localhost:5000/";

        protected override void OnStartup(StartupEventArgs e)
        {

            HubConnection hubConnection = new HubConnection(URL_SIGNALR_SERVER);

            ImageSenderViewModel imageSenderViewModel = ImageSenderViewModel.CreatedConnectedViewModel(new SignalRImageSenderService(hubConnection));


            MainWindow window = new MainWindow
            {
                DataContext = new MainViewModel(imageSenderViewModel)
            };

            window.Show();
        }
    }
}
