using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbTool;

namespace FkCar.Modle
{
    public abstract class Account : DbObject
    {
        public const int Main = 0,
        Fit = 1,
        Company = 2,
        Expert = 3;

        public virtual int Type { get; }
        public virtual int AccountID { get; }
        public List<BillDetail> Details { get; }
    }


    public class MainAccount : Account
    {
        public override int AccountID
        {
            get
            {
                return 0;
            }
        }

        public override int Type
        {
            get
            {
                return Main;
            }
        }



        public override bool CanSaveCheck(out string cantSaveResean)
        {
            throw new NotImplementedException();
        }
    }
}
