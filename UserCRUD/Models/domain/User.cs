//using Humanizer;


using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UserCRUD.Models.domain
{
    [PrimaryKey(nameof(InternalID))]
    
    public class User
    {
        [Required]
        public Guid InternalID { get; set; }
        [Required]
        public string Id { get; set; }   // mandatory
        [Required]
        public string Name { get; set; }// mandatory
        public string? Email { get; set; }
        [Required]
        public DateTime DateOfBirth { get;set ; }   // mandatory 

        public GenderEnum? Gender { get; set; } 
        public string? Phone { get; set; }   
    }
}
