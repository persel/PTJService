using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTJ.Security.Interfaces
{
    public interface IPtjUser
    {

        bool IsAuthorised(string username);

        bool OnlyReadWorkInformation(string username);

        bool CanUserRead(string username);

        bool CanUserUpdate(string username);

        bool CanUserCreate(string username);

        bool CanUserDelete(string username);

        bool IsUserPraktiker();

        bool IsUserAdmin();

        bool IsUserKundreskontra();

        bool IsUserRadgivare();


    }
}
