using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace TADASHBOARRD.Testcases.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1Tinh()
        {
            IWebDriver driver;

          //DesiredCapabilities capabilities = new DesiredCapabilities();
            //capabilities.SetCapability(CapabilityType.BrowserName, "Firefox");
            //capabilities.SetCapability(CapabilityType.Version, "47");
            //capabilities.SetCapability(CapabilityType.Platform, "WINDOWS");
            driver = new RemoteWebDriver(new Uri("http://192.168.190.158:4444/wd/hub"), DesiredCapabilities.Firefox());
            driver.Navigate().GoToUrl("http://google.com.vn");
        }
    }
}
