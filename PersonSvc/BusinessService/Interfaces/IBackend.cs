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

        Response<PersonAdressViewModel> GetPersonAdressByPersnr(long persnr);

     
        Response<PersonViewModel> UpdatePerson(PersonViewModel model);

        Response<PersonViewModel> CreatePerson(PersonViewModel model);

        Response<PersonViewModel> DeletePerson(long persnr);

        //long GetNewDbId(string tableName);
        PersonAnnanPerson GetPersonAnnanPerson(long personsId);

        PersonAnstalld  GetPersonAnstalld(long personsId);

        PersonKonsult GetPersonKonsult(long personsId);

        PersonPatient GetPersonPatient(long personsId);

        PersonSjukHalsovardsPersonal GetPersonSjukHalsovardsPersonal(long personsId);

    }
}
