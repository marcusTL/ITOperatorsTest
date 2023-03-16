using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClassLib
{
    public class Car
    {
        private string _name;
        private string _origin;
        private string _year;
        private decimal? _miles_per_Gallon;
        private decimal? _cylinders;
        private decimal? _displacement;
        private decimal? _horsepower;
        private decimal? _weight_in_lbs;
        private decimal? _acceleration;

        public Car(string name, string origin, string year, decimal? miles_per_Gallon, decimal? cylinders, decimal? displacement, decimal? horsepower, decimal? weight_in_lbs, decimal? acceleration)
        {
            _name = name;
            _origin = origin;
            _year = year;
            _miles_per_Gallon = miles_per_Gallon;
            _cylinders = cylinders;
            _displacement = displacement;
            _horsepower = horsepower;
            _weight_in_lbs = weight_in_lbs;
            _acceleration = acceleration;
        }

        public string Name { get => _name; set => _name = value; }
        public string Origin { get => _origin; set => _origin = value; }
        public string Year { get => _year; set => _year = value; }
        [JsonPropertyName("Miles_per_Gallon")]
        public decimal? MilesPerGallon { get => _miles_per_Gallon; set => _miles_per_Gallon = value; }
        public decimal? Cylinders { get => _cylinders; set => _cylinders = value; }
        public decimal? Displacement { get => _displacement; set => _displacement = value; }
        public decimal? Horsepower { get => _horsepower; set => _horsepower = value; }
        [JsonPropertyName("Weight_in_lbs")]
        public decimal? WeightInLbs { get => _weight_in_lbs; set => _weight_in_lbs = value; }
        public decimal? Acceleration { get => _acceleration; set => _acceleration = value; }

        public override string ToString()
        {
            return $"Name: {_name}, Origin {_origin}, Year: {_year}, Miles per Gallon: {_miles_per_Gallon}, Cylinders: {_cylinders}," +
                $"Displacement: {_displacement}, Weight in lbs: {_weight_in_lbs}, Acceleration: {_acceleration}";
        }
    }
}
