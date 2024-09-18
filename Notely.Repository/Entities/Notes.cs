using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notely.Repository.Entities
{
    public class Notes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Category { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;
    }
}
