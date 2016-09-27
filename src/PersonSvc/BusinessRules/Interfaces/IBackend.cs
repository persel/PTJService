using PTJ.Base.BusinessRules.PersonSvc;
using PTJ.DataLayer.Models;
using PTJ.Message;


namespace PersonSvc.BusinessRules.Interfaces
{
    interface IBackend
    {
        Response<PersonAdressViewModel> GetByKstnr(int kstnr, int page , int limit);

        //Response GetByAlias(string alias);

        Response<PersonAdressViewModel> GetByPersnr(long persnr);

       // Response<PersonAdressViewModel> GetPersonAdressByPersnr(long persnr);

     
        Response<PersonAdressViewModel> UpdatePerson(PersonViewModel model);

        Response<PersonAdressViewModel> CreatePerson(PersonViewModel model);

        Response<PersonAdressViewModel> DeletePerson(long persnr);

    }
}
