using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes___Objects.Vehicles
{
    public class Vehicle
    {
        public string Brand { get; set; }
        public int Speed { get; set; }

        public virtual void Drive()
        {
            Console.WriteLine($"This is a {Brand} going at {Speed} km/h");
        }
    }
}
