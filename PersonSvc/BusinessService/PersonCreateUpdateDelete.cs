using System;
using System.Collections.Generic;
using System.Linq;
using PTJ.DataLayer.Models;
using PTJ.Base.BusinessRules.Code;
using PTJ.Base.BusinessRules.Interfaces;
using PTJ.Base.BusinessRules.ViewModels;
//using PTJ.Message;

namespace PersonSvc.BusinessService
{
    public class PersonCreateUpdateDelete : ICreateUpdateDelete<Person>
    {

        private ModelDbContext db;
        DbUtils dbUtils;

        public PersonCreateUpdateDelete(ModelDbContext _db)
        {
            db = _db;
            dbUtils = new DbUtils(db);

        }

        public bool Create(IQueryable<Person> entity)
        {
            throw new NotImplementedException();
        }

        public bool CreatePerson(PersonViewModel model, ref string errorMsg)
        {
            //Response<PersonViewModel> r = new Response<PersonViewModel>();
            //List<PersonViewModel> persList = new List<PersonViewModel>();

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

        public bool Delete(IQueryable<Person> entity)
        {
            throw new NotImplementedException();
        }

        public bool DeletePerson(long persnr)
        {
            throw new NotImplementedException();
        }

        public bool Update(IQueryable<Person> entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
