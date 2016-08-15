using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using TADASHBOARRD.Common;
using System.Diagnostics;
using System.IO;
using System.Web.Script.Serialization;
using OpenQA.Selenium.Interactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TADASHBOARRD.PageActions.GeneralPage
{
    public class GeneralPage : CommonActions
    {

        public void WaitForElementLoad(By locator, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                WebDriverWait wait = new WebDriverWait(WebDriver.driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
        }

        public void waitForAlert(IWebDriver driver)
        {
            int i = 0;
            while (i++ < 5)
            {
                try
                {
                    IAlert alert = driver.SwitchTo().Alert();
                    break;
                }
                catch (NoAlertPresentException e)
                {
                    Console.WriteLine(e);
                    Sleep(1);
                    continue;

                }
            }
        }

        public void AcceptAlert()
        {
            //Sleep(1);
            //waitForAlert(WebDriver.driver);
            WebDriver.driver.SwitchTo().Alert().Accept();
            Sleep(1);
        }

        public string GetTextPopup()
        {
            Sleep(1);
            //waitForAlert(WebDriver.driver);
            return WebDriver.driver.SwitchTo().Alert().Text;
        }

        public string GetText(string locator)
        {
            return FindWebElement(locator).Text;
        }

        private static string GetClassCaller(int level = 4)
        {
            var m = new StackTrace().GetFrame(level).GetMethod();
            string className = m.DeclaringType.Name;
            return className;
        }

        public class control
        {
            public string controlName { get; set; }
            public string type { get; set; }
            public string value { get; set; }
        }

        public string[] GetControlValue(string nameControl)
        {
            string page = GetClassCaller();
            Console.WriteLine(page);
            string path = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
            path = path.Replace("\\bin\\Debug", "");
            string content = string.Empty;
            switch (page)
            {
                case "LoginPage":
                    content = File.ReadAllText(path + @"\Interfaces\LoginPage\" + page + ".json");
                    break;
                case "GeneralPage":
                case "NewPageDialog":
                    content = File.ReadAllText(path + @"\Interfaces\GeneralPage\" + page + ".json");
                    break;
                case "PanelsPage":
                case "NewPanelDialog":
                    content = File.ReadAllText(path + @"\Interfaces\PanelsPage\" + page + ".json");
                    break;
                case "DataProfilesPage":
                case "GeneralSettingsPage":
                    content = File.ReadAllText(path + @"\Interfaces\DataProfilesPage\" + page + ".json");
                    break;
                default:
                    break;
            }

            var result = new JavaScriptSerializer().Deserialize<List<control>>(content);
            string[] control = new string[2];
            foreach (var item in result)
            {
                if (item.controlName.Equals(nameControl))
                {
                    control[0] = item.type;
                    control[1] = item.value;
                    return control;
                }
            }
            return null;
        }

        public IWebElement FindWebElement(string locator)
        {
            string[] control = GetControlValue(locator);
            switch (control[0].ToUpper())
            {
                case "ID":
                    return WebDriver.driver.FindElement(By.Id(control[1]));
                case "NAME":
                    return WebDriver.driver.FindElement(By.Name(control[1]));
                case "CLASSNAME":
                    return WebDriver.driver.FindElement(By.ClassName(control[1]));
                default:
                    return WebDriver.driver.FindElement(By.XPath(control[1]));
            }
        }

        public void ClickOnDynamicElement(string control, string value)
        {
            FindDynamicWebElement(control, value).Click();
        }

        public IWebElement FindDynamicWebElement(string name, string value)
        {
            string[] control = GetControlValue(name);
            string dynamicControl = string.Format(control[1].ToString(), value);
            return WebDriver.driver.FindElement(By.XPath(dynamicControl));
        }

        //public void Click(string locator)
        //{
        //    FindWebElement(locator).Click();
        //}

        public void EnterValue(string locator, string value)
        {
            FindWebElement(locator).Clear();
            FindWebElement(locator).SendKeys(value);
        }

        public void EnterValueDropdownList(string locator, string value)
        {
            FindWebElement(locator).SendKeys(value);
        }

        public void TickCheckbox(string locator)
        {
            if (FindWebElement(locator).Selected == false)
            {
                FindWebElement(locator).Click();
            }
        }

        public void UntickCheckbox(string locator)
        {
            if (FindWebElement(locator).Selected)
            {
                FindWebElement(locator).Click();
            }
        }

        public void Logout()
        {
            Sleep(1);
            Click("user tab");
            Click("logout tab");
            // For edge
            Sleep(1);
        }

        //public void MouseHover(string locator)
        //{
        //    Actions action = new Actions(WebDriver.driver);
        //    action.MoveToElement(FindWebElement(locator)).Perform();
        //}
        public void OpenDataProfilesPage()
        {
            Click("administer tab");
            Click("data profiles tab");
        }
        public void OpenPanelsPage()
        {
            Click("administer tab");
            Click("create panel tab");
            
        }
        public void OpenCreateProfilePageFromGeneralPage()
        {
            Sleep(1);
            Click("global setting tab");
            Click("create profile tab");
        }
        public void OpenExecutionDashboardPage()
        {
            Click("execution dashboard tab");
        }
        public void OpenOverviewPage()
        {
            Click("overview tab");
        }
        public void OpenAddPageDialog()
        {
            Sleep(1);
            Click("global setting tab");
            Click("add page tab");
        }

        public void PerformDelete()
        {
            Sleep(1);
            Click("global setting tab");
            Click("delete tab");
            AcceptAlert();
        }

        public void DeleteAllPages()
        {
            Sleep(1);
            string xpath = string.Empty;
            string xpathNext = string.Empty;
            string locatorClass = string.Empty;

            int numTab = WebDriver.driver.FindElements(By.XPath("//div[@id='main-menu']/div/ul/li/a")).Count;
            int pageIndex = numTab - 2;
            while (pageIndex != 0)
            {
                for (int i = numTab - 2; i >= 1; i--)
                {
                    int numChildren = WebDriver.driver.FindElements(By.XPath("//div[@id='main-menu']/div/ul/li[" + pageIndex + "]/a//..//ul/li/a")).Count;
                    for (int j = 0; j <= numChildren; j++)
                    {
                        xpath = "//div[@id='main-menu']/div/ul/li[" + pageIndex + "]/a";

                        locatorClass = WebDriver.driver.FindElement(By.XPath(xpath)).GetAttribute("class").ToString();
                        while (locatorClass.Contains("haschild"))
                        {
                            Actions builder = new Actions(WebDriver.driver);
                            builder.MoveToElement(WebDriver.driver.FindElement(By.XPath(xpath))).Build().Perform();
                            xpathNext = "/following-sibling::ul/li/a";
                            xpath = xpath + xpathNext;
                            locatorClass = WebDriver.driver.FindElement(By.XPath(xpath)).GetAttribute("class").ToString();
                        }
                        string text = WebDriver.driver.FindElement(By.XPath(xpath)).Text;
                        if (text.Equals("Overview") || text.Equals("Execution Dashboard"))
                        {
                            break;
                        }
                        else
                        {
                            WebDriver.driver.FindElement(By.XPath(xpath)).Click();
                            PerformDelete();
                        }
                    }
                    pageIndex = pageIndex - 1;
                }
            }
        }

        public void Sleep(int second)
        {
            Thread.Sleep(second * 1000);
        }

        public void SelectItemByText(string locator, string value)
        {
            SelectElement selectcontrol = new SelectElement(FindWebElement(locator));
            selectcontrol.SelectByText(value);
        }

        /// <summary>
        /// Using Javascript for IE,Chrome
        /// </summary>
        public void ClickItemByJS(string control)
        {
            IWebElement webElement = FindWebElement(control);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)WebDriver.driver;
            executor.ExecuteScript("arguments[0].click();", webElement);
        }

        public void Click(string locator)
        {
            Sleep(1);
            if (TestData.browser == "chrome" || TestData.browser == "ie")
            {
                IWebElement webElement = FindWebElement(locator);
                IJavaScriptExecutor executor = (IJavaScriptExecutor)WebDriver.driver;
                executor.ExecuteScript("arguments[0].click();", webElement);
            }
            else
            {
                FindWebElement(locator).Click();
            }
        }

        public string GetUserName()
        {
            Sleep(1);
            return GetText("user tab");
        }

        public string GetRepository()
        {
            Sleep(1);
            return GetText("repository label");
        }

        public string GetSecondPageName()
        {
            Sleep(1);
            return GetText("second page tab");
        }

        public bool DoesElementPresent(string locator)
        {
            try
            {
                return FindWebElement(locator).Displayed;

            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool DoesDynamicElementPresent(string locator, string name)
        {
            try
            {
                return FindDynamicWebElement(locator, name).Displayed;

            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void CheckPageDisplays(string pageName)
        {
            bool exist = DoesDynamicElementPresent("random page tab", pageName);
            Assert.IsTrue(exist);
        }
    }
}
