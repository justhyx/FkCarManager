using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbTool;
namespace FkCar.Modle
{

    /// <summary>
    /// 工作流状态类
    /// </summary>
    public class Flow : DbObject
    {
        public const string
            FlowBelongBookingOID = "FlowBelongBookingOID",
            FlowBelongTripOId = "FlowBelongTripOId",
            FlowState = "FlowState",
            FlowTimeMark = "FlowTimeMark";

        public ComboValue<Booking> BelongBooking { get; private set; }
        public ComboValue<Trip> BelongTrip { get; private set; }
        public ComboValue<int> State { get; private set; }
        public ComboValue<DateTime> TimeMark { get; private set; }

        public Flow NextFlow()//生成下一步对象
        {
            Flow newone = new Flow(this.BelongBooking.Value, this.BelongTrip.Value);
            //   FlowState state;
            switch (State.Value)
            {
                case FlowStateType_BeBooking:
                    newone.State.Value = FlowStateType_Enforcement;
                    break;
                case FlowStateType_Enforcement:
                    newone.State.Value = FlowStateType_Done;
                    break;
                case FlowStateType_Cancel:
                case FlowStateType_Done:
                default:
                    throw new ApplicationException("没有后续的执行的状态");
            }

            //            return new Flow(this.BelongOrder.Value, state, DateTime.Now);
            return newone;
        }

        public Flow(Booking booking, Trip trip)
        {
            this.CreateFromView();
            InitializationObjcet(booking, trip, FlowStateType_BeBooking, DateTime.Now);
        }

        public Flow(int tid, Booking orderid, Trip trip, int flow, DateTime timemark, bool IsCover)
        {
            this.CreateFromDB(tid, IsCover);

            InitializationObjcet(orderid, trip, flow, timemark);

        }
        private void InitializationObjcet(Booking booking, Trip belongtrip, int flow, DateTime timemark)
        {
            BelongBooking = new ComboValue<Booking>(FlowBelongTripOId, booking);
            BelongTrip = new ComboValue<Trip>(FlowBelongTripOId, belongtrip);

            State = new ComboValue<int>(FlowState, flow);

            TimeMark = new ComboValue<DateTime>(FlowTimeMark, timemark);
        }
        public override bool CanSaveCheck(out string alertmsg)
        {
            alertmsg = "";

            return true;
        }

        public const int FlowStateType_BeBooking = 1,
             FlowStateType_Cancel = 2,
              FlowStateType_Enforcement = 3,
               FlowStateType_Done = 4;



    }

}
