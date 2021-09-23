using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheConfigurator2000.Classes;

namespace TheConfigurator2000.Data
{
    interface IProductsService
    {

        List<Product> GetProducts();

        Product GetProduct(Guid id);

        void UpdateProduct(Product product);

        void AddProduct(Product product);

        void DeleteProduct(Guid id);
    }
}
