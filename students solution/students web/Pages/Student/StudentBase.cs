using Dtos.Pagination;
using Dtos.Parent;
using System.Globalization;

namespace students_web.Pages.Student
{
    public class StudentBase: ComponentBase
    {
        [Inject]
        public IStudentService BaseStudent { get; set; }

        public IEnumerable<StudentDto> Students { get; set; }

        public StudentDto student { get; set; } = new StudentDto();
        public bool Visible { get; set; } = false;
        public bool DeleteSection { get; set; } = false;

        public int parentId { get; set; }

        [Inject]
        public IParentService BaseParent { get; set; }
        public IEnumerable<ParentDto> Parents { get; set; }

        private int PageSize { get; set; } = 5;
        private int Current { get; set; } = 1;

        protected void Edit(StudentDto row)
        {
            Visible = true;
            student = row;
        }

        protected override async Task OnInitializedAsync()
        {
            await GetAll();
            Parents = await BaseParent.GetAll();
        }

        protected async Task Next()
        {
            if(Students.Count()< PageSize)
            {

            }
            else
            {
                Current++;
                await GetAll();
            }
        }

        protected async Task Prev()
        {
            if(Current> 1)
            {
                Current--;
            }
            await GetAll();
        }

        protected async Task GetAll()
        {
            Students = await BaseStudent.GetAll(Current, PageSize);
        }

        protected async Task Add(StudentDto student)
        {
            await BaseStudent.Add(student);
            await GetAll();
            Visible = false;

        }

        protected async Task Update(StudentDto student)
        {
            Visible = false;
            await BaseStudent.Update(student);
            await GetAll();

        }

        protected async Task Delete(int id)
        {
            await BaseStudent.Delete(id);
            await GetAll();
            Visible = false;
            DeleteSection = false;

        }

        protected async Task GetByParentId(int parentId)
        {
            if(parentId == 0)
            {
                await GetAll();
            }
            else
            {
                Students = await BaseStudent.GetByParentId(parentId, Current, PageSize);
            }
        }


    }
}
