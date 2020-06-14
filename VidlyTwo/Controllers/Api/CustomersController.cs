using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyTwo.Models;

namespace VidlyTwo.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        //GET /api/customers/1
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customer == null)
                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());

            return customer;
        }

        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if(!ModelState.IsValid)
                throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());

            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customerInDB == null)
                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());

            customerInDB.Name = customer.Name;
            customerInDB.BirthDate = customer.BirthDate;
            customerInDB.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            customerInDB.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDB == null)
                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());

            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();
        }
    }
}
