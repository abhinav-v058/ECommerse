using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerse.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace ECommerse.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        [HttpGet]
        public async Task<IEnumerable<APIProduct>> Get()
        {
            return new[] { new APIProduct {
                Id = Guid.NewGuid(),
                Name = "Fake",
                Description = "Description of this product",
                IsAvailable = true,
                Price = 234
            }
            };
        }
    }
}
