//using Ptj.XacmlHandler;
using PTJ.Security.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTJ.Security.Code
{
    public class Roles : IRoles
    {


        public List<string> getRoleFromPdp()
        {
           // var xacmlRequest = new XacmlHandler();

            /**
            * Add list becouse some user have more then one role
            **/
            List<string> myRole = new List<string>();


            //if (xacmlRequest.GetPdpPermitOrDeny("isPraktiker", "generalPolicies"))
            //{
            //    myRole.Add((ConfigurationManager.AppSettings.AllKeys.Contains("isPraktiker")) ? ConfigurationManager.AppSettings["isPraktiker"] : "");
            //}
            //else if (xacmlRequest.GetPdpPermitOrDeny("isRadgivare", "generalPolicies"))
            //{
            //    myRole.Add((ConfigurationManager.AppSettings.AllKeys.Contains("isRadgivare")) ? ConfigurationManager.AppSettings["isRadgivare"] : "");
            //}
            //else if (xacmlRequest.GetPdpPermitOrDeny("isKundreskontra", "generalPolicies"))
            //{
            //    myRole.Add((ConfigurationManager.AppSettings.AllKeys.Contains("isKundreskontra")) ? ConfigurationManager.AppSettings["isKundreskontra"] : "");
            //}
            //if (xacmlRequest.GetPdpPermitOrDeny("isHkKstnrAnsv", "generalPolicies"))
            //{
            //    myRole.Add((ConfigurationManager.AppSettings.AllKeys.Contains("isHkKstnrAnsv")) ? ConfigurationManager.AppSettings["isHkKstnrAnsv"] : "");
            //}
            //else if (xacmlRequest.GetPdpPermitOrDeny("isAdmin", "generalPolicies"))
            //{
            //    myRole.Add((ConfigurationManager.AppSettings.AllKeys.Contains("isAdmin")) ? ConfigurationManager.AppSettings["isAdmin"] : "");
            //}
            //else if (myRole.Count == 0)
            //{
            //    myRole.Add((ConfigurationManager.AppSettings.AllKeys.Contains("isOgiltig")) ? ConfigurationManager.AppSettings["isOgiltig"] : "");
            //}


            return myRole;

        }


        public bool isPraktiker()
        {
            try
            {
                //var xacmlRequest = new XacmlHandler();
                //if (xacmlRequest.GetPdpPermitOrDeny("PSE" ,"isPraktiker", "generalPolicies"))
                //{
                //    return true;
                //}
                
                return false;

            }
            catch (Exception e)
            {
                //log.WriteExceptionLog("PdPUtils, isPraktiker" + e.Message + "\n" + e.InnerException.Message);
                throw new Exception("isPraktiker. " + e.Message);
            }

        }

        public bool isRadgivare()
        {

            List<string> roles = this.getRoleFromPdp();
            string radgivare = "";// ConfigurationManager.AppSettings["isRadgivare"];

            foreach (var role in roles)
            {
                if (role == radgivare)
                {
                    return true;
                }
            }

            return false;



        }

        public bool isKundreskontra()
        {
            try
            {
                List<string> roles = this.getRoleFromPdp();
                string isKundreskontra = "";// ConfigurationManager.AppSettings["isKundreskontra"];

                foreach (var role in roles)
                {
                    if (role == isKundreskontra)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception e)
            {
                //log.WriteExceptionLog("PdPUtils, isKundreskontra" + e.Message + "\n" + e.InnerException.Message);
                throw new Exception("isKundreskontra. " + e.Message);
            }

        }

        public bool isAdmin()
        {
            try
            {
                //var xacmlRequest = new XacmlHandler();
                //if (xacmlRequest.GetPdpPermitOrDeny("PSE","isAdmin", "generalPolicies"))
                //{
                //    return true;
                //}


                //return false;

                return true;

            }
            catch (Exception e)
            {
                //log.WriteExceptionLog("PdPUtils, isadmin" + e.Message + "\n" + e.InnerException.Message);
                throw new Exception("isAdmin. " + e.Message);
            }
        }

        public List<string> getMyRoles()
        {
            throw new NotImplementedException();
        }
    }
}
