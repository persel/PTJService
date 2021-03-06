﻿using PTJ.Base.BusinessRules.PersonSvc;
using PTJ.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTJ.Base.BusinessRules.PersonSvc
{
    public interface IPerson
    {

        List<PersonAdressViewModel> GetByKstnr(int kstnr, int page, int limit);

        List<PersonAdressViewModel> GetPersonByPersnr(long persnr, bool? workInformationOnly);

        

        /* *
         * Employee Or Consult
         * */
        List<PersonAdressViewModel> GetEmployeeByPersnr(long persnr);

        List<PersonAdressViewModel> GetConsultByPersnr(long persnr);

        List<PersonAdressViewModel> GetEmployeeOrConsultByPersnr(long persnr);

        List<PersonAdressViewModel> GetEmployeeByOrgnr(long orgnr);

        List<PersonAdressViewModel> GetConsultByOrgnr(long orgnr);

        List<PersonAdressViewModel> GetEmployeeAndConsultByOrgnr(long orgnr);

        /* *
         * Patient
         * */

        PersonAdressViewModel GetPatientByPersnr(long persnr);

        PersonAdressViewModel GetPatientByOrgnr(long orgnr);

    }
}
