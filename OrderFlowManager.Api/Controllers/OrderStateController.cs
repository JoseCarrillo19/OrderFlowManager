using Microsoft.AspNetCore.Mvc;
using OrderFlowManager.Business.Interfaces;
using OrderFlowManager.Domain.Entities;

namespace OrderFlowManager.Api.Controllers
{
    [ApiController]
    [Route("api/crud/orders")]
    public class OrderStateController : ControllerBase
    {
        private readonly IOrderStateServices _service;

        public OrderStateController(IOrderStateServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _service.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _service.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound(new { message = "Order not found" });

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] Order order)
        {
            await _service.AddOrderAsync(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] Order order)
        {
            var existingOrder = await _service.GetOrderByIdAsync(id);
            if (existingOrder == null)
                return NotFound(new { message = "Order not found" });

            existingOrder.CustomerName = order.CustomerName;
            await _service.UpdateOrderAsync(existingOrder);

            return Ok(existingOrder);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _service.DeleteOrderAsync(id);
            return Ok(new { message = "Order deleted successfully." });
        }

        [HttpGet("state/{state}")]
        public async Task<IActionResult> GetOrdersByState(string state)
        {
            var orders = await _service.GetOrdersByStateAsync(state);
            if (!orders.Any())
                return NotFound(new { message = "No orders found in this state" });

            return Ok(orders);
        }
    }
}
