using book.Models;
using System.ComponentModel.DataAnnotations;

namespace book.Dtos
{
    public class AuthorDTO
    {
        public string? Name { get; set; }
        [Required]
        public string? email { get; set; }
        public List<Cradit_CardDTO>? craditdto { get; set; }
        public List<BookDTO>? bookdto { get; set; }
        public NationalIDDTO? nationalIDDTO { get; set; }
    }
}
