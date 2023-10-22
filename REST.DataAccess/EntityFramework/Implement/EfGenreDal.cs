using REST.Entities.Models.ViewModels;
using REST.DataAccess.EntityFramework.Context;
using REST.DataAccess.EntityFramework.Interface;
using REST.DataAccess.EntityFramework.Repositories.Implement;
using REST.Entities;
using REST.Entities.DTOs.User;
using Microsoft.EntityFrameworkCore;

namespace REST.DataAccess.EntityFramework.Implement
{
    public class EfGenreDal : GenericRepository<Genre>, IEfGenreDal
    {
        private readonly PatikaContext _context;
        public EfGenreDal(PatikaContext context) : base(context)
        {
            _context = context;
        }
       
    }
}
