﻿using GeneralStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using System.Web.Http.Results;

namespace GeneralStoreAPI.Controllers
{
    public class CustomerController : ApiController
    {
        private StoreDbContext _context = new StoreDbContext();

        //Post--Create
        public IHttpActionResult Post(Customer customer)
        {
            //if an empty customer is passed in
            if (customer == null)
            {
                return BadRequest("Your request body cannot be empty.");
            }

            //If the ModelState is valid
            if (ModelState.IsValid == true)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest(ModelState);

        }
            //Get--Read All
        public IHttpActionResult Get()
            {
            List<Customer> customers = _context.Customers.ToList();
            if (customers.Count != 0)
            {
                return Ok(customers);
            }
            return BadRequest("Your database contains no Customers.");
        }

            //Get {id}--Read By ID
        public IHttpActionResult Get(int id)
        {
            
            Customer customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
            


            //Put {id]--Update by ID

            //Delete{id}--Delete by ID
    }
}


