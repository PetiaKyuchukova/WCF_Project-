using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BigSister
{
    public class BigSisterService : IBigSisterService
    {
        public int CalculateSpaceShipPrice(SpaceShip spaceShip)
        {
            int miliesTax = 0;
            int yearsTax = 0;

            if(spaceShip == null)
            {
                throw new ArgumentException("Invalid spaceship type!");
            }
            else if((spaceShip.lightMilesTraveled == 0)
            || (spaceShip.yearOfPurchase == 0)
            || (spaceShip.yearOfTaxCalculation == 0))
            {
                throw new ArgumentException("Invalid input!");
            }
            else if (!(spaceShip.yearOfPurchase < spaceShip.yearOfTaxCalculation))
            {
                throw new ArgumentException("Invalid value! Year of purchase must be smaller than year of tax calculation!");
            }
            else
            {
                miliesTax = (int)(spaceShip.lightMilesTraveled / 1000) * spaceShip.taxIncrease;
                yearsTax = (spaceShip.yearOfTaxCalculation - spaceShip.yearOfPurchase) * spaceShip.taxDeclines;
            }

            return spaceShip.initialTax + miliesTax - yearsTax;
        }
    }
}
