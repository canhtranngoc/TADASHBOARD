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
            Driver.driver.Navigate().GoToUrl(TestData.TestData.dashBoardURL);
        }

        public static void CheckTextDisplays(string expectedText, string actualText)
        {
            Assert.AreEqual(expectedText, actualText);
        }

        public void WaitForElementLoad(By locator, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
        }

        public void ConfirmPopup()
        {
            Thread.Sleep(1000);
            Driver.driver.SwitchTo().Alert().Accept();
        }

        public string GetTextPopup()
        {
            Thread.Sleep(1000);
            return Driver.driver.SwitchTo().Alert().Text;
        }
        public void test()
        {
            
        }
    }
}
