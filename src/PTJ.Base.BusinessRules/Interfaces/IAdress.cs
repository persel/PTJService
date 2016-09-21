using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PTJ.Base.BusinessRules.ViewModels;
using PTJ.Message;
using PTJ.DataLayer.Models;

namespace PTJ.Base.BusinessRules.Interfaces
{
    interface IAdress
    {
        List<AdressViewModel> GetByAdressId(long id);

        Mail GetMailAdress(long id);

        Telefon GetPhoneNumber(long id);

        GatuAdress GetStreetAdress(long id);

        List<AdressViewModel> GetByPersonId(long id);

        List<AdressViewModel> GetByType(long id);

        List<AdressViewModel> GetAllAdressesById(long id);

    }
}
