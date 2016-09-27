using PTJ.Base.BusinessRules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PTJ.Base.BusinessRules.PersonSvc;
using PTJ.Message;
using PTJ.DataLayer.Models;
using PTJ.Base.BusinessRules.AdressSvc;

namespace PTJ.Base.BusinessRules.PersonSvc
{
    public class PersonCode : IPerson
    {
        private ModelDbContext db;
        AdressCode ac;

        public PersonCode(ModelDbContext _db)
        {
            db = _db;
            ac = new AdressCode(db);
        }

        public List<PersonViewModel> GetByKstnr(int kstnr, int page, int limit)
        {
            throw new NotImplementedException();
        }

        public List<PersonAdressViewModel> GetPersonByPersnr(long persnr)
        {
            List<PersonAdressViewModel> persList = new List<PersonAdressViewModel>();
            var persnrStr = persnr.ToString();

            var personDb = (from p in db.Person
                            where p.PersonNummer == persnrStr
                            select p).ToList();

            

            foreach (var person in personDb)
            {
                PersonAdressViewModel model = new PersonAdressViewModel();
                model.Person = person;
                persList.Add(model);
            }

            //model.PersonAnnanPerson = GetPersonAnnanPerson(personDb.Id);
            //model.PersonAnstalld = GetPersonAnstalld(personDb.Id);
            //model.PersonKonsult = GetPersonKonsult(personDb.Id);
            //model.PersonPatient = GetPersonPatient(personDb.Id);
            //model.PersonSjukHalsovardsPersonal = GetPersonSjukHalsovardsPersonal(personDb.Id);

            return persList;
        }

        public List<PersonAdressViewModel> GetConsultByOrgnr(long orgnr)
        {
            throw new NotImplementedException();
        }

        public List<PersonAdressViewModel> GetConsultByPersnr(long persnr)
        {
            throw new NotImplementedException();
        }

        public List<PersonAdressViewModel> GetEmployeeAndConsultByOrgnr(long orgnr)
        {
            throw new NotImplementedException();
        }

        public List<PersonAdressViewModel> GetEmployeeByOrgnr(long orgnr)
        {
            throw new NotImplementedException();
        }

        public List<PersonAdressViewModel> GetEmployeeByPersnr(long persnr)
        {
            throw new NotImplementedException();
        }

        public List<PersonAdressViewModel> GetEmployeeOrConsultByPersnr(long persnr)
        {
            throw new NotImplementedException();
        }

        public PersonAdressViewModel GetPatientByOrgnr(long orgnr)
        {
            throw new NotImplementedException();
        }

        public PersonAdressViewModel GetPatientByPersnr(long persnr)
        {
            throw new NotImplementedException();
        }

        public List<PersonAdressViewModel> GetPersonAdressByPersnr(long persnr)
        {
            List<PersonAdressViewModel> lst = new List<PersonAdressViewModel>();
            var persnrStr = persnr.ToString();

            var personDb = (from p in db.Person
                            where p.PersonNummer == persnrStr
                            select p).FirstOrDefault();

            PersonAdressViewModel model = new PersonAdressViewModel();
            AdressViewModel adrModel = new AdressViewModel();

            model.Person = personDb;
            //model.PersonAnnanPerson = GetPersonAnnanPerson(personDb.Id);
            //model.PersonAnstalld = GetPersonAnstalld(personDb.Id);
            //model.PersonKonsult = GetPersonKonsult(personDb.Id);
            //model.PersonPatient = GetPersonPatient(personDb.Id);
            //model.PersonSjukHalsovardsPersonal = GetPersonSjukHalsovardsPersonal(personDb.Id);
            //model.Adress.Add(aList);

            //Get adresses
            List<PersonAdress> adrList = new List<PersonAdress>();

            //Läs id:n för personens adresser
            adrList = (from pa in db.PersonAdress
                           where pa.PersonFkid == personDb.Id
                           select pa).ToList();

            foreach (var item in adrList)
            {
                var adrvm = ac.GetByAdressId(item.Id);
                //model.Adress.Add(adrvm[0]);
            }

            lst.Add(model);
            return lst;
        }
    }
}
