using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Web.Http;
using Vidly_App.DTOs;
using Vidly_App.Models;

namespace Vidly_App.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: api/Customers
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customer = _context.Customer.Include(m => m.MembershipType);
            if (!string.IsNullOrWhiteSpace(query))
            {
               customer = customer.Where(c => c.Name.Contains(query));
            };
                
               var custDto = customer.ToList().Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(custDto);
        }

        // GET: api/Customers/5
        public IHttpActionResult GetCustomer(int id)
        {
            var user = _context.Customer.Include(m => m.MembershipType).SingleOrDefault(c => c.Id == id);
            if (user == null)
                return NotFound();
            return Ok(Mapper.Map<Customer,CustomerDto>(user));
        }

        // POST: api/Customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerdto)
        {
            if (!ModelState.IsValid)
               return NotFound();
            var customer = Mapper.Map<CustomerDto, Customer>(customerdto);
            _context.Customer.Add(customer);
            _context.SaveChanges();

            customerdto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customerdto.Id), customerdto);
        }

        // PUT: api/Customers/5
        [HttpPut]
        public IHttpActionResult PutCustomer(int id, CustomerDto customerDto)
        {
            var customer = _context.Customer.Single(c => c.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            Mapper.Map(customerDto, customer);
           
            _context.SaveChanges();

            return Ok(customerDto);
        } 

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var customer = _context.Customer.Single(c => c.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customer.Remove(customer);
            _context.SaveChanges();
            return Ok();

        }
    }
}
