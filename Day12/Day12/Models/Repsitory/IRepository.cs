namespace Day12.Models.Repsitory
{
    // This interface defines the contract for a generic repository pattern to manage entities of type T it is useful for CRUD operations.
    public interface IRepository<T> where T : class

    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<int> SaveChangesAsync();

    }
}
