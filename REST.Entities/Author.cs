using REST.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.Entities
{
    public class Author
    {
        [Key]
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
        public bool? IsDeleted { get; set; }

    }
}
