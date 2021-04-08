using System;
using System.Collections.Generic;

namespace Lab5._3
{
    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        public Car()
        {
            Make = "Unknown";
            Model = "Unknown";
            Year = 0000;
            Price = 30000m;
        }
        public Car(string pMake, string pModel, int pYear, decimal pPrice)
        {
            Make = pMake;
            Model = pModel;
            Year = pYear;
            Price = pPrice;
        }

        public override string ToString()
        {
            return $"{Make}   \t{Model}\t                      {Year}\t\t${Price} ";
        }

    }
    class UsedCar : Car
    {
        public double Milage;

        public UsedCar(string make, string model, int year, decimal price, double milage)
        {
            Make = make;
            Model = model;
            Year = year;
            Price = price;
            Milage = milage;
        }
        public override string ToString()
        {
            return $"{Make}   \t{Model}\t                      {Year}\t\t${Price}\t\t(Used) {Milage} miles ";
        }
    }
    class CarLot
    {
        public List<Car> AvailableCars = new List<Car>();

        public void AddCar(Car newCar)
        {
            AvailableCars.Add(newCar);
        }

        public void RemoveCar(Car byeCar)
        {
            AvailableCars.Remove(byeCar);
            Console.WriteLine($"{byeCar.Make} {byeCar.Model} was removed\n");
        }

        public void ListCar()
        {
            foreach (Car vehicle in AvailableCars)
            {
                Console.WriteLine($"{AvailableCars.IndexOf(vehicle) + 1}. {vehicle}");
            }
            int add = AvailableCars.Count + 1;
            int quit = AvailableCars.Count + 2;
            Console.WriteLine($"{add}. Add a car");
            Console.WriteLine($"{quit}. Quit");

            bool valid = false;
            while (!valid)
            {
                Console.WriteLine("\nWhich car would you like to purchase, or would you like to add a car?");
                Console.Write("Please input a number from the available menu options: ");
                int response = 0;
                try
                {
                    response = Int32.Parse(Console.ReadLine());
                    valid = true;


                    if (response == quit)
                    {
                        Console.WriteLine("\nThank you for visiting, goodbye!\n");
                        valid = true;
                    }
                    else if (response == add)
                    {
                        Console.Write("What is the Make of your car?: ");
                        string make = Console.ReadLine();
                        Console.Write("What is the Model of your car?: ");
                        string model = Console.ReadLine();
                        Console.Write("What is the year of your car? (Please only enter in YYYY format): ");
                        int year = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("How many miles are on your car?: ");
                        int miles = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("What would you like to sell your car for?: ");
                        int price = Int32.Parse(Console.ReadLine());

                        if (miles == 0)
                        {
                            Car userCar = new Car(make, model, year, price);
                            AddCar(userCar);
                            Console.WriteLine($"\n{make} {model} has been added to Chelsea's Car Lot Inverntory.\n");
                            valid = true;
                            Console.WriteLine();
                            ListCar();
                        }
                        else
                        {
                            UsedCar userCar = new UsedCar(make, model, year, price, miles);
                            AddCar(userCar);
                            Console.WriteLine($"\n{make} {model} has been added to Chelsea's Car Lot Inverntory.\n");
                            valid = true;
                            Console.WriteLine();
                            ListCar();
                        }

                    }
                    else
                    {
                        bool valid2 = false;
                        while (!valid2)
                        {
                            Console.WriteLine($"\nYou selected:\n{AvailableCars[response - 1]}");
                            Console.Write("Would you like to purchase this vehicle? (y/n): ");
                            string answer = Console.ReadLine().ToLower();

                            if (answer == "y")
                            {
                                Console.WriteLine("\nExcellent! Our finance department will be in touch shortly...");
                                RemoveCar(AvailableCars[response - 1]);
                                ListCar();
                                valid2 = true;
                            }
                            else if (answer == "n")
                            {
                                Console.WriteLine("\nThat's okay, we'll bring you back to our main menu!\n\n");
                                valid2 = true;
                                ListCar();
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid Entry.\n");
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid Entry");
                    valid = false;
                }

            }


        }

        class Program
        {

            static void Main(string[] args)
            {
                Car newFord = new Car("Ford", "Focus", 2008, 2000m);
                Car newChevy = new Car("Chevy", "Blazer", 2020, 42000m);
                Car newJeep = new Car("Jeep", "Compass", 2021, 48000m);
                UsedCar usedChevy = new UsedCar("Chevy", "Cruze", 2016, 5600m, 89500);
                UsedCar usedDodge = new UsedCar("Dodge", "Ram", 2008, 2400m, 150866);
                UsedCar usedFord = new UsedCar("Ford", "F-150", 2016, 8450m, 65000);
                CarLot cars = new CarLot();
                cars.AddCar(newFord);
                cars.AddCar(newChevy);
                cars.AddCar(newJeep);
                cars.AddCar(usedChevy);
                cars.AddCar(usedDodge);
                cars.AddCar(usedFord);

                Console.WriteLine("welcome to Chelsea's Current Car Collection!");
                cars.ListCar();


            }



        }
    }
}
