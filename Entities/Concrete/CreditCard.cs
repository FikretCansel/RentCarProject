using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard
    {
        public string CardHolderName { get; set; }
        public byte[] CardNumberHash { get; set; }
        public byte[] CardNumberSalt { get; set; }
        public int Cvv { get; set; }
        public int ValidThru { get; set; }
    }
}
