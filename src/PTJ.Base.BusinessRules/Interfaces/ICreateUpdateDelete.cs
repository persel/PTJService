using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTJ.Base.BusinessRules.Interfaces
{
    public interface ICreateUpdateDelete<T>
    {
        bool Create(IQueryable<T> entity);


        bool Update(IQueryable<T> entity);


        bool Delete(IQueryable<T> entity);
    }
}
