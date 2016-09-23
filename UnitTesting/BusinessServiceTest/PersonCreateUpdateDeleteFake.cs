using PersonSvc.BusinessService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTJ.DataLayer.Models;
using PTJ.Base.BusinessRules.ViewModels;

namespace UnitTesting.BusinessServiceTest
{
    class PersonCreateUpdateDeleteFake : IPersonCreateUpdateDelete
    {
        public bool CreatePerson(PersonViewModel model, ref string errorMsg)
        {
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
