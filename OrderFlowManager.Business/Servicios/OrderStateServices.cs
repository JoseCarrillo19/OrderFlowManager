using OrderFlowManager.Business.Interfaces;
using OrderFlowManager.Domain.Entities;
using OrderFlowManager.Domain.Interfaces;

namespace OrderFlowManager.Business.Servicios
{
    public class OrderStateServices: IOrderStateServices
    {
        private readonly IOrderStateRepository _repository;

        public OrderStateServices(IOrderStateRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddOrderAsync(Order order)
        {
            await _repository.AddAsync(order);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            await _repository.UpdateAsync(order);
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _repository.GetByIdAsync(id);
            if (order == null)
                throw new InvalidOperationException("Order not found.");

            await _repository.DeleteAsync(order);
        }

        public async Task<IEnumerable<Order>> GetOrdersByStateAsync(string state)
        {
            return await _repository.GetByStateAsync(state);
        }
    }
}
