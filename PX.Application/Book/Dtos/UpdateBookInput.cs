using System;
namespace PX.Application.Book.Dtos
{
    public class UpdateBookInput
    {
        public string Name { get; set; }
        public int NumberOfPages { get; set; }
        public DateTime DateOfPublication { get; set; }
        public string Authors { get; set; }
    }
}
