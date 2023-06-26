using System.ComponentModel.DataAnnotations;

namespace UserCRUD.Models
{
    public class UpdateUserViewModel
    {
        public Guid InternalID { get; set; }  
        [Required]
        public string Id { get; set; }  
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }
         public GenderEnum? Gender { get; set; } 
        public string? Phone { get; set; }
    }
}
