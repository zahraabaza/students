
using AutoMapper.QueryableExtensions;
using students_Api.Helpers;

namespace students_Api.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public BaseRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().Where(x=> !x.IsDeleted).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllByAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().Where(x=> !x.IsDeleted).Where(expression)
                .Where(expression).ToListAsync();
        }

        public async Task<TEntity> GetByAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().Where(x => !x.IsDeleted).Where(expression).FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> Map_GetAllAsync<T>()
        {
            return await _context.Set<TEntity>()
                .Where(x => !x.IsDeleted)
                .ProjectTo<T>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<T>> Map_GetAllByAsync<T>(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>()
                .Where(x => !x.IsDeleted)
                .Where(expression)
                .ProjectTo<T>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<T> Map_GetByAsync<T>(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().Where(x => !x.IsDeleted)
                .Where(expression)
                .ProjectTo<T>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<PagedList<T>> Map_GetAllAsync<T>(UserParams userParams)
        {
            var query = _context.Set<TEntity>()
                .Where(x=> !x.IsDeleted)
                .ProjectTo<T>(_mapper.ConfigurationProvider)
                .AsQueryable();
            return await PagedList<T>.CreateAsync(query, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<PagedList<T>> Map_GetAllByAsync<T>(Expression<Func<TEntity, bool>> expression, UserParams userParams)
        {
            var query = _context.Set<TEntity>()
                .Where(x => !x.IsDeleted)
                .Where(expression)
                .ProjectTo<T>(_mapper.ConfigurationProvider)
                .AsQueryable();
            return await PagedList<T>.CreateAsync(query, userParams.PageNumber, userParams.PageSize);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}
