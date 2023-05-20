namespace students_Api.Controllers
{
    public class StudentController : BaseGenericAPIController<Student, StudentDto, StudentDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IBaseRepository<Student> _Repo;
        public StudentController(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
            _Repo = _uow.BaseRepository<Student>();
        }

        [HttpGet("GetByParentId/{parentId}")]
        public async Task<IActionResult> GetByParentId(int parentId)
        {
            var students = await _Repo.Map_GetAllByAsync<StudentDto>(x => x.ParentId == parentId);

            return Ok(students);
        }
    }
}
