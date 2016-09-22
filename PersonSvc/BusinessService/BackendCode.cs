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
            Response<PersonViewModel> r = new Response<PersonViewModel>();
            using (db)
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var personDb = (from p in db.Person
                            where p.PersonNummer == persnr.ToString()
                            select p).FirstOrDefault();
                        if (personDb != null)
                        {
                            personDb.UppdateradDatum = DateTime.Now; //do not delete. Set date instead to preserve history
                            db.SaveChanges();
                        }
                        else
                        {
                            r.success = "false";
                            r.message = "Kan inte ta bort personen eftersom personen saknas i databasen.";
                            r.total = 0;
                        }
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


        public Response<PersonViewModel> UpdatePerson(PersonViewModel model)
        {
            Response<PersonViewModel> r = new Response<PersonViewModel>();
            List<PersonViewModel> persList = new List<PersonViewModel>();

            //Set timestamp on old instance and create new instance with same id to preserve history
            using (db)
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var personDb = (from p in db.Person
                            where p.Id == model.Person.Id
                            select p).FirstOrDefault();

                        if (personDb != null)
                        {
                            //Update old
                            personDb.UppdateradDatum = DateTime.Now;
                            db.SaveChanges();
                            //create new
                            Person person = new Person();
                            person.Id = personDb.Id;
                            person.ForNamn = model.Person.ForNamn;
                            person.EfterNamn = model.Person.EfterNamn;
                            //person.Username = model.Person.Username;
                            person.PersonNummer = model.Person.PersonNummer;
                            person.SkapadDatum = DateTime.Now;
                            db.Person.Add(person);
                            db.SaveChanges();
                        }

                        //Save person type
                        if (model.PersonAnnanPerson != null)
                        {
                            //Hämta och uppdatera
                            var annanPersonDb = (from p in db.PersonAnnanPerson
                                where p.Id == model.PersonAnnanPerson.Id
                                select p).FirstOrDefault();
                            if (annanPersonDb != null)
                            {
                                //update old
                                annanPersonDb.UpdateradDatum = DateTime.Now;
                                db.SaveChanges();
                                //create new
                                PersonAnnanPerson annanPers = new PersonAnnanPerson();
                                annanPers.Id = dbUtils.GetNewDbId("PersonAnnanPerson");
                                //annanPers.PersonFk = 

                            }
                            
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


        public Response<PersonViewModel> CreatePerson(PersonViewModel model)
        {
            Response<PersonViewModel> r = new Response<PersonViewModel>();

            PersonValidation validate = new PersonValidation(db);
            PersonCreateUpdateDelete crud = new PersonCreateUpdateDelete(db);

            string validationMsg = String.Empty;
            string errorMsg = String.Empty;
            bool isValidateOk = true;

            try
            {
                //1. Check all parameters are ok
                if (validate.CheckCreateValues(model, ref validationMsg))
                {
                    if (validate.AllreadyExist(model.Person.PersonNummer, ref validationMsg))
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

        public Response<PersonAdressViewModel> GetPersonAdressByPersnr(long persnr)
        {
            Response<PersonAdressViewModel> r = new Response<PersonAdressViewModel>();

            try
            {
                r.result = pc.GetPersonAdressByPersnr(persnr);
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

    }
}
