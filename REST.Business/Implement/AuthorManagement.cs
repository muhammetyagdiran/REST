using AutoMapper;
using Azure;
using BCrypt.Net;
using REST.Entities.Models.ViewModels;
using REST.Business.Interface;
using REST.Business.ResponseModel;
using REST.Business.Security;
using REST.DataAccess.EntityFramework.Implement;
using REST.DataAccess.EntityFramework.Interface;
using REST.Entities;
using REST.Entities.DTOs.User;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REST.DataAccess.EntityFramework.Interface;
using REST.Entities.DTOs.Genre;
using GenreAddRequestDTO = REST.Entities.DTOs.Genre.GenreAddRequestDTO;
using REST.Entities.DTOs.Book;
using REST.Entities.DTOs.Author;

namespace REST.Business.Implement
{
    public class AuthorManagement : IAuthorService
    {
        private readonly IEfAuthorDal _efAuthorDal; 
        private readonly IMapper _mapper;

        public AuthorManagement(IMapper mapper, IEfAuthorDal efAuthorDal)
        {
            _mapper = mapper;
            _efAuthorDal = efAuthorDal;
        }


        public IList<Author> GetAuthorAll()
        {
            return _efAuthorDal.GetAllQuery().ToList();
        }
        public AuthorResponseDTO GetById(int AuthorId)
        {
            var Author = _efAuthorDal.Get(x => x.AuthorId == AuthorId);
            var AuthorResponseDTO = _mapper.Map<AuthorResponseDTO>(Author);
            return AuthorResponseDTO;
        }
        public BaseResponse<AuthorResponseDTO> Add(AuthorRequestDTO authorAddRequest)
        {
            var Author = _mapper.Map<Author>(authorAddRequest);
            var result = _efAuthorDal.Add(Author);
            var AuthorResponseDTO = _mapper.Map<AuthorResponseDTO>(authorAddRequest);
            if (result == true)
            {

                return new BaseResponse<AuthorResponseDTO>(AuthorResponseDTO);
            }
            else
            {
                return new BaseResponse<AuthorResponseDTO>("Author not added");
            }
        }
        public BaseResponse<AuthorResponseDTO> Update(AuthorRequestDTO authorRequestDTO)
        {
            var Author = _mapper.Map<Author>(authorRequestDTO);
            var result = _efAuthorDal.Update(Author);
            if (result == true)
            {
                var AuthorResponseDTO = _mapper.Map<AuthorResponseDTO>(authorRequestDTO);
                return new BaseResponse<AuthorResponseDTO>(AuthorResponseDTO);
            }
            else
            {
                return new BaseResponse<AuthorResponseDTO>("Author not updated");
            }
        }
        public BaseResponse Delete(int AuthorId)
        {
            var Author = _efAuthorDal.Get(x => x.AuthorId == AuthorId && x.IsDeleted == false);
            Author.IsDeleted = true;
            var result = _efAuthorDal.Update(Author);
            if (result == true)
            {

                return new BaseResponse<AuthorResponseDTO>(200);
            }
            else
            {
                return new BaseResponse<AuthorResponseDTO>("Author not deleted");
            }
        }
    }
}
