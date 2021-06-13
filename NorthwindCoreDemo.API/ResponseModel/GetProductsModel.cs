using NorthwindCoreDemo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindCoreDemo.API.ResponseModel
{
    public class GetProductsModel : Responsebase
    {
        public List<Product> Products { get; set; }
    }
}
