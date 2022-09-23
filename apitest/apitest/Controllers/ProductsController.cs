using apitest.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace apitest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly Context _context;
        public ProductsController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult getProducts()
        {
            return Ok(_context.Products.ToList());
        }
        [HttpPut("{id}")]
        public IActionResult updateProduct(int id,Product product)
        {
            var updated = _context.Products.FirstOrDefault(x => x.Id == id);
            updated.Name = product.Name;
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult deleteProduct(int id)
        {
            var deleteProduct = _context.Products.FirstOrDefault(x => x.Id == id);
            _context.Remove(deleteProduct);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPost]
        public IActionResult addProducts(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
            return Created("", product);
        }
    }
}
