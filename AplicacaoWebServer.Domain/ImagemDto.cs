﻿using System;

namespace AplicacaoWebServer.Domain
{
    public class ImagemDto
    {
        public string Sender { get; set; }
        public string Message { get; set; }
        public byte[] Imagem { get; set; }
    }

}
