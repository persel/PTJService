using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTJ.Base.BusinessRules.Interfaces
{
    public interface IValidation<T>
    {
        //bool CanICreate(string child, string parent );

        //bool CanIDelete(string child, string parent);

        //bool CanIUpdate<T>();

        bool AllreadyExist(string entityId, ref string validationMsg);

        bool CheckCreateValues(IViewModel<T> model, ref string validationMsg);

        bool CheckUpdatesValues(IViewModel<T> entity);

        bool DoParentEntityExist(long entityId);

        bool DoChildExist(long entityId);

    }

   
}
