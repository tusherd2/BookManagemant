using BookManagemant.Context;
using BookManagemant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookManagemant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookDBContext _dbContext;
        private readonly IConfiguration _configuration;
        public BookController(BookDBContext DBContext)
        {
            _dbContext = DBContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookss()
        {
            var books = await _dbContext.Books.ToListAsync();

            return Ok(books);
        }

        //[HttpPost]
        //public async Task<IActionResult> GetSearchedBookss([FromBody] BookModel bookRequest)
        //{
        //    var books = await _dbContext.Books.ToListAsync();

        //    return Ok(books);
        //}

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BookModel bookRequest)
        {
            bookRequest.Id = Guid.NewGuid();

            await _dbContext.Books.AddAsync(bookRequest);
            _dbContext.SaveChanges();

            return Ok(bookRequest);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetBook([FromRoute] Guid id)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);

            if(book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateBook([FromRoute] Guid id, BookModel bookRequest)
        {
            var book = await _dbContext.Books.FindAsync(id);

            if(book == null)
            {
                return NotFound();
            }

            book.BookName = bookRequest.BookName;
            book.PublisherName = bookRequest.PublisherName;
            book.Age = bookRequest.Age;
            book.PublishDate = bookRequest.PublishDate;
            book.PageNo = bookRequest.PageNo;
            book.BookType = bookRequest.BookType;

            await _dbContext.SaveChangesAsync();

            return Ok(book);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteBook([FromRoute] Guid id)
        {
            var book = await _dbContext.Books.FindAsync(id);

            if(book == null)
            {
                return NotFound();
            }

            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();

            return Ok(book);
        }
    }
}
