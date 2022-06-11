using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase 
    {
        private readonly StoreContext _context;
        public ProductController(  StoreContext context)
        {
            _context = context;


        }

        [HttpGet]
        public  async Task<ActionResult<List<Product>>>GetProducts()
        {
            var products = await _context.Products.ToListAsync();

            return Ok(products);
        }

        /*public string Getproducts()
        {
            return "This will return a list of products ";
        } */ 

        [HttpGet("{ID}")]

        public async Task<ActionResult<Product>> Getproduct(int ID)
        {
            return await _context.Products.FindAsync(ID);
        }
        
    }
}