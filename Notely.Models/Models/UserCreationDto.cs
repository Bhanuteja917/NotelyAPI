using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notely.Models.Models
{
    public class UserCreationDto
    {
        public required string UserName {get; set;}
        public required string Password { get; set; }
        public required string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;

    }
}
