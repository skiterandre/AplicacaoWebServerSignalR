namespace Aplicacao.WPF.Server.ViewModel
{
    public class MainViewModel
    {
        public ImageSenderViewModel ImageSenderViewModel { get; set; }

        public MainViewModel(ImageSenderViewModel imageSenderViewModel)
        {
            ImageSenderViewModel = imageSenderViewModel;
        }
    }
}
