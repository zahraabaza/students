using System.ComponentModel.DataAnnotations;

namespace Dtos.Parent
{
    public class ParentDto: BaseDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string WorkPhone { get; set; }

        [Required]
        public string HomePhone { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
