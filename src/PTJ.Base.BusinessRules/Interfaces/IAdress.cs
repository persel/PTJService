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
        Response<AdressViewModel> GetByAdressId(long id);

        Mail GetMailAdress(long id);
        
        Telefon GetPhoneNumber(long id);

        GatuAdress GetStreetAdress(long id);

        Response<AdressViewModel> GetByPersonId(long id);
        
        Response<AdressViewModel> GetByType(long id);

        Response<AdressViewModel> GetAllAdressesById(long id);

    }
}
