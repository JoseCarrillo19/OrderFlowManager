using OrderFlowManager.Domain.Interfaces;

namespace OrderFlowManager.Domain.Entities.States
{
    public class PendingState : IOrderState
    {
        public void Process(Order order)
        {
            order.TransitionToState(new ProcessingState(), "Processing");
        }

        public void Ship(Order order) =>
            throw new InvalidOperationException("Cannot ship a pending order.");

        public void Deliver(Order order) =>
            throw new InvalidOperationException("Cannot deliver a pending order.");
    }
}
