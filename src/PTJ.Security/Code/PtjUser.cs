using PTJ.Security.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTJ.Security.Code
{
    public class PtjUser : IPtjUser
    {
        public bool CanUserCreate(string username)
        {
            throw new NotImplementedException();
        }

        public bool CanUserDelete(string username)
        {
            throw new NotImplementedException();
        }

        public bool CanUserRead(string username)
        {
            throw new NotImplementedException();
        }

        public bool CanUserUpdate(string username)
        {
            throw new NotImplementedException();
        }

        public bool IsAuthorised(string username)
        {
            return (username == "pse" || username == "test" || username == "mah") ? true : false; 
        }

        public bool IsUserAdmin()
        {
            throw new NotImplementedException();
        }

        public bool IsUserKundreskontra()
        {
            throw new NotImplementedException();
        }

        public bool IsUserPraktiker()
        {
            throw new NotImplementedException();
        }

        public bool IsUserRadgivare()
        {
            throw new NotImplementedException();
        }

        public bool OnlyReadWorkInformation(string username)
        {
            return ( username == "test") ? true : false;
        }
    }
}
