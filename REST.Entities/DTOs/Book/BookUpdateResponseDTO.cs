using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.Entities.DTOs.Book
{
    public class BookUpdateResponseDTO
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
    }
}
