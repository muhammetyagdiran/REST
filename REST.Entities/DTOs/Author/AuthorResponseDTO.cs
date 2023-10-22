using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.Entities.DTOs.Author
{
    public class AuthorResponseDTO
    {
        public int AuthorId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [NotMapped]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public DateTime? DateOfBirth { get; set; }
    }
}
