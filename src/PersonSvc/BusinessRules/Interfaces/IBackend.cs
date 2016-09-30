using PersonSvc.ViewModels;
using PTJ.Base.BusinessRules.PersonSvc;
using PTJ.DataLayer.Models;
using PTJ.Message;


namespace PersonSvc.BusinessRules.Interfaces
{
    interface IBackend
    {
        Response<PersonAdressViewModel> GetByKstnr(int kstnr, int page , int limit, bool workInformationOnly);

        //Response GetByAlias(string alias);

        Response<PersonAdressViewModel> GetByPersnr(long persnr,bool workInformationOnly);

       // Response<PersonAdressViewModel> GetPersonAdressByPersnr(long persnr);

     
        Response<PersonAdressViewModel> UpdatePerson(PersonViewModelSave model);

        Response<PersonAdressViewModel> CreatePerson(PersonViewModelSave model);

        Response<PersonAdressViewModel> DeletePerson(long persnr);

    }
}
