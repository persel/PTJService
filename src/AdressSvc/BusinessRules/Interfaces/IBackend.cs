using PTJ.Base.BusinessRules.AdressSvc;
using PTJ.Base.BusinessRules.PersonSvc;
using PTJ.DataLayer.Models;
using PTJ.Message;

namespace AdressSvc.BusinessRules.Interfaces
{
    interface IBackend
    {
        Response<AdressViewModel> GetByPersnr(long persnr);

        Response<AdressViewModel> UpdateAdress(PersonViewModel model);

        Response<AdressViewModel> InsertAdress(PersonViewModel model);

        Response<AdressViewModel> DeleteAdress(long persnr);

    }
}
