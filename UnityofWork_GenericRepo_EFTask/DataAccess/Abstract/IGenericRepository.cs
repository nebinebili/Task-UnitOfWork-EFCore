using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UnitofWork_GenericRepo_EFTask.DataAccess.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> Query(Expression<Func<T, bool>> exp);


        void Add(T entity);

        void Update(T entity);

        void Remove(T entity);
    }
}
