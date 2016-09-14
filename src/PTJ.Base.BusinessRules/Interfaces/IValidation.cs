using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTJ.Base.BusinessRules.Interfaces
{
    public interface IValidation
    {
        bool CanICreate(string child, string parent );

        bool CanIDelete(string child, string parent);

        bool CanIUpdate<T>();

        bool DoParentEntityExist(long entityId);

        bool DoChildExist(long entityId);
    }
}
