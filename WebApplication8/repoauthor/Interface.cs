using book.Dtos;

namespace book.repoauthor
{
    public interface IAuthor
    {
        public void addauthor(AuthorDTO authorDTO);
        public void Updateauthor(AuthorDTO authorDTO, int id);
        public AuthorDTO getauthor(int id);
        public List<AuthorDTO> getauthorall();
        public void remove(int id);
    }
}
