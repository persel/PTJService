using PTJ.Base.BusinessRules.ViewModels;
using PTJ.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTJ.Base.BusinessRules.Interfaces
{
    public interface IPerson
    {
     
        Response<PersonViewModel> GetByKstnr(int kstnr, int page, int limit);

        Response<PersonAdressViewModel> GetPersonAdressByPersnr(long persnr);

        /* *
         * Employee Or Consult
         * */
        Response<PersonAdressViewModel> GetEmployeeByPersnr(long persnr);

        Response<PersonAdressViewModel> GetConsultByPersnr(long persnr);

        Response<PersonAdressViewModel> GetEmployeeOrConsultByPersnr(long persnr);

        Response<PersonAdressViewModel> GetEmployeeByOrgnr(long orgnr);

        Response<PersonAdressViewModel> GetConsultByOrgnr(long orgnr);

        Response<PersonAdressViewModel> GetEmployeeAndConsultByOrgnr(long orgnr);

        /* *
         * Patient
         * */

        Response<PersonAdressViewModel> GetPatientByPersnr(long persnr);

        Response<PersonAdressViewModel> GetPatientByOrgnr(long orgnr);

    }
}
