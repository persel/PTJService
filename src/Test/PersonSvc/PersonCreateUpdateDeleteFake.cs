using PersonSvc.BusinessRules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PTJ.Base.BusinessRules.PersonSvc;
using PTJ.DataLayer.Models;
using PersonSvc.ViewModels;

namespace Test.PersonSvc
{
    public class PersonCreateUpdateDeleteFake : IPersonCreateUpdateDelete
    {
        public bool AllreadyExist(string entityId, ref string validationMsg)
        {
            return false;
        }

        public bool CreatePerson(PersonViewModelSave model, ref string errorMsg)
        {
            Person p = new Person();


            //context.Person.Add(p);

            return true;
        }

        public bool DeletePerson(long persnr, ref string errorMsg)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePerson(PersonViewModelSave model, ref string errorMsg)
        {
            throw new NotImplementedException();
        }
    }
}
