using book.Dtos;

namespace WebApplication8.bookrepo
{
    public interface IBook
    {
        public void add(BookDTO1 bookDTO);
        public void remove(int id);
        public void update(BookDTO1 bookDTO,int id);
        public BookDTO1 get(int id);
        public List<BookDTO1> getall();

    }
}
