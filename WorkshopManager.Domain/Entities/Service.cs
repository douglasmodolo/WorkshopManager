using WorkshopManager.Domain.Common;

namespace WorkshopManager.Domain.Entities
{
    public class Service : BaseEntity
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int EstimatedTimeInMinutes { get; private set; }

        protected Service() { }

        public Service(string name, decimal price, int estimatedTimeInMinutes)
        {
            Name = name;
            Price = price;
            EstimatedTimeInMinutes = estimatedTimeInMinutes;
        }
    }
}
