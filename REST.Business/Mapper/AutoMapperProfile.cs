using AutoMapper;
using REST.Entities;
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
        }
    }
}
