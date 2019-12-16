using CarDealer.Models;
using System.Collections.Generic;

namespace CarDealer.DTO.Export
{
    public class CarInfoDto
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public ICollection<Part> Parts { get; set; }
    }
}
