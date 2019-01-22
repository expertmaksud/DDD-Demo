using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PX.Application.Book;
using PX.Application.Book.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PX.Api.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        // GET: api/books
        [HttpGet]
        public async Task<IEnumerable<BookDto>> Get()
        {
            return await _bookService.GetAllBooks();

        }

        // GET api/books/guid
        [HttpGet("{id}")]
        public async Task<BookDto> Get(Guid id)
        {
            return await _bookService.GetBookById(id);
        }

        // POST api/books
        [HttpPost]
        public async Task Post([FromBody] AddBookInput request)
        {
            await _bookService.AddBook(request);
        }

        // PUT api/books/guid
        [HttpPut("{id}")]
        public async Task<BookDto> Put(Guid id, [FromBody]UpdateBookInput value)
        {
            return await _bookService.UpdateBook(id, value);
        }

        // DELETE api/books/guid
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _bookService.SoftDelete(id);
        }
    }
}