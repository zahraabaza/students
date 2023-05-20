using Microsoft.Extensions.Options;
using students_Api.IRepository;
using students_Api.Repository;
using System.Collections;

namespace students_Api.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UnitOfWork(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }

        public IMapper Mapper => _mapper;



        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }

        public IBaseRepository<TEntity> BaseRepository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null) _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(BaseRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context, _mapper);

                _repositories.Add(type, repositoryInstance);
            }

            return (BaseRepository<TEntity>)_repositories[type];
        }
    }
}
