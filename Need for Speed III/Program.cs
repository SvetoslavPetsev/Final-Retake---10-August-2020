using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Need_for_Speed_III
{
    public class Status
    {
        public int Mileage { get; set; }
        public int Fuel { get; set; }
        public Status(int mileage, int fuel)
        {
            this.Mileage = mileage;
            this.Fuel = fuel;
        }
    }
    class Program
    {
        static void Main()
        {

            Dictionary<string, Status> carList = new Dictionary<string, Status>();

            int numberCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberCars; i++)
            {
                string[] newCar = Console.ReadLine().Split("|");
                string name = newCar[0];
                int mileage = int.Parse(newCar[1]);
                int fuel = int.Parse(newCar[2]);
                Status newStatus = new Status(mileage, fuel);
                carList.Add(name, newStatus);
            }

            string input;
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] info = input.Split(" : ");
                string cmd = info[0];

                if (cmd == "Drive")
                {
                    string name = info[1];
                    int distance = int.Parse(info[2]);
                    int fuel = int.Parse(info[3]);

                    if (carList.ContainsKey(name))
                    {
                        if (carList[name].Fuel >= fuel)
                        {
                            carList[name].Fuel -= fuel;
                            carList[name].Mileage += distance;

                            Console.WriteLine($"{name} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                            if (carList[name].Mileage >= 100000)
                            {
                                carList.Remove(name);
                                Console.WriteLine($"Time to sell the {name}!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }
                    }
                }
                else if (cmd == "Refuel") //problem?
                {
                    string name = info[1];
                    int fuel = int.Parse(info[2]);

                    if (carList.ContainsKey(name))
                    {
                        if (carList[name].Fuel + fuel > 75)
                        {
                            fuel = 75 - carList[name].Fuel;
                        }
                        else if (carList[name].Fuel == 75)
                        {
                            fuel = 0;
                        }
                        carList[name].Fuel += fuel;
                        Console.WriteLine($"{name} refueled with {fuel} liters");
                    }
                }
                else if (cmd == "Revert")
                {
                    string name = info[1];
                    int kilometers = int.Parse(info[2]);

                    if (carList.ContainsKey(name))
                    {
                        carList[name].Mileage -= kilometers;
                        if (carList[name].Mileage < 10000)
                        {
                            carList[name].Mileage = 10000;
                        }
                        else
                        {
                            Console.WriteLine($"{name} mileage decreased by {kilometers} kilometers");
                        }
                    }
                }
            }

            foreach (var car in carList.OrderByDescending(x => x.Value.Mileage).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
        }
    }
}
