using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PX.Application.Book.Dtos;
using PX.Core.Abstraction;

namespace PX.Application.Book
{
    public interface IBookService : IAppServiceBase
    {
        Task AddBook(AddBookInput input);
        Task<IEnumerable<BookDto>> GetAllBooks();
        Task<BookDto> GetBookById(Guid id);
        Task<BookDto> UpdateBook(Guid id, UpdateBookInput input);
        Task<bool> SoftDelete(Guid id);
    }
}
