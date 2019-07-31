using System.ComponentModel.DataAnnotations;

namespace Nedo_net {
    public class StudentDTO {
        [Required]
        [StringLength( 50 )]
        public string FName { get; set; }

        [Required]
        [StringLength( 50 )]
        public string LName { get; set; }

        [Required]
        public bool IsGranted { get; set; }

        public string Email { get; set; }
    }
}
