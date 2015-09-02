using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FkCar.Modle;

namespace SysUnitTest.ModelObjTest
{
    [TestClass]
    public class VehicleTest
    {
        Vehicle viewvehicle, dbvehicle;

        [TestInitialize]
        public void TestInit()
        {
            viewvehicle = new Vehicle();
            dbvehicle = new Vehicle("粤Z 123456", "RB 1234", "TOYOTA", "FK", 1, 7, 23, false);
        }

        [TestMethod]
        public void NewObj()
        {
            string alertmsg;
            Assert.AreEqual(viewvehicle.IsFromDb, false, "IsFromDb");
            Assert.AreEqual(viewvehicle.TID, -1, "TID");

            Assert.AreEqual(viewvehicle.CanSaveCheck(out alertmsg), false, alertmsg);
            Assert.AreEqual(viewvehicle.CNCardID.Value, string.Empty, "CNCardID.Value");
            Assert.AreEqual(viewvehicle.CNCardID.BeenChange, false, "CNCardID.BeenChange");
            Assert.AreEqual(viewvehicle.CNCardID.Key, Vehicle.CarCNCardID, "CNCardID.Key");
            Assert.AreEqual(viewvehicle.HKCardID.Value, string.Empty, "HKCardID.Value");
            Assert.AreEqual(viewvehicle.HKCardID.BeenChange, false, Vehicle.CarHKCardID, "HKCardID.BeenChange");
            Assert.AreEqual(viewvehicle.SeatCount.Value, 0, "SeatCount.Value");
            Assert.AreEqual(viewvehicle.State.Value, (int)1, "State.Value");

            viewvehicle.CNCardID.Value = "123";
            viewvehicle.HKCardID.Value = "123";
            viewvehicle.Model.Value = "TOYOTA Alpha -WHITE 2015";
            viewvehicle.Owner.Value = "FK";
            viewvehicle.State.Value = 3;
            viewvehicle.SeatCount.Value = 0;

            Assert.IsFalse(viewvehicle.CanSaveCheck(out alertmsg), alertmsg);
            Console.WriteLine(alertmsg);
            viewvehicle.CNCardID.Value = "粤Z W#$G";
            viewvehicle.HKCardID.Value = "RC 4";
            viewvehicle.SeatCount.Value = 7;
            Assert.IsFalse(viewvehicle.CanSaveCheck(out alertmsg), alertmsg);
        }

        [TestMethod]
        public void LoadObj()
        {
            string s;
            Assert.AreEqual(dbvehicle.CanSaveCheck(out s), true, s);

        }




    }

}
