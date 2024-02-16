using System;
using System.Collections.Generic;

namespace pd4task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Ship> ships = new List<Ship>();
            int option;
            do
            {
                Console.Clear();
                option = Menu();
                if (option == 1)
                {
                    AddShip(ships);
                }
                if (option == 2)
                {
                    ViewShip(ships);
                }
                if (option == 3)
                {
                    Serial(ships);
                }
                if (option == 4)
                {
                    Update(ships);
                }
            } while (option != 5);

        }

        static int Menu()
        {
            Console.WriteLine("1. Add Ship");
            Console.WriteLine("2. View Ship Position");
            Console.WriteLine("3. View Ship Serial number");
            Console.WriteLine("4. Change Ship Position");
            Console.WriteLine("5. Exit:");
            int ch = int.Parse(Console.ReadLine());
            return ch;
        }

        static void AddShip(List<Ship> ships)
        {
            Console.WriteLine("Enter Ship Number: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Ship Latitude: ");
            Console.WriteLine("Enter Latitude’s Degree: ");
            int deg = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Latitude’s Minute: ");
            float latmin = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Latitude’s Direction: ");
            char dire = char.Parse(Console.ReadLine());
            Console.WriteLine("Enter Longitude’s Degree: ");
            int londeg = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Longitude’s Minute: ");
            float longmin = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Longitude’s Direction: ");
            char longdire = char.Parse(Console.ReadLine());
            Ship ship = new Ship(name, deg, latmin, dire, londeg, longmin, longdire);
            ships.Add(ship);
            Console.WriteLine("Ship added successfully.");
        }

        static void ViewShip(List<Ship> ships)
        {
            Console.WriteLine("Enter Ship Number: ");
            string no = Console.ReadLine();
            Ship shipp = null;
            foreach (Ship ship in ships)
            {
                if (ship.Name == no)
                {
                    shipp = ship;
                    break;
                }
            }
            if (shipp != null)
            {
                Console.WriteLine($"Ship Number: {shipp.Name}");
                Console.WriteLine($"Latitude: {shipp.Latitude.Degrees}°{shipp.Latitude.Minutes}' {shipp.Latitude.Direction}");
                Console.WriteLine($"Longitude: {shipp.Longitude.Degrees}°{shipp.Longitude.Minutes}' {shipp.Longitude.Direction}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Ship not found.");
                Console.ReadKey();
            }
        }

        static void Serial(List<Ship> ships)
        {
            Console.WriteLine("Enter the ship latitude: ");
            Angle longitude = GetAngleFromUser();
            Console.WriteLine("Enter the ship longitude: ");
            Angle latitude = GetAngleFromUser();
            foreach (Ship ship in ships)
            {
                if (latitude.Equals(ship.Latitude) && longitude.Equals(ship.Longitude))
                {
                    Console.WriteLine($"Ship found at {ship.Latitude.Degrees}°{ship.Latitude.Minutes}' {ship.Latitude.Direction} and {ship.Longitude.Degrees}°{ship.Longitude.Minutes}' {ship.Longitude.Direction}");
                    Console.ReadKey();
                    return;
                }
            }
            Console.WriteLine("Ship not found."); 
            Console.ReadKey();
        }

        static Angle GetAngleFromUser()
        {
            Console.WriteLine("Enter Degrees: ");
            int degrees = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Minutes: ");
            float minutes = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Direction (N, S, E, W): ");
            char direction = char.Parse(Console.ReadLine());
            return new Angle(degrees, minutes, direction);
        }

        static void Update(List<Ship> ships)
        {
            Console.WriteLine("Enter serial number: ");
            string serialNumber = Console.ReadLine();

            Ship shipToUpdate = null;

            foreach (Ship ship in ships)
            {
                if (ship.Name == serialNumber)
                {
                    shipToUpdate = ship;
                    break;
                }
            }
            if (shipToUpdate != null)
            {
                Console.WriteLine("Enter new Latitude: ");
                Angle newLatitude = GetAngleFromUser();
                Console.WriteLine("Enter new Longitude: ");
                Angle newLongitude = GetAngleFromUser();
                shipToUpdate.Latitude = newLatitude;
                shipToUpdate.Longitude = newLongitude;
                Console.WriteLine($"Ship {serialNumber} updated successfully.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Ship not found.");
                Console.ReadKey();
            }
        }
    }
}
