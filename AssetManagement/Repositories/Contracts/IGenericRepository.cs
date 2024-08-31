namespace AssetManagement.Repository.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task Add(T obj);
        Task Edit(object ID, T obj);
        Task Delete(object ID);
        Task<T> Get(object ID);
        Task<IEnumerable<T>> GetAll();

    }
}
