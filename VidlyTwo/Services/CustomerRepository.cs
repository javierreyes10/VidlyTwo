using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidlyTwo.Models;

namespace VidlyTwo.Services
{
    public class CustomerRepository : ICustomerRepository
    {
    

        private ApplicationDbContext _context;
        private ICustomerRepository _customerRepositoryImplementation;

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

        public IEnumerable<MembershipType> MembershipTypes()
        {
            return _context.MembershipTypes;
        }

        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Save(Customer customer)
        {
            var customersInDb = _context.Customers.Single(c => c.Id == customer.Id);

            customersInDb.Name = customer.Name;
            customersInDb.BirthDate = customer.BirthDate;
            customersInDb.MembershipTypeId = customer.MembershipTypeId;
            customersInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

            _context.SaveChanges();
        }
    }

}
