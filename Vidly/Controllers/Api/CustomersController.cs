using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.DTOs;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IEnumerable<CustomerDTO> GetCustomers() {
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDTO>);
        }

        //GET /api/customers/id
        public IHttpActionResult GetCustomer(int id) {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer,CustomerDTO>(customer));
        }

        //POST /api/customers/id
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDTO) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDTO.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id),customerDTO);
        }

        //PUT /api/customers/id
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerDTO) {
            if (!ModelState.IsValid){
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDB = _context.Customers.Single(c => c.Id == id);
            if (customerInDB == null){
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map(customerDTO, customerInDB);

            _context.SaveChanges();
        }

        //DELETE /api/customers/id
        [HttpDelete]
        public void DeleteCustomer(int id) {
            var customerToDelete = _context.Customers.Single(c => c.Id == id);

            if (customerToDelete == null){
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerToDelete);
            _context.SaveChanges();
        }
    }
}
