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
    public class AdressCode : IAdress
    {
        private IApplicationDbContext db;
        public AdressCode(IApplicationDbContext _db)
        {
            db = _db;
        }

        public List<AdressViewModel> GetByAdressId(long id)
        {
            List<AdressViewModel> lst = new List<AdressViewModel>();
            AdressViewModel model = new AdressViewModel();

            var adrDb = (from a in db.Adress
                            where a.Id == id
                            select a).FirstOrDefault();

            if (adrDb != null)
            {
                model.Adress = adrDb;

                //Check type and get adress
                switch (adrDb.AdressTypFkid)
                {
                    case 1:
                        model.GatuAdress = GetStreetAdress(model.Adress.Id);
                        break;
                    case 2:
                        model.Mail = GetMailAdress(model.Adress.Id);
                        break;
                    case 3:
                        model.Telefon = GetPhoneNumber(model.Adress.Id);
                        break;
                    default:
                        break;
                }

                //Get variant description
                var variantDb = (from v in db.AdressVariant
                                 where v.Id == model.Adress.AdressVariantFkid
                                 select v).FirstOrDefault();

                model.Adressvariant = variantDb;
            }

            lst.Add(model);

            return lst;
        }

        public Mail GetMailAdress(long id)
        {
            Mail mailAdrDb = new Mail();

            mailAdrDb = (from m in db.Mail
                         where m.Id == id
                         select m).FirstOrDefault();            
            return mailAdrDb;
        }

        public Telefon GetPhoneNumber(long id)
        {
            Telefon phoneDb = new Telefon();

            phoneDb = (from p in db.Telefon
                         where p.Id == id
                         select p).FirstOrDefault();
            return phoneDb;
        }

        public GatuAdress GetStreetAdress(long id)
        {
            GatuAdress streetAdrDb = new GatuAdress();

            streetAdrDb = (from s in db.GatuAdress
                       where s.Id == id
                       select s).FirstOrDefault();
            return streetAdrDb;
        }

        public List<AdressViewModel> GetByPersonId(long id)
        {
            throw new NotImplementedException();
        }

        public List<AdressViewModel> GetByType(long id)
        {
            throw new NotImplementedException();
        }

        public List<AdressViewModel> GetAllAdressesById(long pId)
        {
            throw new NotImplementedException();
            //Response<AdressViewModel> r = new Response<AdressViewModel>();
            //return r;
        }
    }
}
