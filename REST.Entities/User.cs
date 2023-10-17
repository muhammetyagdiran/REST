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
    public class User 
    {
        [Key]
        public int UserId { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [NotMapped]
        public string? FullName
        {
            get
            {
                return FirstName + " " + FirstName;
            }
        }
        public string? Phone { get; set; }
        public string? Country { get; set; }
        public bool? IsDeleted { get; set; }

    }
}
