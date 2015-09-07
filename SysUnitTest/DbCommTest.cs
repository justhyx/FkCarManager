using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DbTool;
using Pro.CommonUntil;


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
            object o = CommonDbTool.Scalar("Select date('now', 'localtime');");//要加 , 'localtime' 不然时间不对
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
