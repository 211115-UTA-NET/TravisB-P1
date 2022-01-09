﻿using TravisB_P1.API1;
using TravisB_P1.API1.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

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
        public async Task<ActionResult<IEnumerable<Inventory>>> GetStoreInventory([FromQuery, Required] Locations location)
        {
            IEnumerable<Inventory> inventory;
            try
            {
                inventory = await _repository.GetStoreInventory(location);
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

