using Microsoft.EntityFrameworkCore;

namespace FirstAPI.DataAccess.Repositories.Concrete
{
    public class GenericRepository<T, TContext> 
        where T : class, new()
        where TContext : DbContext
    {
        private readonly TContext _context;

        public GenericRepository(TContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T GetById(int id) => _context.Set<T>().Find(id);

        public async void Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async void Update(int id, T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity =  GetById(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public  void DeleteMultible(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();

        }
    }
}
