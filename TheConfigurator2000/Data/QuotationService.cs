using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheConfigurator2000.Classes;

namespace TheConfigurator2000.Data
{
    public class QuotationService : IQuotationService
    {

        private List<Quotation> Quotations = new()
        {
            new Quotation
            {
                Id = Guid.NewGuid(),
                Name = "Quotazione1",
                Products = new()
            },
            new Quotation
            {
                Id = Guid.NewGuid(),
                Name = "Qutoazione2",
                Products = new()
            }
        };

        public void AddProductToQuotation(Product product,Quotation quotation)
        {
            quotation.Products.Add(product);
            UpdateQuotation(quotation);
        }

        public void AddQuotation(Quotation quotation)
        {
            var id = Guid.NewGuid();
            quotation.Id = id;
            Quotations.Add(quotation);
        }

        public void DeleteQuotation(Guid id)
        {
            var quotation = GetQuotation(id);
            Quotations.Remove(quotation);
        }

        public Quotation GetQuotation(Guid id)
        {
            return Quotations.SingleOrDefault(x => x.Id == id);
        }

        public List<Quotation> GetQuotations()
        {
            return Quotations;
        }

        public void RemoveProductFromQuotation(Product product, Quotation quotation)
        {
            quotation.Products.Remove(product);
            UpdateQuotation(quotation);
        }

        public void UpdateQuotation(Quotation quotation)
        {
            var oldQuotation = GetQuotation(quotation.Id);

            oldQuotation.Name = quotation.Name;
            oldQuotation.Products = quotation.Products;

        }
    }
}
