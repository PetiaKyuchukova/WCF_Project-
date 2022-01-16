using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BigSister
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IBigSisterService
    {
        [OperationContract]
        int CalculateSpaceShipPrice(SpaceShip spaceShip);

    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "BigSister.ContractType".

    [DataContract]
    [KnownType(typeof(SpaceShipCargo))]
    [KnownType(typeof(SpaceShipFamily))]
    public abstract class SpaceShip
    {
        public SpaceShip()
        { }
        public SpaceShip(int yearOfPurchase, int yearOfTaxCalculation, int lightMilesTraveled)
        {
            this.yearOfPurchase = yearOfPurchase;
            this.yearOfTaxCalculation = yearOfTaxCalculation;
            this.lightMilesTraveled = lightMilesTraveled;
        }
        [DataMember]
        public abstract int initialTax { get; set;  }
        [DataMember]
        public abstract int taxIncrease { get; set; }
        [DataMember]
        public abstract int taxDeclines { get;set;}
        [DataMember]
        public int yearOfPurchase { get; set; }
        [DataMember]
        public int yearOfTaxCalculation { get; set; }
        [DataMember]
        public int lightMilesTraveled { get; set; }
    }

    [DataContract]
    [KnownType(typeof(SpaceShip))]
    public class SpaceShipCargo : SpaceShip
    {
        public SpaceShipCargo()
        { }
        public SpaceShipCargo(int yearOfPurchase, int yearOfTaxCalculation, int lightMilesTraveled)
        {
            this.yearOfPurchase = yearOfPurchase;
            this.yearOfTaxCalculation = yearOfTaxCalculation;
            this.lightMilesTraveled = lightMilesTraveled;
        }

        [DataMember]
        public override int initialTax { get { return 10000; } set { _initialTax = value; } }
        private int _initialTax;

        [DataMember]
        public override int taxIncrease { get { return 1000; } set { _taxIncrease = value; } }
        private int _taxIncrease;

        [DataMember]
        public override int taxDeclines { get { return 736; } set { _taxDeclines = value; } }
        private int _taxDeclines;
    }

    [DataContract]
    [KnownType(typeof(SpaceShip))]
    public class SpaceShipFamily : SpaceShip
    {
        public SpaceShipFamily()
        { }
        public SpaceShipFamily(int yearOfPurchase, int yearOfTaxCalculation, int lightMilesTraveled)
        {
            this.yearOfPurchase = yearOfPurchase;
            this.yearOfTaxCalculation = yearOfTaxCalculation;
            this.lightMilesTraveled = lightMilesTraveled;
        }

        [DataMember]
        public override int initialTax { get { return 5000; } set { _initialTax = value; } }
        private int _initialTax;

        [DataMember]
        public override int taxIncrease { get { return 100; } set { _taxIncrease = value; } }
        private int _taxIncrease;

        [DataMember]
        public override int taxDeclines { get { return 355; } set { _taxDeclines = value; } }
        private int _taxDeclines;

    }

}


