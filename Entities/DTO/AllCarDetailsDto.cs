using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class AllCarDetailsDto : CarDetailsDto
    {
        public List<CarImage> CarImages { get; set; }
    }
}
