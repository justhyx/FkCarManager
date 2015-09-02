using FkCar.BLL;
using FkCar.Modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FkCar.BLL
{
    public class DriverBLL 
    {
        public static DriverBLL singerton;
        public static DriverBLL GetBLLObject()
        {
            if (singerton == null)
            { singerton = new DriverBLL(); }
            return singerton;
        }


        public DriverBLL()
        {
           // TableName = "TDriver";
        }
    }
}
