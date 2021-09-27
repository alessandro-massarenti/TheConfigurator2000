using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheConfigurator2000.Classes;

namespace TheConfigurator2000.Data
{
    public class CustomerService : ICustomerService
    {
        public void AddCustomer(Customer customer)
        {
            var id = Guid.NewGuid();
            customer.Id = id;

            using var context = new Context.AppDbContext();

            context.Customers.Add(customer);

            context.SaveChanges();
        }

        public void DeleteCustomer(Guid id)
        {
            using var context = new Context.AppDbContext();
            context.Customers.Remove(GetCustomer(id));
            context.SaveChanges();
        }

        public Customer GetCustomer(Guid id)
        {
            using var context = new Context.AppDbContext();
            return context.Customers.SingleOrDefault(q => q.Id == id);
        }

        public List<Customer> GetCustomers()
        {
            using var context = new Context.AppDbContext();
            return context.Customers.ToList();
        }

        public void UpdateCustomer(Customer customer)
        {
            Customer oldProduct = GetCustomer(customer.Id);

            oldProduct.Name = customer.Name;

            using var context = new Context.AppDbContext();
            context.Attach(oldProduct).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                context.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                if (!CustomerExists(customer.Id))
                {
                    return;
                }
                else
                {
                    throw;
                }
            }
        }

        private static bool CustomerExists(Guid id)
        {
            using var context = new Context.AppDbContext();
            return context.Customers.Any(e => e.Id == id);
        }
    }
}
