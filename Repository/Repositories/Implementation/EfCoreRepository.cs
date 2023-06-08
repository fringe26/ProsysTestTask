using Microsoft.EntityFrameworkCore;
using Repository.DAL;
using Repository.Repositories.Abstraction;

namespace Repository.Repositories.Implementation
{
    public class EfCoreRepository<T,TId> : IRepository<T,TId> where T : class
    {
        private readonly ExamDbContext _context;
        protected ExamDbContext Context => _context;

        public EfCoreRepository(ExamDbContext context)
        {
            _context = context;
        }

        public virtual async Task<IList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
     
        public async Task<bool> AddAsync(T item)
        {
            try
            {
                await _context.Set<T>().AddAsync(item);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<bool> Update(T item)
        {
            try
            {
                _context.Set<T>().Update(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(T item)
        {
            try
            {
                _context.Set<T>().Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual async Task<T> DetailsByKey(TId key)
        {
            return await _context.Set<T>().FindAsync(key);
        }
    }
}
