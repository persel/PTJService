using PTJ.Base.BusinessRules.ViewModels;
using PTJ.DataLayer.Models;
using PTJ.Message;

namespace AdressSvc.BusinessService.Interfaces
{
    interface IBackend
    {
        Response<AdressViewModel> GetByPersnr(long persnr);

        Response<AdressViewModel> UpdateAdress(PersonViewModel model);

        Response<AdressViewModel> InsertAdress(PersonViewModel model);

        Response<AdressViewModel> DeleteAdress(long persnr);

    }
}
