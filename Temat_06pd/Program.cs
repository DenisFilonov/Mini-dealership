using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temat_06pd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    Car car = new Car(" ","","","","",2,1,1,"C");
            //    car.Show();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error: {ex.Message}"); // не показало эксепшн
            //}

            Operations a = new Operations();
            a.AddCar(new Car());
            a.AddCar(new Car("Peugeot", "2008", "Crossover", "Manual Transmission", "Grey", 11500, 230, 2010, "J"));
            a.AddCar(new Car("KIA", "RIO", "Hatchback", "Manual Transmission", "Red", 6500, 200, 2005, "B"));

            //a.ShowCars();
            //a.SortCarsByPrice();

            //a.SortCarsByName();
            //a.ShowCars();

            a.DelCar(2);
            a.ShowCars();

            Console.ReadKey();
        }
    }
}
