    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyTwo.Models;
using VidlyTwo.Services;
using VidlyTwo.ViewModels;

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

        public ActionResult New()
        {
            var membershipTypes = _customerService.MembershipTypes();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes,
                Customer = new Customer()
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _customerService.MembershipTypes()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                _customerService.Add(customer);
            }
            else
            {
                _customerService.Save(customer);
            }

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _customerService.CustomerById(id);
            if (customer == null) return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _customerService.MembershipTypes()
            };
            return View("CustomerForm", viewModel);
        }
    }
}