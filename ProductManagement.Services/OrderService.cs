using Microsoft.EntityFrameworkCore;
using ProductManagement.Core;
using ProductManagement.DataContext;

namespace ProductManagement.Services
{
    public class OrderService : IOrderService
    {
        ProductManagementDataContext _DataContext { get; }
        public OrderService(ProductManagementDataContext context) 
        {
            _DataContext = context;
        }
        public async Task<Order?> Get(int id) 
        {
            return await _DataContext.Orders.Include(p => p.OrderLineItems).Include(p => p.Customer).FirstOrDefaultAsync(p=>p.Id == id);
        }

        public async Task<int> Create(Order entity)
        {
            try
            {
                await _DataContext.AddAsync(entity);
                return await _DataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<int> Delete(Order entity)
        {
            try
            {
                return await _DataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<int> Update(Order entity)
        {
            try
            {
                _DataContext.Orders.Update(entity);
                return await _DataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<IEnumerable<Order?>> Get(int pageNumber, int pageSize)
        {
            try
            {
                return await _DataContext.Orders.Skip(pageNumber).Take(pageSize).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
