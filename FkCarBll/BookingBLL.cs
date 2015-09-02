using FkCar.Modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FkCar.BLL
{
    public class BookingBLL
    {
        public static BookingBLL singerton;
        public static BookingBLL GetBLLObject()
        {
            if (singerton == null)
            { singerton = new BookingBLL(); }
            return singerton;
        }

    }


}
