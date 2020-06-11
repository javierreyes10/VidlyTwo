using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidlyTwo.Models;

namespace VidlyTwo.Services
{
    interface ICustomerRepository
    {
        IEnumerable<Customer> Customers();
        Customer CustomerById(int id);
    }

    public class CustomerRepository : ICustomerRepository
    {
    

        private ApplicationDbContext _context;

        public CustomerRepository()
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
            return _context.Customers.Include(c => c.MembershipType).FirstOrDefault(c => c.Id == id);
        }
    }

}
