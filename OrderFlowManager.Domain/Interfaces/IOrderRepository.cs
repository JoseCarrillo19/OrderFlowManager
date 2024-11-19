using OrderFlowManager.Domain.Entities;

namespace OrderFlowManager.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order?> GetByIdAsync(int id);
        Task SaveAsync(Order order);
    }
}
