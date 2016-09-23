using PTJ.Base.BusinessRules.ViewModels;
using PTJ.DataLayer.Models;
using PTJ.Message;


namespace PersonSvc.BusinessService.Interfaces
{
    interface IBackend
    {
        Response<PersonViewModel> GetByKstnr(int kstnr, int page , int limit);

        //Response GetByAlias(string alias);

        Response<PersonViewModel> GetByPersnr(long persnr);

       // Response<PersonAdressViewModel> GetPersonAdressByPersnr(long persnr);

     
        Response<PersonViewModel> UpdatePerson(PersonViewModel model);

        Response<PersonViewModel> CreatePerson(PersonViewModel model);

        Response<PersonViewModel> DeletePerson(long persnr);

    }
}
