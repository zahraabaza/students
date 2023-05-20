using students_Api.Helpers;

namespace students_Api.IRepository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllByAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetByAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<T>> Map_GetAllAsync<T>();
        Task<IEnumerable<T>> Map_GetAllByAsync<T>(Expression<Func<TEntity, bool>> expression);
        Task<T> Map_GetByAsync<T>(Expression<Func<TEntity, bool>> expression);
        Task<PagedList<T>> Map_GetAllAsync<T>(UserParams userParams);
        Task<PagedList<T>> Map_GetAllByAsync<T>(Expression<Func<TEntity, bool>> expression, UserParams userParams);
    }
}
