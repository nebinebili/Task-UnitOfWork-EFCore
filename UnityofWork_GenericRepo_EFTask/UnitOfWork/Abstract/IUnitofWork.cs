using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitofWork_GenericRepo_EFTask.DataAccess.Abstract;
using UnitofWork_GenericRepo_EFTask.Models;

namespace UnitofWork_GenericRepo_EFTask.UnitOfWork.Abstract
{
    public interface IUnitofWork:IDisposable
    {
         IGenericRepository<Category> CategoryRepo { get; }
         IGenericRepository<Book> BookRepo { get;  }
         int Complete();
    }
}
