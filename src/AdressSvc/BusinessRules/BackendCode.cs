﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdressSvc.BusinessRules.Interfaces;
using PTJ.Message;
using PTJ.DataLayer.Models;
using PTJ.Base.BusinessRules.PersonSvc;
using PTJ.Base.BusinessRules.Code;
using PTJ.Base.BusinessRules.AdressSvc;

namespace AdressSvc.BusinessRules
{
    public class BackendCode : IBackend
    {
        private ModelDbContext db;
        AdressCode ac;
        DbUtils dbUtils;

        public BackendCode(ModelDbContext _db)
        {
            db = _db;
            dbUtils = new DbUtils(db);
            ac = new AdressCode(db);
        }

        public Response<AdressViewModel> GetByAdressId(long id)
        {
            Response<AdressViewModel> result = new Response<AdressViewModel>();
            List<AdressViewModel> lst = new List<AdressViewModel>();

            var adress =  ac.GetByAdressId(id);
            lst.Add(adress);
            result.result = lst;

            return result;
           
        }


        public Response<AdressViewModel> GetByPersnr(long persnr)
        {
            Response<AdressViewModel> result = new Response<AdressViewModel>();

            var adress = ac.GetByPersonId(persnr,false);
            result.result = adress;
            result.success = "true";
            result.message = "Ok";

            return result;
        }


        public Response<AdressViewModel> UpdateAdress(AdressViewModel model)
        {
            throw new NotImplementedException();
        }

        public Response<AdressViewModel> InsertAdress(AdressViewModel model)
        {
            throw new NotImplementedException();
        }


        public Response<AdressViewModel> DeleteAdress(long id)
        {
            Response<AdressViewModel> r = new Response<AdressViewModel>();
            using (db)
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var adressDb = (from a in db.Adress
                                        where a.Id == id
                                        select a).FirstOrDefault();

                        if (adressDb != null)
                        {
                            adressDb.UpdateradDatum = DateTime.Now; //do not delete. Set date instead to preserve history
                            db.SaveChanges();
                        }
                        else
                        {
                            r.success = "false";
                            r.message = "Kan inte ta bort adressen eftersom den saknas i databasen.";
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

    
    }
}
