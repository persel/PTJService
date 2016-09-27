using PTJ.Base.BusinessRules.PersonSvc;
using PTJ.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonSvc.BusinessRules.Interfaces
{
    public interface IPersonCreateUpdateDelete
    {
        bool AllreadyExist(string entityId, ref string validationMsg);

        bool CreatePerson(PersonViewModel model, ref string errorMsg);


        bool UpdatePerson(PersonViewModel model, ref string errorMsg);


        bool DeletePerson(long persnr, ref string errorMsg);
    }
}
