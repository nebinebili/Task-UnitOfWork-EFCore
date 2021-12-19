using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitofWork_GenericRepo_EFTask.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }

        public virtual List<Book> Books { get; set; } = new List<Book>();

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
