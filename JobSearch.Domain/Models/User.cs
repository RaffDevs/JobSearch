using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearch.API.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(6)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
