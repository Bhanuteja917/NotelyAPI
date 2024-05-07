using System.ComponentModel.DataAnnotations;

namespace Notely.Models.Models
{
    public class NotesForUpdateDto
    {
        [Required]
        [MaxLength(30)]
        public required string Title { get; set; }

        [Required]
        [MaxLength(20)]
        public required string Category { get; set; }

        [Required]
        [MaxLength(200)]
        public required string Description { get; set; }
    }
}