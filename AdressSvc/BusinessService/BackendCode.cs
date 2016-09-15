using System;
using PTJ.DataLayer.Models;
using PTJ.Base.BusinessRules;
using PTJ.Base.BusinessRules.ViewModels;
using PTJ.Message;
using AdressSvc.BusinessService.Interfaces;
using PTJ.Base.BusinessRules.Code;

namespace AdressSvc.BusinessService
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

        public Response<PersonViewModel> GetByPersnr(long persnr)
        {
            throw new NotImplementedException();
        }

        public Response<PersonViewModel> UpdateAdress(PersonViewModel model)
        {
            throw new NotImplementedException();
        }

        public Response<PersonViewModel> InsertAdress(PersonViewModel model)
        {
            throw new NotImplementedException();
        }

        public Response<PersonViewModel> DeleteAdress(long persnr)
        {
            throw new NotImplementedException();
        }
    }
}
