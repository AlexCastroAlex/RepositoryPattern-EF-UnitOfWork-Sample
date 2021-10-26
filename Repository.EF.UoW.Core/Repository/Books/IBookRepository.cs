using Repository.EF.UoW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EF.UoW.Core.Repository.Books
{
    public interface IBookRepository : IGenericRepository<Book>
    {
    }
}
