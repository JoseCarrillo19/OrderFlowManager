namespace OrderFlowManager.Business.Interfaces
{
    public interface IOrderService
    {
        Task ProcessOrderAsync(int id);
        Task ShipOrderAsync(int id);
        Task DeliverOrderAsync(int id);
    }
}
