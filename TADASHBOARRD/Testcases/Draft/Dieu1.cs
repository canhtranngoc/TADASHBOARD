﻿using System;
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
    public class Dieu1: BaseTest
    {



        [TestMethod]
        public void TestMethod1()
        {
            NavigateTADashboard();
            LoginPage loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            Thread.Sleep(1000);

            string xpath = string.Empty;
            string xpathNext = string.Empty;
            string locatorClass = string.Empty;
            int numTab = WebDriver.driver.FindElements(By.XPath("//div[@id='main-menu']/div/ul/li/a")).Count;
            int pageIndex = numTab - 3;
            Console.WriteLine(pageIndex);

            while (pageIndex != 1)
            {
                for (int i = numTab - 4; i >= 1; i--)
                {
                    int numChildren = WebDriver.driver.FindElements(By.XPath("//div[@id='main-menu']/div/ul/li[" + pageIndex + "]/a//..//ul/li/a")).Count;
                    Console.WriteLine(numChildren);
                    for (int j = 0; j <= numChildren; j++)
                    {
                        xpath = "//div[@id='main-menu']/div/ul/li[" + pageIndex + "]/a";
                        Console.WriteLine(xpath);
                        locatorClass = WebDriver.driver.FindElement(By.XPath(xpath)).GetAttribute("class").ToString();
                        Console.WriteLine(locatorClass);
                        while (locatorClass.Equals("haschild"))
                        {
                            Actions builder = new Actions(WebDriver.driver);
                            builder.MoveToElement(WebDriver.driver.FindElement(By.XPath(xpath))).Build().Perform();
                            xpathNext = "/following-sibling::ul/li/a";
                            xpath = xpath + xpathNext;
                            Console.WriteLine(xpath);
                            locatorClass = WebDriver.driver.FindElement(By.XPath(xpath)).GetAttribute("class").ToString();
                            Console.WriteLine(locatorClass);
                        }
                        Console.WriteLine(xpath);
                        WebDriver.driver.FindElement(By.XPath(xpath)).Click();
                        WebDriver.driver.FindElement(By.XPath("//li[@class='mn-setting']/a")).Click();
                        WebDriver.driver.FindElement(By.XPath("//a[.='Delete']")).Click();
                        WebDriver.driver.SwitchTo().Alert().Accept();
                        Thread.Sleep(1000);
                    }
                    pageIndex = pageIndex - 1;
                    Console.WriteLine(pageIndex);
                }
            }
    }
}