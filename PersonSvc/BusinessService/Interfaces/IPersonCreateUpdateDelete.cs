using PTJ.Base.BusinessRules.ViewModels;
using PTJ.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonSvc.BusinessService.Interfaces
{
    public interface IPersonCreateUpdateDelete
    {
        bool CreatePerson(PersonViewModel model, ref string errorMsg);


        bool UpdatePerson(PersonViewModel model, ref string errorMsg);


        bool DeletePerson(long persnr, ref string errorMsg);
    }
}
