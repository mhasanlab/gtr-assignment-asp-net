using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTRBDAssignmentAPI.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        Product AddProduct(Product product);
        Product UpdateProduct(Product product);
        void DeleteProduct(int? id);
    }
}
