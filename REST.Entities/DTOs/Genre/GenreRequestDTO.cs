using REST.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.Entities.DTOs.Genre
{
    public class GenreRequestDTO
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

    }
}
