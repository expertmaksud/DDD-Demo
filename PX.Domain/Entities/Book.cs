using System;
using PX.Core.Audit;

namespace PX.Domain.Entities
{
    public class Book : FullyAuditedEntity<Guid>
    {
        public Book()
        {
        }

        public string Name { get; set; }
        public int  NumberOfPages { get; set; }
        public DateTime DateOfPublication { get; set; }
        public string Authors { get; set; }
    }
}
