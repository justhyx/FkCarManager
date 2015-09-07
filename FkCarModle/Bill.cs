using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pro.CommonUntil;
using DbTool;

namespace FkCar.Modle
{
    public class Bill : DbObject
    {

        public override bool CanSaveCheck(out string alertmsg)
        {
            throw new NotImplementedException();
        }


    }
}
