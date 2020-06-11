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
        private readonly CustomerRepository _customerService;

        public CustomersController()
        {
            _customerService = new CustomerRepository();
        }
        public ActionResult Index()
        {
            return View(_customerService.Customers());
        }

        public ActionResult Details(int id)
        {

            var customer = _customerService.CustomerById(id);

            if (customer == null) return HttpNotFound();

            return View(customer);
        }
    }
}