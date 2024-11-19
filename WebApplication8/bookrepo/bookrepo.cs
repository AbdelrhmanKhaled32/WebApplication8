using book.Data;
using book.Dtos;
using book.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace WebApplication8.bookrepo
{
    public class bookrepo : IBook
    {
        private readonly AppDbContext context;
        public bookrepo(AppDbContext db)
        {
            context = db;
        }
        public void add(BookDTO1 bookDTO)
        {
            var x = new Book
            {
                Title = bookDTO.Title,
                publishyear=bookDTO.publishyear,
                author=bookDTO.authors.Select(x=>new Author { nationalID=new NationalID { number=x.nationalIDDTO.number},Name=x.Name,email=x.email,cradits=x.craditdto.Select(q=>new Cradit_Card { Name=q.Name,number=q.number}).ToList(),}).ToList(),
            };
            context.Books.Add(x);
            context.SaveChanges();
        }

        public BookDTO1 get(int id)
        {
           var xq = context.Books.Include(q=>q.author).ThenInclude(q=>q.cradits).FirstOrDefault(s => s.Id == id);
            return new BookDTO1
            {
                Title = xq.Title,
                publishyear = xq.publishyear,
                authors = xq.author.Select(x => new AuthorDTO1 { Name = x.Name, email = x.email, nationalIDDTO = new NationalIDDTO { number = x.nationalID.number }, craditdto = x.cradits.Select(a => new Cradit_CardDTO { Name = a.Name, number = a.number }).ToList() }).ToList(),
            };


        }

        public List<BookDTO1> getall()
        {
            var xq = context.Books.
                Include(q => q.author).
                ThenInclude(q => q.cradits).
                Select(z=>new BookDTO1 { Title = z.Title, publishyear = z.publishyear, authors = z.author.
                Select(z => new AuthorDTO1
                {
                    Name = z.Name,
                    email = z.email,
                    craditdto = z.cradits.
                Select(w => new Cradit_CardDTO { Name = w.Name, number = w.number }).ToList(),
                    nationalIDDTO = new NationalIDDTO { number = z.nationalID.number }
                }).ToList() }).ToList();
            return xq;
        }

        public void remove(int id)
        {
            var xq = context.Books.Include(q => q.author).ThenInclude(q => q.cradits).FirstOrDefault(s => s.Id == id);
            if(xq != null)
            {
                context.Books.Remove(xq);
                context.SaveChanges();
            }
        }

        public void update(BookDTO1 bookDTO, int id)
        {
            var xq = context.Books.Include(q => q.author).FirstOrDefault(s => s.Id == id);
            if (xq != null)
            {
                throw new Exception("avalibale");
            }
            Book x = new Book
            {
                author = xq.author,
                Title = xq.Title,
                publishyear = xq.publishyear,
            };
            context.Books.Update(x);
            context.SaveChanges();
        }
    }
}
