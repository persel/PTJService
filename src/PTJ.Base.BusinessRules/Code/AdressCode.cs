using PTJ.Base.BusinessRules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PTJ.Base.BusinessRules.ViewModels;
using PTJ.Message;
using PTJ.DataLayer.Models;

namespace PTJ.Base.BusinessRules.Code
{
    public class AdressCode : IAdress
    {
        private ModelDbContext db;
        public AdressCode(ModelDbContext _db)
        {
            db = _db;
        }
    }
}
