using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.Entities.DTOs.Author
{
    public class AuthorRequestDTO
    {
        public int AuthorId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
