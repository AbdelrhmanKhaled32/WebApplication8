using book.Models;
using System.ComponentModel.DataAnnotations;

namespace book.Dtos
{
    public class BookDTO
    {
        public string? Title { get; set; }
        public DateTime? publishyear { get; set; }
    }
}
