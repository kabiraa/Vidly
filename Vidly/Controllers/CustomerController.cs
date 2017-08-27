using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

        public ActionResult CustomerForm()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid) {
                var customerFormModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", customerFormModel);
            }

            //_context.Customers.Add(customer);
            /*Note: This line does not mean that the customer object has been added into the DB.
            It is in memory of the DB context object. The DB context has the mechanism to verify if any change
            has been made to it.*/

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else {
                var existingCustomer = _context.Customers.Single(c => c.Id == customer.Id);

                existingCustomer.Name = customer.Name; //Could have used an automapper here.
                existingCustomer.Birthdate = customer.Birthdate;
                existingCustomer.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                existingCustomer.MembershipType = customer.MembershipType;
                existingCustomer.MembershipTypeId = customer.MembershipTypeId;
            }
            _context.SaveChanges(); // SQL statements are generate at runtime based on modifications made to DB context
                                    // run on the DB.
            return RedirectToAction("CustomerList", "Customer");
        }

        [Route("Customer/CustomerList")]
        public ActionResult CustomerList()
        {
            /*
             * The below line gives us the list of all customers, however note that Entity framework 
             * is not querying up the object as of now.
             */
            var customers = _context.Customers.Include(c=> c.MembershipType); // Customers is our DbSet
            
            var viewModel = new ListCustomerViewModel()
            {
                Customers = customers
            };
            return View(viewModel);
        }

        [Route("Customer/Details/{id}")]
        public ActionResult Details(int id) {
            var customers = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c=>c.Id == id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            else {
                return View(customers);
            }
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}