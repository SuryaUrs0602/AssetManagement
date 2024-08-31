using AssetManagement.Models;
using AssetManagement.Repository.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Diagnostics.CodeAnalysis;

namespace AssetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwaresController : ControllerBase
    {
        private readonly IGenericRepository<Software> _genericRepository;

        public SoftwaresController(IGenericRepository<Software> context)
        {
            _genericRepository = context;
        }

        /// <summary>
        /// This action method retrieves a list of all Software from the database. 
        /// It queries the Software table to get all available Software records and returns them.
        /// The method returns an ActionResult containing an enumerable collection of Software objects.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAllSoftwares()
        {
            var software = await _genericRepository.GetAll();
            return Ok(software);
        }

        /// <summary>
        /// This action method retrieves a specific Software record from the database based on the provided ID.
        /// It uses the FindAsync method to locate the Software by its primary key.
        /// If the Software with the specified ID is found, it returns the Software wrapped in an Ok response. 
        /// If no Software with the given ID is found, it returns a NotFound response.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("{ID}")]
        public async Task<ActionResult> GetSoftware(int ID)
        {
            var software = await _genericRepository.Get(ID);

            if (software == null)
                return NotFound();

            return Created();
        }

        /// <summary>
        /// This action method is used to create a new software record in the database. 
        /// It accepts a software object from the request body, adds it to the software table and then saves the changes.
        /// Upon successful creation, it returns a CreatedAtAction response that includes the location of the newly created software resource and the software object itself.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddSoftware(Software software)
        {
            await _genericRepository.Add(software);
            return Created();
        }

        /// <summary>
        /// This action method is used to delete a specific software record from the database. 
        /// It first locates the software by its ID using FindAsync.
        /// If the software is found, it removes the software from the softwares table and saves the changes.
        /// If the software with the given ID does not exist, it returns a NotFound response. On successful deletion, it returns a NoContent response.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpDelete("{ID}")]
        public async Task<ActionResult> DeleteSoftware(int ID)
        {
            await _genericRepository.Delete(ID);
            return NoContent();
        }

        /// <summary>
        /// This action method updates an existing software record in the database with the provided ID.
        /// t first locates the software using FindAsync.
        /// If the software is found, it updates the software's properties with the values provided in the software object from the request body.
        /// After updating the properties, it sets the entity's state to Modified and saves the changes asynchronously.
        /// If the software with the specified ID is not found, it returns a BadRequest response indicating that the request is invalid.
        /// On successful update, it returns a NoContent response.
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPut("{ID}")]
        public async Task<ActionResult> EditSoftware(int ID, Software software)
        {
            await _genericRepository.Edit(ID, software);
            return NoContent();
        }
    }
}
