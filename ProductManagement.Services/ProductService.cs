using Microsoft.EntityFrameworkCore;
using ProductManagement.Core;
using ProductManagement.DataContext;

namespace ProductManagement.Services
{
    public class ProductService : IProductService
    {
        ProductManagementDataContext _DataContext;
        public ProductService(ProductManagementDataContext context) 
        {
            _DataContext = context;
        }

        public async Task<IEnumerable<Product?>> Get(int pageNumber, int pageSize)
        {
            try
            {
                return await _DataContext.Products.Skip((pageNumber -1) * pageSize).Take(pageSize).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<int> Create(Product entity)
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

        public async Task<int> Delete(Product entity)
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

        public async Task<Product?> Get(int id)
        {
            try
            {
                return await _DataContext.Products.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> Update(Product entity)
        {
            try
            {
                entity.DateModified = DateTime.Now;
                _DataContext.Products.Update(entity);
             
                return await _DataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
