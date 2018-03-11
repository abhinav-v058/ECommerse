using ECommerce.Productcatalog.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Productcatalog
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task AddProduct(Product product);
    }
}
