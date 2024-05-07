using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notely.Models.Models
{
    public class NotesDto
    {
        public int Id { get; set; }

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
