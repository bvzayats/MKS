using System.ComponentModel.DataAnnotations;

namespace WebAPISwagger.Models {
    public class StudentDTO {

        [Required]
        [StringLength( 50 )]
        public string Name { get; set; }

        [Required]
        [StringLength( 50 )]
        public string Surname { get; set; }

        [Required]
        public string Faculty { get; set; }

        [Required]
        public int Course { get; set; }

        public int? NumberHostel { get; set; }
    }
}
