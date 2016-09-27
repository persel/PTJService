using AdressSvc.BusinessRules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PTJ.Base.BusinessRules.ViewModels;
using PTJ.Base.BusinessRules.AdressSvc;

namespace AdressSvc.BusinessRules
{
    public class AdressCreateUpdateDelete : IAdressCreateUpdateDelete
    {
        public bool AllreadyExist(string entityId, ref string validationMsg)
        {
            throw new NotImplementedException();
        }

        public bool CreateAdress(AdressViewModel model, ref string errorMsg)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAdress(long persnr, ref string errorMsg)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAdress(AdressViewModel model, ref string errorMsg)
        {
            throw new NotImplementedException();
        }
    }
}
