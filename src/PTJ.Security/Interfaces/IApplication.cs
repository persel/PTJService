using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTJ.Security.Interfaces
{
    interface IApplication
    {
        bool CanAppicationRead(int applicationId);

        bool CanAppicationUpdate(int applicationId);

        bool CanAppicationCreate(int applicationId);

        bool CanAppicationDelete(int applicationId);
    }
}
