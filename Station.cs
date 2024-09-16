using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_009_13_09_2024
{
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Train> Trains { get; set; }
    }
}
