using System.Text.Json.Serialization;

namespace JohnSimpsonA7.CarNameSpace
{
    public class Car : IComparable<Car>
    {

        [JsonPropertyName("make")]
        public required string Make { get; set; }
        [JsonPropertyName("model")]
        public required string Model { get; set; }
        [JsonPropertyName("year")]
        public required int Year { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [JsonPropertyName("color")]
        public required string Color { get; set; }
        [JsonPropertyName("cylinders")]
        public int Cylinders { get; set; }
        [JsonPropertyName("mileage")]
        public int Mileage { get; set; }

        public int CompareTo(Car? other)
        {
            if (other == null) return 1;
            return string.Compare(this.Make, other.Make, StringComparison.OrdinalIgnoreCase);
        }
    }
}
