using ProductManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Services
{
    public interface ICrudService<T>
    {
        Task<T?> Get(int id);
        Task<IEnumerable<T?>> Get(int pageNumber, int pageSize);
        Task<int> Create(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
    }
}
