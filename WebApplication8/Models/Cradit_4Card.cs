using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace book.Models
{
    public class Cradit_Card
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ?Name { get; set; }
        [Required]
        [Range(10,20)]
        public int number { get; set; }
        public int id_author { get; set; }
        public Author ?author { get; set; }
    }
}
