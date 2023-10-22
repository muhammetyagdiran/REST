using REST.Entities.Models.ViewModels;
using REST.Business.ResponseModel;
using REST.DataAccess.EntityFramework.Repositories.Interface;
using REST.Entities;
using REST.Entities.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REST.Entities.DTOs.Genre;
using GenreAddRequestDTO = REST.Entities.DTOs.Genre.GenreAddRequestDTO;

namespace REST.Business.Interface
{
    public interface IGenreService
    {
        IList<Genre> GetGenreAll();
        BaseResponse<GenreResponseDTO> Add(GenreAddRequestDTO genreAddRequestDTO);
        BaseResponse<GenreResponseDTO> Update(GenreRequestDTO genreRequestDTO);
        BaseResponse Delete(int GenreId);

    }
}
