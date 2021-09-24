using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheConfigurator2000.Classes
{
    public class QuotationProductMapping
    {
        [Key, Column(Order = 0)]
        public Guid QuotationId { get; set; }
        [Key, Column(Order = 1)]
        public Guid ProductId { get; set; }
        public virtual Quotation Quotation { get; set; }
        public virtual Product Product { get; set; }

        public int count { get; set; }


    }
}
