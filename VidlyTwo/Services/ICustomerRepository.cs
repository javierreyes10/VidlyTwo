using System.Collections.Generic;
using VidlyTwo.Models;

namespace VidlyTwo.Services
{
    interface ICustomerRepository
    {
        IEnumerable<Customer> Customers();
        Customer CustomerById(int id);
    }
}