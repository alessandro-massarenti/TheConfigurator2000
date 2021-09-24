using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheConfigurator2000.Classes;

namespace TheConfigurator2000.Data
{
    public class QuotationService : IQuotationService
    {

        public void AddProductToQuotation(Product product,Quotation quotation)
        {
            using var context = new Context.AppDbContext();

            context.Quotations.Find(quotation.Id).Products.Add(product);
            context.SaveChanges();
        }

        public void AddQuotation(Quotation quotation)
        {

            if (quotation.Id == Guid.Empty)
            {
                var id = Guid.NewGuid();
                quotation.Id = id;
            }
            using var context = new Context.AppDbContext();
            context.Quotations.Add(quotation);
            context.SaveChanges();
        }

        public void DeleteQuotation(Guid id)
        {
            using var context = new Context.AppDbContext();
            context.Quotations.Remove(GetQuotation(id));
            context.SaveChanges();
        }

        public Quotation GetQuotation(Guid id)
        {
            using var context = new Context.AppDbContext();


            //var q = context.Quotations.First();
            ////List<TheConfigurator2000.Classes.Product> products = context.Quotations.First().Products.ToList();

            ////Carica i prodotti
            //context.Entry(q).Collection(s => s.Products).Load();

            var q = context.Quotations.SingleOrDefault(q => q.Id == id);
            if (q != null)
            context.Entry(q).Collection(s => s.Products).Load();

            return q;
        }

        public List<Quotation> GetQuotations()
        {
            using var context = new Context.AppDbContext();

            List<Quotation> q = context.Quotations.ToList();
            foreach (var x in q)
            {
                context.Entry(x).Collection(s => s.Products).Load();
            }
            return q;
        }

        public void RemoveProductFromQuotation(Product product, Quotation quotation)
        {
            quotation.Products.Remove(product);
            UpdateQuotation(quotation);
        }

        public void UpdateQuotation(Quotation quotation)
        {

            using var context = new Context.AppDbContext();

            var oldQuotation = context.Quotations.FirstOrDefault(q => q.Id == quotation.Id);


            oldQuotation.Name = quotation.Name;
            oldQuotation.Products = quotation.Products;

            context.SaveChanges();

        }
    }
}
