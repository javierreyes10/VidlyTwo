using System.Collections.Generic;
using VidlyTwo.Models;

namespace VidlyTwo.Services
{
    interface ICustomerRepository
    {
        IEnumerable<Customer> Customers();
        Customer CustomerById(int id);
        IEnumerable<MembershipType> MembershipTypes();
        void Add(Customer customer);
        void Save(Customer customer);
    }
}