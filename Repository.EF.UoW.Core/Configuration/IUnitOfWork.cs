using Repository.EF.UoW.Core.Repository.Books;
using Repository.EF.UoW.Core.Repository.Catalogs;

namespace Repository.EF.UoW.Core.Configuration;

public interface IUnitOfWork
{
    IBookRepository Books { get; }
    ICatalogRepository Catalogs { get; }
    Task CompleteAsync();
    void Dispose();
}