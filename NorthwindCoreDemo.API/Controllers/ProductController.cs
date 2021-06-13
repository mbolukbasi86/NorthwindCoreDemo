using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindCoreDemo.API.RequestModel;
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
        private readonly NorthwindDbContext _northwindDbContext; //It' for demo. Do not use DbContext in Controller.!!!

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
    }
}
