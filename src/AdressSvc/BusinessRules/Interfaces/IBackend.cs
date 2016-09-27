using PTJ.Base.BusinessRules.AdressSvc;
using PTJ.Base.BusinessRules.PersonSvc;
using PTJ.DataLayer.Models;
using PTJ.Message;

namespace AdressSvc.BusinessRules.Interfaces
{
    interface IBackend
    {
        Response<AdressViewModel> GetByPersnr(long persnr);

        Response<AdressViewModel> UpdateAdress(AdressViewModel model);

        Response<AdressViewModel> InsertAdress(AdressViewModel model);

        Response<AdressViewModel> DeleteAdress(long persnr);

    }
}
