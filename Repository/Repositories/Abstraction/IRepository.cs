using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Abstraction
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsync();
        Task<T> DetailsById(int? id);
        Task<bool> AddAsync(T item);
        Task<bool> Update(T item);
        Task<bool> DeleteAsync(T item);
    }
}
