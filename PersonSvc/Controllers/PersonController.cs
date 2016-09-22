﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PTJ.DataLayer.Models;
using PTJ.Message;
using PersonSvc.BusinessService;
using PersonSvc.BusinessService.Interfaces;
using PTJ.Base.BusinessRules.ViewModels;
using PTJ.Base.BusinessRules.Code;
using PTJ.Base.BusinessRules.Interfaces;

namespace PersonSvc.Controllers
{
    /* *
        * ASP.NET Web API Help Pages
        * http://localhost:<random_port>/swagger/ui
        * http://localhost:<random_port>/swagger/v1/swagger.json
        * https://docs.asp.net/en/latest/tutorials/web-api-help-pages-using-swagger.html
     **/

    //[Route("api/[controller]/[action]")]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private IBackend backend;
        private ModelDbContext db;


        public PersonController(ModelDbContext context)
        {
            db = context;
            backend = new BackendCode(db);
        }

      
        [HttpGet("GetByPersnr/{persnr}")]
        public Response<PersonViewModel> GetByPersnr(long persnr)
        {
            return backend.GetByPersnr(persnr);
        }

        // POST api/values
        [HttpPost]
        public Response<PersonViewModel> Create([FromBody] PersonViewModel model)
        {
            Response<PersonViewModel> result = new Response<PersonViewModel>();
            if (model.Person.PersonNummer != String.Empty && !String.IsNullOrEmpty(model.Person.ForNamn) && !String.IsNullOrEmpty(model.Person.EfterNamn))
            {
                result = backend.CreatePerson(model);
            }
            else
            {
                result.success = "false";
                result.message = "Missing parameters, check: Id, Persnr,  Fname, Lname, Username";
                result.errorcode = 600;
            }
            return result;
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


        //// DELETE api/values/5
        //[HttpDelete("{persnr}")]
        //public void Delete(long persnr)
        //{

        //}

        // DELETE api/values/5
        [HttpDelete("{persnr}")]
        public Response<PersonViewModel> Delete(long persnr)
        {
            Response<PersonViewModel> result = new Response<PersonViewModel>();

            if (persnr != 0)
            {
                backend.DeletePerson(persnr);
            }
            else
            {
                result.success = "false";
                result.message = "Missing parameters, check: Id, Persnr,  Fname, Lname, Username";
                result.errorcode = 600;
            }
            return result;
        }
    }
}
