using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheConfigurator2000.Classes;

namespace TheConfigurator2000.Data
{
    interface ICustomerService
    {
        List<Customer> GetCustomers();
        Customer GetCustomer(Guid id);

        void UpdateCustomer(Customer customer);
        void AddCustomer(Customer customer);
        void DeleteCustomer(Guid id);


    }
}
