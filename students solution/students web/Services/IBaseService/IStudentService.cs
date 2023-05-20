namespace students_web.Services.IBaseService
{
    public interface IStudentService
    {
        public Task<IEnumerable<StudentDto>> GetAll(int CurrentPage, int ItemPerPage);
        public Task<IEnumerable<StudentDto>> GetByParentId(int parentId, int CurrentPage, int ItemPerPage);
        public Task<StudentDto> Add(StudentDto studentDto);
        public Task<StudentDto> Update(StudentDto studentDto);
        public Task<StudentDto> Delete(int id);
    }
}
