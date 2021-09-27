using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheConfigurator2000.Classes
{
    public class Customer
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<Quotation> Quotations { get; set; }

    }
}
