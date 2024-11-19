using OrderFlowManager.Domain.Interfaces;

namespace OrderFlowManager.Domain.Entities.States
{
    public class ShippedState : IOrderState
    {
        public void Process(Order order) =>
            throw new InvalidOperationException("Order has already been processed.");

        public void Ship(Order order) =>
            throw new InvalidOperationException("Order has already been shipped.");

        public void Deliver(Order order)
        {
            order.TransitionToState(new DeliveredState(), "Delivered");
        }
    }
}
