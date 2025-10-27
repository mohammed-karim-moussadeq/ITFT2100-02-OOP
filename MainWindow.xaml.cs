// Author:  Kyle Chapman AND Karim El Moussadeq
// (please don't leave the previous line saying "AND YOU".)
// Created: October 1, 2025
// Updated: 
// Description:
// Code for a WPF form to display car objects. Currently, it is purely for
// display, and shows a car's make, model, year and price. Creating the car
// class to support the function of this program is meant as an exercise.
// Functionality should exist to move through the list of car objects.
// See the Car class (which you will create in a separate file!) for more details.

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

namespace CarViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // "Global" or "class-level" variables, including a list for cars.
        // If there's an issue on this line, it means you haven't defined a Car class (which is the point of the exercise).
        List<Car> listOfCars = new List<Car>();
        int currentIndex = 0;
    
        /// <summary>
        /// Constructor for the form class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When the form loads, initialize the list of cars.
        /// </summary>
        private void FormLoad(object sender, RoutedEventArgs e)
        {
            // Create some default car objects.
            // You'll be encouraged to add a few more!
            // If these lines are in error, either the Car class is missing or there's an issue with its parametrized constructor.
            var carOne = new Car("Hyundai", "Tucson", 2020, 17500, true);
            var carTwo = new Car("Dodge", "Caliber", 2012, 11499, true);
            var carThree = new Car("Volkswagen", "Beetle", 1979, 5999, false);
            var carFour = new Car("Porsche", "992 911GT3 RS", 2023, 124000, true);
            var carFive = new Car("BMW", "M4", 2021, 69999, true);

            // Add the car objects into the list.
            // It's also technically possible to manage the list within the class.
            // Can you think of any positives or negatives of this?
            listOfCars.Add(carOne);
            listOfCars.Add(carTwo);
            listOfCars.Add(carThree);
            listOfCars.Add(carFour);
            listOfCars.Add(carFive);

            // Show the first car.
            DisplayCar(listOfCars[0]);

            // cars make
            string[] makes = { "Hyundai", "Dodge", "Volkswagen", "Porsche", "BMW", "Audi", "Toyota", "Ford", "Chevrolet", "Nissan", "Ferrari", "Bentley", "Lamborghini", "Rolls Roys", "Aston Martin", "Cadillac", "Alfa Romeo", "Maclaren", "Cupra", "Seat"};
            foreach (var make in makes)
            {
               comboMake.Items.Add(make);
            }

            // cars years
            for (int year = DateTime.Now.Year; year >= DateTime.Now.Year - 49; year--)
            {
                comboYear.Items.Add(year.ToString());
            }

           

        }

        /// <summary>
        /// Displays a car object in the form.
        /// </summary>
        /// <param name="currentCar">A valid car object.</param>
        private void DisplayCar(Car currentCar)
        {
            // If the method signature above has an error in it, the Car class doesn't exist.
            // If the lines below cause errors, then the Car class' properties aren't set up correctly.

            // Set form control properties based on values of the car passed in.
            comboMake.Text = currentCar.Make;
            textModel.Text = currentCar.Model;
            comboYear.Text = currentCar.Year.ToString();
            textPrice.Text = currentCar.Price.ToString();

        }

        /// <summary>
        /// Display the first car from the list in the form.
        /// </summary>
        private void ShowFirstCar(object sender, RoutedEventArgs e)
        {
            // Set the index to 0, and show it.
            currentIndex = 0;
            DisplayCar(listOfCars[currentIndex]);
            // Previous is disabled, Next is enabled.
            buttonPrevious.IsEnabled = false;
            buttonNext.IsEnabled = true;
        }

        /// <summary>
        /// Display the last car in the list in the form.
        /// </summary>
        private void ShowLastCar(object sender, RoutedEventArgs e)
        {
            // Set the index to the end of the list, and show it.
            currentIndex = listOfCars.Count - 1;
            DisplayCar(listOfCars[currentIndex]);
            // Next is disabled, Previous is enabled.
            buttonPrevious.IsEnabled = true;
            buttonNext.IsEnabled = false;
        }

        /// <summary>
        /// Display the previous car in the list in the form.
        /// </summary>
        private void ShowPreviousCar(object sender, RoutedEventArgs e)
        {
            // Reduce the current index by 1.
            currentIndex -= 1;
            // If the index is 0 (or less?), set it to 0 and disable Previous.
            if (currentIndex <= 0)
            {
                currentIndex = 0;
                buttonPrevious.IsEnabled = false;
            }
            // Display the car at this index and enable the Next button.
            DisplayCar(listOfCars[currentIndex]);
            buttonNext.IsEnabled = true;
        }

        /// <summary>
        /// Display the next car from the list in the form.
        /// </summary>
        private void ShowNextCar(object sender, RoutedEventArgs e)
        {
            // Increase the current index by 1.
            currentIndex += 1;
            // If at the end of the list, set the index to the maximum and disable Next.
            if (currentIndex >= listOfCars.Count - 1)
            {
                currentIndex = listOfCars.Count - 1;
                buttonNext.IsEnabled = false;
            }
            // Display the car at this index and enable the Previous button.
            DisplayCar(listOfCars[currentIndex]);
            buttonPrevious.IsEnabled = true;
        }

        private void buttonEnter_Click(object sender, RoutedEventArgs e)
        {
            // to chech if the fields are empty when a person tries to enter a car
            if (comboMake.SelectedIndex == -1 ||
           comboYear.SelectedIndex == -1 ||
           string.IsNullOrEmpty(textModel.Text) ||
           string.IsNullOrEmpty(textPrice.Text))
            {
                MessageBox.Show("Please fill in all fields before entering the car.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else {
                // validation for the entry of the new or used car
                    LabelResult.Content = "You have entered a " +
                        (checkIsNew.IsChecked == true ? "new " : "used ") +
                        comboYear.Text + " " +
                        comboMake.Text + " " +
                        textModel.Text + " for " +
                        textPrice.Text + ".";
            }


            // get the fields values
            string make = comboMake.Text;
            string model = textModel.Text;
            int year = int.Parse(comboYear.Text);
            bool isNew = checkIsNew.IsChecked ?? false;
            decimal price = decimal.Parse(textPrice.Text);

            // adding or updating cars in the list

            if ( listCars.SelectedIndex == -1 )

            {
                Car newCar = new Car(make, model, year, price, isNew);
                listOfCars.Add(newCar);

            }
            else
            {  Car excistingCar =  listOfCars[listCars.SelectedIndex];
                excistingCar.Make = make;
                excistingCar.Model = model;
                excistingCar.Year = year;
                excistingCar.Price = decimal.Parse(textPrice.Text);
                excistingCar.IsNew = isNew;
                LabelResult.Content = "Car is updated successfully.";
            }

            // refresh the listbox
            listCars.Items.Clear();
            foreach (var car in listOfCars)
            {
                // adding cars to the listbox
                listCars.Items.Add(
                     "#" + car.IdentificationNumber + " " +
                     car.Year + " " + car.Make + " " + car.Model + "  " +
                     (car.IsNew ? "New" : "Used") + "  " +
                     car.Price.ToString("C")
                 );

            }
        }

        // Reseting the inputs
        private void buttonReset_Click(object sender, RoutedEventArgs e)
        {
            comboMake.SelectedIndex = -1;
            comboYear.SelectedIndex = -1;
            textModel.Clear();
            textPrice.Clear();
            checkIsNew.IsChecked = false;
            LabelResult.Content = string.Empty;
            listCars.Items.Clear();




        }
        // Exit the application
        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}