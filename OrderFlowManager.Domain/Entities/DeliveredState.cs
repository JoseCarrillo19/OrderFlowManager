using OrderFlowManager.Domain.Interfaces;

namespace OrderFlowManager.Domain.Entities
{
    public class DeliveredState : IOrderState
    {
        public void Process(Order order) =>
            throw new InvalidOperationException("Order has already been delivered.");

        public void Ship(Order order) =>
            throw new InvalidOperationException("Order has already been delivered.");

        public void Deliver(Order order) =>
            throw new InvalidOperationException("Order has already been delivered.");
    }
}
