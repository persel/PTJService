using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTJ.Security.Interfaces
{
    interface IApplication
    {
        bool CanApplicationRead(int applicationId);

        bool CanAppilcationUpdate(int applicationId);

        bool CanApplicationCreate(int applicationId);

        bool CanApplicationDelete(int applicationId);
    }
}
