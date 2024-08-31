using AssetManagement.Models;
using AssetManagement.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AssetDbContext _context;
        private DbSet<T> _dbSet;

        public GenericRepository(AssetDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task Add(T obj)
        {
            _dbSet.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(object ID)
        {
            var obj = await _dbSet.FindAsync(ID);
            if (obj != null)
            {
                _dbSet.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<T> Get(object ID)
        {
            return await _dbSet.FindAsync(ID);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        //Check this edit action method.
        //Not working properly
        public async Task Edit(object ID, T obj)
        {
            var data = await _dbSet.FindAsync(ID);

            if (data != null)
            {
                _context.Entry(data).CurrentValues.SetValues(obj);
                await _context.SaveChangesAsync();
            }
        }
    }
}
