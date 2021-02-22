using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.WPF.ViewModel
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
