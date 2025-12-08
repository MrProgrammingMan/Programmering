using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Classes___Objects.Vehicles
{
    public class Bicycle : Vehicle
    {
        public override void Drive()
        {
            Console.WriteLine($"This {Brand} is pedalling at {Speed} km/h, FUCKING SICKKKK");
        }
    }
}
