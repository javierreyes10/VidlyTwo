using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyTwo.Services;

namespace VidlyTwo.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customerService = new CustomerService(); 

            return View(customerService.Customers());
        }

        public ActionResult Details(int id)
        {
            var customerService = new CustomerService();
            var customer = customerService.CustomerById(id);

            if (customer == null) return HttpNotFound();

            return View(customer);
        }
    }
}