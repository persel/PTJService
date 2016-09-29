using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PTJ.DataLayer.Models;
using AdressSvc.BusinessRules.Interfaces;
using AdressSvc.BusinessRules;
using PTJ.Base.BusinessRules.AdressSvc;
using PTJ.Message;

namespace AdressSvc.Controllers
{

    /* *
       * ASP.NET Web API Help Pages
       * http://localhost:<random_port>/swagger/ui
       * http://localhost:<random_port>/swagger/v1/swagger.json
       * https://docs.asp.net/en/latest/tutorials/web-api-help-pages-using-swagger.html
    **/

    [Route("api/[controller]")]
    public class AdressController : Controller
    {
        private ModelDbContext db;
        private IBackend backend;

        public AdressController(ModelDbContext context)
        {
            db = context;
            backend = new BackendCode(db);
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
        public Response<AdressViewModel> Get(int id)
        {
            return backend.GetByAdressId(id);  
        }

        [HttpGet("GetByPersnr/{persnr}")]
        public Response<AdressViewModel> GetByPersnr(long persnr)
        {
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
