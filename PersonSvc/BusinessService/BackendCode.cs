using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonSvc.BusinessService.Interfaces;
using PTJ.Message;
using PTJ.DataLayer.Models;
using PTJ.Base.BusinessRules.ViewModels;
using PTJ.Base.BusinessRules.Code;

namespace PersonSvc.BusinessService
{
    public class BackendCode : IBackend
    {
        //private dastabaseContext db;
        private ModelDbContext db;
        PersonCode pc;
        DbUtils dbUtils;
        public BackendCode(ModelDbContext _db)
        {
            db = _db;
            dbUtils = new DbUtils(db);
            pc = new PersonCode(db);
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
            return pc.GetByPersnr(persnr);
        }


        public Response<PersonViewModel> AddPerson(Person person)
        {
            throw new NotImplementedException();
        }


        public Response<PersonViewModel> UpdatePerson(PersonViewModel model)
        {
            Response<PersonViewModel> r = new Response<PersonViewModel>();
            List<PersonViewModel> persList = new List<PersonViewModel>();
            using (db)
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var personDb = (from p in db.Person
                                        where p.Id == model.Person.Id
                                        select p).FirstOrDefault();

                        personDb.ForNamn = model.Person.ForNamn;
                        personDb.EfterNamn = model.Person.EfterNamn;
                        //personDb.Username = model.Person.Username;
                        personDb.PersonNummer = model.Person.PersonNummer;
                        personDb.UppdateradDatum = DateTime.Now;
                        db.SaveChanges();

                        //Save person type
                        if (model.PersonAnnanPerson != null)
                        {
                            //Hämta och uppdatera
                            var annanPersonDb = (from p in db.PersonAnnanPerson
                                            where p.Id == model.PersonAnnanPerson.Id
                                            select p).FirstOrDefault();

                            annanPersonDb.UpdateradDatum = DateTime.Now;
                            db.SaveChanges();
                        }
                        else if (model.PersonAnstalld != null)
                        {
                            //Hämta och uppdatera
                            var anstalldPersonDb = (from p in db.PersonAnstalld
                                                 where p.Id == model.PersonAnstalld.Id
                                                 select p).FirstOrDefault();

                            anstalldPersonDb.UpdateradDatum = DateTime.Now;
                            db.SaveChanges();
                        }
                        else if (model.PersonKonsult != null)
                        {
                            //Hämta och uppdatera
                            var konsultPersonDb = (from p in db.PersonKonsult
                                                   where p.Id == model.PersonKonsult.Id
                                                    select p).FirstOrDefault();

                            konsultPersonDb.UpdateradDatum = DateTime.Now;
                            db.SaveChanges();
                        }
                        else if (model.PersonPatient != null)
                        {
                            //Hämta och uppdatera
                            var patientPersonDb = (from p in db.PersonPatient
                                                   where p.Id == model.PersonPatient.Id
                                                    select p).FirstOrDefault();

                            patientPersonDb.UpdateradDatum = DateTime.Now;
                            db.SaveChanges();
                        }
                        else if (model.PersonSjukHalsovardsPersonal != null)
                        {
                            //Hämta och uppdatera
                            var HKPersonalPersonDb = (from p in db.PersonSjukHalsovardsPersonal
                                                   where p.Id == model.PersonSjukHalsovardsPersonal.Id
                                                   select p).FirstOrDefault();

                            HKPersonalPersonDb.UpdateradDatum = DateTime.Now;
                            db.SaveChanges();
                        }
                        
                        // Commit transaction if all commands succeed, transaction will auto-rollback
                        // when disposed if either commands fails
                        transaction.Commit();
                        r.success = "true";
                        r.message = "all ok";
                        r.total = 0;
                    }
                    catch (Exception e)
                    {
                        //Handle failure
                        r.success = "false";
                        r.message = e.Message;
                        r.total = 0;
                    }
                }
            }

            return r;
        }



        public Response<PersonViewModel> InsertPerson(PersonViewModel model)
        {
            Response<PersonViewModel> r = new Response<PersonViewModel>();
            List<PersonViewModel> persList = new List<PersonViewModel>();

            using (db)
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var allreadyExist = (from p in db.Person
                                             where p.PersonNummer == model.Person.PersonNummer
                                             select p.PersonNummer).FirstOrDefault();

                        if (String.IsNullOrEmpty(allreadyExist))
                        {
                            //model.Person.Id = GetNewDbId("Person");
                            model.Person.Id = dbUtils.GetNewDbId("Person");
                            model.Person.SkapadDatum = DateTime.Now;
                            model.Person.UppdateradDatum = DateTime.Now;
                            model.Person.UppdateradAv = "mah";
                            db.Person.Add(model.Person);
                            db.SaveChanges();

                            //Get id 
                            var dbPersonId = model.Person.Id;

                            //Save person type
                            if (model.PersonAnnanPerson != null)
                            {
                                model.PersonAnnanPerson.PersonFkid = model.Person.Id;
                                model.PersonAnnanPerson.Id = dbUtils.GetNewDbId("PersonAnnanPerson");
                                model.PersonAnnanPerson.SkapadDatum = DateTime.Now;
                                model.PersonAnnanPerson.UpdateradDatum= DateTime.Now;
                                db.PersonAnnanPerson.Add(model.PersonAnnanPerson);
                                db.SaveChanges();
                            }
                            else if (model.PersonAnstalld != null)
                            {
                                model.PersonAnstalld.PersonFkid = model.Person.Id;
                                model.PersonAnstalld.Id = dbUtils.GetNewDbId("PersonAnstalld");
                                model.PersonAnstalld.SkapadDatum = DateTime.Now;
                                model.PersonAnstalld.UpdateradDatum = DateTime.Now;
                                db.PersonAnstalld.Add(model.PersonAnstalld);
                                db.SaveChanges();
                            }
                            else if (model.PersonKonsult != null)
                            {
                                model.PersonKonsult.PersonFkid = model.Person.Id;
                                model.PersonKonsult.Id = dbUtils.GetNewDbId("PersonKonsult");
                                model.PersonKonsult.SkapadDatum = DateTime.Now;
                                model.PersonKonsult.UpdateradDatum = DateTime.Now;
                                db.PersonKonsult.Add(model.PersonKonsult);
                                db.SaveChanges();
                            }
                            else if (model.PersonPatient != null)
                            {
                                model.PersonPatient.PersonFkid = model.Person.Id;
                                model.PersonPatient.Id = dbUtils.GetNewDbId("PersonPatient");
                                model.PersonPatient.SkapadDatum = DateTime.Now;
                                model.PersonPatient.UpdateradDatum = DateTime.Now;
                                db.PersonPatient.Add(model.PersonPatient);
                                db.SaveChanges();
                            }
                            else if (model.PersonSjukHalsovardsPersonal != null)
                            {
                                model.PersonSjukHalsovardsPersonal.PersonFkid = model.Person.Id;
                                model.PersonSjukHalsovardsPersonal.Id = dbUtils.GetNewDbId("PersonSjukHalsovardsPersonal");
                                model.PersonSjukHalsovardsPersonal.SkapadDatum = DateTime.Now;
                                model.PersonSjukHalsovardsPersonal.UpdateradDatum = DateTime.Now;
                                db.PersonSjukHalsovardsPersonal.Add(model.PersonSjukHalsovardsPersonal);
                                db.SaveChanges();
                            }
                        }

                        // Commit transaction if all commands succeed, transaction will auto-rollback
                        // when disposed if either commands fails
                        transaction.Commit();
                        r.success = "true";
                        r.message = "all ok";
                        r.total = 0;
                    }
                    catch (Exception e)
                    {
                        //Handle failure
                        r.success = "false";
                        r.message = e.Message;
                        r.total = 0;
                    }
                }
            }

            return r;
        }

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
            //throw new NotImplementedException();

            var HKPerson = (from p in db.PersonSjukHalsovardsPersonal
                            where p.PersonFkid == personsId
                            select p).FirstOrDefault<PersonSjukHalsovardsPersonal>();

            return HKPerson;
        }

        //public long GetNewDbId(string tableName)
        //{
        //    long Id = 0;

        //    switch (tableName)
        //    {
        //        case "Person":
        //            Id = db.Person.Select(s => s.Id).Max() + 1;
        //            break;
        //        case "PersonAnnanPerson":
        //            Id = db.PersonAnnanPerson.Select(s => s.Id).Max() + 1;
        //            break;
        //        case "PersonAnstalld":
        //            Id = db.PersonAnstalld.Select(s => s.Id).Max() + 1;
        //            break;
        //        case "PersonKonsult":
        //            Id = db.PersonKonsult.Select(s => s.Id).Max() + 1;
        //            break;
        //        case "PersonPatient":
        //            Id = db.PersonPatient.Select(s => s.Id).Max() + 1;
        //            break;
        //        case "PersonSjukHalsovardsPersonal":
        //            Id = db.PersonSjukHalsovardsPersonal.Select(s => s.Id).Max() + 1;
        //            break;
        //        default:
        //            break;
        //    }
        //    return Id;
        //}
    }
}
