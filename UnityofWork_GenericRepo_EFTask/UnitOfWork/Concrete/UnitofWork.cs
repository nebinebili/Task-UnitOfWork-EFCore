using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitofWork_GenericRepo_EFTask.Context;
using UnitofWork_GenericRepo_EFTask.DataAccess.Abstract;
using UnitofWork_GenericRepo_EFTask.DataAccess.Concrete;
using UnitofWork_GenericRepo_EFTask.Models;
using UnitofWork_GenericRepo_EFTask.UnitOfWork.Abstract;

namespace UnitofWork_GenericRepo_EFTask.UnitOfWork.Concrete
{
    public class UnitofWork : IUnitofWork
    {
        private MyDbContext _context;

        public UnitofWork(MyDbContext context)
        {
            _context = context;
            CategoryRepo = new GenericRepository<Category>(_context);
            BookRepo = new GenericRepository<Book>(_context);
        }

        public IGenericRepository<Category> CategoryRepo { get; private set; }

        public IGenericRepository<Book> BookRepo { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
