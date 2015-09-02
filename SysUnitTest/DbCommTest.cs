using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pro.DbTool;
using Pro.CommonUntil;
using Pro.CommonUntil.MVC;

namespace SysUnitTest
{
    [TestClass]
    public class DbCommTest
    {

        [TestInitialize]
        public void ConnTest()
        {
            CommonDbTool.BuildFactory();
        }

        [TestMethod]
        public void SelectDateTest()
        {
            object o = CommonDbTool.Scalar("Select date('now');");
            Assert.IsNotNull(o, "查不到当前时间");
            try
            {
                DateTime d = DateTime.Parse(o.ToString());
                Assert.IsNotNull(d, "转换失败");
                Assert.IsTrue(DateTime.Today.Day.Equals(d.Day),string.Format( "时间差大,Today.Day is {0},d.Day is {1}", DateTime.Today.Day, d.Day));
            }
            catch (Exception ex)
            {
                LogWriter.WriteErrLog(typeof(CommonDbTool), ex);
                Assert.Fail(ex.Message);
            }
        }
    }
}
