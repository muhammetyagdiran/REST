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
using REST.Entities.DTOs.Book;

namespace REST.Business.Implement
{
    public class BookManagement : IBookService
    {
        private readonly IEfBookDal _efBookDal;
        private readonly IMapper _mapper;


        public BookManagement(IEfBookDal efBookDal, IMapper mapper)
        {
            _efBookDal = efBookDal;
            _mapper = mapper;
        }


        public BookResponseDTO GetById(int BookId)
        {
            var Book =  _efBookDal.Get(x => x.BookId == BookId);
            var BookResponseDTO = _mapper.Map<BookResponseDTO>(Book);
            return BookResponseDTO;
        }


        public BaseResponse<BookUpdateResponseDTO> Update(BookUpdateRequestDTO bookUpdateRequestDTO)
        {
            var Book = _mapper.Map<Book>(bookUpdateRequestDTO);
            var result = _efBookDal.Update(Book);
            if (result == true)
            {
                var BookUpdateResponseDTO= _mapper.Map<BookUpdateResponseDTO>(bookUpdateRequestDTO);
                return new BaseResponse<BookUpdateResponseDTO>(BookUpdateResponseDTO);
            }
            else
            {
                return new BaseResponse<BookUpdateResponseDTO>("User not updated");
            }

        }
        public BaseResponse Delete(int BookId)
        {
            var Book = _efBookDal.Get(x => x.BookId == BookId && x.IsDeleted == false);
            Book.IsDeleted = true;
            var result = _efBookDal.Update(Book);
            if (result == true)
            {

                return new BaseResponse<Book>(200);
            }
            else
            {
                return new BaseResponse<Book>("User not deleted");
            }
        }
        public IList<Book> GetBookByAuthorId(int AuthorId)
        {
            return  _efBookDal.GetBooksByAuthorId(AuthorId);
        }
    }
}
