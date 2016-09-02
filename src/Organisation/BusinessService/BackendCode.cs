using Organisation.BusinessService;
using Organisation.BusinessService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Organisation.Model;

namespace Organisation.BusinessService
{
    public class BackendCode : IBackend
    {
        private ModelContext db;


        public BackendCode()//ModelContext db1)
        {
            //db = ModelContext;// db1;
        }

        public Person GetById(long persnr)
        {
            //ModelContext db = new ModelContext();
            return new Person();// db.Person.First();
        }

    }
}
