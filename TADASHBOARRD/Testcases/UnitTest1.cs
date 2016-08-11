using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TADASHBOARRD.Common;
using TADASHBOARRD.PageActions.LoginPage;
using TADASHBOARRD.PageActions.GeneralPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Threading;


namespace TADASHBOARRD.Testcases
{
    [TestClass]
    public class UnitTest1: BaseTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //NavigateTADashboard();
            //WebDriver.driver.FindElement(By.XPath("//select[@id='repository']")).SendKeys("SampleRepository");
            //WebDriver.driver.FindElement(By.XPath("//input[@id='username']")).SendKeys("administrator");
            //WebDriver.driver.FindElement(By.XPath("//input[@id='password']")).SendKeys("");
            //WebDriver.driver.FindElement(By.XPath("//div[@class='btn-login']")).Click();
            //Thread.Sleep(1000);
            ////GeneralPage generalPage = new GeneralPage();
            ////WebDriver.driver.FindElement(By.XPath("//a[.='Dieu']")).Click();
            ////generalPage.Click("//a[.='Dieu']");
            //string xpath = string.Empty;
            //string next = string.Empty;
            //string locatorClass = string.Empty;

            //int items = WebDriver.driver.FindElements(By.XPath("//div[@id='main-menu']/div/ul/li/a")).Count;

            //xpath = "//div[@id='main-menu']/div/ul/li[2]/a";
            //Console.WriteLine(xpath);
            //locatorClass = WebDriver.driver.FindElement(By.XPath(xpath)).GetAttribute("class").ToString();
            //Console.WriteLine(locatorClass);
            //while (locatorClass.Equals("haschild"))
            //{
            //    Actions builder = new Actions(WebDriver.driver);
            //    builder.MoveToElement(WebDriver.driver.FindElement(By.XPath(xpath))).Build().Perform();
            //    next = "/following-sibling::ul/li/a";
            //    xpath = xpath + next;
            //    Console.WriteLine(xpath);
            //    locatorClass = WebDriver.driver.FindElement(By.XPath(xpath)).GetAttribute("class").ToString();
            //    Console.WriteLine(locatorClass);
            //    //WebDriver.driver.FindElement(By.XPath(xpath)).Click();
            //    //WebDriver.driver.FindElement(By.XPath("//li[@class='mn-setting']/a")).Click();
            //    //WebDriver.driver.FindElement(By.XPath("//a[.='Delete']")).Click();
            //    //WebDriver.driver.SwitchTo().Alert().Accept();
            //}
            //WebDriver.driver.FindElement(By.XPath(xpath)).Click();
            //WebDriver.driver.FindElement(By.XPath("//li[@class='mn-setting']/a")).Click();
            //WebDriver.driver.FindElement(By.XPath("//a[.='Delete']")).Click();
            ////generalPage.Click("//li[@class='mn-setting']/a");
            ////generalPage.Click("//a[.='Delete']");
            //WebDriver.driver.SwitchTo().Alert().Accept();
        }
    }
}
