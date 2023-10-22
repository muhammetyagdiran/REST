using Microsoft.AspNetCore.Mvc;
using REST.Business.Interface;
using REST.Business.ResponseModel;
using REST.Core.Extensions;
using REST.Entities;
using REST.Entities.DTOs.Author;
using REST.Entities.DTOs.Book;
using REST.Entities.DTOs.Genre;
using REST.Entities.DTOs.User;


namespace REST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        private readonly ILogger<UserController> _logger;

        public AuthorController(ILogger<UserController> logger, IAuthorService authorService, IBookService bookService)
        {
            _logger = logger;
            _authorService = authorService;
            _bookService = bookService;
        }
        [HttpGet]
        public IList<Author> Get()
        {
            return _authorService.GetAuthorAll();
        }
        [HttpGet]
        [Route("GetById")]
        public AuthorResponseDTO GetById(int AuthorId)
        {
            return _authorService.GetById(AuthorId);

        }
        [HttpPost]
        [Route("Add")]
        public BaseResponse<AuthorResponseDTO> Add(AuthorRequestDTO authorAddRequestDTO)
        {
            return _authorService.Add(authorAddRequestDTO);
        }
        [HttpPut]
        [Route("Update")]
        public BaseResponse<AuthorResponseDTO> Update(AuthorRequestDTO authorRequestDTO)
        {
            return _authorService.Update(authorRequestDTO);
        }
        [HttpDelete]
        [Route("Delete/{AuthorId}")]
        public BaseResponse Delete(int AuthorId)
        {
            var Books = _bookService.GetBookByAuthorId(AuthorId);
            if(Books.Count != 0)
            {
                return new BaseResponse<Author>("Please delete the book first!");
            }
            return _authorService.Delete(AuthorId);
        }

    }
}