namespace TaskManagmentProject.Abstraction.IServices
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        TEntity Fetch(int id);
        IEnumerable<TEntity> Set();
        void Save(TEntity entity);
        void SaveChanges();
        void Delete(int id);
        void Delete(TEntity entity);
    }
}
