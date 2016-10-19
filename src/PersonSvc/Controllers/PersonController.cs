using System;

using Microsoft.AspNetCore.Mvc;
using PTJ.DataLayer.Models;
using PTJ.Message;
using PersonSvc.BusinessRules;
using PersonSvc.BusinessRules.Interfaces;
using PTJ.Base.BusinessRules.PersonSvc;

using PersonSvc.BusinessRules.Utils;
using PTJ.Security.Code;
using PTJ.Security.Interfaces;
using PersonSvc.ViewModels;

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
        private readonly IPerson pc;
        private readonly IPersonCreateUpdateDelete crud;
        private readonly IBackend backend;
        private readonly IPersonValidation validate;
        private readonly IValueUtils valueUtils;
        private readonly IPtjUser user;
        private readonly ModelDbContext db;


        public PersonController(ModelDbContext context, IPersonCreateUpdateDelete _crud)
        {

            db = context;
            crud = _crud;
            pc =  new PersonCode(db);
            valueUtils = new ValueUtils();
            validate = new PersonValidation(valueUtils);
            backend = new BackendCode(crud, pc, validate);
            user = new PtjUser();
        }

        [HttpGet("GetByKstnr")]
        public Response<PersonAdressViewModel> GetByKstnr( [RequiredFromQuery]string application, [RequiredFromQuery]string username, [RequiredFromQuery] int kstnr, [FromQuery] int page, [FromQuery] int limit)
        {
            //ToDO for now gets all
            if (user.IsAuthorised(username))
            {
                bool canOnlyReadWorkInformation = user.OnlyReadWorkInformation(username);
                return backend.GetByKstnr(
                    kstnr: kstnr, 
                    page: page, 
                    limit: limit,
                    workInformationOnly: canOnlyReadWorkInformation
                    );
            }
            else
            {
                Response<PersonAdressViewModel> r = new Response<PersonAdressViewModel>();
                r.success = "false";
                r.message = "User Is not Authorise!, check permission for user " + username;
                return r;
            }
           
        }


        [HttpGet("GetByPersnr")]
        public Response<PersonAdressViewModel> GetByPersnr([RequiredFromQuery]string application, [RequiredFromQuery]string username, [RequiredFromQuery]long persnr)
        {
        
            if (user.IsAuthorised(username))
            {
                bool canOnlyReadWorkInformation = user.OnlyReadWorkInformation(username);

                return backend.GetByPersnr(persnr, canOnlyReadWorkInformation);
               
            }
            else
            {
                Response<PersonAdressViewModel> r = new Response<PersonAdressViewModel>();
                r.success = "false";
                r.message = "User Is not Authorise!, check permission for user " + username;
                return r;
            }
           
        }

        // POST api/values
        [HttpPost]
        public Response<PersonAdressViewModel> Create([FromBody] PersonViewModelSave model)
        {
            Response<PersonAdressViewModel> result = new Response<PersonAdressViewModel>();
            if (model.PersonNummer != String.Empty && !String.IsNullOrEmpty(model.ForNamn) && !String.IsNullOrEmpty(model.EfterNamn))
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
        public Response<PersonAdressViewModel> UpdatePers([FromBody] PersonViewModelSave model)
        {
            Response<PersonAdressViewModel> result = new Response<PersonAdressViewModel>();
            if (model.Id != 0 && !String.IsNullOrEmpty(model.PersonNummer) && !String.IsNullOrEmpty(model.ForNamn) && !String.IsNullOrEmpty(model.EfterNamn))
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
        [HttpDelete("{persnr}")]
        public Response<PersonAdressViewModel> Delete(long persnr)
        {
            Response<PersonAdressViewModel> result = new Response<PersonAdressViewModel>();

            if (persnr != 0)
            {
                result = backend.DeletePerson(persnr);
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
