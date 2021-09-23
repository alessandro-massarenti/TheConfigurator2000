using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheConfigurator2000.Classes;

namespace TheConfigurator2000.Data
{
    public class ProductService : IProductsService
    {
        private List<Product> Products = new()
        {
            new Product {
                Id = Guid.NewGuid(),
                Name = "Prodotto1",
                Price = 25
            },
            new Product {
                Id = Guid.NewGuid(),
                Name = "Prodotto2",
                Price = 23
            }
        };

        public void AddProduct(Product product)
        {
            var id = Guid.NewGuid();
            product.Id = id;
            Products.Add(product);

        }

        public void DeleteProduct(Guid id)
        {
            var product = GetProduct(id);
            Products.Remove(product);
        }

        public Product GetProduct(Guid id)
        {
            return Products.SingleOrDefault(x => x.Id == id);
        }

        public List<Product> GetProducts()
        {
            return Products;
        }

        public void UpdateProduct(Product product)
        {
            var oldProduct = GetProduct(product.Id);

            oldProduct.Name = product.Name;
            oldProduct.Price = product.Price;

        }
    }
}
