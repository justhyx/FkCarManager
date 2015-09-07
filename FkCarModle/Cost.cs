using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbTool;
namespace FkCar.Modle
{
    public class Cost : DbObject
    {
        public Cost(int id)

        { }

        public override bool CanSaveCheck(out string alertmsg)
        {
            throw new NotImplementedException();
        }
    }
}
