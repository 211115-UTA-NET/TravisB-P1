using TravisB_P1.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using TravisB_P1.DataStorage;

namespace TravisB_P1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : Controller
    {
        private readonly IRepository _repository;
        private readonly ILogger<InventoryController> _logger;

        public InventoryController(IRepository repository, ILogger<InventoryController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetMenuAsync([FromQuery, Required] Locations location)
        {
            IEnumerable<Inventory> inventory;
            try
            {
                inventory = await _repository.GetMenuAsync(location);
            }
            catch (Exception ex)
            {

            }
            return inventory.ToList();
        }
    }
}
