using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarViewer
{
    internal class Car
    {
        private static int id = 0;
        // Fields
        private string make;
        private string model;
        private int year;
        private decimal price;
        private bool isNew;
        private int identificationNumber;
        /// <summary>
        /// default constructor
        /// </summary>
        public Car()
        { 
            identificationNumber = id++;
            make = "Unknown";
            model = "Unknown";
            year = 0;
            price = 0.0m;
            isNew = false;
        }

        // Parametrized constructor
        public Car(string make, string model, int year, decimal price, bool isNew)
        {
            identificationNumber = id++;
            this.make = make;
            this.model = model;
            this.year = year;
            this.price = price;
            this.isNew = isNew;
        }

        public Car(string make, string model, int year, bool isNew, decimal price)
        {
            this.make = make;
            this.model = model;
            this.year = year;
            this.isNew = isNew;
            this.price = price;
            
        }

        /// <summary>
        ///  get and set make of the car
        /// </summary>
        public string Make
        {
            get { return make; }
            set { make = value; }
        }
        /// <summary>
        /// to get and set model of the car
        /// </summary>
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        /// <summary>
        /// set and get year of the car
        /// </summary>
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        /// <summary>
        /// set and get price of the car
        /// </summary>
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
        /// <summary>
        /// get and set if the car is new or not
        /// </summary>
        public bool IsNew
        {
            get { return isNew; }
            set { isNew = value; }

        }


        /// <summary>
        /// get and sets identification number of the car
        /// </summary>
        public int IdentificationNumber
        {
            get { return identificationNumber; }
            set { identificationNumber = value; }
        }

        public override string ToString()
        {
            return $"{year} {make} {model} - {(isNew ? "New" : "Used")} - ${price}";
        }



    }
}
