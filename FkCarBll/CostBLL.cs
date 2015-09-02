using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FkCar.BLL
{
    public class CostBLL
    {
        public static CostBLL singerton;
        public static CostBLL GetBLLObject()
        {
            if (singerton == null)
            { singerton = new CostBLL(); }
            return singerton;
        }
    }
}
