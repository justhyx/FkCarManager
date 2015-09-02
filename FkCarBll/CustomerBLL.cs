using FkCar.Modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FkCar.BLL
{
    public class CustomerBLL
    {
        public CustomerBLL()
        { //TableName = "TCustomer"; 
        }
        public static CustomerBLL singerton;
        public static CustomerBLL GetBLLObject()
        {
            if (singerton == null)
            { singerton = new CustomerBLL(); }
            return singerton;
        }
    }
}
