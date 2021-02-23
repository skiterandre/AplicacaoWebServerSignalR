using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using fm = System.Windows.Forms;

namespace Aplicacao.WPF.Views
{
    /// <summary>
    /// Interaction logic for ImageSenderView.xaml
    /// </summary>
    public partial class ImageSenderView : UserControl
    {
        private fm.NotifyIcon trayIcon;
        public ImageSenderView()
        {
            InitializeComponent();
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            trayIcon = new fm.NotifyIcon();
            trayIcon.Icon = new Icon("Icons/Error.ico");
            trayIcon.Visible = true;
            trayIcon.BalloonTipText = "Teste Tray Icon";
            trayIcon.BalloonTipTitle = "Title";
            trayIcon.BalloonTipIcon = fm.ToolTipIcon.Info;
            trayIcon.ShowBalloonTip(2000);
            trayIcon.Click += ButtonMaximize_Click;
        }

        private void ButtonMaximize_Click(object sender, EventArgs e)
        {
            this.Visibility = Visibility.Visible;
            trayIcon.Visible = false;
        }
    }
}
