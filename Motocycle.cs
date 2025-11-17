using CarViewer3;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CarViewer3
{

    /// Represents a motorcycle, which is a type of vehicle.
    /// Includes additional features such as a sidecar.

    public class Motorcycle : Vehicle
    {
        //  counter for generating unique IDs
        private static int id = 1;

        // Instance fields
        private int identificationNumber;
        private bool hasSidecar;


        /// Default constructor.
        public Motorcycle() : base()
        {
            identificationNumber = id++;
            hasSidecar = false;
        }


        /// Parametrized constructor.      
        public Motorcycle(string make, string model, int year, decimal price, bool isNew, bool hasSidecar)
            : base(make, model, year, price, isNew)
        {
            identificationNumber = id++;
            this.hasSidecar = hasSidecar;
        }

        /// Unique motorcycle identification number. 
        public int IdentificationNumber { get; private set; }


        public bool HasSidecar
        {
            get { return hasSidecar; }
            set { hasSidecar = value; }
        }


        /// Returns the type of vehicle.
        public override string Type => "Motorcycle";


        /// Returns the description of the motorcycle. 
        public override string ToString()
        {
            return $"#{identificationNumber} {Year} {Make} {Model} - {(IsNew ? "New" : "Used")} - ${Price}" +
                   $"{(hasSidecar ? " - With Sidecar" : "")}";
        }
    }
}

