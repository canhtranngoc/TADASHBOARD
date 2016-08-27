using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using TADASHBOARRD.Common;
using Fenton.Selenium.SuperDriver;
using System.Collections.Generic;
using TADASHBOARRD.Testcases.Test;
using TADASHBOARRD.PageActions.LoginPage;

namespace TADASHBOARRD.Testcases.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
         IWebDriver driver;
            //driver = new RemoteWebDriver(new Uri("http://192.168.190.158:4444/wd/hub/"), DesiredCapabilities.Firefox());
            //driver.Manage().Window.Maximize();
            //driver.Navigate().GoToUrl("http://192.168.191.92:54001/TADashboard/2f9njff6y9.page");
           //    driver = LocalDriver.GetDriver(Browser.SuperWebDriver);
            //   driver.Navigate().GoToUrl("http://google.com.vn");

            //  LoginPage loginpage = new LoginPage();
            //  loginpage.Login(TestData.defaulRepository, TestData.validUsername, "1");

            driver = RemoteDriver1.GetDriverGrid(Browser.SuperWebDriver);
      


        }
    }
}
