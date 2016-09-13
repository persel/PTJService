using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTJ.Security.Interfaces
{
    interface IRoles
    {

        List<string> getMyRoles();
        bool isPraktiker();
        bool isAdmin();
        bool isKundreskontra();

        bool isRadgivare();

    }
}
