using PersonSvc.ViewModels;
using PTJ.Base.BusinessRules.PersonSvc;
using PTJ.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonSvc.BusinessRules.Interfaces
{
    public interface IPersonCreateUpdateDelete
    {
        bool AllreadyExist(string entityId, ref string validationMsg);

        bool CreatePerson(PersonViewModelSave model, ref string errorMsg);


        bool UpdatePerson(PersonViewModelSave model, ref string errorMsg);


        bool DeletePerson(long persnr, ref string errorMsg);
    }
}
