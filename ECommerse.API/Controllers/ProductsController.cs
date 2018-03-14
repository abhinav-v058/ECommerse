using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Productcatalog.Model;
using ECommerse.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Services.Remoting.Client;

namespace ECommerse.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductCatalogService _catalogService;

        public ProductsController()
        {
            _catalogService = ServiceProxy.Create<IProductCatalogService>(new Uri("fabric:/ECommerce/ProductCatalog"),
                new Microsoft.ServiceFabric.Services.Client.ServicePartitionKey(0));
        }

        [HttpGet]
        public async Task<IEnumerable<APIProduct>> Get()
        {
            IEnumerable<Product> products = await _catalogService.GetAllProducts();
            return products.Select(s => new APIProduct
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                IsAvailable = (s.Availability > 0),
                Price = s.Price
            });
            
        }
    }
}
