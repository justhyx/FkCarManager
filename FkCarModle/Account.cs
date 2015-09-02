using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FkCar.Modle
{
    public class Account
    {
        public virtual int AccountType { get; }
        public virtual int AccountID { get; }
        public List<BillDetail> Details { get; }

    }

  


    public class MainAccount : Account
    {


    }
}
