using System;
using System.Collections.Generic;
using System.Text;

using Pro.CommonUntil;
using DbTool;

namespace FkCar.Modle
{
    public class Booking : DbObject
    {
        private void InitializationObjcet(int oid, DateTime createtime, Client customer, int state)
        {
            ObjID = new ComboValue<int>(BookingOID, oid);
            CreateTime = new ComboValue<DateTime>(BookingCreateTime, createtime);
            Customer = new ComboValue<Modle.Client>(BookingCustomer, customer);
            State = new ComboValue<int>(BookingState, state);
            bookingorder = new List<Trip>();

        }

        public Booking()
        {
            this.CreateFromView();
            InitializationObjcet(-1, DateTime.MinValue, null, BookingStateType_Ready);
            bookingorder.Add(Trip.NewTrip(this));
        }
        public Booking(int tid, int oid, DateTime createtime, Client customer, int state, IEnumerable<Trip> orders)
        {
            this.CreateFromDB(tid, false);
            InitializationObjcet(-1, DateTime.MinValue, null, BookingStateType_Ready);
            bookingorder.AddRange(orders);
        }


        public static readonly string
            BookingOID = "BookingOID",
            BookingCreateTime = "BookingCreateTime",
            BookingCustomer = "BookingCustomer",
            //BookingOrderCount = "BookingOrderCount",
            BookingState = "BookingState";

        public ComboValue<int> ObjID { get; private set; }
        public ComboValue<DateTime> CreateTime { get; private set; }

        public ComboValue<Client> Customer { get; private set; }
        //public int OrderCount { get; private set; }

        public ComboValue<int> State { get; private set; }
        public static readonly int BookingStateType_Ready = 1,
        BookingStateType_Ordered = 2,
        BookingStateType_Done = 3,
        BookingStateType_Update = 4,
        BookingStateType_Cancel = 5;

        private List<Trip> bookingorder;
        public List<Trip> Orders
        {
            get
            {
                if (bookingorder == null)
                {
                    LogWriter.WriteErrLog(typeof(Booking), new NullReferenceException("订单的行程计划对象被提前释放！"));
                    bookingorder = new List<Trip>();
                }

                return bookingorder;
            }
        }

        public override bool CanSaveCheck(out string alertmsg)
        {
            checkmark = true;
            checksb = new StringBuilder();

            if (this.Customer.Value.State.Value == Modle.Client.CustomerState_Banned)
            {
                checksb.Append("当前的客户被列入黑名单。不接受下单！");
                checkmark = false;
            }


            alertmsg = (checksb.Length == 0) ? PassCheckMsg : checksb.ToString();
            checksb = null;
            return checkmark;
        }
    }


}
