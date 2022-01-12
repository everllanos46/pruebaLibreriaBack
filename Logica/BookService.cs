namespace Logica;
using Datos;
using Entidad;
public class BookService
{
    private LibraryContext _context;
    public BookService (LibraryContext context)
	{
           _context=context; 
	}

    public async Task<Response<Book>> RegisterBook(Book book)
    {
        try
        {
            book.State=1;
            _context.Books.Add(book);
            _context.SaveChanges();
            return new Response<Book>(book, "Registrado correctamente");
            
        } catch (Exception ex)
        {
            return new Response<Book>($"Hubo un error en la aplicación, {ex.Message}");
        }
    }

    public async Task<Response<Book>> GetBooks()
    {
        try
        {
           List<Book> books = _context.Books.ToList();
           return new Response<Book>(books, "Consultado Correctamente");
        } catch (Exception ex)
        {
            return new Response<Book>($"Hubo un error en la aplicación, {ex.Message}");
        }
    }

    public async Task<Response<Book>> EditBook(Book book){
        try{
            var bookEdit = _context.Books.Find(book.BookId);
            if(bookEdit!=null){
                bookEdit=book;
                _context.Books.Update(bookEdit);
                _context.SaveChanges();
                return new Response<Book>(bookEdit, "Editado correctamente");
            }
            return new Response<Book>("No se encontró al libro que quiere editar");
        }catch (Exception ex)
        {
            return new Response<Book>($"Hubo un error en la aplicación, {ex.Message}");
        }
    }

    public async Task<Response<Book>> DeleteBook(Book book){
        try{
            var bookEdit = _context.Books.Find(book.BookId);
            if(bookEdit!=null){
                bookEdit.State=0;
                _context.Books.Update(bookEdit);
                _context.SaveChanges();
                return new Response<Book>(bookEdit, "Eliminado correctamente");
            }
            return new Response<Book>("No se encontró al libro que quiere editar");
        }catch (Exception ex)
        {
            return new Response<Book>($"Hubo un error en la aplicación, {ex.Message}");
        }
    }
   
}



