using PTJ.Base.BusinessRules.AdressSvc;
using PTJ.Base.BusinessRules.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdressSvc.BusinessRules.Interfaces
{
    interface IAdressCreateUpdateDelete
    {
        bool AllreadyExist(string entityId, ref string validationMsg);

        bool CreateAdress(AdressViewModel model, ref string errorMsg);


        bool UpdateAdress(AdressViewModel model, ref string errorMsg);


        bool DeleteAdress(long persnr, ref string errorMsg);
    }
}
