using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheConfigurator2000.Classes;

namespace TheConfigurator2000.Data
{
    public class QuotationService : IQuotationService
    {


        public void AddQuotation(Quotation quotation)
        {
            if (quotation.Id == Guid.Empty)
            {
                quotation.Id = Guid.NewGuid();
            }
            using (var context = new Context.AppDbContext())
            {
                context.Quotations.Add(quotation);
                context.SaveChanges();
            }
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

            var quotation = context.Quotations.SingleOrDefault(q => q.Id == id);
            if (quotation != null)
            {
                context.Entry(quotation).Collection(s => s.QuotationProducts).Load();
                foreach (var qp in quotation.QuotationProducts)
                {
                    context.Entry(qp).Reference(t => t.Product).Load();
                }
            }

            return quotation;
        }

        public List<Quotation> GetQuotations()
        {
            using (var context = new Context.AppDbContext())
            {

                List<Quotation> quotations = context.Quotations.ToList();
                foreach (var q in quotations)
                {
                    context.Entry(q).Collection(s => s.QuotationProducts).Load();
                    foreach(var qp in q.QuotationProducts)
                    {
                       context.Entry(qp).Reference(t=> t.Product).Load();
                    }
                }
                return quotations;
            }
        }

        public void UpdateQuotation(Quotation quotation)
        {

            using (var context = new Context.AppDbContext())
            {

                var oldQuotation = context.Quotations.Find(quotation.Id);

                oldQuotation.Name = quotation.Name;

                context.SaveChanges();
            }

        }

        public void AddProductToQuotation(Product product, Quotation quotation)
        {
            using (var context = new Context.AppDbContext())
            {

                var quotationProduct = context.QuotationProduct.Find(quotation.Id, product.Id);

                if (quotationProduct == null) { 

                    quotationProduct = new QuotationProduct() { QuotationId = quotation.Id, ProductId = product.Id };
                    context.Quotations.Find(quotation.Id).QuotationProducts.Add(quotationProduct);
                }
                else
                    quotationProduct.Count++;

               

                //context.Quotations.Find(quotation.Id).QuotationProducts.Find(quotationProduct.QuotationId,quotationProduct.ProductId).Count++;

                context.SaveChanges();
            }
        }

        public void RemoveProductFromQuotation(Product product, Quotation quotation)
        {
            using (var context = new Context.AppDbContext())
            {
                var quotationInDb = context.Quotations.Find(quotation.Id);
                context.Entry(quotationInDb).Collection(s => s.QuotationProducts).Load();


                var quotationProduct = context.QuotationProduct.Find(quotation.Id, product.Id);
                if (quotationProduct.Count > 1)
                    quotationProduct.Count--;
                else
                    quotationInDb.QuotationProducts.Remove(quotationProduct);
                context.SaveChanges();
            }
        }

        public int GetProductsCount(List<QuotationProduct> quotationProducts)
        {
            int tot = 0;

            foreach(var product in quotationProducts)
            {
                    tot += product.Count;
            }

            return tot;
        }
    }
}
