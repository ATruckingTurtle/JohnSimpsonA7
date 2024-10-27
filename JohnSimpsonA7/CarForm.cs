using JohnSimpsonA7.CarNameSpace;
using System.Text.Json;
using JohnSimpsonA7.CarComparer;

namespace JohnSimpsonA7
{
    public partial class CarForm : Form
    {
        public List<Car>? car = new List<Car>();
        public CarForm()
        {
            InitializeComponent();
            displayCars();
        }


        /// <summary>
        /// Loads the data.  takes the data and sends it to next method display car
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public void loadData(string fileName)
        {
            try
            {
                var data = File.ReadAllText(fileName);
                car = JsonSerializer.Deserialize<List<Car>>(data);
                displayCars();
            }
            catch (Exception ea)
            {
                MessageBox.Show($@"Error loading file: {ea.Message}");
            }
        }

        /// <summary>
        /// Displays the cars or displays "no data loaded"
        /// </summary>
        private void displayCars()
        {
            CarDisplay.Items.Clear();
            if (car.Count == 0)
            {
                CarDisplay.Items.Add("No Data Loaded");
            }
            else
            {
                foreach (var car in car)
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
            loadData(folder.FileName);
        }

        /// <summary>
        /// Sorts the make click.  Button when clicked sorts vehicles Alphabetically by make.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SortMake_Click(object? sender, EventArgs e)
        {
            try
            {
                if (car != null) car.Sort();
                displayCars();
            }

            catch (Exception ea)
            {
                MessageBox.Show($@"Error comparing: {ea.Message}");
            }
        }

        private void SortMakeAndPrice_Click(object sender, EventArgs e)
        {
            car.Sort(new CarMakePriceComparison());
            displayCars();
        }

    }
}
