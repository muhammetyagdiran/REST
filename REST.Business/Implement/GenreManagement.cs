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

namespace REST.Business.Implement
{
    public class GenreManagement : IGenreService
    {
        private readonly IEfGenreDal _efGenreDal; 
        private readonly IMapper _mapper;

        public GenreManagement(IMapper mapper, IEfGenreDal efGenreDal)
        {
            _mapper = mapper;
            _efGenreDal = efGenreDal;
        }


        public IList<Genre> GetGenreAll()
        {
            return _efGenreDal.GetAllQuery().ToList();
        }

        public BaseResponse<GenreResponseDTO> Add(GenreAddRequestDTO genreAddRequestDTO )
        {
            var Genre = _mapper.Map<Genre>(genreAddRequestDTO);
            var result = _efGenreDal.Add(Genre);
            var GenreResponseDTO = _mapper.Map<GenreResponseDTO>(genreAddRequestDTO);
            if (result == true)
            {

                return new BaseResponse<GenreResponseDTO>(GenreResponseDTO);
            }
            else
            {
                return new BaseResponse<GenreResponseDTO>("Genre not added");
            }
        }
        public BaseResponse<GenreResponseDTO> Update(GenreRequestDTO genreRequestDTO)
        {
            var Genre = _mapper.Map<Genre>(genreRequestDTO);
            var result = _efGenreDal.Update(Genre);
            if (result == true)
            {
                var GenreResponseDTO = _mapper.Map<GenreResponseDTO>(genreRequestDTO);
                return new BaseResponse<GenreResponseDTO>(GenreResponseDTO);
            }
            else
            {
                return new BaseResponse<GenreResponseDTO>("Genre not updated");
            }
        }
        public BaseResponse Delete(int GenreId)
        {
            var Genre = _efGenreDal.Get(x => x.GenreId == GenreId && x.IsDeleted == false);
            Genre.IsDeleted = true;
            var result = _efGenreDal.Update(Genre);
            if (result == true)
            {

                return new BaseResponse<GenreResponseDTO>(200);
            }
            else
            {
                return new BaseResponse<GenreResponseDTO>("Genre not deleted");
            }
        }
    }
}
