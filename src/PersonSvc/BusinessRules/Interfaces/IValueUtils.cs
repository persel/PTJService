using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonSvc.BusinessRules.Interfaces
{
    public interface IValueUtils
    {
        bool OnlyNumbers(long value);

        long CleanAndPreperPersnrForSaveOrUpdate(long value);

    }
}
