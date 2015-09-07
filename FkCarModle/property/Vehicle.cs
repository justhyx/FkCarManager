using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DbTool;

namespace FkCar.Modle
{
    public class Vehicle : DbObject
    {
        public static readonly string
            CarCNCardID = "CarCNCardID",
            CarHKCardID = "CarHKCardID",
            CarModel = "CarModel",
            CarOwner = "CarOwner",
            CarState = "CarState",
            CarSeatCount = "CarSeatCount";

        public Vehicle()
        {
            this.CreateFromView();
            InitializationObjcet(ShortSpace, ShortSpace, ShortSpace, ShortSpace, 1, 0);
        }
        public Vehicle(string cncardid, string encardid, string model, string owner, int state, int seats, int tid, bool iscover)
        {
            this.CreateFromDB(tid, iscover);
            InitializationObjcet(cncardid, encardid, model, owner, state, seats);
        }
        private void InitializationObjcet(string cncardid, string encardid, string model, string owner, int state, int seats)
        {
            CNCardID = new ComboValue<string>(CarCNCardID, cncardid);
            HKCardID = new ComboValue<string>(CarHKCardID, encardid);
            Model = new ComboValue<string>(CarModel, model);
            Owner = new ComboValue<string>(CarOwner, owner);
            State = new ComboValue<int>(CarState, state);
            SeatCount = new ComboValue<int>(CarSeatCount, seats);
        }
        //public int ID { get { return base.TID; } }

        public ComboValue<string> CNCardID { get; private set; }
        public ComboValue<string> HKCardID { get; private set; }
        public ComboValue<string> Model { get; private set; }
        public ComboValue<string> Owner { get; private set; }

        /// <summary>
        ///   Ready = 1, //待命
        //    Fix = 2, //维修
        //    Scrap = 3, //报废
        /// </summary>
        public ComboValue<int> State { get; private set; }
        public ComboValue<int> SeatCount { get; private set; }

        public override bool CanSaveCheck(out string cantSaveResean)
        {
            checkmark = true;
            checksb = new StringBuilder();
            //Regex regex = new Regex();
            //if (CNCardID.Value.Equals(ShortSpace) || CNCardID.Value.Equals(string.Empty))
            //{ sb.AppendFormat(NoSetAlertMsg, CNCardID.Key); m = false; }
            CheckValue(CNCardID);

            if (!new Regex(@"[\u4e00-\u9fa5]{1}[A-Z]{1}\s*[A-Z_0-9]{5}").IsMatch(CNCardID.Value.ToUpper()))
            { checksb.AppendFormat("{0} 输入的不是有效的内容！", CNCardID.Key); checkmark = false; }

            //if (HKCardID.Value.Equals(ShortSpace) || HKCardID.Value.Equals(string.Empty))
            //{ sb.AppendFormat(NoSetAlertMsg, HKCardID.Key); m = false; }
            CheckValue(HKCardID);
            if (!new Regex(@"((?!IOQ)\w){2}\s*\d{1,4}").IsMatch(HKCardID.Value.ToUpper()))
            { checksb.AppendFormat("{0} 输入的不是有效的内容！", HKCardID.Key); checkmark = false; }

            //if (Model.Value.Equals(ShortSpace) || Model.Value.Equals(string.Empty))
            //{ checksb.AppendFormat(NoSetAlertMsg, Model.Key); checkmark = false; }
            CheckValue(Model);


            //if (Owner.Value.Equals(ShortSpace) || Owner.Value.Equals(string.Empty))
            //{ checksb.AppendFormat(NoSetAlertMsg, Owner.Key); checkmark = false; }
            CheckValue(Owner);

            if (State.Source.Equals(3) && State.BeenChange)
            { checksb.AppendFormat("{0} 已经报废的车辆不能再进行状态修改！", State.Key); checkmark = false; }

            if (SeatCount.Value <= 0)
            { checksb.AppendFormat(NoSetAlertMsg, SeatCount.Key); checkmark = false; }

            cantSaveResean = (checksb.Length == 0) ? PassCheckMsg : checksb.ToString();
            checksb = null;
            return checkmark;
        }
    }

    //public enum VehicleState
    //{
    //    Ready = 1, //待命
    //    Fix = 2, //维修
    //    Scrap = 3, //报废
    //}
}
