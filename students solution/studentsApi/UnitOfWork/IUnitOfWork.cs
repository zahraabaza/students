using students_Api.IRepository;

namespace students_Api.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBaseRepository<TEntity> BaseRepository<TEntity>() where TEntity : BaseEntity;
        Task<bool> SaveAsync();
        bool HasChanges();
        IMapper Mapper { get; }
    }
}
