using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes___Objects.Vehicles
{
    public class Car : Vehicle
    {
        public override void Drive()
        {
            Console.WriteLine($"This is a {Brand} with a cool ass engine going at {Speed} km/h");
        }
    }
}
