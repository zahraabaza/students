namespace students_Api.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ParentDto, Parent>().ReverseMap();
            CreateMap<StudentDto, Student>().ReverseMap();
        }
    }
}
