using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.EF.UoW.Core.Configuration;
using Repository.EF.UoW.Core.Models;
using System.Linq.Expressions;

namespace Repository.EF.UoW.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookstoreController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public BookstoreController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<Books>
        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _unitOfWork.Books.All();
        }


        // GET api/<Books>/5
        [HttpGet("{id}")]
        public async Task<Book> Get(int id)
        {
            return await _unitOfWork.Books.GetById(id);
        }

        [HttpGet("getbygenre/{genre}")]
        public async Task<IEnumerable<Book>> GetByGenre(string genre)
        {
            Expression<Func<Book, bool>> byGenre = s => s.Genre == genre;
            return await _unitOfWork.Books.Find(byGenre);
        }


        // POST api/<Books>
        [HttpPost("AddScenario")]
        public async Task<IActionResult> Post()
        {
            var Catalog = new Catalog
            {
                CatalogueId = 4,
                Name = "Programming Books",
                Description = "Books on Software development"
            };
            var book = new Book
            {
                Id = 4,
                Genre = "Technology",
                Author = "Charles Petzold",
                Title = "Programming Windows 5th Edition",
                Price = 30,
                Publisher = "Microsoft Press",
                Catalog =Catalog
            };

            await _unitOfWork.Books.Upsert(book);
            await _unitOfWork.Catalogs.Upsert(Catalog);
            await _unitOfWork.CompleteAsync();


            return Ok();
        }


        [HttpPost("DeleteAndUpdateScenario")]
        public async Task<IActionResult> PostUpdateDelete()
        {
            var Catalog = new Catalog
            {
                CatalogueId = 4,
                Name = "Programming Books",
                Description = "Books on Software development for beginners"
            };
            var book = new Book
            {
                Id = 4,
                Genre = "Technology",
                Author = "Charles Petzold",
                Title = "Programming Windows 5th Edition",
                Price = 30,
                Publisher = "Microsoft Press",
                Catalog = Catalog
            };

            await _unitOfWork.Books.Upsert(book);
            await _unitOfWork.Catalogs.Upsert(Catalog);
            await _unitOfWork.Catalogs.Delete(Catalog.CatalogueId);
            await _unitOfWork.CompleteAsync();


            return Ok();
        }


        // PUT api/<Books>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Books>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

}
