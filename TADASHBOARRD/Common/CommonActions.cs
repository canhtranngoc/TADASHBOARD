using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TADASHBOARRD.Common
{
    class CommonActions
    {
        public static void NavigateTADashboard()
        {
            Constant.driver.Navigate().GoToUrl(TestData.TestData.dashBoardURL);
        }

        public static void CheckTextDisplays(string expectedText, string actualText)
        {
            Assert.AreEqual(expectedText, actualText);
        }

    }
}
