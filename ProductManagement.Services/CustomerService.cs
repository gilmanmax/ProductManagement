using Microsoft.EntityFrameworkCore;
using ProductManagement.Core;
using ProductManagement.DataContext;

namespace ProductManagement.Services
{
    public class CustomerService : ICustomerService
    {
        ProductManagementDataContext _DataContext { get;}
        public CustomerService(ProductManagementDataContext context)
        {
            _DataContext = context;
        }
        public async Task<int> Create(Customer entity)
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

        public async Task<int> Delete(Customer entity)
        {
            try
            {
                _DataContext.Remove(entity);
                return await _DataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<Customer?> Get(int id)
        {
            try
            {
                return await _DataContext.Customer.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> Update(Customer entity)
        {
            try
            {
                _DataContext.Update(entity);
                return await _DataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<IEnumerable<Customer?>> Get(int pageNumber, int pageSize)
        {
            try
            {
                return await _DataContext.Customer.Skip(pageNumber).Take(pageSize).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
