using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TADASHBOARRD.Common;
using System.Diagnostics;
using System.IO;
using System.Web.Script.Serialization;
using System.Reflection;


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
            Thread.Sleep(1000);
            WebDriver.driver.SwitchTo().Alert().Accept();
        }

        public string GetTextPopup()
        {
            Thread.Sleep(1000);
            return WebDriver.driver.SwitchTo().Alert().Text;
        }
        private static string GetClassCaller(int level = 3)
        {
            var m = new StackTrace().GetFrame(level).GetMethod();
            string className = m.DeclaringType.Name;
            //string methodName = m.Name;
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
            string path = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
            path = path.Replace("\\bin\\Debug", "");
            string content = File.ReadAllText(path + "\\Interfaces\\" + page + ".json");
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

        }
        public void OpenDataProfilesPage()
        {

        }
        public void OpenPanelsPage()
        {

        }
        public void OpenCreateProfilePageFromGeneralPage()
        {

        }
        public void OpenExecutionDashboardPage()
        {

        }
        public void OpenOverviewPage()
        {

        }
        public void OpenNewPageDialog()
        {

        }
        public void OpenNewPanelDialogFromGeneralPage()
        {

        }
    }
}
