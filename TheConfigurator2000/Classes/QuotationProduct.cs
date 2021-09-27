using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheConfigurator2000.Classes
{
    public class QuotationProduct
    {
        public Guid QuotationId { get; set; }
        public Guid ProductId { get; set; }
        public virtual Quotation Quotation { get; set; }
        public virtual Product Product { get; set; }

        public int Count { get; set; } = 1;


        public double GetTotal()
        {
            return Product.Price * Count;
        }

    }
}
