using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbTool;
using System.Text.RegularExpressions;
namespace FkCar.Modle
{
    public class Driver : DbObject
    {
        public static readonly int DriverState_Ready = 1, DriverState_Hold = 2;

        public static readonly string
            DriverName = "DriverName",
            DriverCNPhone = "DriverCNPhone",
            DriverHKPhone = "DriverHKPhone",
            DriverState = "DriverState",
            DriverRegDate = "DriverRegDate";

        public override bool CanSaveCheck(out string alertmsg)
        {
            checkmark = true;
            checksb = new StringBuilder();

            CheckValue(Name);
            CheckValue(CNPhone);
            if (!new Regex(@"^(?<国家代码>(\+86)|(\＋８６))?(?<手机号>((13[0-9]{1})|(15[0-9]{1})|(18[0,5-9]{1}))+\d{8})$").IsMatch(CNPhone.Value.ToUpper()))
            { checksb.AppendFormat("{0} 输入的不是有效的内容！", CNPhone.Key); checkmark = false; }

            CheckValue(HKPhone);
            if (!new Regex(@"(?<三位区号>((852)|(８５２))\D?\d{8}").IsMatch(HKPhone.Value.ToUpper()))
            { checksb.AppendFormat("{0} 输入的不是有效的内容！", HKPhone.Key); checkmark = false; }

            alertmsg = (checksb.Length == 0) ? PassCheckMsg : checksb.ToString();
            checksb = null;
            return checkmark;
        }

        public void InitializationObjcet(string name, string cnphoe, string hkphone, int state, DateTime regdate)
        {
            Name = new ComboValue<string>(DriverName, name);
            CNPhone = new ComboValue<string>(DriverCNPhone, cnphoe);
            HKPhone = new ComboValue<string>(DriverHKPhone, hkphone);
            State = new ComboValue<int>(DriverState, state);
            RegDate = new ComboValue<DateTime>(DriverRegDate, regdate);
        }

        public Driver()
        {
            base.CreateFromView();
            InitializationObjcet(string.Empty, string.Empty, string.Empty, DriverState_Ready, DateTime.Now);
        }

        public Driver(int tid, string name, string cnphone, string hkphone, int state, DateTime regdate)
        {
            base.CreateFromDB(tid, false);
            InitializationObjcet(name, cnphone, hkphone, state, regdate);
        }

        public int ID { get { return base.TID; } }

        public ComboValue<string> Name { get; private set; }
        public ComboValue<string> CNPhone { get; private set; }
        public ComboValue<string> HKPhone { get; private set; }

        //1 正常，2 休息
        public ComboValue<int> State { get; private set; }
        public ComboValue<DateTime> RegDate { get; private set; }
    }
}
