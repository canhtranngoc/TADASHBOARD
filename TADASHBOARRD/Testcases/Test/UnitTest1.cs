﻿using System;
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
            //DesiredCapabilities capabilities = DesiredCapabilities.Firefox();
            //capabilities.SetCapability(CapabilityType.BrowserName, "Firefox");
            //capabilities.SetCapability(CapabilityType.Version, "47");
            //capabilities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
            driver = new RemoteWebDriver(new Uri("http://192.168.191.92:4444/wd/hub"), DesiredCapabilities.Firefox());
            driver.Navigate().GoToUrl("http://google.com.vn");
        }
    }
}
