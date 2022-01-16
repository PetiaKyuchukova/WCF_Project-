using BigSister;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BigSisterUnitTest
{
    [TestClass]
    public class BigSisterUnitTest
    {
        [TestMethod]
        public void CalculateSpaceShipPrice_InvalidYears()
        {
            BigSisterService bigSister = new BigSisterService();
            SpaceShip spaceShipCargo = new SpaceShipCargo(5000, 3001, 2000);

            Assert.ThrowsException<ArgumentException>(() => bigSister.CalculateSpaceShipPrice(spaceShipCargo));
        }

        [TestMethod]
        public void CalculateSpaceShipPrice_OK()
        {
            BigSisterService bigSister = new BigSisterService();
            SpaceShip spaceShipCargo = new SpaceShipCargo(3000, 3001, 2000);
            const int expectedResult = 11264;
            int result = bigSister.CalculateSpaceShipPrice(spaceShipCargo);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CalculateSpaceShipPrice_InvalidSpaceShipType()
        {
            BigSisterService bigSister = new BigSisterService();
            SpaceShip spaceShipCargo = null;

            Assert.ThrowsException<ArgumentException>(() => bigSister.CalculateSpaceShipPrice(spaceShipCargo));
        }

        [TestMethod]
        public void CalculateSpaceShipPrice_InvalidParams()
        {
            BigSisterService bigSister = new BigSisterService();
            SpaceShip spaceShipCargo = new SpaceShipCargo(0, 0, 0);

            Assert.ThrowsException<ArgumentException>(() => bigSister.CalculateSpaceShipPrice(spaceShipCargo));
        }
    }
}
