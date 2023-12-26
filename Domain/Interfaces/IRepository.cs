using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
   public interface IRepository<T> where T : class
    {
        Task<T> FindByIdAsync(int id);
        Task<IEnumerable<T>> FindAllAsync();     
        Task EditAsync(T entity);
        Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate);
        Task<int> CreateAsync(T entity);
    }
}
