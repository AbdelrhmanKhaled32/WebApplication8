using System.ComponentModel.DataAnnotations;

namespace book.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ?Title { get; set; }
        [Required]
        public DateTime ?publishyear { get; set; }
        public List<Author> ?author { get; set; }

    }
}
