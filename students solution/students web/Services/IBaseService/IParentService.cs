using Dtos.Parent;

namespace students_web.Services.IBaseService
{
    public interface IParentService
    {
        public Task<IEnumerable<ParentDto>> GetAll(int CurrentPage, int ItemPerPage);
        public Task<IEnumerable<ParentDto>> GetAll();
        public Task<IEnumerable<ParentDto>> Search(string keyword, int currentPage, int ItemPerPage);
        public Task<ParentDto> Add(ParentDto parent);
        public Task<ParentDto> Update(ParentDto parent);
        public Task<ParentDto> Delete(int id);
    }
}
