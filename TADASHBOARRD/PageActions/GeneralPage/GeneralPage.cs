using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TADASHBOARRD.Common;

namespace TADASHBOARRD.PageActions.GeneralPage
{
    class GeneralPage:CommonActions
    {

        public void WaitForElementLoad(By locator, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                WebDriverWait wait = new WebDriverWait(WebDriver.driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
        }

        public void ConfirmPopup()
        {
            Thread.Sleep(1000);
            WebDriver.driver.SwitchTo().Alert().Accept();
        }

        public string GetTextPopup()
        {
            Thread.Sleep(1000);
            return WebDriver.driver.SwitchTo().Alert().Text;
        }
    }
}
