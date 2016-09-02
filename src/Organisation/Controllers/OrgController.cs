using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Organisation.BusinessService;
using Organisation.Model;
using Organisation.BusinessService.Interfaces;
using PTJ.DataLayer;
using PTJ.Message;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Organisation.Controllers
{
    [Route("api/[controller]")]
    public class OrgController : Controller
    {
        private ModelContext db;
        private IBackend backend;

        public OrgController(ModelContext context)
        {
            db = context;
            backend = new BackendCode(db);
        }
        // GET: api/org
        [HttpGet]
        public Response<Person> Get()
        {
            //var person = db.Person.First();
            Response<Person> r = new Response<Person>();
            List<Person> li = new List<Person>();
            Person p = backend.GetById(123124);
            li.Add(p);

            r.limit = 10;
            r.message = "Ok";
            r.success = "true";
            r.result = li;

            return r;
        }

        // GET api/org/5
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
