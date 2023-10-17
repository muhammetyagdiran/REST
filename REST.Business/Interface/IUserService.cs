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

namespace REST.Business.Interface
{
    public interface IUserService
    {
        IList<User> GetUsersAll();
        BaseResponse<User> Add(UserAddRequestDTO userAddRequestDTO);
        BaseResponse<User> Update(UserAddRequestDTO userAddRequestDTO);
        BaseResponse Delete(int UserId);

    }
}
