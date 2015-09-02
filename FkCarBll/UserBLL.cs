using FkCar.Modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pro.DbTool;
using Pro.CommonUntil;
using Pro.CommonUntil.MVC;
namespace FkCar.BLL
{
    public class UserBLL : BaseBLL<User>
    {
        private static UserBLL singerton;
        public static UserBLL GetBLLObject()
        {
            if (singerton == null)
            { singerton = new UserBLL(); }
            return singerton;
        }

        protected override User MakeModelObject(System.Data.IDataReader rd)
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

        public override string UpdateSql(User m)
        {
            throw new NotImplementedException();
        }

        public override string DeleteSql(User m)
        {
            throw new NotImplementedException();
        }

        public override string SaveSql(User m)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateCheck()
        {
            DateTime dnow = DateTime.MinValue;

            try
            {
                dnow = Convert.ToDateTime(CommonDbTool.Scalar("Select DATE('NOW');"));
            }
            catch (Exception ex)
            {
                LogWriter.WriteErrLog(GetType(), ex);
            }

            return dnow;
        }
    }
}
