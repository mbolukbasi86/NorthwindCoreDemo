using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NorthwindCoreDemo.API.RequestModel;
using NorthwindCoreDemo.API.ResponseModel;
using NorthwindCoreDemo.Data;
using NorthwindCoreDemo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindCoreDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly NorthwindDbContext _northwindDbContext; //It's for demo. Do not use DbContext in Controller.!!!

        public ProductController(NorthwindDbContext northwindDbContext)
        {
            _northwindDbContext = northwindDbContext;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] AddProductRequestModel req)
        {
            var p = new Product
            {
                CategoryId = req.CategoryId,
                ProductName = req.ProductName,
                UnitPrice = req.UnitPrice,
                UnitsInStock = req.UnitsInStock,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            _northwindDbContext.Add(p);
            _northwindDbContext.SaveChanges();
            return Ok();
        }

        [HttpPost("Delete")]
        public IActionResult Delete([FromBody] DeleteProductRequestModel req)
        {
            var p = new Product();
            p.ProductId = req.ProductId;
            _northwindDbContext.Remove(p);
            _northwindDbContext.SaveChanges();
            return Ok();
        }
        [HttpGet("GetProducts")]
        public IActionResult GetProducts()
        {
            var p = new GetProductsModel();
            p.Products = _northwindDbContext.Product.ToList();
            return Ok(p);
        }
    }
}
