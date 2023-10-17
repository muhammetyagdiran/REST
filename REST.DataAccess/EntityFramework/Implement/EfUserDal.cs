using REST.Entities.Models.ViewModels;
using REST.DataAccess.EntityFramework.Context;
using REST.DataAccess.EntityFramework.Interface;
using REST.DataAccess.EntityFramework.Repositories.Implement;
using REST.Entities;
using REST.Entities.DTOs.User;
using Microsoft.EntityFrameworkCore;

namespace REST.DataAccess.EntityFramework.Implement
{
    public class EfUserDal : GenericRepository<User>, IEfUserDal
    {
        private readonly PatikaContext _context;
        public EfUserDal(PatikaContext context) : base(context)
        {
            _context = context;
        }

        public IList<User> GetUsersAll()
        {
            return _context.User.ToList();
            
        }

       
 
    }
}
