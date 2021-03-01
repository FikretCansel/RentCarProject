using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Model:IEntity
    {
        public int Id { get; set; }
        public int Year { get; set; }
    }
}
