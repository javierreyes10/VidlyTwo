using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidlyTwo.Models;

namespace VidlyTwo.Services
{
    interface ICustomerService
    {
        IEnumerable<Customer> Customers();
        Customer CustomerById(int id);
    }

    public class CustomerService : ICustomerService
    {
    

        private ApplicationDbContext _context;

        public CustomerService()
        {
            _context = new ApplicationDbContext();
        }

        protected void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IEnumerable<Customer> Customers()
        {
            return _context.Customers.Include(c => c.MembershipType);
        }

        public Customer CustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }
    }

}
