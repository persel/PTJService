﻿using Organisation.Model;
using PTJ.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organisation.BusinessService.Interfaces
{
    public interface IBackend
    {

        Person GetById(long persnr);



    }
}