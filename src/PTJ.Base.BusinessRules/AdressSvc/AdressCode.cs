using PTJ.Base.BusinessRules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PTJ.Base.BusinessRules.PersonSvc;
using PTJ.Message;
using PTJ.DataLayer.Models;

namespace PTJ.Base.BusinessRules.AdressSvc
{
    public class AdressCode : IAdress
    {
        private ModelDbContext db;
        public AdressCode(ModelDbContext _db)
        {
            db = _db;
        }

        public AdressViewModel GetByAdressId(long id)
        {
            AdressViewModel model = new AdressViewModel();
           

            try
            {
                var adrDb = (from a in db.Adress
                             where a.Id == id
                             select a).FirstOrDefault();

                if (adrDb != null)
                {
                    model.Id = id;

                    var streetAdrDb = (from s in db.GatuAdress
                                       where s.AdressFkid == id
                                       select s).FirstOrDefault();

                    if (streetAdrDb != null)
                    {
                        model.GatuAdress = streetAdrDb.AdressRad1;
                        model.Postnummer = streetAdrDb.Postnummer.ToString();
                        model.Stad = streetAdrDb.Stad;
                    }

                    var mailAdrDb = (from m in db.Mail
                                     where m.AdressFkid == id
                                     select m).FirstOrDefault();

                    if (mailAdrDb != null)
                    {
                        model.Mail = mailAdrDb.MailAdress;

                    }

                    var phoneDb = (from p in db.Telefon
                                   where p.AdressFkid == id
                                   select p).FirstOrDefault();

                    if (phoneDb != null)
                    {
                        model.Telefon = phoneDb.TelefonNummer.ToString();
                    }

                    var variantDb = (from v in db.AdressVariant
                                     where v.Id == adrDb.AdressVariantFkid
                                     select v).FirstOrDefault();


                    if (variantDb != null)
                    {
                        model.AdressvariantText = variantDb.Variant;
                        model.Adressvariant = variantDb.Id;
                    }

                    var typDb = (from v in db.AdressTyp
                                 where v.Id == adrDb.AdressTypFkid
                                 select v).FirstOrDefault();

                    if (typDb != null)
                    {
                        model.AdressTypText = typDb.Typ;
                        model.AdressTyp = typDb.Id;
                    }
                }
            }
            catch (Exception e)
            {
               e.ToString();
            }

            return model;
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

        public List<AdressViewModel> GetByPersonId(long persnr, bool? workInformationOnly)
        {
            List<AdressViewModel> lst = new List<AdressViewModel>();

            List<long> types;

            if (workInformationOnly.Value)
            {
                types = new List<long> {2,7,9,11};
            }
            else
            {
                types = new List<long> {1,2,3,4,5,6,7,8,9,10,11,12};
            }


            var personAdressId = (from pa in db.PersonAdress
                                  join a in db.Adress on pa.AdressFkid equals a.Id 
                                where pa.PersonFkid == persnr && types.Contains(a.AdressVariantFkid) 
                                select pa.AdressFkid).ToList();

            if ( personAdressId != null )
            {
                foreach (var item in personAdressId)
                {
                    AdressViewModel av = this.GetByAdressId(item);
                    lst.Add(av);
                }
            }

            return lst;
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
