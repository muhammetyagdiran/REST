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

namespace REST.Business.Implement
{
    public class UserManagement : IUserService
    {
        private readonly IEfUserDal _efUserDal;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserManagement(IEfUserDal efUserDal, IConfiguration configuration, IMapper mapper)
        {
            _efUserDal = efUserDal;
            _configuration = configuration;
            _mapper = mapper;
        }


        public IList<User> GetUsersAll()
        {
            return _efUserDal.GetUsersAll();
        }

        public BaseResponse<User> Add(UserAddRequestDTO userAddRequestDTO)
        {
            var User = _mapper.Map<User>(userAddRequestDTO);
            var result = _efUserDal.Add(User);
            if (result == true)
            {
                
                return new BaseResponse<User>(User);
            }
            else
            {
                return new BaseResponse<User>("User not added");
            }
        }
        public BaseResponse<User> Update(UserAddRequestDTO userAddRequestDTO)
        {
            var User = _mapper.Map<User>(userAddRequestDTO);
            var result = _efUserDal.Update(User);
            if (result == true)
            {

                return new BaseResponse<User>(User);
            }
            else
            {
                return new BaseResponse<User>("User not added");
            }
        }
        public BaseResponse Delete(int UserId)
        {
            var User = _efUserDal.Get(x => x.UserId == UserId && x.IsDeleted == false);
            User.IsDeleted = true;
            var result = _efUserDal.Update(User);
            if (result == true)
            {

                return new BaseResponse<User>(200);
            }
            else
            {
                return new BaseResponse<User>("User not deleted");
            }
        }
    }
}
