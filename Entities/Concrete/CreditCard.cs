using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public short Cvv { get; set; }
        public byte ValidThruMonth { get; set; }
        public byte ValidThruYear { get; set; }
    }
}
