
using BigSister;
using BigSisterServiceReference;
using System;

namespace WCFService1ClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int yearOfPurchased = 0;
            int yearOfTaxCalculation = 0;
            int traveledMiles = 0;

            BigSisterServiceClient bigSisterServiceClient = new BigSisterServiceClient();
            Console.WriteLine("What is type of your spaceship? Cargo/family");
            string spaceshipType = Console.ReadLine();   
            
            Console.WriteLine("Which year the spaceship was purchased?");
            int.TryParse(Console.ReadLine(), out yearOfPurchased);

            Console.WriteLine("Which is year of tax calculation? ");
            int.TryParse(Console.ReadLine(), out yearOfTaxCalculation);

            Console.WriteLine("How many  light miles are traveled?");
            int.TryParse(Console.ReadLine(), out traveledMiles);


            SpaceShip spaceShip;
            if (spaceshipType.ToLower() == "family")
            {
                spaceShip = new SpaceShipFamily(yearOfPurchased, yearOfTaxCalculation, traveledMiles);
            }
            else if (spaceshipType.ToLower() == "cargo")
            {
                spaceShip = new SpaceShipCargo(yearOfPurchased, yearOfTaxCalculation, traveledMiles);
            }
            else
            {
                spaceShip = null;
            }

            int calculatedPrice = 0;

            try
            {
                calculatedPrice = bigSisterServiceClient.CalculateSpaceShipPrice(spaceShip);
            }
            catch(Exception exception)
            {
                Console.WriteLine("Exception thrown - "+ exception.Message);
            }
            
            Console.WriteLine("BigSister tax:" + calculatedPrice.ToString());
        }
    }
}
