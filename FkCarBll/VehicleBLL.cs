using FkCar.Modle;
using Pro.CommonUntil.MVC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FkCar.BLL
{
    public class VehicleBLL : BaseBLL<Vehicle>
    {
        private static VehicleBLL singleton;

        protected VehicleBLL()
        {
            TableName = "TVehicle";
            this.SaveCheckEvent += SaveCheck;
            this.UpdateCheckEvent += UpdateCheck;
            this.DeleteCheckEvent += DeleteCheck;

        }

        public static VehicleBLL GetBLLObject()
        {
            if (singleton == null)
            { singleton = new VehicleBLL(); }
            return singleton;
        }
        protected override Vehicle MakeModelObject(IDataReader rd)
        {
            return new Vehicle(
                    Convert.ToString(rd[Vehicle.CarCNCardID]),
                    Convert.ToString(rd[Vehicle.CarHKCardID]),
                    Convert.ToString(rd[Vehicle.CarModel]),
                    Convert.ToString(rd[Vehicle.CarOwner]),
                    Convert.ToInt32(rd[Vehicle.CarState]),
                    Convert.ToInt32(rd[Vehicle.CarSeatCount]),
                    Convert.ToInt32(rd[Vehicle.TableID]),
                    false);
        }

        public override string SelectWithId(int TID)
        {
            SqlBuilder sqlbuilder = NewSqlBuilder(new Vehicle());
            return sqlbuilder.CompleteSelectSql(TableName, "TID = '" + TID + "'");
        }

        public SqlBuilder NewSqlBuilder(Vehicle v)
        {
            SqlBuilder sqlbuilder = new SqlBuilder();
            sqlbuilder.AddUpdatValue(v.CNCardID);
            sqlbuilder.AddUpdatValue(v.HKCardID);
            sqlbuilder.AddUpdatValue(v.Owner);
            sqlbuilder.AddUpdatValue(v.State);
            sqlbuilder.AddUpdatValue(v.SeatCount);
            sqlbuilder.AddUpdatValue(v.Model);
            return sqlbuilder;
        }

        public override string SelectSqlWithCondition(string conditiong)
        {
            return NewSqlBuilder(new Vehicle()).CompleteSelectSql(TableName, conditiong);
        }

        public bool SaveCheck(Vehicle dbobj, DbEventArgs args)
        {
            string alertmsg;
            if (!dbobj.CanSaveCheck(out alertmsg))
                throw new ApplicationException(string.Format(@"{0}:{1}/{2}  内容不完整，无法保存！{3}", typeof(Vehicle).ToString(), dbobj.CNCardID, dbobj.HKCardID, alertmsg));

            if (dbobj.IsFromDb) throw new Exception("数据库中存在该数据！请改用更新操作！", new ApplicationException());
            return false;
        }

        public bool UpdateCheck(Vehicle dbobj, DbEventArgs args)
        {
            string alertmsg;
            if (!dbobj.CanSaveCheck(out alertmsg))
                throw new ApplicationException(string.Format(@"{0}:{1}/{2}  内容不完整，无法保存！{3}", typeof(Vehicle).ToString(), dbobj.CNCardID, dbobj.HKCardID, alertmsg));
            if (!dbobj.IsFromDb) throw new Exception("不能更新非数据库来源数据！", new ApplicationException());

            return true;
        }

        public bool DeleteCheck(Vehicle dbobj, DbEventArgs args)
        {
            if (!dbobj.IsFromDb) throw new Exception("无法删除非数据库来源数据！", new ApplicationException());
            if (TripBLL.GetBLLObject().GetList().Any<Trip>(o => o.Car.Value.TID == dbobj.TID))
            { throw new ApplicationException("不能删除已经生成订单的车辆"); }

            return true;
        }

        public override string UpdateSql(Vehicle m)
        {
            return NewSqlBuilder(m).CompleteChangeSql(TableName, "TID = " + m.TID);
        }

        public override string DeleteSql(Vehicle m)
        {
            return string.Format("Deletc From {0} WHERE ({1})", TableName, "TID = " + m.TID);
        }

        public override string SaveSql(Vehicle m)
        {

            return NewSqlBuilder(m).CompleteInsertSql(TableName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="showCanel"></param>
        /// <returns></returns>
        public List<Vehicle> GetObjs()
        {
            return base.GetList(Vehicle.CarState + " = ‘正常’");
        }



        public List<Vehicle> GetAll(bool hasorder)
        {
            if (hasorder)
            {

                var cars = from order in TripBLL.GetBLLObject().GetList()
                           where order.State.Value.Equals("Cancel") == false
                           select order.Car.Value.TID;

                string condition = (cars.Count<int>() == 0) ? "1=1" : string.Format("TID in ('{0}')", string.Join("','", cars));
                return base.GetList(condition);
            }
            else { return base.GetList(); }

        }
    }
}
