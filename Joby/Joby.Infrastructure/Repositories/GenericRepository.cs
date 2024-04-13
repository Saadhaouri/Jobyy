
using Joby.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private readonly JobyDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(JobyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<TEntity>();
        }

        public TEntity GetById(string id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
