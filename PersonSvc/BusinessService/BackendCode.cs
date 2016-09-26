using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonSvc.BusinessService.Interfaces;
using PTJ.Message;
using PTJ.DataLayer.Models;
using PTJ.Base.BusinessRules.ViewModels;
using PTJ.Base.BusinessRules.Code;
using PTJ.Base.BusinessRules.Interfaces;

namespace PersonSvc.BusinessService
{
    public class BackendCode : IBackend
    {

        private IPerson pc;
        private IPersonCreateUpdateDelete crud;
        private IPersonValidation validate;

        public BackendCode(IPersonCreateUpdateDelete _crud, IPerson _pc, IPersonValidation _validate)
        {
            pc = _pc;
            crud = _crud;
            validate = _validate;
        }

        //public BackendCode(IApplicationDbContext _db, IPersonCreateUpdateDelete _crud, IPerson _pc)
        //{
        //    IApplicationDbContext db1;
        //    db1 = _db;
        //    dbUtils = new DbUtils(db);
        //    pc = _pc;
        //    crud = _crud;
        //}

        public Response<PersonViewModel> GetByKstnr(int kstnr, int page, int limit)
        {
            throw new NotImplementedException();
        }

        public Response<PersonViewModel> GetByPersnr(long persnr)
        {
            Response<PersonViewModel> r = new Response<PersonViewModel>();

            try
            {
                r.result = pc.GetPersonByPersnr(persnr);
                r.success = "true";
                r.message = "all ok";
                r.total = r.result.Count();
            }
            catch (Exception e)
            {
                //Handle failure
                r.success = "false";
                r.message = e.Message;
                r.total = 0;
            }

            return r;
        }


        public Response<PersonViewModel> CreatePerson(PersonViewModel model)
        {
            Response<PersonViewModel> r = new Response<PersonViewModel>();

          

            string validationMsg = String.Empty;
            string errorMsg = String.Empty;
            bool isValidateOk = true;

            try
            {
                //1. Check all parameters are ok
                if (validate.CheckCreateValues(model, ref validationMsg))
                {
                    if (crud.AllreadyExist(model.Person.PersonNummer, ref validationMsg))
                    {
                        isValidateOk = false;
                    }
                }
                else
                {
                    isValidateOk = false;
                }

                //2. Send them back to the create class if all is ok
                if (isValidateOk)
                {
                    if (crud.CreatePerson(model, ref errorMsg))
                    {
                        long PersonNummer = Convert.ToInt64(model.Person.PersonNummer);

                        //if all is ok return the newly created person in the response
                        r.success = "true";
                        r.message = "all ok";
                        r.result = pc.GetPersonByPersnr(PersonNummer);
                        r.total = r.result.Count();
                    }
                    else
                    {
                        r.success = "false";
                        r.message = errorMsg;
                        r.total = 0;
                    }
                }
                else
                {
                    r.success = "false";
                    r.message = "CheckCreateValues or allready exist error: " + validationMsg;
                    r.errorcode = 600;
                }


            }
            catch (Exception e)
            {
                //Handle failure
                r.success = "false";
                r.message = e.Message;
                r.total = 0;
            }

            return r;
        }

        public Response<PersonViewModel> UpdatePerson(PersonViewModel model)
        {
            Response<PersonViewModel> r = new Response<PersonViewModel>();
            List<PersonViewModel> persList = new List<PersonViewModel>();

            string errorMsg = String.Empty;
            if (crud.UpdatePerson(model, ref errorMsg))
            {
                long PersonNummer = Convert.ToInt64(model.Person.PersonNummer);
                r.success = "true";
                r.message = "Person {persnr} updated";
                r.result = pc.GetPersonByPersnr(PersonNummer);
                r.total = r.result.Count();
            }
            else
            {
                r.success = "false";
                r.message = "Error: " + errorMsg;
                r.errorcode = 600;
            }

            return r;
        }

        public Response<PersonViewModel> DeletePerson(long persnr)
        {
            Response<PersonViewModel> r = new Response<PersonViewModel>();
            string errorMsg = String.Empty;
            if (crud.DeletePerson(persnr, ref errorMsg))
            {
                r.success = "true";
                r.message = "Person {persnr} deleted";
            }
            else
            {
                r.success = "false";
                r.message = "Error: " + errorMsg;
                r.errorcode = 600;
            }
            return r;
        }

    }
}
