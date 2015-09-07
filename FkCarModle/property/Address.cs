using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pro.CommonUntil;
using DbTool;

namespace FkCar.Modle
{
    public class Address : DbObject
    {
        public static readonly string
        AddressCity = "AddressCity",
        AddressENName = "AddressENName",
        AddressCNName = "AddressCNName",
        AddressExactlyStreet = "AddressExactlyStreet";

        public override bool CanSaveCheck(out string alertmsg)
        {
            checkmark = true;

            checksb = new StringBuilder();

            CheckValue(City);
            CheckValue(ENName);
            CheckValue(CNName);
            CheckValue(ExactlyStreet);

            alertmsg = (checksb.Length == 0) ? PassCheckMsg : checksb.ToString();
            return checkmark;
        }



        public Address()
        {
            this.CreateFromView();
            InitializationObjcet(string.Empty, string.Empty, string.Empty, string.Empty);
        }

        public Address(int tid, string city, string cnname, string enname, string street)
        {
            this.CreateFromDB(tid, false);
            InitializationObjcet(city, cnname, enname, street);
        }

        private void InitializationObjcet(string city, string cnname, string enname, string street)
        {
            City = new ComboValue<string>(AddressCity, city);
            CNName = new ComboValue<string>(AddressCNName, cnname);
            ENName = new ComboValue<string>(AddressENName, enname);
            ExactlyStreet = new ComboValue<string>(AddressExactlyStreet, street);
        }

        public ComboValue<string> City;//城市
        public ComboValue<string> ENName;//地点名称
        public ComboValue<string> CNName;//英文名称
        public ComboValue<string> ExactlyStreet; //具体地址
    }
}
