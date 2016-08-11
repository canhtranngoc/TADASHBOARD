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

namespace TADASHBOARRD.PageActions.GeneralPage
{
   public class GeneralPage:CommonActions
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
            Sleep(1);
            WebDriver.driver.SwitchTo().Alert().Accept();
        }

        public string GetTextPopup()
        {
            Sleep(1);
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
                case "PanelPage":
                    content = File.ReadAllText(path + @"\Interfaces\PanelPage\" + page + ".json");
                    break;
                case "DataProfilesPage":
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

        public IWebElement FindWebElement(string name)
        {
            string[] control = GetControlValue(name);
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

        public void Click(string locator)
        {
            FindWebElement(locator).Click();
        }

        public void EnterValue(string locator, string value)
        {
            FindWebElement(locator).Clear();
            FindWebElement(locator).SendKeys(value);
        }
        public void Logout()
        {
            Sleep(1);
            if (TestData.browser == "chrome" || TestData.browser == "ie")
            {
                ClickItemByJS("user tab");
                ClickItemByJS("logout tab");
            }
            else
            {
                MouseHover("user tab");
                Click("logout tab");
            }
            // For edge
            Sleep(1);
        }

        public void MouseHover(string locator)
        {
            Actions action = new Actions(WebDriver.driver);
            action.MoveToElement(FindWebElement(locator)).Perform();
        }
        public void OpenDataProfilesPage()
        {
            MouseHover("administer tab");
            Click("create profile tab");
        }
        public void OpenPanelsPage()
        {
            MouseHover("administer tab");
            Click("create panel tab");
        }
        public void OpenCreateProfilePageFromGeneralPage()
        {
            Sleep(1);
            MouseHover("global setting tab");
            Click("create profile tab");
        }
        public void OpenExecutionDashboardPage()
        {

        }
        public void OpenOverviewPage()
        {

        }
        public void OpenNewPanelDialogFromGeneralPage()
        {
            Sleep(1);
            MouseHover("global setting tab");
            Click("add page tab");
        }
        public void DeletePage()
        {
            Sleep(1);
            MouseHover("global setting tab");
            Click("delete tab");
            ConfirmPopup();
        }
        public void DeletePages()
        {

        }
        public void Sleep(int second)
        {
            Thread.Sleep(second*1000);
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
        public void ClickItem(string locator)
        {
            FindWebElement(locator).Click();
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

    }
}
