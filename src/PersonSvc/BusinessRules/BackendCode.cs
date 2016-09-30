using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonSvc.BusinessRules.Interfaces;
using PTJ.Message;
using PTJ.DataLayer.Models;
using PTJ.Base.BusinessRules.PersonSvc;
using PTJ.Base.BusinessRules.Code;
using PTJ.Base.BusinessRules.Interfaces;
using System.Diagnostics;
using PersonSvc.ViewModels;

namespace PersonSvc.BusinessRules
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


        public Response<PersonAdressViewModel> GetByKstnr(int kstnr, int page = 1, int limit = 50, bool workInformationOnly = true)
        {
            var watch = Stopwatch.StartNew();
            // the code that you want to measure comes here
           
            Response<PersonAdressViewModel> r = new Response<PersonAdressViewModel>();
            r.result = pc.GetByKstnr(kstnr, page, limit);
            r.success = "true";
            r.message = "Ok";
            r.total = r.result.Count();

            watch.Stop();
           

            r.responsetime = watch.ElapsedMilliseconds.ToString();
            r.time = DateTime.Now.ToString();

            return r;
        }

        public Response<PersonAdressViewModel> GetByPersnr(long persnr, bool workInformationOnly = true)
        {
            var watch = Stopwatch.StartNew();
            Response<PersonAdressViewModel> r = new Response<PersonAdressViewModel>();

            try
            {
                r.result = pc.GetPersonByPersnr(persnr, workInformationOnly);
                r.success = "true";
                r.message = "Ok";
                r.total = r.result.Count();
            }
            catch (Exception e)
            {
                //Handle failure
                r.success = "false";
                r.message = e.Message;
                r.total = 0;
            }

            watch.Stop();
            r.responsetime = watch.ElapsedMilliseconds.ToString();
            r.time = DateTime.Now.ToString();

            return r;
        }


        public Response<PersonAdressViewModel> CreatePerson(PersonViewModelSave model)
        {
            Response<PersonAdressViewModel> r = new Response<PersonAdressViewModel>();

          

            string validationMsg = String.Empty;
            string errorMsg = String.Empty;
            bool isValidateOk = true;

            try
            {
                //1. Check all parameters are ok
                if (validate.CheckCreateValues(model, ref validationMsg))
                {
                    if (crud.AllreadyExist(model.PersonNummer, ref validationMsg))
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
                        long PersonNummer = Convert.ToInt64(model.PersonNummer);

                        //if all is ok return the newly created person in the response
                        r.success = "true";
                        r.message = "all ok";
                        r.result = pc.GetPersonByPersnr(persnr: PersonNummer, workInformationOnly: false );
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

        public Response<PersonAdressViewModel> UpdatePerson(PersonViewModelSave model)
        {
            Response<PersonAdressViewModel> r = new Response<PersonAdressViewModel>();
           

            string errorMsg = String.Empty;
            if (crud.UpdatePerson(model, ref errorMsg))
            {
                long PersonNummer = Convert.ToInt64(model.PersonNummer);
                r.success = "true";
                r.message = "Person {persnr} updated";
                r.result = pc.GetPersonByPersnr(PersonNummer,false);
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

        public Response<PersonAdressViewModel> DeletePerson(long persnr)
        {
            Response<PersonAdressViewModel> r = new Response<PersonAdressViewModel>();
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
