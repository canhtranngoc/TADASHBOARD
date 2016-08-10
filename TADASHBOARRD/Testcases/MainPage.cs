using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TADASHBOARRD.Testcases
{
    [TestClass]
    public class MainPage:BaseTest
    {
        [TestMethod]
        public void TC01()
        {
            NavigateTADashboard();
        }
    }
}
