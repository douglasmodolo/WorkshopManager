namespace WorkshopManager.Domain.Enums
{
    public enum ServiceOrderStatus
    {
        Draft = 1,            // Rascunho / Orçamento inicial
        PendingApproval = 2,  // Aguardando aprovação do cliente
        InProgress = 3,       // Em andamento / Mecânico trabalhando
        Completed = 4,        // Finalizada (Gera financeiro e baixa estoque)
        Cancelled = 5         // Cancelada
    }
}
