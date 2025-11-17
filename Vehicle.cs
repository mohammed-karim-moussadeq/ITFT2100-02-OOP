using System;

namespace CarViewer3
{
    /// <summary>
    /// Abstract base class representing a vehicle.
    /// </summary>
    public abstract class Vehicle
    {
        // counter for tracking number of created vehicles
        private static int count = 0;

        // Initialize make and model fields 
        private string make = string.Empty;
        private string model = string.Empty;
        private int year;
        private decimal price;
        private bool isNew;


        /// Default constructor.
        public Vehicle()
        {
            count++;
            Make = "Unknown";
            Model = "Unknown";   // valid (not empty)

            // Set to a safe year (avoids OutOfRange error)
            Year = DateTime.Now.Year;

            Price = 0;
            IsNew = false;
        }


        /// Parametrized constructor
        public Vehicle(string make, string model, int year, decimal price, bool isNew)
        {
            count++;

            Make = make;
            Model = model;   // triggers validation
            Year = year;     // triggers validation
            Price = price;   // triggers validation
            IsNew = isNew;
        }


        /// Gets or sets make

        public string Make
        {
            get { return make; }
            set { make = value; }
        }


        /// Gets or sets the model and Throws ArgumentNullException if blank.

        public string Model
        {
            get { return model; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Model cannot be empty.");
                }
                model = value;
            }
        }


        /// Gets or sets the year 

        public int Year
        {
            get { return year; }
            set
            {
                int currentYear = DateTime.Now.Year;
                int minYear = currentYear - 50;

                if (value < minYear || value > currentYear)
                {
                    throw new ArgumentOutOfRangeException(
                        $"Year must be between {minYear} and {currentYear}.");
                }

                year = value;
            }
        }


        /// Gets or sets the price 

        public decimal Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be negative.");
                }
                price = value;
            }
        }


        /// Gets or sets foe new vehicle

        public bool IsNew
        {
            get { return isNew; }
            set { isNew = value; }
        }


        /// Gets the total number of vehicles created.

        public static int Count
        {
            get { return count; }
        }


        /// Abstract property used for vehicle type.
        public abstract string Type { get; }


        /// Returns description of the vehicle.
        public override string ToString()
        {
            return $"{year} {make} {model} - {(isNew ? "New" : "Used")} - ${price}";
        }
    }
}
