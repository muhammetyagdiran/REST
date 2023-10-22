using Microsoft.AspNetCore.Mvc;
using REST.Business.Interface;
using REST.Business.ResponseModel;
using REST.Core.Extensions;
using REST.Entities;
using REST.Entities.DTOs.Book;
using REST.Entities.DTOs.User;


namespace REST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        [Route("GetById")]
        public BookResponseDTO GetById(int BookId)
        {
            return _bookService.GetById(BookId);
            
        }
        [HttpPut]
        [Route("UpdateBook")]
        public BaseResponse<BookUpdateResponseDTO> Update(BookUpdateRequestDTO bookUpdateRequestDTO)
        {
            return _bookService.Update(bookUpdateRequestDTO);
        }
        [HttpDelete]
        [Route("Delete/{BookId}")]
        public BaseResponse Delete(int BookId)
        {
            return _bookService.Delete(BookId);
        }
    }
}