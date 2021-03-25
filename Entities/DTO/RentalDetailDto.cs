using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class RentalDetailDto:IDto
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string FirstAndLastName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int TotalRentPrice { get; set; }
    }
}
