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
    public class FlowBLL : BaseBLL<Flow>
    {
        private static FlowBLL singleton;
        public static FlowBLL GetBLLObject()
        {
            if (singleton == null)
            { singleton = new FlowBLL(); }
            return singleton;
        }

        protected FlowBLL()
        {
            TableName = "TFlow";
            this.SaveCheckEvent += SaveCheck;
            this.UpdateCheckEvent += UpdateCheck;
            this.DeleteCheckEvent += DeleteCheck;
        }

        private bool DeleteCheck(Flow dbobj, DbEventArgs args)
        {
            throw new NotImplementedException();
        }

        private bool UpdateCheck(Flow dbobj, DbEventArgs args)
        {
            throw new NotImplementedException();
        }

        private bool SaveCheck(Flow dbobj, DbEventArgs args)
        {
            throw new NotImplementedException();
        }




        protected override Flow MakeModelObject(IDataReader rd)
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

        public override string UpdateSql(Flow m)
        {
            throw new NotImplementedException();
        }

        public override string DeleteSql(Flow m)
        {
            throw new NotImplementedException();
        }

        public override string SaveSql(Flow m)
        {
            return NewSqlBuilder(m).CompleteInsertSql(TableName);
        }

        public SqlBuilder NewSqlBuilder(Flow v)
        {
            SqlBuilder sqlbuilder = new SqlBuilder();
            sqlbuilder.AddUpdatValue(v.BelongBooking.Value.ObjID);
            sqlbuilder.AddUpdatValue(v.BelongTrip.Value.ObjID);
            sqlbuilder.AddUpdatValue(v.State);
            sqlbuilder.AddUpdatValue(v.TimeMark);

            return sqlbuilder;
        }
    }
}
