using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_009_13_09_2024
{
    public class Train
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public double RouteDuration { get; set; } 
        public int StationId { get; set; }
        public Station Station { get; set; }
    }
}
