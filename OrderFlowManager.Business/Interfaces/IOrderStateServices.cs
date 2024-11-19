using OrderFlowManager.Domain.Entities;

namespace OrderFlowManager.Business.Interfaces
{
    public interface IOrderStateServices
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(int id);
        Task AddOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int id);
        Task<IEnumerable<Order>> GetOrdersByStateAsync(string state);
    }
}
