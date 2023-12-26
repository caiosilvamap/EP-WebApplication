using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estudos_de_Projetos.Repository
{
    interface IRepository<T> where T : class
    {
        Task<T> FindByIdAsync(int id);
        Task<IEnumerable<T>> FindAllAsync();
        Task AddAsync(T entity);
        Task EditAsync(T entity);
    }
}
