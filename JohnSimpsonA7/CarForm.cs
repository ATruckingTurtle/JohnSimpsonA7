using JohnSimpsonA7.CarNameSpace;
using System.Text.Json;

namespace JohnSimpsonA7
{
    public partial class CarForm : Form
    {
        public List<Car>? Cars = new List<Car>();
        public CarForm()
        {
            InitializeComponent();
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
                Cars = JsonSerializer.Deserialize<List<Car>>(data);
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
            if (Cars.Count == 0)
            {
                CarDisplay.Items.Add("No Data Loaded");
            }
            else
            {
                foreach (var car in Cars)
                {
                    CarDisplay.Items.Add(
                        $"Make: {car.Make}, Model: {car.Model}, Price: {car.Price}, Mileage: {car.Mileage}, Color: {car.Color}");
                }
            }
            
        }

        private void FileButton_Click(object? sender, EventArgs e)
        {
            var folder = new OpenFileDialog();
            var result = folder.ShowDialog();
            if (result != DialogResult.OK) return;
            loadData(folder.FileName);
        }
    }
}
