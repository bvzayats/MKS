using System.ComponentModel.DataAnnotations;

namespace NedoNet.API.Entities {
    public class CreateUserEntity : UserBaseEntity {
        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}