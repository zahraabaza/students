using System.ComponentModel.DataAnnotations;

namespace Dtos
{
    public class BaseDto
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
