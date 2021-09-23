using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheConfigurator2000.Classes;


namespace TheConfigurator2000.Data
{
    interface IQuotationService
    {

        List<Quotation> GetQuotations();

        Quotation GetQuotation(Guid id);

        void UpdateQuotation(Quotation quotation);

        void AddQuotation(Quotation quotation);

        void DeleteQuotation(Guid id);

        void AddProductToQuotation(Product product,Quotation quotation);
        void RemoveProductFromQuotation(Product product, Quotation quotation);
    }
}
