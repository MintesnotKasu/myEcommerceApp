
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _storeContext;

        public ProductsController(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        [HttpGet("GetProducts")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            try
            {
                var products = await _storeContext.Products.ToListAsync();

                return Ok(products);

            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }     
           
        }
        

        [HttpGet("GetProductById/{id}")]
        public async Task<Product> GetProductById(int id)
        {
            var product = await _storeContext.Products.FindAsync(id);

            return product;
            
        }
    }
}
