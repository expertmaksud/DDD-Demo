using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PX.Application.Book.Dtos;
using PX.Core.Abstraction;
using PX.Data.Repositories;
using PX.Domain.BookAggregate;
using PX.Domain.Entities;

namespace PX.Application.Book
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepo, IMapper mapper)
        {
            _bookRepo = bookRepo;
            _mapper = mapper;
        }

        public async Task AddBook(AddBookInput input)
        {
            try
            {
                var book = new PX.Domain.Entities.Book
                {
                    Id = new Guid(),
                    Name = input.Name,
                    NumberOfPages = input.NumberOfPages,
                    DateOfPublication = input.DateOfPublication,
                    Authors = input.Authors

                };

                await _bookRepo.Create(book);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<IEnumerable<BookDto>> GetAllBooks()
        {
            try
            {
                var books = await _bookRepo.GetAll();

                return _mapper.Map<IEnumerable<BookDto>>(books);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BookDto> GetBookById(Guid id)
        {
            try
            {
                var book = await _bookRepo.GetById(x => x.Id == id);

                return _mapper.Map<BookDto>(book);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> SoftDelete(Guid id)
        {
            try
            {
                var book = await _bookRepo.GetById(x => x.Id == id);

                book.IsDeleted = true;

                await _bookRepo.Update(book);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<BookDto> UpdateBook(Guid id, UpdateBookInput input)
        {
            try
            {

                var book = await _bookRepo.GetById(x => x.Id == id);

                book.Name = input.Name;
                book.NumberOfPages = input.NumberOfPages;
                book.DateOfPublication = input.DateOfPublication;
                book.Authors = input.Authors;
                book.UpdateDate = DateTime.UtcNow;

                await _bookRepo.Update(book);

                return _mapper.Map<BookDto>(book);
            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}
