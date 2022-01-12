using Entidad;
using Microsoft.EntityFrameworkCore;

namespace Datos;
public class LibraryContext :DbContext
{
    public LibraryContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Book> Books{ get; set; }
    public DbSet<Log> Logs{ get; set; }
    public DbSet<User> Users{ get; set; }

}
