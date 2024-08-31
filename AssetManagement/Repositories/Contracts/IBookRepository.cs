
using AssetManagement.Models;

namespace AssetManagement.Repository.Contracts
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<IEnumerable<Book>> GetByAuthorName(string authorName); 
    }
}
