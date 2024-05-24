
using Core.Entities;
using Core.Interfaces;
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
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;   
        }

        [HttpGet("GetProductById/{id}")]
        public async Task<Product> GetProductById(int id)
        {
            var product = await _repo.GetProductByIdAsync(id);

            return product;

        }

        [HttpGet("GetProducts")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            try
            {
                var products = await _repo.GetProductsAsync();

                return Ok(products);

            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }     
           
        }

        [HttpGet("GetProductTypes")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            var productTypesList = await _repo.GetProductTypesAsync();

            return Ok(productTypesList);
        }

        [HttpGet("GetProductBrands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            var productBrandList = await _repo.GetProductBrandsAsync();

            return Ok(productBrandList);
        } 
        

      
    }
}
