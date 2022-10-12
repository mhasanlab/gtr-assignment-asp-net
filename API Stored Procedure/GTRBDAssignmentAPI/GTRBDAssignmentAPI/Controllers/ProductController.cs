using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GTRBDAssignmentAPI.Models;
using Microsoft.AspNetCore.Hosting;

namespace GTRBDAssignmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository productRepository;
        private IWebHostEnvironment webHostEnvironment;

        public ProductController(IProductRepository repo, IWebHostEnvironment environment)
        {
            productRepository = repo;
            webHostEnvironment = environment;
        }

         
        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return productRepository.GetAllProducts().ToList();
        }

        // GET: api/Product/id

        [HttpGet("{id}")]
        public Product GetProductById(int id)
        {
            return productRepository.GetProductById(id);
        }

        // POST: api/Product

        [HttpPost]
        public Product Create([FromBody] Product product)
        {
            return productRepository.AddProduct(product);
        }

        // PUT: api/Product/1

        [HttpPut]
        public Product Update([FromForm] Product product)
        {
            return productRepository.UpdateProduct(product);
        }

        // DELETE: api/Product/1

        [HttpDelete("{id}")]
        public void Delete(int? id) => productRepository.DeleteProduct(id);
    }
}
