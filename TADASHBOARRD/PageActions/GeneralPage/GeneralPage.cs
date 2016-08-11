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
            Thread.Sleep(1000);
            WebDriver.driver.SwitchTo().Alert().Accept();
        }

        public string GetTextPopup()
        {
            Thread.Sleep(1000);
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
            Console.WriteLine(control[1]);
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

        public IWebElement FindDynamicWebElement(string name, string value)
        {
            string[] control = GetControlValue(name);
            string dynamicControl = string.Format(control[1].ToString(), value);
            return WebDriver.driver.FindElement(By.XPath(dynamicControl));
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
            Thread.Sleep(1000);
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
            Thread.Sleep(1000);
        }

        public void MouseHover(string locator)
        {
            Actions action = new Actions(WebDriver.driver);
            action.MoveToElement(FindWebElement(locator)).Perform();
        }
        public void OpenDataProfilesPage()
        {

        }
        public void OpenPanelsPage()
        {
            MouseHover("administer tab");
            Click("create panel tab");
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
            Thread.Sleep(1000);
            MouseHover("global setting tab");
            Click("add page tab");

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
            Thread.Sleep(1000);
            return GetText("user tab");
        }

       public string GetRepository()
       {
           Thread.Sleep(1000);
           return GetText("repository label");
       }

        public void Delete1()
        {
            Delete();
        }

        public void ClickOnDynamicElement(string control, string value)
        {
            FindDynamicWebElement(control, value).Click();
        }

        public string A(IWebElement b)
        {
            return b.ToString();
        }

        public void Delete()
        {
            string xpath = string.Empty;
            string next = string.Empty;
            string locatorClass = string.Empty;
          //  int numTab = WebDriver.driver.FindElements(By.XPath("//div[@id='main-menu']/div/ul/li/a")).Count;
            int numTab = WebDriver.driver.FindElements(By.XPath("//div[@id='main-menu']/div/ul/li/a")).Count;
            int pageIndex = numTab - 3;
            Console.WriteLine(pageIndex);
            while (pageIndex != 1)
            {
                for (int i = numTab - 4; i >= 1; i--)
                {
                    int numChildren = WebDriver.driver.FindElements(By.XPath("//div[@id='main-menu']/div/ul/li[" + pageIndex + "]/a/..//ul/li/a")).Count;
                    Console.WriteLine(numChildren);
                    for (int j = 0; j <= numChildren; j++)
                    {
                        //xpath = "//div[@id='main-menu']/div/ul/li[" + pageIndex + "]/a";
                        //xpath = FindDynamicWebElement("path child page",pageIndex.ToString()).ToString();
                        xpath = FindWebElement("path child page").ToString();
                        Console.WriteLine(xpath);
                        //locatorClass = WebDriver.driver.FindElement(By.XPath(xpath)).GetAttribute("class").ToString();
                        locatorClass = WebDriver.driver.FindElement(By.XPath(xpath)).GetAttribute("class").ToString();

                        Console.WriteLine(locatorClass);
                        while (locatorClass.Equals("haschild"))
                        {
                            Actions builder = new Actions(WebDriver.driver);
                            builder.MoveToElement(WebDriver.driver.FindElement(By.XPath(xpath))).Build().Perform();
                            next = "/following-sibling::ul/li/a";
                            xpath = xpath + next;
                            Console.WriteLine(xpath);
                            locatorClass = WebDriver.driver.FindElement(By.XPath(xpath)).GetAttribute("class").ToString();
                            Console.WriteLine(locatorClass);
                        }
                        WebDriver.driver.FindElement(By.XPath(xpath)).Click();
                       // FindDynamicWebElement("path child page", pageIndex.ToString()).Click();

                        // ClickOnDynamicElement("path child page", pageIndex.ToString());

                        WebDriver.driver.FindElement(By.XPath("//li[@class='mn-setting']/a")).Click();
                        WebDriver.driver.FindElement(By.XPath("//a[.='Delete']")).Click();
                        WebDriver.driver.SwitchTo().Alert().Accept();
                        Thread.Sleep(1000);
                    }
                    pageIndex = pageIndex - 1;
                    //Console.WriteLine(pageIndex);
                }

            }
        }
    

    }
}
