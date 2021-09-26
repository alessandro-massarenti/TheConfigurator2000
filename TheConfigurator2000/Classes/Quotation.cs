using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheConfigurator2000.Classes
{
    public class Quotation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<QuotationProduct> QuotationProducts { get; set; } = new();

        //public virtual ICollection<QuotationProductMapping> QuotationProductMappings { get; set; }

        public double GetTotalPrice()
        {
            double total = 0;
            foreach (var productMap in QuotationProducts)
            {
                total += productMap.Product.Price * productMap.Count;
            }

            return total;
        }

    }
}
