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
    }
}