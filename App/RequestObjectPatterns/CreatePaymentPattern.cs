﻿using System;

namespace App.RequestObjectPatterns
{
    public class CreatePaymentPattern : IControllerPattern
    {
        public UInt64 Value { get; set; }
        public string Sender { get; set; }
        public string Password { get; set; }
        public string PassPhrase { get; set; }
    }
}
