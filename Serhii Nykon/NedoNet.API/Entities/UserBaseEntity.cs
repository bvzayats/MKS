using System.ComponentModel.DataAnnotations;

namespace NedoNet.API.Entities {
    public class UserBaseEntity {
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }
}