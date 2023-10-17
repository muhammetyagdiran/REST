using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace REST.DataAccess.EntityFramework.Repositories.Interface
{
    public interface IGenericRepository<T> where T:class
    {
        bool Add(T entity);
        bool Delete(T entity);
        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        bool Update(T entity);
        IQueryable GetQuery();
        IQueryable<T> GetAllQuery(Expression<Func<T, bool>> filter = null);
        //DbSet<T> Entity { get; }
        //Task<T> AddAsync(T entity);
        //bool Update(T entity);
        //bool Delete(T entity);
        //Task<bool> DeleteByIdAsync(int id);
        //IQueryable<T> GetAll();
        //IList<T> GetWhere(Expression<Func<T, bool>> expression);
        //Task<T> GetByIdAsync(int id);
        //Task<T> GetFirstWhereAsync(Expression<Func<T, bool>> expression);
        //Task<T> GetFirstAsync();
    }
}
