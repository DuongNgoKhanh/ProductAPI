using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Models;
using System.Data;

namespace ProductAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Get all product:GET /api/product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            if (products == null || !products.Any())
            {
                return NotFound("No products found.");
            }

            return Ok(products);
        }

        //Get product by id: GET /api/product/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByID(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound("No product has id " + id);
            }
            return Ok(product);
        }

        //Post new product:POST /api/product/
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            //Product has to have name
            if(string.IsNullOrEmpty(product.ProductName))
            {
                return BadRequest("Product name is required");
            }

            //The price has to >=0
            if (product.Price <=0)
            {
                return BadRequest("Product price has to greater than zero");
            }

            //The stock has to be positive
            if (product.StockQuantity < 0)
            {
                return BadRequest("The quantity cannot be negative");
            }

            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetProductByID), new { id = product.ProductId }, product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

        //Modified product by id: PUT /api/product/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product) {
            if(id != product.ProductId)
            {
                return BadRequest("Wrong product");
            }
            _context.Entry(product).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound("No product has id " + id);
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
