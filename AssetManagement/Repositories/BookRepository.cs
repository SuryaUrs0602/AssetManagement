using AssetManagement.Models;
using AssetManagement.Repository;
using AssetManagement.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly AssetDbContext _context;

        public BookRepository(AssetDbContext context) : base(context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<Book>> GetByAuthorName(string AuthorName)
        {
            return await _context.books.Where(e => e.AuthorName.ToLower() == AuthorName.ToLower()).ToListAsync();
        }
    }
}
