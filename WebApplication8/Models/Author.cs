using System.ComponentModel.DataAnnotations;

namespace book.Models
{
    public class Author
    {
        [Key]
        public int Id_author_ { get; set; }
        [Required]
        public string ?Name { get; set; }
        [Required]
        public string ?email { get; set; }
        public List<Cradit_Card>? cradits { get; set; }
        public List<Book>? books { get; set; }
        public NationalID ?nationalID { get; set; }
        
    }
}
