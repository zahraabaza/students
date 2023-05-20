using System.ComponentModel.DataAnnotations;

namespace Dtos.Student
{
    public class StudentDto: BaseDto
    {
        public virtual string ParentAddress { get; set; }
        [Required]
        public int ParentId { get; set; }
    }
}
