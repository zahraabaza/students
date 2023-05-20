using students_Api.Extenstions;
using students_Api.Helpers;

namespace students_Api.Controllers
{
    public class ParentController : BaseGenericAPIController<Parent, ParentDto, ParentDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IBaseRepository<Parent> _Repo;
        public ParentController(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
            _Repo = _uow.BaseRepository<Parent>();
        }

        [HttpGet("search/{keyword}")]
        public async Task<IActionResult> Search(string keyword, [FromQuery] UserParams userParams)
        {
            //Search with first or last name or address 
            var result = await _Repo.Map_GetAllByAsync<ParentDto>(x => x.FirstName.ToLower().Contains(keyword.ToLower())
                || x.LastName.ToLower().Contains(keyword.ToLower()) || x.Address.ToLower().Contains(keyword.ToLower())
            , userParams);

            Response.AddPaginationHeader(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages);
            
            return Ok(result);
        }
    }
}
