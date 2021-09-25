using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TheConfigurator2000.Classes
{
    public class Product
    {

        public Guid Id { get; set; }
        public String Name { get; set; }
        public double Price { get; set; }

        //Navigation properties
        public List<Quotation> Quotations { get; set; }
    }
}
