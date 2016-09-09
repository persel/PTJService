using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTJ.Base.BusinessRules.Interfaces
{
    public interface IValidation
    {
        bool canICreate(string child, string parent );

        bool canIDelete(string child, string parent);

        bool canIUpdate<T>();

        bool doParentEntityExist(long entityId);

        bool doChildExist(long entityId);
    }
}
