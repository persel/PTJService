using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTJ.DataLayer
{
    public class PersonAdress
    {
        public long Id { get; set; }
        public long personId { get; set; }

        public int adressId { get; set; }
    }
}
