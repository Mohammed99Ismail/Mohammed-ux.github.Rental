using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using VenMovie.Dtos;
using VenMovie.Models;

namespace VenMovie.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _contect;
        public CustomersController()
        {
            _contect = new ApplicationDbContext();
        }
        //get/api/customers
        public IHttpActionResult GetCustomers(string query=null)
        {
            var customersQuery = _contect.Customers
               .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }
        //get/api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer= _contect.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound()
;           }
            return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }
        //post/api/cutomers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _contect.Customers.Add(customer);
            _contect.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }
        //put/api/cutomers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id,CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customerUpdate = _contect.Customers.SingleOrDefault(c => c.Id == id);
            if (customerUpdate == null)
            {
                return NotFound();
            }
            Mapper.Map(customerDto, customerUpdate);
            _contect.SaveChanges();
            return Ok();
        }
        //delete/api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerDelete = _contect.Customers.SingleOrDefault(c => c.Id == id);
            if (customerDelete == null)
            {
                return NotFound();
            }
            _contect.Customers.Remove(customerDelete);
            _contect.SaveChanges();
            return Ok();
        }
    }
}
