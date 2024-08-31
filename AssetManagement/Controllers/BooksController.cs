using AssetManagement.Models;
using AssetManagement.Repositories;
using AssetManagement.Repository.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Cryptography.Xml;
//using System.Web.Http;

namespace AssetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _genericRepository;
        public BooksController(IBookRepository context)
        {
            _genericRepository = context;
        }

        /// <summary>
        /// This action method retrieves a list of all books from the database. 
        /// It queries the books table to get all available book records and returns them.
        /// The method returns an ActionResult containing an enumerable collection of Book objects.
        /// </summary>
        /// <returns></returns>
        [NotImplementedActionFilter]
        [HttpGet]
        public async Task<ActionResult> GetAllBooks()
        {
            //var book = await _genericRepository.GetAll();
            //return Ok(book);

            throw new NotImplementedException("This method is not implemented");
        }

        /// <summary>
        /// This action method retrieves a specific book record from the database based on the provided ID.
        /// It uses the FindAsync method to locate the book by its primary key.
        /// If the book with the specified ID is found, it returns the book wrapped in an Ok response. 
        /// If no book with the given ID is found, it returns a NotFound response.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        
        [HttpGet("{ID}:int")]
        public async Task<ActionResult> GetBook(int ID)
        {
            var book = await _genericRepository.Get(ID);

            if (book == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(String.Format("No employee found with ID = {0}", ID)),
                    ReasonPhrase = "Employee not found"
                };
                throw new System.Web.Http.HttpResponseException(response);
            }

            return Ok(book);
        }

        /// <summary>
        /// This action method is used to create a new book record in the database. 
        /// It accepts a Book object from the request body, adds it to the books table and then saves the changes.
        /// Upon successful creation, it returns a CreatedAtAction response that includes the location of the newly created book resource and the book object itself.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> PostNewBook(Book book)
        {
            await _genericRepository.Add(book);

            return Created();
        }

        /// <summary>
        /// This action method is used to delete a specific book record from the database. 
        /// It first locates the book by its ID using FindAsync.
        /// If the book is found, it removes the book from the books table and saves the changes.
        /// If the book with the given ID does not exist, it returns a NotFound response. On successful deletion, it returns a NoContent response.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpDelete("{ID}")]
        public async Task<ActionResult> DeleteBook(int ID)
        {
            await _genericRepository.Delete(ID);
            return NoContent();
        }

        /// <summary>
        /// This action method updates an existing book record in the database with the provided ID.
        /// t first locates the book using FindAsync.
        /// If the book is found, it updates the book's properties with the values provided in the Book object from the request body.
        /// After updating the properties, it sets the entity's state to Modified and saves the changes asynchronously.
        /// If the book with the specified ID is not found, it returns a BadRequest response indicating that the request is invalid.
        /// On successful update, it returns a NoContent response.
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPut("{ID}")]
        public async Task<ActionResult> EditBook(int ID, Book book)
        {
            await _genericRepository.Edit(ID, book);
            return NoContent();
        }


        [HttpGet("{AuthorName}")]
        public async Task<ActionResult> GetBooksByAuthor(string AuthorName)
        {
            var book = await _genericRepository.GetByAuthorName(AuthorName);
            return Ok(book);
        }
    }
}
