using System;
using Microsoft.EntityFrameworkCore;
using PX.Data.Factory;
using PX.Domain.BookAggregate;
using PX.Domain.Entities;

namespace PX.Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {

        public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
        { }
    }
}
