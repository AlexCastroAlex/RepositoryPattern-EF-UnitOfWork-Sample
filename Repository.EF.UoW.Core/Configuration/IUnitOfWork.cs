using Repository.EF.UoW.Core.Repository.Employees;
using Repository.EF.UoW.Core.Repository.TasksToDo;

namespace Repository.EF.UoW.Core.Configuration;

public interface IUnitOfWork
{
    IBookRepository Books { get; }
    ICatalogRepository Catalogs { get; }
    Task CompleteAsync();
    void Dispose();
}