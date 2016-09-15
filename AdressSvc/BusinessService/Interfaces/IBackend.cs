using PTJ.Base.BusinessRules.ViewModels;
using PTJ.DataLayer.Models;
using PTJ.Message;

namespace AdressSvc.BusinessService.Interfaces
{
    interface IBackend
    {
        Response<PersonViewModel> GetByPersnr(long persnr);

        Response<PersonViewModel> UpdateAdress(PersonViewModel model);

        Response<PersonViewModel> InsertAdress(PersonViewModel model);

        Response<PersonViewModel> DeleteAdress(long persnr);

    }
}
