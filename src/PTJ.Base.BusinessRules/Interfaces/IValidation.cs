using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTJ.Base.BusinessRules.Interfaces
{
    public interface IValidation<T>
    {
      

        bool CheckCreateValues(IViewModel<T> model, ref string validationMsg);

        bool CheckUpdatesValues(IViewModel<T> entity, ref string validationMsg);

        //bool CheckCreateValues(PersonViewModel model, ref string validationMsg)
    


        //bool CheckUpdatesValues(IViewModel<PersonViewModel> entity, ref string validationMsg)
     

    }

   
}
