namespace FirstAPI.DataAccess.Repositories.Abstract
{
    public interface IGenericRepository<T> where T : class, new()
    {
        Task<List<T>> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(int id, T entity);
        Task Delete(int id);
        void DeleteMultible(List<T> entities);

    }
}
