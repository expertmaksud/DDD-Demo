using System;
namespace PX.Application.Book.Dtos
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int NumberOfPages { get; set; }
        public DateTime DateOfPublication { get; set; }
        public string Authors { get; set; }
        public DateTime CreateDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public long? UpdateBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
