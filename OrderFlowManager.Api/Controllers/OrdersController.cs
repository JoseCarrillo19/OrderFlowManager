using Microsoft.AspNetCore.Mvc;
using OrderFlowManager.Business.Interfaces;

namespace OrderFlowManager.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("{id}/process")]
        public async Task<IActionResult> ProcessOrder(int id)
        {
            await _orderService.ProcessOrderAsync(id);
            return Ok("Order processed.");
        }

        [HttpPost("{id}/ship")]
        public async Task<IActionResult> ShipOrder(int id)
        {
            await _orderService.ShipOrderAsync(id);
            return Ok("Order shipped.");
        }

        [HttpPost("{id}/deliver")]
        public async Task<IActionResult> DeliverOrder(int id)
        {
            await _orderService.DeliverOrderAsync(id);
            return Ok("Order delivered.");
        }
    }
}
