using AssetManagement.Models;
using AssetManagement.Repository.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HardwaresController : ControllerBase
    {
        private readonly IGenericRepository<Hardware> _genericRepository;

        public HardwaresController(IGenericRepository<Hardware> context)
        {
            _genericRepository = context;
        }

        /// <summary>
        /// This action method retrieves a list of all hardwares from the database. 
        /// It queries the hardware table to get all available hardwares records and returns them.
        /// The method returns an ActionResult containing an enumerable collection of hardware objects.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAllHardware()
        {
            var hardware = await _genericRepository.GetAll();
            return Ok(hardware);
        }

        /// <summary>
        /// This action method retrieves a specific hardware record from the database based on the provided ID.
        /// It uses the FindAsync method to locate the hardwares by its primary key.
        /// If the hardware with the specified ID is found, it returns the hardware wrapped in an Ok response. 
        /// If no hardware with the given ID is found, it returns a NotFound response.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("{ID}")]
        public async Task<ActionResult> GetHardware(int ID)
        {
            var hardware = await _genericRepository.Get(ID);

            if (hardware == null) 
                return NotFound();

            return Ok(hardware);
        }

        /// <summary>
        /// This action method is used to create a new hardware record in the database. 
        /// It accepts a hardware object from the request body, adds it to the hardware table and then saves the changes.
        /// Upon successful creation, it returns a CreatedAtAction response that includes the location of the newly created hardwares resource and the hardwares object itself.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddHardware(Hardware hardware)
        {
            await _genericRepository.Add(hardware);
            return Created();
        }

        /// <summary>
        /// This action method is used to delete a specific hardware record from the database. 
        /// It first locates the hardware by its ID using FindAsync.
        /// If the hardware is found, it removes the hardware from the hardwares table and saves the changes.
        /// If the hardware with the given ID does not exist, it returns a NotFound response. On successful deletion, it returns a NoContent response.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpDelete("{ID}")]
        public async Task<ActionResult> DeleteHardware(int ID)
        {
            await _genericRepository.Delete(ID);
            return NoContent();
        }

        /// <summary>
        /// This action method updates an existing hardware record in the database with the provided ID.
        /// t first locates the hardware using FindAsync.
        /// If the hardware is found, it updates the hardware's properties with the values provided in the hardware object from the request body.
        /// After updating the properties, it sets the entity's state to Modified and saves the changes asynchronously.
        /// If the hardware with the specified ID is not found, it returns a BadRequest response indicating that the request is invalid.
        /// On successful update, it returns a NoContent response.
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPut("{ID}")]
        public async Task<ActionResult> EditHardware(int ID, Hardware hardware)
        {
            await _genericRepository.Edit(ID, hardware);
            return NoContent() ;
        }
    }
}
