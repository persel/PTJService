using PTJ.Base.BusinessRules.PersonSvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonSvc.BusinessRules.Interfaces
{
    public interface IPersonValidation
    {
        bool CheckCreateValues(PersonViewModel model, ref string validationMsg);

        bool CheckUpdatesValues(PersonViewModel model, ref string validationMsg);
    }
}
