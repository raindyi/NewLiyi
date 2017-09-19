using System;
using IISMonitorDX.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IISMonitorDX.UT
{
    [TestClass]
    public class MonitorAction_UT
    {
        [TestMethod]
        public void 获取应用程序池_GetApplications_TM()
        {
            IISMonitorDX.Core.MonitorAction action=new MonitorAction();
            var lists = action.GetApplications();
            Assert.IsTrue(lists.Count>0);
        }
    }
}
