using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbTool;
namespace FkCar.Modle
{
    /// <summary>
    /// 最核心的业务对象
    /// </summary>
    public class Trip : DbObject
    {
        public static readonly string
            TripOid = "TripOid", // 
            TripBookingOID = "TripBookingOID",
            TripPickUpTime = "TripPickUpTime",
            TripCar = "TripCar",
            TripDriver = "TripDriver",
            TripMainPassager = "TripMainPassager",
            TripStartingAddress = "TripStartingAddress",
            TripDestinationAddress = "TripDestinationAddress",
            TripPayState = "TripPayState",
            TripQuote = "TripQuote",
            TripSettlement = "TripSettlement",
            TripState = "TripState",
            TripFlightMsg = "TripFlightMsg";

       


        private void InitializationObjcet(int oid, Booking bookingoid, DateTime pickupitem, Vehicle car, Driver driver, string mainpassager, Address starting, Address destination, string flight, int paystate, float quote, int settlement, Flow state)
        {
            ObjID = new ComboValue<int>(TripOid, oid);
            Booking = new ComboValue<Booking>(TripBookingOID, bookingoid);

            this.PickUpTime = new ComboValue<DateTime>(TripPickUpTime, pickupitem);
            this.Car = new ComboValue<Vehicle>(TripCar, car);
            this.Driver = new ComboValue<Driver>(TripDriver, driver);
            this.MainPassager = new ComboValue<string>(TripMainPassager, mainpassager);
            this.StartingAddress = new ComboValue<Address>(TripStartingAddress, starting);
            this.DestinationAddress = new ComboValue<Address>(TripDestinationAddress, destination);
            this.Settlement = new ComboValue<int>(TripSettlement, settlement);
            this.Quote = new ComboValue<float>(TripQuote, quote);
            this.PayState = new ComboValue<int>(TripPayState, paystate);
            this.State = new ComboValue<Flow>(TripState, state);
            this.Flight = new ComboValue<string>(TripFlightMsg, flight);
        }

        public Trip(Booking prebooking)
        {
            this.CreateFromView();
            InitializationObjcet(-1, prebooking, DateTime.Now, new Vehicle(), new Driver(), string.Empty, new Address(), new Address(), string.Empty, PayState_Unpay, 1000.0f, TripSettlementType_Cash, new Flow(prebooking, this));
        }

        public Trip(int tid, int oid, Booking bookingoid, DateTime pickupitem, Vehicle car, Driver driver, string mainpassager, Address starting, Address destination, string flight, int paystate, float quote, int settlement, Flow state, bool iscover)
        {
            this.CreateFromDB(tid, iscover);
            InitializationObjcet(oid, bookingoid, pickupitem, car, driver, mainpassager, starting, destination, flight, paystate, quote, settlement, state);
        }

        public static Trip NewTrip(Booking prebooking)
        {
            Trip Trip = new Trip(prebooking);

            //Trip.Booking.Value = prebooking;
            return Trip;
        }


        public override bool CanSaveCheck(out string alertmsg)
        {
            checkmark = true;
            checksb = new StringBuilder();



            alertmsg = (checksb.Length == 0) ? PassCheckMsg : checksb.ToString();
            checksb = null;
            return checkmark;
        }

        public ComboValue<int> ObjID { get; private set; }
        public ComboValue<Booking> Booking { get; private set; }

        public ComboValue<DateTime> PickUpTime { get; private set; }

        public ComboValue<Vehicle> Car { get; private set; }
        public ComboValue<Driver> Driver { get; private set; }
        public ComboValue<string> MainPassager { get; private set; }

        public ComboValue<int> PassagerCount { get; private set; }

        public ComboValue<Address> StartingAddress { get; private set; }

        public ComboValue<Address> DestinationAddress { get; private set; }
        public ComboValue<string> Flight { get; private set; }
        public ComboValue<int> PayState { get; private set; }
        public const int PayState_Unpay = 1, PayState_PayToDri = 2, PayState_PayToKK = 3, PayState_PayByCheck = 4;

        //报价
        public ComboValue<float> Quote { get; private set; }

        //结款方式                
        public ComboValue<int> Settlement { get; private set; }
        public const int TripSettlementType_Cash = 1,
            TripSettlementType_PerPay = 2,
            TripSettlementType_Monthly = 3,
            TripSettlementType_Credit = 4;

        public ComboValue<Flow> State { get; private set; }
    }



}
