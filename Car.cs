using System;

namespace CarViewer3
{

    /// Represents a car vehicle.

    public class Car : Vehicle
    {
        // Static counter for assigning unique IDs to each car
        private static int id = 1;

        // Unique identification number for each car
        private int identificationNumber;


        /// Default constructor.

        public Car() : base()
        {
            identificationNumber = id++;
        }

        /// Parametrized constructor.

        public Car(string make, string model, int year, decimal price, bool isNew)
            : base(make, model, year, price, isNew)
        {
            identificationNumber = id++;
        }


        /// Gets the unique identification number of the car.
        public int IdentificationNumber { get; private set; }


        /// Returns the type of this vehicle.
        public override string Type => "Car";


        /// Returns description of the car.

        public override string ToString()
        {
            return $"#{identificationNumber} {Year} {Make} {Model} - {(IsNew ? "New" : "Used")} - ${Price}";
        }
    }
}
