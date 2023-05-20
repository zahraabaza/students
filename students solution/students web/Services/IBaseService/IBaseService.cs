using Dtos;

namespace students_web.Services.IBaseService
{
    public interface IBaseService<Dto> where Dto : class
    {
        public Task<IEnumerable<Dto>> GetAll();
    }
}
