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
        private readonly IRepository _repository;
        private readonly ILogger<InventoryController> _logger;

        public InventoryController(IRepository repository, ILogger<InventoryController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetStoreInventory([FromQuery, Required] Locations location)
        {
            IEnumerable<Inventory> inventory;
            try
            {
                inventory = await _repository.GetStoreInventoryAsync(location);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Sql error while getting store inventory", location);
                return StatusCode(500);
            }
            return inventory.ToList();
        }
    }
}
