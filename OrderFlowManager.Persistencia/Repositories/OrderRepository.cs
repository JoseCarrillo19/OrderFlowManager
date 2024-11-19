using OrderFlowManager.Domain.Entities;
using OrderFlowManager.Domain.Entities.States;
using OrderFlowManager.Domain.Interfaces;
using OrderFlowManager.Persistencia.Data;

namespace OrderFlowManager.Persistencia.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order != null)
            {
                IOrderState newState = order.CurrentState switch
                {
                    "Pending" => new PendingState(),
                    "Processing" => new ProcessingState(),
                    "Shipped" => new ShippedState(),
                    "Delivered" => new DeliveredState(),
                    _ => throw new InvalidOperationException("Invalid state")
                };

                order.TransitionToState(newState, order.CurrentState);
            }

            return order;
        }


        public async Task SaveAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}
