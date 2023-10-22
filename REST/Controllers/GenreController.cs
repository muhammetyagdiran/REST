using Microsoft.AspNetCore.Mvc;
using REST.Business.Interface;
using REST.Business.ResponseModel;
using REST.Core.Extensions;
using REST.Entities;
using REST.Entities.DTOs.Genre;
using REST.Entities.DTOs.User;


namespace REST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly ILogger<UserController> _logger;

        public GenreController(ILogger<UserController> logger, IGenreService genreService)
        {
            _logger = logger;
            _genreService = genreService;
        }
        [HttpGet]
        public IList<Genre> Get()
        {
            return _genreService.GetGenreAll();
        }
        [HttpPost]
        [Route("Add")]
        public BaseResponse<GenreResponseDTO> Add(GenreAddRequestDTO genreAddRequestDTO)
        {
            return _genreService.Add(genreAddRequestDTO);
        }
        [HttpPut]
        [Route("Update")]
        public BaseResponse<GenreResponseDTO> Update(GenreRequestDTO genreRequestDTO)
        {
            return _genreService.Update(genreRequestDTO);
        }
        [HttpDelete]
        [Route("Delete/{GenreId}")]
        public BaseResponse Delete(int GenreId)
        {
            return _genreService.Delete(GenreId);
        }

    }
}