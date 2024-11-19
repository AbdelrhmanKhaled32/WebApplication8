using book.Models;
using Microsoft.EntityFrameworkCore;

namespace book.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<NationalID> nationalIDs { get; set; }
        public DbSet<Cradit_Card> cards { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NationalID>().HasIndex(x => x.author_id).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
