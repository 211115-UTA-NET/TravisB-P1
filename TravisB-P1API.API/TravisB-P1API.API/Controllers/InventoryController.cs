using TravisB_P1API.API;
using TravisB_P1API.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using TravisB_P1.DataStorage;
using TravisB_P1.Logic;

namespace TravisB_P1API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly SqlRepository _repository;

        public InventoryController(SqlRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("/inventory")]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetStoreInventory([FromQuery, Required] Locations location)
        {
            IEnumerable<Inventory> inventory;
            try
            {
                inventory = await _repository.GetStoreInventoryAsync(location);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("In the catch block, 500 incoming");
                return StatusCode(500);
            }
            return inventory.ToList();
        }
    }
}
