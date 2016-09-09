using PTJ.Base.BusinessRules.ViewModels;
using PTJ.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTJ.Base.BusinessRules.Interfaces
{
    interface IPerson
    {
        Response<PersonViewModel> GetByPersnr(long persnr);

    }
}
