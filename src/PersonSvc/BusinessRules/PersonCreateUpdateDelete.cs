using System;
using System.Collections.Generic;
using System.Linq;
using PTJ.DataLayer.Models;
using PTJ.Base.BusinessRules.Code;
using PTJ.Base.BusinessRules.Interfaces;
using PTJ.Base.BusinessRules.PersonSvc;
using PersonSvc.BusinessRules.Interfaces;
using PersonSvc.ViewModels;
//using PTJ.Message;

namespace PersonSvc.BusinessRules
{
    public class PersonCreateUpdateDelete : IPersonCreateUpdateDelete //ICreateUpdateDelete<Person>
    {

        private ModelDbContext db;
        DbUtils dbUtils;

        public PersonCreateUpdateDelete(ModelDbContext _db)
        {
            db = _db;
            dbUtils = new DbUtils(db);

        }

        public bool AllreadyExist(string entityId, ref string validationMsg)
        {
            var allreadyExist = (from p in db.Person
                                 where p.PersonNummer == entityId 
                                 select p.PersonNummer).FirstOrDefault();

            if (String.IsNullOrEmpty(allreadyExist))
            {
                return false;
            }
            else
            {
                validationMsg = "Error Create Person allready exist " + entityId;
                return true;
            }
        }


        public bool CreatePerson(PersonViewModelSave model, ref string errorMsg)
        {
            var transaction = db.Database.BeginTransaction();

            try
            {
                var allreadyExist = (from p in db.Person
                                     where p.PersonNummer == model.PersonNummer
                                     select p.PersonNummer).FirstOrDefault();

                if (String.IsNullOrEmpty(allreadyExist))
                {
                    Person newPerson = new Person();
                    newPerson.Id = dbUtils.GetNewDbId("Person");
                    newPerson.PersonNummer = model.PersonNummer;
                    newPerson.ForNamn = model.ForNamn;
                    newPerson.MellanNamn = model.MellanNamn;
                    newPerson.EfterNamn = model.EfterNamn;
                    newPerson.SkapadDatum = DateTime.Now;
                    newPerson.UppdateradAv = "mah";// model.UppdateradAvAlias;

                    db.Person.Add(newPerson);
                    db.SaveChanges();

                    //Get id 
                    var dbPersonId = newPerson.Id;

                    //Save person type
                    if (model.PersonAnnanPerson)
                    {
                        PersonAnnanPerson newAnnanPerson = new PersonAnnanPerson();

                        newAnnanPerson.Id = dbUtils.GetNewDbId("PersonAnnanPerson");
                        newAnnanPerson.PersonFkid = newPerson.Id;
                        newAnnanPerson.AnnanPersonFkid = 9999;
                        newAnnanPerson.SkapadDatum = DateTime.Now;
                        newAnnanPerson.UpdateradAv = "mah";

                        db.PersonAnnanPerson.Add(newAnnanPerson);
                        db.SaveChanges();
                    }

                    if (model.PersonAnstalld)
                    {
                        PersonAnstalld newPersonAnstalld = new PersonAnstalld();

                        newPersonAnstalld.PersonFkid = newPerson.Id;
                        newPersonAnstalld.Id = dbUtils.GetNewDbId("PersonAnstalld");
                        newPersonAnstalld.AnstalldFkid = 9999;
                        newPersonAnstalld.SkapadDatum = DateTime.Now;
                        newPersonAnstalld.UpdateradAv = "mah";
                        db.PersonAnstalld.Add(newPersonAnstalld);
                        db.SaveChanges();
                    }

                    if (model.PersonKonsult)
                    {
                        PersonKonsult newPersonKonsult = new PersonKonsult();
                        newPersonKonsult.PersonFkid = newPerson.Id;
                        newPersonKonsult.Id = dbUtils.GetNewDbId("PersonKonsult");
                        newPersonKonsult.KonsultFkid = 9999;
                        newPersonKonsult.UpdateradAv = "mah";
                        newPersonKonsult.SkapadDatum = DateTime.Now;
                        newPersonKonsult.UpdateradDatum = DateTime.Now;

                        db.PersonKonsult.Add(newPersonKonsult);
                        db.SaveChanges();
                    }

                    if (model.PersonPatient)
                    {
                        PersonPatient newPersonPatient = new PersonPatient();

                        newPersonPatient.PersonFkid = newPerson.Id;
                        newPersonPatient.Id = dbUtils.GetNewDbId("PersonPatient");
                        newPersonPatient.PatientFkid = 9999;
                        newPersonPatient.UpdateradAv = "mah";
                        newPersonPatient.SkapadDatum = DateTime.Now;

                        db.PersonPatient.Add(newPersonPatient);
                        db.SaveChanges();
                    }

                    if (model.PersonSjukHalsovardsPersonal)
                    {
                        PersonSjukHalsovardsPersonal newPersonSjukHalsovardsPersonal = new PersonSjukHalsovardsPersonal();

                        newPersonSjukHalsovardsPersonal.PersonFkid = newPerson.Id;
                        newPersonSjukHalsovardsPersonal.Id = dbUtils.GetNewDbId("PersonSjukHalsovardsPersonal");
                        newPersonSjukHalsovardsPersonal.SjukHalsovardsPersonalFkid = 9999;
                        newPersonSjukHalsovardsPersonal.UpdateradAv = "mah";
                        newPersonSjukHalsovardsPersonal.SkapadDatum = DateTime.Now;
                        newPersonSjukHalsovardsPersonal.UpdateradDatum = DateTime.Now;

                        db.PersonSjukHalsovardsPersonal.Add(newPersonSjukHalsovardsPersonal);
                        db.SaveChanges();
                    }
                }
                transaction.Commit();

                return true;

            }
            catch (Exception e)
            {
                errorMsg = e.Message;
                return false;
            }

        }


        public bool DeletePerson(long persnr, ref string errorMsg)
        {
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
                            return true;
                        }
                        else
                        {
                            errorMsg = "Kan inte ta bort personen eftersom personen saknas i databasen.";
                            return false;
                        }
                    }
                    catch (Exception e)
                    {
                        errorMsg = e.Message;
                        return false;
                    }
                }
            }

        }

        public bool UpdatePerson(PersonViewModelSave model, ref string errorMsg)
        {

            using (db)
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var personDb = (from p in db.Person
                                        where p.Id == model.Id
                                        select p).FirstOrDefault();

                        if (personDb != null)
                        {
                            //Update old
                            personDb.UppdateradDatum = DateTime.Now;                          
                            db.SaveChanges();

                            //create new
                            //model.Person.Id = dbUtils.GetNewDbId("Person");
                            //model.Person.SkapadDatum = DateTime.Now;
                            //model.Person.UppdateradDatum = DateTime.Now;
                            //model.Person.UppdateradAv = "mah";
                            //db.Person.Add(model.Person);
                            //db.SaveChanges();

                            Person person = new Person();
                            person.Id = dbUtils.GetNewDbId("Person");
                            person.ForNamn = model.ForNamn;
                            person.EfterNamn = model.EfterNamn;
                          
                            //person.Username = model.Person.Username;
                            person.PersonNummer = model.PersonNummer;
                            person.SkapadDatum = DateTime.Now;
                            db.Person.Add(person);
                            db.SaveChanges();
                        }

                        ////Save person type
                        //if (model.PersonAnnanPerson != null)
                        //{
                        //    //Hämta och uppdatera
                        //    var annanPersonDb = (from p in db.PersonAnnanPerson
                        //                         where p.Id == model.PersonAnnanPerson.Id
                        //                         select p).FirstOrDefault();
                        //    if (annanPersonDb != null)
                        //    {
                        //        //update old
                        //        annanPersonDb.UpdateradDatum = DateTime.Now;
                        //        db.SaveChanges();
                        //        //create new
                        //        PersonAnnanPerson annanPers = new PersonAnnanPerson();
                        //        annanPers.Id = dbUtils.GetNewDbId("PersonAnnanPerson");
                        //        //annanPers.PersonFk = 

                        //    }

                        //}
                        //else if (model.PersonAnstalld != null)
                        //{
                        //    //Hämta och uppdatera
                        //    var anstalldPersonDb = (from p in db.PersonAnstalld
                        //                            where p.Id == model.PersonAnstalld.Id
                        //                            select p).FirstOrDefault();

                        //    anstalldPersonDb.UpdateradDatum = DateTime.Now;
                        //    db.SaveChanges();
                        //}
                        //else if (model.PersonKonsult != null)
                        //{
                        //    //Hämta och uppdatera
                        //    var konsultPersonDb = (from p in db.PersonKonsult
                        //                           where p.Id == model.PersonKonsult.Id
                        //                           select p).FirstOrDefault();

                        //    konsultPersonDb.UpdateradDatum = DateTime.Now;
                        //    db.SaveChanges();
                        //}
                        //else if (model.PersonPatient != null)
                        //{
                        //    //Hämta och uppdatera
                        //    var patientPersonDb = (from p in db.PersonPatient
                        //                           where p.Id == model.PersonPatient.Id
                        //                           select p).FirstOrDefault();

                        //    patientPersonDb.UpdateradDatum = DateTime.Now;
                        //    db.SaveChanges();
                        //}
                        //else if (model.PersonSjukHalsovardsPersonal != null)
                        //{
                        //    //Hämta och uppdatera
                        //    var HKPersonalPersonDb = (from p in db.PersonSjukHalsovardsPersonal
                        //                              where p.Id == model.PersonSjukHalsovardsPersonal.Id
                        //                              select p).FirstOrDefault();

                        //    HKPersonalPersonDb.UpdateradDatum = DateTime.Now;
                        //    db.SaveChanges();
                        //}

                        // Commit transaction if all commands succeed, transaction will auto-rollback
                        // when disposed if either commands fails
                        transaction.Commit();
                        return true;
                        
                        
                    }
                    catch (Exception e)
                    {
                        errorMsg = e.Message;
                        return false;
                    }
                }
            }

        }
    }
}
