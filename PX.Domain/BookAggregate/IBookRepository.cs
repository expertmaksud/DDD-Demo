using System;
using PX.Core.Abstraction;
using PX.Domain.Entities;

namespace PX.Domain.BookAggregate
{
    public interface IBookRepository : IRepository<Book>
    {
    }
}
