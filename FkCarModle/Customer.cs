using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pro.CommonUntil.MVC;
using System.Text.RegularExpressions;
namespace FkCar.Modle
{
    public class Customer : DbObject
    {
        public static readonly int NewCu = 1, BanCu = 2;
        public static readonly string
           CustName = "CustName",
            //客户名称 16 byte
           CustFullName = "CustFullName",
            //全称 64byte 英语，全角字符
           CustCNPhone = "CustCNPhone",
            //中国大陆电话 默认 null
           CustHKPhone = "CustHKPhone",
            // 香港电话
           CustMail = "CustMail",
            //联系邮箱            
           CustType = "CustType",
            //客户类型 
           CustCounty = "CustCounty",
            //国家
           CustState = "CustState",
            // 客人状态。 一般就是有订单之后不能再删除
           CustMeno = "CustMeno";
        //备注 ，特殊要求 付款账户等

        public void InitializationObjcet(string name, string fullname, string cnphone, string hkphone, string mail, int type, string county, int state, string meno)
        {
            Name = new ComboValue<string>(CustName, name);
            FullName = new ComboValue<string>(CustFullName, fullname);
            CNPhone = new ComboValue<string>(CustCNPhone, cnphone);
            HKPhone = new ComboValue<string>(CustHKPhone, hkphone);
            Mail = new ComboValue<string>(CustMail, mail);
            CustomerType = new ComboValue<int>(CustType, type);
            County = new ComboValue<string>(CustCounty, county);
            State = new ComboValue<int>(CustState, state);
            Meno = new ComboValue<string>(CustMeno, meno);

        }

        public Customer()
        {
            this.CreateFromView();
            InitializationObjcet(ShortSpace, ShortSpace, ShortSpace, ShortSpace, ShortSpace, CustomerType_Individual, ShortSpace, 1, ShortSpace);
        }

        public Customer(string name, string fullname, string cnphone, string hkphone, string mail, int type, string county, int state, string meno)
        {
            this.CreateFromView();
            InitializationObjcet(name, fullname, cnphone, hkphone, mail, type, county, state, meno);
        }


        public ComboValue<string> Name { get; private set; }
        public ComboValue<string> FullName { get; private set; }
        public ComboValue<string> CNPhone { get; private set; }
        public ComboValue<string> HKPhone { get; private set; }
        public ComboValue<string> Mail { get; private set; }
        public ComboValue<int> CustomerType { get; private set; } // 1. 散客 ，2 长期客户 ， 3 公司单 4， 行家

        public static readonly int CustomerType_Individual = 1,
         CustomerType_LongTerm = 2,
         CustomerType_Company = 3,
         CustomerType_Experts = 4;
        public ComboValue<string> County { get; private set; }
        public ComboValue<int> State { get; private set; }
        public static readonly int CustomerState_NewOne = 1, CustomerState_Normal = 2,
            CustomerState_Banned = 3;

        public ComboValue<string> Meno { get; private set; }

        public override bool CanSaveCheck(out string alertmsg)
        {
            checkmark = true;
            checksb = new StringBuilder();
            CheckValue(Name);
            CheckValue(FullName);
            CheckValue(CNPhone);
            if (!new Regex(@"^(?<国家代码>(\+86)|(\＋８６))?(?<手机号>((13[0-9]{1})|(15[0-9]{1})|(18[0,5-9]{1}))+\d{8})$").IsMatch(CNPhone.Value.ToUpper()))
            { checksb.AppendFormat("{0} 输入的不是有效的内容！", CNPhone.Key); checkmark = false; }
            CheckValue(HKPhone);
            if (!new Regex(@"(?<三位区号>((852)|(８５２))\D?\d{8}").IsMatch(HKPhone.Value.ToUpper()))
            { checksb.AppendFormat("{0} 输入的不是有效的内容！", HKPhone.Key); checkmark = false; }
            CheckValue(Mail);

            //  CheckValue(CustomerType);

            if (CustomerType.Value > CustomerType_Experts || CustomerType.Value < CustomerType_Individual)
            { checksb.AppendFormat("{0} 输入的不是有效的内容！", CustomerType.Key); checkmark = false; }

            CheckValue(County);

            alertmsg = (checksb.Length == 0) ? PassCheckMsg : checksb.ToString();
            checksb = null;
            return checkmark;
        }
    }
}
