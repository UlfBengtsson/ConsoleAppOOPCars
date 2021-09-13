using System;
using System.Collections.Generic;

namespace ConsoleAppOOPCars
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car("525i","Blue", 2001, "V6");
            //myCar.Color = "Blue";

            //Console.WriteLine("Car color is: " + myCar.Color);

            Car dadsCar = new Car("C3","Silver");
            //dadsCar.Color = "Silver";

            List<Car> cars = new List<Car>();

            cars.Add(dadsCar);
            cars.Add(myCar);

            foreach (Car aCar in cars)
            {
                Console.WriteLine(aCar.Info());
            }

            Console.WriteLine(myCar.StartEngine());
            Console.WriteLine(dadsCar.StartEngine());

            foreach (Car aCar in cars)
            {
                Console.WriteLine(aCar.Drive());
            }
        }
    }
}
