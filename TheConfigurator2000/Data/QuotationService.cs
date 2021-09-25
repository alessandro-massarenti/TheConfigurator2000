﻿using System;
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
            context.Entry(quotation).Collection(s => s.Products).Load();

            return quotation;
        }

        public List<Quotation> GetQuotations()
        {
            using (var context = new Context.AppDbContext()){ 

                List<Quotation> quotations = context.Quotations.ToList();
                foreach (var x in quotations)
                {
                    context.Entry(x).Collection(s => s.Products).Load();
                }
                return quotations;
            }
        }

        public void UpdateQuotation(Quotation quotation)
        {

            using( var context = new Context.AppDbContext()) {

                var oldQuotation = context.Quotations.Find(quotation.Id);

            oldQuotation.Name = quotation.Name;

            context.SaveChanges();
        }

        }

        public void AddProductToQuotation(Product product, Quotation quotation)
        {
            using( var context = new Context.AppDbContext()){

                context.Quotations.Find(quotation.Id).Products.Add(product);

                context.SaveChanges();
            }
        }

        public void RemoveProductFromQuotation(Product product, Quotation quotation)
        {
            using (var context = new Context.AppDbContext())
            {
                var quotationInDb = context.Quotations.Find(quotation.Id);
                context.Entry(quotationInDb).Collection(s => s.Products).Load();
                quotationInDb.Products.Remove(context.Products.Find(product.Id));

                context.SaveChanges();



            }
        }
    }
}
