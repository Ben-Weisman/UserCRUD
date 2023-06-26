using System.ComponentModel.DataAnnotations;
using UserCRUD.Models.domain;

namespace UserCRUD.Models
{
    public class AddUserViewModel
    {
        [Required]
        public string Id { get; set; }   
        [Required]
        public string Name { get; set; }
        public string? Email { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }   

        public GenderEnum? Gender { get; set; }
        public string? Phone { get; set; }
    }
}
