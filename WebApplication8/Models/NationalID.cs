using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace book.Models
{
    public class NationalID
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(10, 20)]
        public int number { get; set; }
        public int author_id { get; set; }
        [ForeignKey("author_id")]
        public Author ?author { get; set; }
    }
}
