using Microsoft.Extensions.Logging;
using Repository.EF.UoW.Core.Repository.Books;
using Repository.EF.UoW.Core.Repository.Catalogs;

namespace Repository.EF.UoW.Core.Configuration;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly DBContext _context;

    private readonly ILogger _logger;

    public IBookRepository Books { get; private set; }

    public ICatalogRepository Catalogs { get; private set; }

    public UnitOfWork(DBContext context, ILoggerFactory loggerFactory)
    {
        _context = context;
        _logger = loggerFactory.CreateLogger("logs");

        Books = new BookRepository(context, _logger);
        Catalogs = new CatalogRepository(context, _logger);
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}