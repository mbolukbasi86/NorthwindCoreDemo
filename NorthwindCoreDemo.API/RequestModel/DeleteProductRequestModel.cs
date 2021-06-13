using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindCoreDemo.API.RequestModel
{
    public class DeleteProductRequestModel : RequestBase
    {
        public int ProductId { get; set; }
    }
}
