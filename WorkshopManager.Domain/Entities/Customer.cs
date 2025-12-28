using WorkshopManager.Domain.Common;

namespace WorkshopManager.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string DocumentId { get; private set; } // CPF ou CNPJ

        private readonly List<Vehicle> _vehicles = new();
        public virtual IReadOnlyCollection<Vehicle> Vehicles => _vehicles.AsReadOnly();

        protected Customer() { }

        public Customer(string name, string email, string phoneNumber, string documentId)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            DocumentId = documentId;
        }
    }
}
