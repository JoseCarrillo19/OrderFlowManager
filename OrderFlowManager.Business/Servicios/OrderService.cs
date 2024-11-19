using OrderFlowManager.Business.Interfaces;
using OrderFlowManager.Domain.Interfaces;

namespace OrderFlowManager.Business.Servicios
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task ProcessOrderAsync(int id)
        {
            var order = await _repository.GetByIdAsync(id)
                         ?? throw new InvalidOperationException("Order not found.");
            order.Process();
            await _repository.SaveAsync(order);
        }

        public async Task ShipOrderAsync(int id)
        {
            var order = await _repository.GetByIdAsync(id)
                         ?? throw new InvalidOperationException("Order not found.");
            order.Ship();
            await _repository.SaveAsync(order);
        }

        public async Task DeliverOrderAsync(int id)
        {
            var order = await _repository.GetByIdAsync(id)
                         ?? throw new InvalidOperationException("Order not found.");
            order.Deliver();
            await _repository.SaveAsync(order);
        }
    }
}
