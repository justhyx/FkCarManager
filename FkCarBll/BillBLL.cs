using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbTool;
namespace FkCar.BLL
{
    public class BillBLL
    {
        public static BillBLL singerton;
        public static BillBLL GetBLLObject()
        {
            if (singerton == null)
            { singerton = new BillBLL(); }
            return singerton;
        }
    }
}
