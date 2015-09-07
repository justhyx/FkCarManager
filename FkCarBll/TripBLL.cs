using FkCar.Modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DbTool;
namespace FkCar.BLL
{
    public class TripBLL : BaseBLL<Trip>
    {
        public static TripBLL singerton;
        public static TripBLL GetBLLObject()
        {
            if (singerton == null)
            { singerton = new TripBLL(); }
            return singerton;
        }

        protected override Trip MakeModelObject(IDataReader rd)
        {
            throw new NotImplementedException();
        }

        public override string SelectWithId(int TID)
        {
            throw new NotImplementedException();
        }

        public override string SelectSqlWithCondition(string condition)
        {
            throw new NotImplementedException();
        }

        public override string UpdateSql(Trip m)
        {
            throw new NotImplementedException();
        }

        public override string DeleteSql(Trip m)
        {
            throw new NotImplementedException();
        }

        public override string SaveSql(Trip m)
        {
            throw new NotImplementedException();
        }
    }
}
