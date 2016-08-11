using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TADASHBOARRD.Common
{
    public class CommonActions
    {
        public static void NavigateTADashboard()
        {
            WebDriver.driver.Navigate().GoToUrl(TestData.dashBoardURL);
        }

        public static void CheckTextDisplays(string expectedText, string actualText)
        {
            Assert.AreEqual(expectedText, actualText);
        }
        public static string GetDateTime()
        {
            return DateTime.Now.ToString("mmddyyhhmmss");
        }
        public void test()
        {
            
        }
    }
}
