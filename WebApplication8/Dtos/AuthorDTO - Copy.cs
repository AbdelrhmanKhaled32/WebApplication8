using book.Models;
using System.ComponentModel.DataAnnotations;

namespace book.Dtos
{
    public class AuthorDTO1
    {
        public string? Name { get; set; }
        [Required]
        public string? email { get; set; }
        public List<Cradit_CardDTO>? craditdto { get; set; }
        public NationalIDDTO? nationalIDDTO { get; set; }
    }
}
