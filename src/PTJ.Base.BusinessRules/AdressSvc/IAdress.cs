using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PTJ.Base.BusinessRules.AdressSvc;
using PTJ.Message;
using PTJ.DataLayer.Models;

namespace PTJ.Base.BusinessRules.AdressSvc
{
    interface IAdress
    {
        AdressViewModel GetByAdressId(long id);

        Mail GetMailAdress(long id);

        Telefon GetPhoneNumber(long id);

        GatuAdress GetStreetAdress(long id);

        List<AdressViewModel> GetByPersonId(long id, bool? workInformationOnly);

        List<AdressViewModel> GetByType(long id);

        List<AdressViewModel> GetAllAdressesById(long id);

    }
}
