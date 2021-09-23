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
        public List<Product> Products { get; set; }

    }
}
