using OrderFlowManager.Domain.Interfaces;

namespace OrderFlowManager.Domain.Entities.States
{
    public class ProcessingState : IOrderState
    {
        public void Process(Order order) =>
            throw new InvalidOperationException("Order is already being processed.");

        public void Ship(Order order)
        {
            order.TransitionToState(new ShippedState(), "Shipped");
        }

        public void Deliver(Order order) =>
            throw new InvalidOperationException("Cannot deliver an order that is not shipped.");
    }
}
