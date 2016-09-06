using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PTJ.DataLayer.Models;

namespace AdressSvc.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private ModelDbContext db;

        public ValuesController(ModelDbContext context)
        {
            db = context;
        }

        // GET api/values
        [HttpGet]
        public List<Adress> Get()
        {
            List<Adress> adress = new List<Adress>();
            adress = (from a in db.Adress
                     where a.UpdateradAv == "PTJ/pnr"
                     select a).ToList();
            return adress;
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
