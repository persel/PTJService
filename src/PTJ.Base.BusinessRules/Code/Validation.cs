using PTJ.Base.BusinessRules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTJ.Base.BusinessRules.Code
{
    public class Validation : IValidation
    {
        public bool canICreate(string childId, string parentId)
        {
            throw new NotImplementedException();
        }

        public bool canIDelete(string child, string parent)
        {
            throw new NotImplementedException();
        }

        public bool canIUpdate<T>()
        {
            throw new NotImplementedException();
        }

        public bool doChildExist(long entityId)
        {
            throw new NotImplementedException();
        }

        public bool doParentEntityExist(long entityId)
        {
            throw new NotImplementedException();
        }
    }
}
