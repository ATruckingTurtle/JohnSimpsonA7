using JohnSimpsonA7.CarNameSpace;
using System.Text.Json;
using JohnSimpsonA7.CarComparer;

namespace JohnSimpsonA7
{
    public partial class CarForm : Form
    {
        public List<Car>? Car = [];
        public CarForm()
        {
            InitializeComponent();
            DisplayCars();
        }
        /// <summary>
        /// should only enable buttons if data is present 
        /// </summary>
        private void SetButton()
        {
            if (Car != null) SortMake.Enabled = (Car.Count > 0);
            if (Car != null) SortMakeAndPrice.Enabled = (Car.Count > 0);
        }

        /// <summary>
        /// Loads the data.  takes the data and sends it to next method display car
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public void LoadData(string fileName)
        {
            try
            {
                var data = File.ReadAllText(fileName);
                Car = JsonSerializer.Deserialize<List<Car>>(data);
                DisplayCars();
            }
            catch (Exception ea)
            {
                MessageBox.Show($@"Error loading file: {ea.Message}");
            }
        }

        /// <summary>
        /// Displays the cars or displays "no data loaded"
        /// </summary>
        private void DisplayCars()
        {
            CarDisplay.Items.Clear();
            if (Car is { Count: 0 })
            {
                CarDisplay.Items.Add("No Data Loaded");
            }
            else
            {
                if (Car == null) return;
                foreach (var car in Car)
                {
                    CarDisplay.Items.Add(
                        $"Make: {car.Make}, Model: {car.Model}, Price: {car.Price}, Mileage: {car.Mileage}, Color: {car.Color}");
                }
            }
            
        }

        /// <summary>
        /// Files the button click. Opens up the dialog to find the right file, and sends it to another function to read the data.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FileButton_Click(object? sender, EventArgs e)
        {
            var folder = new OpenFileDialog();
            var result = folder.ShowDialog();
            if (result != DialogResult.OK) return;
            LoadData(folder.FileName);
        }

        /// <summary>
        /// Sorts the make click.  Button when clicked sorts vehicles Alphabetically by make.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SortMake_Click(object? sender, EventArgs e)
        {
            if (Car is { Count: > 0 }) {

                try
                {
                    if (Car != null) Car.Sort();
                    DisplayCars();
                }

                catch (Exception ea)
                {
                    MessageBox.Show($@"Error comparing: {ea.Message}");
                }
            }
            else
            {
                MessageBox.Show(@"Please add data before clicking this.", @"Low Data Error");
            }
        }

        /// <summary>
        /// Button to sort the car make and price.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortMakeAndPrice_Click(object sender, EventArgs e)
        {
            if (Car is { Count: > 0 })
            {
                Car?.Sort(new CarMakePriceComparison());
                DisplayCars();
            }
            else
            {
                MessageBox.Show(@"Please add data before clicking this.", @"Low Data Error");
            }
        }

    }
}
