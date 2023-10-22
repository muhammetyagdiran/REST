using AutoMapper;
using REST.Entities;
using REST.Entities.DTOs.Book;
using REST.Entities.DTOs.Genre;
using REST.Entities.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.Business.Mapper
{
    public  class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<UserDTO, User>();
            CreateMap<UserAddRequestDTO, User>();
            CreateMap<User, UserAddRequestDTO>();
            CreateMap<BookResponseDTO, Book>();
            CreateMap<Book, BookResponseDTO>();
            CreateMap<BookUpdateRequestDTO, BookUpdateResponseDTO>();
            CreateMap<BookUpdateResponseDTO, BookUpdateRequestDTO>();
            CreateMap<Book, BookUpdateRequestDTO>();
            CreateMap<BookUpdateRequestDTO, Book>();
            CreateMap<GenreAddRequestDTO, GenreResponseDTO>();
            CreateMap<GenreResponseDTO, GenreAddRequestDTO>();
            CreateMap<Genre, GenreAddRequestDTO>();
            CreateMap<GenreAddRequestDTO, Genre>();
            CreateMap<GenreRequestDTO, GenreResponseDTO>();
            CreateMap<GenreResponseDTO, GenreRequestDTO>();
            CreateMap<Genre, GenreRequestDTO>();
            CreateMap<GenreRequestDTO, Genre>();
        }
    }
}

