using WorkshopManager.Domain.Common;
using WorkshopManager.Domain.Exceptions;

namespace WorkshopManager.Domain.Entities
{
    public class Service : BaseEntity
    {
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public decimal Price { get; private set; }
        public int EstimatedTimeInMinutes { get; private set; }

        protected Service() { }

        public Service(string name, decimal price, int estimatedTimeInMinutes, string? description = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new BusinessException("O nome do serviço é obrigatório.");

            if (price < 0)
                throw new BusinessException("O preço do serviço não pode ser negativo.");

            if (estimatedTimeInMinutes < 0)
                throw new BusinessException("O tempo estimado não pode ser negativo.");

            Name = name;
            Price = price;
            EstimatedTimeInMinutes = estimatedTimeInMinutes;
            Description = description;
        }
    }
}
