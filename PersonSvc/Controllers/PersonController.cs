﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PTJ.DataLayer.Models;
using PTJ.Message;
using PersonSvc.BusinessService;
using PersonSvc.BusinessService.Interfaces;

namespace PersonSvc.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PersonController : Controller
    {
        private IBackend backend;
        private ModelDbContext db;

        public PersonController(ModelDbContext context)
        {
            db = context;
            backend = new BackendCode(db);
        }


        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("{persnr}")]
        public Response<PersonViewModel> GetByPersnr(long persnr)
        {
            //Response resp = backend.GetByPersnr(persnr);
            return backend.GetByPersnr(persnr);
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