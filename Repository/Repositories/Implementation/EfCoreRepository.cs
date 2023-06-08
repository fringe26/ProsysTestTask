using Microsoft.EntityFrameworkCore;
using Repository.DAL;
using Repository.Repositories.Abstraction;

namespace Repository.Repositories.Implementation
{
    public class EfCoreRepository<T> : IRepository<T> where T : class
    {
        protected readonly ExamDbContext _context;

        public EfCoreRepository(ExamDbContext context)
        {
            _context = context;
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T> DetailsById(int? id)
        {
            return await _context.Set<T>().FindAsync(id);
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
                throw;
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
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
