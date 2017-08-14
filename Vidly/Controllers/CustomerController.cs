using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        [Route("Customer/CustomerList")]
        public ActionResult CustomerList()
        {
            var customers = GetCustomers();
            var viewModel = new ListCustomerViewModel()
            {
                Customers = customers
            };
            return View(viewModel);
        }

        [Route("Customer/Details/{id}")]
        public ActionResult Details(int id) {
            if (string.IsNullOrEmpty(GetCustomerName(id)))
            {
                return HttpNotFound();
            }
            else {
                return Content("Customer Name:: " + GetCustomerName(id));
            }
        }

        private string GetCustomerName(int id) {
            string customerName = "";
            var customers = GetCustomers();
            foreach (Customer c in customers) {
                if (c.Id == id)
                    customerName = c.Name;
            }
            return customerName;
        }

        private IEnumerable<Customer> GetCustomers() {
            return new List<Customer>()
            {
                new Customer() {  Name = "Jyotnain", Id = 1 },
                new Customer() { Name = "Gaurav", Id = 2 }
            };
        }
    }
}