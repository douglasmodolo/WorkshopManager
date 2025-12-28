using WorkshopManager.Domain.Common;

namespace WorkshopManager.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public string Plate { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public string Color { get; private set; }
        public string? VIN { get; private set; } // Chassi
        public Guid CustomerId { get; private set; }

        public virtual Customer Customer { get; private set; } = null!;

        protected Vehicle() { }

        public Vehicle(string plate, string brand, string model, int year, string color, Guid customerId, string? vin = null)
        {
            if (string.IsNullOrWhiteSpace(plate)) throw new ArgumentException("Plate is required");
            if (year < 1900 || year > DateTime.Now.Year + 1) throw new ArgumentException("Invalid year");

            Plate = plate.ToUpper();
            Brand = brand;
            Model = model;
            Year = year;
            Color = color;
            CustomerId = customerId;
            VIN = vin;
        }
    }
}