//using Axiomatics.Pep.Sdk;
//using System;
//using Cybercom.CespId.Integration.AspNet;

//namespace Ptj.XacmlHandler
//{
//    public class XacmlHandler
//    {
//        Aps5WsPolicyDecisionPointProvider pdpProvider = null;

//        public void SetPdpProvider()//string _url, string _username , string _password)
//        {


//            this.pdpProvider = new Aps5WsPolicyDecisionPointProvider(url, userName, password);
//        }

//        private static bool HandleXacmlResponse(XacmlAuthorizationDecisionResponse pdpResponse)
//        {
//            bool xacmlResponse = false;

//            foreach (XacmlAuthorizationDecision result in pdpResponse.Decisions)
//            {
//                if (result.Decision == XacmlDecision.Permit)
//                {
//                    xacmlResponse = true;
//                }
//            }
//            return xacmlResponse;
//        }

//        //public bool GetPdpPermitOrDeny(string subject, string action, string resource)
//        //{
//        //    //SamlMembershipUser user = Membership.GetUser() as SamlMembershipUser;
//        //    //string subject = String.Empty;


//        //    //if (user != null)
//        //    //{
//        //    //    subject = user.UserName;
//        //    //}
//        //    //else
//        //    //{
//        //    //    throw new Exception("An exception occurred reading Saml. User = null. Please contact your system administrator. ");
//        //    //}

//        //    return GetPdpPermitOrDeny(subject, action, resource);
//        //    //return true;
//        //}

//        public bool GetPdpPermitOrDeny(string subject, string action, string resource)
//        {
//            SetPdpProvider();
//            XacmlAuthorizationDecisionResponse pdpResponse = null;

//            pdpResponse = this.pdpProvider.Evaluate(new XacmlDecisionRequestContext
//            {
//                new XacmlDecisionRequest
//                {
//                    new XacmlAttributes(XacmlConstants.Categories.Resource)
//                    {
//                        { new Uri("urn:oasis:names:tc:xacml:1.0:resource:resource-id"), resource}
//                    },

//                    new XacmlAttributes(XacmlConstants.Categories.Action)
//                    {
//                        { new Uri("urn:oasis:names:tc:xacml:1.0:action:action-id"), action}
//                    },

//                    new XacmlAttributes(XacmlConstants.Categories.Subject)
//                    {
//                        { new Uri("urn:oasis:names:tc:xacml:1.0:subject:subject-id"), subject}
//                    },
//                }
//            });

//            return HandleXacmlResponse(pdpResponse);
//        }

//        public bool GetPdpPermitOrDeny(XacmlDecisionRequestContext xacmlrequest)
//        {
//            XacmlAuthorizationDecisionResponse pdpResponse = null;
//            pdpResponse = this.pdpProvider.Evaluate(xacmlrequest);
//            return HandleXacmlResponse(pdpResponse);
//        }

//        public XacmlAuthorizationDecisionResponse GetPdpDescision(XacmlDecisionRequestContext xacmlrequest)
//        {
//            return this.pdpProvider.Evaluate(xacmlrequest);
//        }
//    }
//}