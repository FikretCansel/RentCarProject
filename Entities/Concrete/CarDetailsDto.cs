using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class CarDetailsDto:IDto
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
    }
}
