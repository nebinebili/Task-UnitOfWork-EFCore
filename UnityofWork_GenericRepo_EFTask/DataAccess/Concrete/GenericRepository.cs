using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UnitofWork_GenericRepo_EFTask.Context;
using UnitofWork_GenericRepo_EFTask.DataAccess.Abstract;

namespace UnitofWork_GenericRepo_EFTask.DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected MyDbContext _context;

        public GenericRepository(MyDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return from entity in _context.Set<T>()
                   select entity;
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp);
        }


        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
