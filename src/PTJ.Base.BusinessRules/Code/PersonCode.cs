using PTJ.Base.BusinessRules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PTJ.Base.BusinessRules.ViewModels;
using PTJ.Message;
using PTJ.DataLayer.Models;

namespace PTJ.Base.BusinessRules.Code
{
    public class PersonCode : IPerson
    {
        private ModelDbContext db;
        public PersonCode(ModelDbContext _db)
        {
            db = _db;
        }

        public Response<PersonViewModel> GetByKstnr(int kstnr, int page, int limit)
        {
            throw new NotImplementedException();
        }

        public Response<PersonViewModel> GetPersonByPersnr(long persnr)
        {
            //throw new NotImplementedException();
            Response<PersonViewModel> r = new Response<PersonViewModel>();

            //var test = db.Person.ToList();
            var persnrStr = persnr.ToString();

            var personDb = (from p in db.Person
                            where p.PersonNummer == persnrStr
                            select p).FirstOrDefault<Person>();

            PersonViewModel model = new PersonViewModel();
            List<PersonViewModel> persList = new List<PersonViewModel>();

            model.Person = personDb;
            //model.PersonAnnanPerson = GetPersonAnnanPerson(personDb.Id);
            //model.PersonAnstalld = GetPersonAnstalld(personDb.Id);
            //model.PersonKonsult = GetPersonKonsult(personDb.Id);
            //model.PersonPatient = GetPersonPatient(personDb.Id);
            //model.PersonSjukHalsovardsPersonal = GetPersonSjukHalsovardsPersonal(personDb.Id);
            persList.Add(model);


            r.success = "true";
            r.message = "all ok";
            r.total = persList.Count();
            r.result = persList;

            return r;
        }

        public Response<PersonAdressViewModel> GetConsultByOrgnr(long orgnr)
        {
            throw new NotImplementedException();
        }

        public Response<PersonAdressViewModel> GetConsultByPersnr(long persnr)
        {
            throw new NotImplementedException();
        }

        public Response<PersonAdressViewModel> GetEmployeeAndConsultByOrgnr(long orgnr)
        {
            throw new NotImplementedException();
        }

        public Response<PersonAdressViewModel> GetEmployeeByOrgnr(long orgnr)
        {
            throw new NotImplementedException();
        }

        public Response<PersonAdressViewModel> GetEmployeeByPersnr(long persnr)
        {
            throw new NotImplementedException();
        }

        public Response<PersonAdressViewModel> GetEmployeeOrConsultByPersnr(long persnr)
        {
            throw new NotImplementedException();
        }

        public Response<PersonAdressViewModel> GetPatientByOrgnr(long orgnr)
        {
            throw new NotImplementedException();
        }

        public Response<PersonAdressViewModel> GetPatientByPersnr(long persnr)
        {
            throw new NotImplementedException();
        }

        public Response<PersonAdressViewModel> GetPersonAdressByPersnr(long persnr)
        {
            Response<PersonAdressViewModel> r = new Response<PersonAdressViewModel>();

            var persnrStr = persnr.ToString();

            var personDb = (from p in db.Person
                            where p.PersonNummer == persnrStr
                            select p).FirstOrDefault();

            PersonAdressViewModel model = new PersonAdressViewModel();
            List<Adress> aList = new List<Adress>();

            model.Person = personDb;
            //model.PersonAnnanPerson = GetPersonAnnanPerson(personDb.Id);
            //model.PersonAnstalld = GetPersonAnstalld(personDb.Id);
            //model.PersonKonsult = GetPersonKonsult(personDb.Id);
            //model.PersonPatient = GetPersonPatient(personDb.Id);
            //model.PersonSjukHalsovardsPersonal = GetPersonSjukHalsovardsPersonal(personDb.Id);
            //model.Adress.Add(aList);


            r.success = "true";
            r.message = "all ok";
            r.total = aList.Count();
            //r.result = aList;

            return r;
        }
    }
}
