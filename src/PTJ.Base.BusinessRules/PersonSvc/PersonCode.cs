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

        public List<PersonAdressViewModel> GetByKstnr(int kstnr, int page, int limit)
        {
            var personDb = (from p in db.Person select p).ToList();

            return this.CreatePersonViewModelList(personDb);
        }

        public List<PersonAdressViewModel> GetPersonByPersnr(long persnr, bool? workInformationOnly = true)
        {
            
            List<PersonAdressViewModel> persList = new List<PersonAdressViewModel>();
            var persnrStr = persnr.ToString();

            var personDb = (from p in db.Person
                            where p.PersonNummer == persnrStr
                            select p).ToList();

            persList = this.CreatePersonViewModelList(personDb, workInformationOnly);

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

        private List<PersonAdressViewModel> CreatePersonViewModelList(List<Person> _personList ,bool? workInformationOnly = true)
        {
            List<PersonAdressViewModel> viewModelList = new List<PersonAdressViewModel>();

            foreach (var person in _personList)
            {
                PersonAdressViewModel m = new PersonAdressViewModel();
                m.Id = person.Id;
                m.ForNamn = person.ForNamn;
                m.MellanNamn = person.MellanNamn;
                m.EfterNamn = person.EfterNamn;
                m.PersonNummer = person.PersonNummer;
                m.SkapadDatum = person.SkapadDatum.ToString("yyyy-mm-dd");


                var employed = (from p in db.PersonAnstalld
                                where p.PersonFkid == person.Id
                                select p).ToList();

                if (employed != null && employed.Count > 0)
                {
                    m.Anstalld = true;
                    m.AnstallDatum = employed.First().SkapadDatum.ToString("yyyy-mm-dd");
                }

                var consult = (from p in db.PersonKonsult
                               where p.PersonFkid == person.Id
                               select p).ToList();

                if (consult != null && consult.Count > 0)
                {
                    m.Konsult = true;
                    m.KonsultDatum = consult.First().SkapadDatum.ToString("yyyy-mm-dd");
                }

                long n;
                bool isNumeric = Int64.TryParse(person.PersonNummer, out n);
                if (isNumeric)
                {
                    m.Adress = ac.GetByPersonId(n, workInformationOnly);
                    viewModelList.Add(m);
                }
             
            }

            return viewModelList;
        }


    }
}
