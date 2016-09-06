using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTJ.Message
{
    public class Response<T>
    {
       
        public string success { get; set; }

        public string message { get; set; }

        public int errorcode { get; set; }

        public int total { get; set; }

        public int limit { get; set; }

        public int page { get; set; }

        public int responsetime { get; set; }

        public int time { get; set; }

        public List<T> result { get; set; }

    }
}
