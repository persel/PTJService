using PersonSvc.BusinessRules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonSvc.BusinessRules.Utils
{
    public sealed class ValueUtils: IValueUtils
    {

        public bool OnlyNumbers(long value)
        {

            return true;
        }

        public long CleanAndPreperPersnrForSaveOrUpdate(long value)
        {

            return value;
        }

    }
}
