using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FkCar.Modle;
using System.Data;
using DbTool;

namespace FkCar.BLL
{
    public class AddressBLL : BaseBLL<Address>
    {
        public static AddressBLL singerton;
        public static AddressBLL GetBLLObject()
        {
            if (singerton == null)
            { singerton = new AddressBLL(); }
            return singerton;
        }
        protected override Address MakeModelObject(IDataReader rd)
        {
            return new Address(
                Convert.ToInt32(rd[Address.TableID]),
                Convert.ToString(rd[Address.AddressCity]),
                Convert.ToString(rd[Address.AddressCNName]),
                Convert.ToString(rd[Address.AddressENName]),
                Convert.ToString(rd[Address.AddressExactlyStreet])
                );
        }

        public override string SelectWithId(int TID)
        {
            throw new NotImplementedException();
        }

        public override string SelectSqlWithCondition(string condition)
        {
            throw new NotImplementedException();
        }

        public override string UpdateSql(Address m)
        {
            throw new NotImplementedException();
        }

        public override string DeleteSql(Address m)
        {
            throw new NotImplementedException();
        }

        public override string SaveSql(Address m)
        {
            throw new NotImplementedException();
        }
    }
}
