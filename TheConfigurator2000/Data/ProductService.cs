using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheConfigurator2000.Classes;

namespace TheConfigurator2000.Data
{
    public class ProductService : IProductsService
    {

        public void AddProduct(Product product)
        {
            var id = Guid.NewGuid();
            product.Id = id;

            using var context = new Context.AppDbContext();

            context.Products.Add(product);

            context.SaveChanges();
        }

        public void DeleteProduct(Guid id)
        {
            using var context = new Context.AppDbContext();
            context.Products.Remove(GetProduct(id));
        }

        public Product GetProduct(Guid id)
        {
            using var context = new Context.AppDbContext();
            return context.Products.SingleOrDefault(p => p.Id == id);
        }

        public List<Product> GetProducts()
        {
            using var context = new Context.AppDbContext();
            return context.Products.ToList();
        }

        public void UpdateProduct(Product product)
        {
            var oldProduct = GetProduct(product.Id);

            oldProduct.Name = product.Name;
            oldProduct.Price = product.Price;

            using (var context = new Context.AppDbContext())
            {
                context.Attach(oldProduct).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                try
                {
                    context.SaveChanges();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
                {
                    if (!QuotationExists(product.Id))
                    {
                        return;
                    }
                    else
                    {
                        throw;
                    }

                }
            }

        }

        private static bool QuotationExists(Guid id)
        {
            using var context = new Context.AppDbContext();
            return context.Products.Any(e => e.Id == id);
        }
    }
}
