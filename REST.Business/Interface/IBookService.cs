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
using REST.Entities.DTOs.Book;

namespace REST.Business.Interface
{
    public interface IBookService
    {
        BookResponseDTO GetById(int BookId);
        BaseResponse<BookUpdateResponseDTO> Update(BookUpdateRequestDTO bookUpdateRequestDTO);
        BaseResponse Delete(int BookId);

    }
}
