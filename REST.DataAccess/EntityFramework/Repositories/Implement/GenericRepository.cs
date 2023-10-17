using REST.DataAccess.EntityFramework.Context;
using REST.DataAccess.EntityFramework.Repositories.Interface;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace REST.DataAccess.EntityFramework.Repositories.Implement
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly PatikaContext _context;
        public GenericRepository(PatikaContext context)
        {
            _context = context;
        }

        public bool Add(T entity)
        {            
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
             var result =  _context.SaveChanges();
            if(result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public bool Delete(T entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            var result = _context.SaveChanges();
            if(result > 0)
            {
                return true;
            }
            else 
            { 
                return false; 
            }
        }
        public T Get(Expression<Func<T, bool>> filter)
        {
             var result =  _context.Set<T>().FirstOrDefault(filter);
            _context.SaveChanges();
            return result;
        }
        public IList<T> GetList(Expression<Func<T, bool>> filter = null)
        {
            return filter == null
              ? _context.Set<T>().ToList()
             : _context.Set<T>().Where(filter).ToList();
        }

        public bool Update(T entity)
        {
            var updatedEntity = _context.Entry(entity);
             updatedEntity.State = EntityState.Modified;
            var result = _context.SaveChanges();
            if(result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IQueryable GetQuery()
        {
                return _context.Set<T>();
        }
        public IQueryable<T> GetAllQuery(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ?
                _context.Set<T>() :
                _context.Set<T>().Where(filter);
        }






        //public DbSet<T> Entity => _context.Set<T>();

        //public async Task<T> AddAsync(T entity)
        //{
        //    EntityEntry entityEntry = await Entity.AddAsync(entity);
        //    entityEntry.State = EntityState.Added;
        //    await _context.SaveChangesAsync();
        //    return entity;
        //}
        //public bool Delete(T entity)
        //{
        //    EntityEntry entityEntry = Entity.Remove(entity);
        //    entityEntry.State = EntityState.Deleted;
        //    return _context.SaveChanges() > 0;

        //}

        //public async Task<bool> DeleteByIdAsync(int id)
        //{
        //    var entity = await Entity.FindAsync(id);
        //    return Delete(entity);
        //}

        //public IQueryable<T> GetAll()
        //{
        //    return Entity.AsQueryable();
        //}

        //public async Task<T> GetByIdAsync(int id)
        //{
        //    return await Entity.FindAsync(id);
        //}

        //public async Task<T> GetFirstAsync()
        //{
        //    return await Entity.FirstOrDefaultAsync();
        //}

        //public async Task<T> GetFirstWhereAsync(Expression<Func<T, bool>> expression)
        //{
        //    return await Entity.FirstOrDefaultAsync(expression);
        //}

        //public async Task<IList<T>> GetWhere(Expression<Func<T, bool>> expression)
        //{
        //    return await Entity.Where(expression).ToList();
        //}

        //public bool Update(T entity)
        //{
        //    EntityEntry<T> entityEntry = Entity.Update(entity);
        //    entityEntry.State = EntityState.Modified;
        //    return _context.SaveChanges() > 0;
        //}
    }
}
