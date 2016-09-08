using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonSvc.BusinessService.Interfaces;
using PTJ.Message;
using PTJ.DataLayer.Models;

namespace PersonSvc.BusinessService
{
    public class BackendCode : IBackend
    {
        //private dastabaseContext db;
        private ModelDbContext db;
        public BackendCode(ModelDbContext _db)
        {
            db = _db;
        }

        public bool CanISeThis(string username)
        {
            return true;
        }

        public Response<PersonViewModel> CreatePerson(Person person)
        {
            throw new NotImplementedException();
        }

        public Response<PersonViewModel> DeletePerson(long persnr)
        {
            throw new NotImplementedException();
        }

        //public Response GetByAlias(string alias)
        //{
        //    var test = db.Person.Where(p => p.Username == alias).ToList();
        //    Response r = new Response();
        //    PersonViewModel model = new PersonViewModel();
        //    List<PersonViewModel> persList = new List<PersonViewModel>();

        //    r.success = "true";
        //    r.message = "all ok";
        //    r.total = test.Count();

        //    foreach (var person in test)
        //    {
        //        model.Person = person;
        //        persList.Add(model);
        //    }
            
        //    r.result = persList;

        //    return r;
        //}


        public Response<PersonViewModel> GetByKstnr(int kstnr, int page, int limit)
        {
            throw new NotImplementedException();
            //var test = db.Person.ToList();
            //Response r = new Response();
            //PersonViewModel model = new PersonViewModel();
            //List<PersonViewModel> persList = new List<PersonViewModel>();

            //r.success = "true";
            //r.message = "all ok";
            //r.total = test.Count();

            //foreach (var person in test)
            //{
            //    model.Person = person;
            //    persList.Add(model);
            //}

            //r.result = persList;

            //return r;
        }

        public Response<PersonViewModel> GetByPersnr(long persnr)
        {
            throw new NotImplementedException();
            //Response r = new Response();

            ////var test = db.Person.ToList();
            //var persnrStr = persnr.ToString();

            //var personDb = (from p in db.Person
            //                where p.PersonNummer == persnrStr
            //                select p).FirstOrDefault<Person>();

            //PersonViewModel model = new PersonViewModel();
            //List<PersonViewModel> persList = new List<PersonViewModel>();

            //model.Person = personDb;
            //model.PersonAnnanPerson = GetPersonAnnanPerson(personDb.Id);
            //model.PersonAnstalld = GetPersonAnstalld(personDb.Id);
            //model.PersonKonsult = GetPersonKonsult(personDb.Id);
            //model.PersonPatient = GetPersonPatient(personDb.Id);
            //model.PersonSjukHalsovardsPersonal = GetPersonSjukHalsovardsPersonal(personDb.Id);
            //persList.Add(model);


            //r.success = "true";
            //r.message = "all ok";
            //r.total = persList.Count();
            //r.result = persList;

            //return r;
        }


        public Response<PersonViewModel> AddPerson(Person person)
        {
            throw new NotImplementedException();
        }


        //public Response UpdatePerson(PersonViewModel model)
        //{
        //    Response r = new Response();
        //    List<PersonViewModel> persList = new List<PersonViewModel>();
        //    using (db)
        //    {
        //        using (var transaction = db.Database.BeginTransaction())
        //        {
        //            try
        //            {
        //                var personDb = (from p in db.Person
        //                                where p.Id == model.Person.Id
        //                                select p).FirstOrDefault<Person>();

        //                personDb.Fname = model.Person.Fname;
        //                personDb.Lname = model.Person.Lname;
        //                personDb.Username = model.Person.Username;
        //                personDb.Persnr = model.Person.Persnr;
        //                db.SaveChanges();

        //                //Save persons adresses
        //                foreach (var adress in model.AdressList)
        //                {
        //                    //get connectobj
        //                    var personAdr = (from pa in db.PersonAdress
        //                                     where pa.PersonId == model.Person.Id
        //                                     select pa).FirstOrDefault<PersonAdress>();

        //                    if (personAdr != null)
        //                    {
        //                        var adressToUpdate = (from a in db.Adress
        //                                              where a.Id == personAdr.AdressId
        //                                              select a).FirstOrDefault<Adress>();

        //                        //Testa rollback med fel adressId
        //                        //var adressToUpdate = (from a in db.Adress
        //                        //                      where a.Id == 22
        //                        //                      select a).FirstOrDefault<Adress>();

        //                        adressToUpdate.Gata = adress.Gata;
        //                        adressToUpdate.Postnummer = adress.Postnummer;
        //                        adressToUpdate.Ort = adress.Ort;
        //                        adressToUpdate.Type = adress.Type;
        //                        db.SaveChanges();
        //                    }
        //                }
        //                // Commit transaction if all commands succeed, transaction will auto-rollback
        //                // when disposed if either commands fails
        //                transaction.Commit();
        //                r.success = "true";
        //                r.message = "all ok";
        //                r.total = 0;
        //            }
        //            catch (Exception)
        //            {
        //                //Handle failure
        //                r.success = "false";
        //                r.message = "error";
        //                r.total = 0;
        //            }
        //        }
        //    }

        //    return r;
        //}

        //public Response<PersonViewModel>       
            
        //    InsertPerson(PersonViewModel model)
        //{
        //    Response r = new Response();
        //    List<PersonViewModel> persList = new List<PersonViewModel>();

        //    using (db)
        //    {
        //        using (var transaction = db.Database.BeginTransaction())
        //        {
        //            try
        //            {
        //                //var personsDb = db.Person.Where(p => p.Persnr == model.Person.Persnr).ToList();

        //                var allreadyExist = (from p in db.Person
        //                                     where p.Persnr == model.Person.Persnr
        //                                     select p.Persnr).FirstOrDefault();

        //                if (allreadyExist == 0)
        //                {
        //                    db.Person.Add(model.Person);
        //                    db.SaveChanges();

        //                    //Get id 
        //                    var dbPersonId = model.Person.Id;

        //                    //Save adresses
        //                    foreach (var adress in model.AdressList)
        //                    {
        //                        db.Adress.Add(adress);
        //                        db.SaveChanges();
        //                        var dbAdressId = adress.Id;
        //                        //Save connection
        //                        PersonAdress persAdr = new PersonAdress();
        //                        persAdr.PersonId = dbPersonId;
        //                        //Testa rollback med fel personid
        //                        //persAdr.PersonId = 22;
        //                        persAdr.AdressId = dbAdressId;
        //                        db.PersonAdress.Add(persAdr);
        //                        db.SaveChanges();
        //                    }
        //                }                        

        //                // Commit transaction if all commands succeed, transaction will auto-rollback
        //                // when disposed if either commands fails
        //                transaction.Commit();
        //                r.success = "true";
        //                r.message = "all ok";
        //                r.total = 0;
        //            }
        //            catch (Exception)
        //            {
        //                //Handle failure
        //                r.success = "false";
        //                r.message = "error";
        //                r.total = 0;
        //            }
        //        }
        //    }

        //    return r;
        //}

        public PersonAnnanPerson GetPersonAnnanPerson(long personsId)
        {

            var annanPerson = (from p in db.PersonAnnanPerson
                                where p.PersonFkid == personsId
                                select p).FirstOrDefault<PersonAnnanPerson>();

            return annanPerson;
        }

        public PersonAnstalld GetPersonAnstalld(long personsId)
        {
            var anstalldPerson = (from a in db.PersonAnstalld
                                   where a.PersonFkid == personsId
                                   select a).FirstOrDefault<PersonAnstalld>();

            return anstalldPerson;
        }

        public PersonKonsult GetPersonKonsult(long personsId)
        {

            var konsultPerson = (from p in db.PersonKonsult
                                  where p.PersonFkid == personsId
                                  select p).FirstOrDefault<PersonKonsult>();

            return konsultPerson;
        }

        public PersonPatient GetPersonPatient(long personsId)
        {

            var patientPerson = (from p in db.PersonPatient
                                 where p.PersonFkid == personsId
                                 select p).FirstOrDefault<PersonPatient>();

            return patientPerson;
        }

        public PersonSjukHalsovardsPersonal GetPersonSjukHalsovardsPersonal(long personsId)
        {
            throw new NotImplementedException();

            //var HKPerson = (from p in db.PersonSjukHalsovardsPersonal
            //                     where p.PersonFkid == personsId
            //                     select p).FirstOrDefault<PersonSjukHalsovardsPersonal>();

            //return HKPerson;
        }

        public long GetNewDbId()
        {
            long Id = 1;
            if (db.Person.Count() != 0)
            {
                Id = db.Person.Select(s => s.Id).Max() + 1;                
            }
            return Id;
        }
    }
}
