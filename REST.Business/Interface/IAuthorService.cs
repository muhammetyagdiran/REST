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
using REST.Entities.DTOs.Author;

namespace REST.Business.Interface
{
    public interface IAuthorService
    {
        IList<Author> GetAuthorAll();
        AuthorResponseDTO GetById(int AuthorId);
        BaseResponse<AuthorResponseDTO> Add(AuthorRequestDTO authorAddRequest);
        BaseResponse<AuthorResponseDTO> Update(AuthorRequestDTO authorRequestDTO);
        BaseResponse Delete(int AuthorId);

    }
}
