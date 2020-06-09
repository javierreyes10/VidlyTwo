using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidlyTwo.Models;

namespace VidlyTwo.Services
{
    interface ICustomerService
    {
        List<Customer> Customers();
        Customer CustomerById(int id);
    }

    public class CustomerService : ICustomerService
    {
        private List<Customer> _customers;

        public CustomerService()
        {
            _customers = new List<Customer>
            {
                new Customer {Id = 1, Name = "Customer 1"},
                new Customer {Id = 2, Name = "Customer 2"},
                new Customer {Id = 3, Name = "Customer 3"}
            };
        }

        public List<Customer> Customers()
        {
            return _customers;
        }

        public Customer CustomerById(int id)
        {
            return _customers.FirstOrDefault(c => c.Id == id);
        }
    }

}
