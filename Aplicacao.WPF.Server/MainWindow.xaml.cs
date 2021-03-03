using Aplicacao.WPF.Server.hubs;
using Aplicacao.WPF.Server.service;
using Aplicacao.WPF.Server.Service;
using Aplicacao.WPF.Server.ViewModel;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using System.Windows;

namespace Aplicacao.WPF.Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IHubContext hubConnection;
        public MainWindow()
        {
            WebApp.Start<Startup>("http://localhost:8089");

            hubConnection = GlobalHost.ConnectionManager.GetHubContext<SenderMessageHub>();
            //ImageSenderViewModel imageSenderViewModel = ImageSenderViewModel.CreatedConnectedViewModel(new SignalRImageSenderService(hubConnection));
            ImageSenderViewModel imageSenderViewModel = ImageSenderViewModel.CreatedConnectedViewModel(hubConnection);

            this.DataContext = new MainViewModel(imageSenderViewModel);
            InitializeComponent();
        }
    
    }
}
