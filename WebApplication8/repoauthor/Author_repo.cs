using book.Data;
using book.Dtos;
using book.Models;
using Microsoft.EntityFrameworkCore;

namespace book.repoauthor
{
    public class Author_repo : IAuthor
    {
        private readonly AppDbContext context;
        public Author_repo(AppDbContext db)
        {
            context= db;
        }
        public void addauthor(AuthorDTO authorDTO)
        {
            var authro = new Author
            {
                Name = authorDTO.Name,
                email = authorDTO.email,
                nationalID = new NationalID { 
                number = authorDTO.nationalIDDTO.number },
                cradits = authorDTO.craditdto.Select(x => new Cradit_Card { Name = x.Name, number = x.number }).ToList(),
                books = authorDTO.bookdto.Select(x => new Book { Title = x.Title, publishyear = x.publishyear }).ToList()
            };  
            context.Author.Add(authro);
            context.SaveChanges();
        }

        public AuthorDTO getauthor(int id)
        {
            var author = context.Author.Include(q => q.cradits).Include(w => w.books).Include(e => e.nationalID).FirstOrDefault(x => x.Id_author_ == id);
            if (author != null)
            {
                return new AuthorDTO
                {
                    Name = author.Name,
                    email = author.email,
                    bookdto = author.books.Select(x => new BookDTO { Title = x.Title, publishyear = x.publishyear }).ToList(),
                    craditdto = author.cradits.Select(q => new Cradit_CardDTO { Name = q.Name, number = q.number }).ToList(),
                    nationalIDDTO = new NationalIDDTO { number = author.nationalID.number }
                };
            }
            return null;
        }
        public List<AuthorDTO> getauthorall()
        {
            var author = context.Author.
                Include(q => q.cradits).
                Include(w => w.books).
                Include(e => e.nationalID).
                Select(z=>
                new AuthorDTO {
                    Name=z.Name,
                    email=z.email,
                    craditdto=z.cradits.Select(q=>new Cradit_CardDTO { Name=q.Name,number=q.number}).ToList()
                    ,nationalIDDTO= new NationalIDDTO { number=z.nationalID.number},
                    bookdto=z.books.Select(a=>new BookDTO { Title=a.Title, publishyear=a.publishyear }).ToList(),
                }).ToList();
            return author;   
        }

        public void remove(int id)
        {
            var x = context.Author.Include(x=>x.books).Include(q=>q.cradits).FirstOrDefault(a => a.Id_author_ == id);
                context.Author.Remove(x);
                context.SaveChanges();
        }

        public void Updateauthor(AuthorDTO authorDTO,int id)
        {
            var author = context.Author.FirstOrDefault(x => x.Id_author_ == id);
            if (author != null) 
            {
                author.email = authorDTO.email;
                author.Name = authorDTO.Name;
                context.Author.Update(author);
                context.SaveChanges();
            }
        }
    }
}
