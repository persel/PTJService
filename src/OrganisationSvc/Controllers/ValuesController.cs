using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrganisationSvc.Model;
using PTJ.DataLayer.Models;
using PTJ.Message;

namespace OrganisationSvc.Controllers
{
    /* *
       * ASP.NET Web API Help Pages
       * http://localhost:<random_port>/swagger/ui
       * http://localhost:<random_port>/swagger/v1/swagger.json
       * https://docs.asp.net/en/latest/tutorials/web-api-help-pages-using-swagger.html
    **/

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
        public Response<Organisation>  Get()
        {
            Response<Organisation> re = new Response<Organisation>();

            List<Organisation> _organisation = new List<Organisation>();
            _organisation = (from o in db.Organisation
                      where o.IngarIorganisation == 1
                      select o).ToList();

            re.result = _organisation;

            return re;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        //[Produces("application/json")]
        //[Consumes("")]
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
