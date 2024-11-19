using OrderFlowManager.Domain.Entities;

namespace OrderFlowManager.Domain.Interfaces
{
    public interface IOrderState
    {
        void Process(Order order);
        void Ship(Order order);
        void Deliver(Order order);
    }

}
