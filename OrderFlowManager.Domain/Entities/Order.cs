using OrderFlowManager.Domain.Entities.States;
using OrderFlowManager.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFlowManager.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CurrentState { get; private set; } = "Pending";
        [NotMapped]
        public IOrderState State { get; private set; }

        public Order()
        {
            State = new PendingState(); 
        }

        public void Process() => State.Process(this);
        public void Ship() => State.Ship(this);
        public void Deliver() => State.Deliver(this);

        public void TransitionToState(IOrderState newState, string newStateName)
        {
            State = newState;
            CurrentState = newStateName;
        }
    }
}
