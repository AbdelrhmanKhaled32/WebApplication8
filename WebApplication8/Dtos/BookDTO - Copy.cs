using book.Models;
using System.ComponentModel.DataAnnotations;

namespace book.Dtos
{
    public class BookDTO1
    {
        public string? Title { get; set; }
        public DateTime? publishyear { get; set; }
        public List<AuthorDTO1> authors { get; set; }
    }
}
