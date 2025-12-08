using static System.Console;
using System.Security.Cryptography.X509Certificates;
using Classes___Objects.Vehicles;

namespace Classes___Objects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>()
            {
                new Car { Brand = "Volvo", Speed = 120 },
                new Bicycle { Brand = "BMW", Speed = 20 }
            };

            foreach (var vehicle in vehicles)
            {
                vehicle.Drive();  
            }
        }
    }
}
