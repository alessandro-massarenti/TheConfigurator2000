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
        public List<Product> Products { get; set; } = new();

        //public virtual ICollection<QuotationProductMapping> QuotationProductMappings { get; set; }

        public double GetTotalPrice()
        {
            double total = 0;
            foreach (var product in Products)
            {
                total += product.Price;
            }

            return total;
        }

    }
}
