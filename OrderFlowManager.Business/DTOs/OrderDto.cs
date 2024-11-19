using OrderFlowManager.Domain.Interfaces;

namespace OrderFlowManager.Business.DTOs
{
    public class OrderDto
    {
        public int? Id { get; set; }
        public string? CustomerName { get; set; }
        public string? CurrentState { get; set; }
        public IOrderState? State { get; set; }
    }

}
