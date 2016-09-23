using System;
using System.Collections.Generic;
using System.Linq;
using PTJ.DataLayer.Models;
using PTJ.Base.BusinessRules.Code;
using PTJ.Base.BusinessRules.Interfaces;
using PTJ.Base.BusinessRules.ViewModels;
using PersonSvc.BusinessService.Interfaces;
//using PTJ.Message;

namespace PersonSvc.BusinessService
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


        public bool CreatePerson(PersonViewModel model, ref string errorMsg)
        {
           
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
                           
                            model.Person.Id = dbUtils.GetNewDbId("Person");
                            model.Person.SkapadDatum = DateTime.Now;
                            //model.Person.UppdateradDatum = DateTime.Now;
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
                                model.PersonAnnanPerson.UpdateradDatum = DateTime.Now;
                                db.PersonAnnanPerson.Add(model.PersonAnnanPerson);
                                db.SaveChanges();
                            }

                            if (model.PersonAnstalld != null)
                            {
                                model.PersonAnstalld.PersonFkid = model.Person.Id;
                                model.PersonAnstalld.Id = dbUtils.GetNewDbId("PersonAnstalld");
                                model.PersonAnstalld.SkapadDatum = DateTime.Now;
                                model.PersonAnstalld.UpdateradDatum = DateTime.Now;
                                db.PersonAnstalld.Add(model.PersonAnstalld);
                                db.SaveChanges();
                            }

                            if (model.PersonKonsult != null)
                            {
                                model.PersonKonsult.PersonFkid = model.Person.Id;
                                model.PersonKonsult.Id = dbUtils.GetNewDbId("PersonKonsult");
                                model.PersonKonsult.SkapadDatum = DateTime.Now;
                                model.PersonKonsult.UpdateradDatum = DateTime.Now;
                                db.PersonKonsult.Add(model.PersonKonsult);
                                db.SaveChanges();
                            }

                            if (model.PersonPatient != null)
                            {
                                model.PersonPatient.PersonFkid = model.Person.Id;
                                model.PersonPatient.Id = dbUtils.GetNewDbId("PersonPatient");
                                model.PersonPatient.SkapadDatum = DateTime.Now;
                                model.PersonPatient.UpdateradDatum = DateTime.Now;
                                db.PersonPatient.Add(model.PersonPatient);
                                db.SaveChanges();
                            }

                            if (model.PersonSjukHalsovardsPersonal != null)
                            {
                                model.PersonSjukHalsovardsPersonal.PersonFkid = model.Person.Id;
                                model.PersonSjukHalsovardsPersonal.Id =
                                dbUtils.GetNewDbId("PersonSjukHalsovardsPersonal");
                                model.PersonSjukHalsovardsPersonal.SkapadDatum = DateTime.Now;
                                model.PersonSjukHalsovardsPersonal.UpdateradDatum = DateTime.Now;
                                db.PersonSjukHalsovardsPersonal.Add(model.PersonSjukHalsovardsPersonal);
                                db.SaveChanges();
                            }
                        }

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

        public bool UpdatePerson(PersonViewModel model, ref string errorMsg)
        {

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
                            //model.Person.Id = dbUtils.GetNewDbId("Person");
                            //model.Person.SkapadDatum = DateTime.Now;
                            //model.Person.UppdateradDatum = DateTime.Now;
                            //model.Person.UppdateradAv = "mah";
                            //db.Person.Add(model.Person);
                            //db.SaveChanges();

                            Person person = new Person();
                            person.Id = dbUtils.GetNewDbId("Person");
                            person.ForNamn = model.Person.ForNamn;
                            person.EfterNamn = model.Person.EfterNamn;
                          
                            //person.Username = model.Person.Username;
                            person.PersonNummer = model.Person.PersonNummer;
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
