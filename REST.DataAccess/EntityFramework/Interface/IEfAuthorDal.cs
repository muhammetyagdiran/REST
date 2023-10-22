
using REST.Entities.Models.ViewModels;
using REST.DataAccess.EntityFramework.Repositories.Interface;
using REST.Entities;
using REST.Entities.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.DataAccess.EntityFramework.Interface
{
    public interface IEfAuthorDal : IGenericRepository<Author>
    {
    }
}
