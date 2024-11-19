using OrderFlowManager.Domain.Entities;

namespace OrderFlowManager.Domain.Interfaces
{
    public interface IOrderStateRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(Order order);
        Task<IEnumerable<Order>> GetByStateAsync(string state);
    }
}
