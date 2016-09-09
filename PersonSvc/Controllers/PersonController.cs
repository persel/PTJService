using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PTJ.DataLayer.Models;
using PTJ.Message;
using PersonSvc.BusinessService;
using PersonSvc.BusinessService.Interfaces;
using PTJ.Base.BusinessRules.ViewModels;

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

        // POST api/values
        [HttpPost]
        public Response<PersonViewModel> InsertPers([FromBody] PersonViewModel model)
        {
            Response<PersonViewModel> result = new Response<PersonViewModel>();
            if (model.Person.PersonNummer != String.Empty && !String.IsNullOrEmpty(model.Person.ForNamn) && !String.IsNullOrEmpty(model.Person.EfterNamn) )
            {
                result = backend.InsertPerson(model);
            }
            else
            {
                result.success = "false";
                result.message = "Missing parameters, check: Id, Persnr,  Fname, Lname, Username";
                result.errorcode = 600;
            }
            return result;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpPut]
        public Response<PersonViewModel> UpdatePers([FromBody] PersonViewModel model)
        {
            Response<PersonViewModel> result = new Response<PersonViewModel>();
            if (model.Person.Id != 0 && !String.IsNullOrEmpty(model.Person.PersonNummer) && !String.IsNullOrEmpty(model.Person.ForNamn) && !String.IsNullOrEmpty(model.Person.EfterNamn))
            {
                result = backend.UpdatePerson(model);
            }
            else
            {
                result.success = "false";
                result.message = "Missing parameters, check: Id, Persnr,  Fname, Lname, Username";
                result.errorcode = 600;
            }
            return result;
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
