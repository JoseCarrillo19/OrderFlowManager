using Microsoft.EntityFrameworkCore;
using OrderFlowManager.Domain.Entities;
using OrderFlowManager.Domain.Interfaces;
using OrderFlowManager.Persistencia.Data;

namespace OrderFlowManager.Persistencia.Repositories
{
    public class OrderStateRepository: IOrderStateRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderStateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetByStateAsync(string state)
        {
            return await _context.Orders
                .Where(order => order.CurrentState == state)
                .ToListAsync();
        }
    }
}
