﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Organisation.Model;
using Organisation.BusinessService.Interfaces;
using Organisation.BusinessService;
using PTJ.Message;


namespace Organisation.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
       
        private ModelContext db;
        private IBackend backend;

        public ValuesController(ModelContext context)
        {
            db = context;
            backend = new BackendCode();
        }

        // GET api/values
        [HttpGet]
        public Response<Person> Get()
        {
            //var person = db.Person.First();
            Response<Person> r = new Response<Person>();
            List<Person> li = new List<Person>();
            Person p = backend.GetById(123124);
            li.Add(new Person());

            r.limit = 10;
            r.message = "Ok";
            r.success = "true";
            r.result = li;

            return r;// new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
