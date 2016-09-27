using PersonSvc.BusinessService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PTJ.Base.BusinessRules.ViewModels;
using PTJ.DataLayer.Models;

namespace Test.PersonSvc
{
    public class PersonCreateUpdateDeleteFake : IPersonCreateUpdateDelete
    {
        public bool AllreadyExist(string entityId, ref string validationMsg)
        {
            return false;
        }

        public bool CreatePerson(PersonViewModel model, ref string errorMsg)
        {
            Person p = new Person();


            //context.Person.Add(p);

            return true;
        }

        public bool DeletePerson(long persnr, ref string errorMsg)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePerson(PersonViewModel model, ref string errorMsg)
        {
            throw new NotImplementedException();
        }
    }
}
