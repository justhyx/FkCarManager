﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbTool;

namespace FkCar.Modle
{
    public class User : DbObject
    {
        public override bool CanSaveCheck(out string cantSaveResean)
        {
            cantSaveResean = PassCheckMsg;
            return true;
        }


    }


}
