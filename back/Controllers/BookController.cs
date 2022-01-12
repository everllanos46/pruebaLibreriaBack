using System;
using Logica;
using Datos;
using Microsoft.AspNetCore.Mvc;
using Entidad;

namespace back.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
	private BookService _bookService;
	public BookController(LibraryContext context)
	{
		_bookService = new BookService(context);
	}


	[HttpPost("[action]")]
	public async Task<ActionResult<Response<Book>>> AddNewBook(Book book){
		try{
			var response = await _bookService.RegisterBook(book);
			if(response!=null && !response.Error){
				return response;
			} 
			return StatusCode(204);
		} catch(Exception e){
			return StatusCode(500);
		}
	}

	[HttpGet("[action]")]
	public async Task<ActionResult<Response<Book>>> GetBooks(){
		try{
			var response = await _bookService.GetBooks();
			if(response!=null && !response.Error){
				return response;
			} 
			return StatusCode(204);
		} catch(Exception e){
			return StatusCode(500);
		}
	}

	[HttpPut("[action]")]
	public async Task<ActionResult<Response<Book>>> EditBook(Book book){
		try{
			var response = await _bookService.EditBook(book);
			if(response!=null && !response.Error){
				return response;
			} 
			return StatusCode(204);
		} catch(Exception e){
			return StatusCode(500);
		}
	}

	[HttpDelete("[action]")]
	public async Task<ActionResult<Response<Book>>> Delete(Book book){
		try{
			var response = await _bookService.DeleteBook(book);
			if(response!=null && !response.Error){
				return response;
			} 
			return StatusCode(204);
		} catch(Exception e){
			return StatusCode(500);
		}
	}

}
