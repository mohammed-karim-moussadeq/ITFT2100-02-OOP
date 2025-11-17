// Author:  Kyle Chapman AND Karim El Moussadeq
// Created: October 1, 2025
// Updated: November 16, 2025
// Description:
// Code for a WPF form to display car objects. Currently, it is purely for
// display, and shows a car's make, model, year and price. Creating the car
// class to support the function of this program is meant as an exercise.
// Functionality should exist to move through the list of car objects.
// See the Car class (which you will create in a separate file!) for more details.

using CarViewer3;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarViewer3
{
    public partial class MainWindow : Window
    {
        // Use Vehicle list so it can hold Cars AND Motorcycles
        private List<Vehicle> listOfVehicles = new List<Vehicle>();
        private int currentIndex = 0;

        public MainWindow()
        {
            InitializedComponent();
            UpdateStatus("Application started");

            // Populate vehicle type selector
            ComboBoxMake.Items.Add("Car");
            ComboBoxMake.Items.Add("Motorcycle");

            // Populate years (last 50 years)
            for (int year = DateTime.Now.Year; year >= DateTime.Now.Year - 49; year--)
            {
                ComboBoxYear.Items.Add(year.ToString());
            }
        }

        private void InitializedComponent()
        {
            throw new NotImplementedException();
        }

        private void ButtonAddVehicle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string type = ComboBoxMake.Text;
                string model = ComboBoxModel.Text;

                // Check if year is selected
             
                string yearString = ComboBoxYear.SelectedItem?.ToString();
                if (string.IsNullOrWhiteSpace(yearString))
                {
                    throw new ArgumentNullException("Year must be selected");
                }
                int year = int.Parse(yearString);

                decimal price = decimal.Parse(TextBoxPrice.Text);
                bool isNew = false; // hook up to a CheckBox if you have one

                Vehicle vehicle;
                if (type == "Car")
                {
                    vehicle = new Car(type, model, year, price, isNew);
                }
                else
                {
                    vehicle = new Motorcycle(type, model, year, price, isNew, false);
                }

                // Add to Vehicle list
                listOfVehicles.Add(vehicle);

                // Show in ListBox (calls ToString())
                ListBoxVehicle.Items.Add(vehicle);

                UpdateStatus($"Added {vehicle.Type}: {vehicle.Model}");
                UpdateStatistics();
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                ComboBoxModel.Focus();
                UpdateStatus("Error: Model blank");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                TextBoxPrice.Focus();
                UpdateStatus("Error: Invalid price");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Please enter a valid price.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                TextBoxPrice.Focus();
                UpdateStatus("Error: Invalid price format");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                UpdateStatus("Error encountered");
            }
        }

        private void UpdateStatistics()
        {
            int count = listOfVehicles.Count;
            decimal total = listOfVehicles.Sum(vehicle => vehicle.Price);
            decimal average = count > 0 ? total / count : 0;

            LabelNumberOfVehicles.Content = $"Number Of Vehicles: {count}";
            LabelTotalPrice.Content = $"Total Price: {total:C}";
            LabelAveragePrice.Content = $"Average Price: {average:C}";
        }
        private void UpdateStatus(string message)
        {

        }


    }
}
