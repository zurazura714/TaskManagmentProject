using Microsoft.EntityFrameworkCore;
using TaskManagmentProject.Abstraction.IRepositories;
using TaskManagmentProject.Data.DBContext;

namespace TaskManagmentProject.Repository.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected TaskDBContext _context;

        public IUnitOfWork Context
        {
            get { return _context; }
        }

        internal RepositoryBase(IUnitOfWork context) : this(context as TaskDBContext) { }

        internal RepositoryBase(TaskDBContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            _context = context;
        }

        public virtual TEntity Fetch(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }


        public virtual IEnumerable<TEntity> Set()
        {
            return _context.Set<TEntity>();
        }
        public virtual void Add(TEntity entity)
        {
            Add(_context.Set<TEntity>(), entity);
        }

        public virtual void Save(TEntity entity)
        {
            Save(_context.Set<TEntity>(), entity);
        }

        public virtual void Delete(int id)
        {
            Delete(Fetch(id));
        }

        public virtual void Delete(TEntity entity)
        {
            Delete(_context.Set<TEntity>(), entity);
        }

        protected virtual void Save(DbSet<TEntity> set, TEntity entity)
        {
            var entry = _context.Entry(entity);
            if (entry == null || entry.State == EntityState.Detached) set.Add(entity);
        }

        protected virtual void Delete(DbSet<TEntity> set, TEntity entity)
        {
            set.Remove(entity);
        }

        protected virtual void Add(DbSet<TEntity> set, TEntity entity)
        {
            var entry = _context.Entry(entity);
            if (entry == null || entry.State == EntityState.Detached)
            {
                set.Add(entity);
            }
        }
    }
}