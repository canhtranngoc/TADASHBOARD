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
        ///<summary>
        ///
        ///</summary>
        public void WaitForElementLoad(By locator, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                WebDriverWait wait = new WebDriverWait(WebDriver.driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
        }

        ///<summary>
        ///
        ///</summary>
        public void WaitForAlert(IWebDriver driver)
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

        ///<summary>
        ///
        ///</summary>
        public void AcceptAlert()
        {
            WaitForAlert(WebDriver.driver);
            WebDriver.driver.SwitchTo().Alert().Accept();
            Sleep(1);
            //waitForAlert(WebDriver.driver);
        }

        ///<summary>
        ///
        ///</summary>
        public string GetTextPopup()
        {
            WaitForAlert(WebDriver.driver);
            return WebDriver.driver.SwitchTo().Alert().Text;

        }

        ///<summary>
        ///
        ///</summary>
        public string GetText(string locator)
        {
            return FindWebElement(locator).Text;
        }

        ///<summary>
        ///
        ///</summary>
        public string GetTextDynamicElement(string locator, string value)
        {
            return FindDynamicWebElement(locator, value).Text;
        }

        ///<summary>
        ///
        ///</summary>
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

        ///<summary>
        ///
        ///</summary>
        public string[] GetControlValue(string nameControl)
        {
            string page = GetClassCaller();
            //string page = "GeneralPage";

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
                case "EditPageDialog":
                case "PanelConfigurationDialog":
                    content = File.ReadAllText(path + @"\Interfaces\GeneralPage\" + page + ".json");
                    break;
                case "PanelsPage":
                case "NewPanelDialog":
                    content = File.ReadAllText(path + @"\Interfaces\PanelsPage\" + page + ".json");
                    break;
                case "DataProfilesPage":
                case "GeneralSettingsPage":
                case "DisplayFieldsPage":
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

        ///<summary>
        ///
        ///</summary>
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

        ///<summary>
        ///
        ///</summary>
        public void ClickOnDynamicElement(string locator, string value)
        {
            FindDynamicWebElement(locator, value).Click();
        }

        ///<summary>
        ///
        ///</summary>
        public IWebElement FindDynamicWebElement(string name, string value)
        {
            string[] control = GetControlValue(name);
            string dynamicControl = string.Format(control[1].ToString(), value);
            return WebDriver.driver.FindElement(By.XPath(dynamicControl));
        }

        ///<summary>
        ///
        ///</summary>
        public void EnterValue(string locator, string value)
        {
            FindWebElement(locator).Clear();
            FindWebElement(locator).SendKeys(value);
        }

        ///<summary>
        ///
        ///</summary>
        public void EnterValueDropdownList(string locator, string value)
        {
            FindWebElement(locator).SendKeys(value);
        }

        ///<summary>
        ///
        ///</summary>
        public void TickCheckbox(string locator)
        {
            if (FindWebElement(locator).Selected == false)
            {
                FindWebElement(locator).Click();
            }
        }

        ///<summary>
        ///
        ///</summary>
        public void UntickCheckbox(string locator)
        {
            if (FindWebElement(locator).Selected)
            {
                FindWebElement(locator).Click();
            }
        }

        ///<summary>
        ///
        ///</summary>
        public void Logout()
        {
            Sleep(1);
            Click("user tab");
            Click("logout tab");
            // For edge
            Sleep(1);
        }

        ///<summary>
        ///
        ///</summary>
        public void OpenDataProfilesPage()
        {
            Click("administer tab");
            Click("data profiles tab");
        }

        ///<summary>
        ///
        ///</summary>
        public void OpenPanelsPage()
        {
            Click("administer tab");
            Click("panels tab");

        }

        ///<summary>
        ///
        ///</summary>
        public void OpenPanelsFromGeneralPage()
        {
            Click("global setting tab");
            Click("create panel tab");
        }

        ///<summary>
        ///
        ///</summary>
        public void OpenNewPanelDialogFromGlobalSetting()
        {
            Click("global setting tab");
            Click("create panel tab");
        }

        ///<summary>
        ///
        ///</summary>
        public void OpenNewPanelDialogFromChoosePanels()
        {
            Click("choose panels button");
            Click("create new panel button");
        }

        public void OpenRandomChartPanelInstance()
        {
            Click("choose panels button");
            Sleep(1);
            int rowCount = WebDriver.driver.FindElements(By.XPath("//div[@class='ptit pchart']/../table//tr")).Count;
            int randomRow = new Random().Next(1, rowCount);
            Console.WriteLine(randomRow);
            int colunmCount = WebDriver.driver.FindElements(By.XPath("//div[@class='ptit pchart']/../table//tr[" + randomRow + "]/td")).Count;
            int randomColumn = new Random().Next(1, colunmCount);
            Console.WriteLine(randomColumn);
            string a = string.Format("//div[@class='ptit pchart']/../table//tr[{0}]/td[{1}]//a", randomRow, randomColumn);
            IWebElement randomChartPanelInstance = WebDriver.driver.FindElement(By.XPath(a));
            randomChartPanelInstance.Click();
        }

        ///<summary>
        ///
        ///</summary>
        public void OpenCreateProfilePageFromGeneralPage()
        {
            Sleep(1);
            Click("global setting tab");
            Click("create profile tab");
        }

        ///<summary>
        ///
        ///</summary>
        public void OpenExecutionDashboardPage()
        {
            Click("execution dashboard tab");
        }
        public void OpenOverviewPage()
        {
            Click("overview tab");
        }

        ///<summary>
        ///
        ///</summary>
        public void OpenAddPageDialog()
        {
            Sleep(1);
            Click("global setting tab");
            Click("add page tab");
        }

        ///<summary>
        ///
        ///</summary>
        public void OpenEditPageDialog()
        {
            Sleep(1);
            Click("global setting tab");
            Click("edit page tab");
        }

        ///<summary>
        ///
        ///</summary>
        public void PerformDelete()
        {
            Sleep(1);
            Click("global setting tab");
            Click("delete tab");
            AcceptAlert();
        }

        ///<summary>
        ///
        ///</summary>
        public void DeleteAllPages()
        {
            Sleep(1);
            string xpath = string.Empty;
            string xpathNext = string.Empty;
            string locatorClass = string.Empty;
            int numTab = WebDriver.driver.FindElements(By.XPath("//div[@id='main-menu']/div/ul/li/a")).Count;
            Console.WriteLine(numTab);
            int pageIndex = numTab - 2;
            Console.WriteLine(pageIndex);
            while (pageIndex != 0)
            {
                for (int i = numTab - 2; i >= 1; i--)
                {
                    int numChildren = WebDriver.driver.FindElements(By.XPath("//div[@id='main-menu']/div/ul/li[" + pageIndex + "]/a//..//ul/li/a")).Count;
                    Console.WriteLine(numChildren);
                    for (int j = 0; j <= numChildren; j++)
                    {
                        xpath = "//div[@id='main-menu']/div/ul/li[" + pageIndex + "]/a";
                        Console.WriteLine(xpath);
                        locatorClass = WebDriver.driver.FindElement(By.XPath(xpath)).GetAttribute("class").ToString();
                        Console.WriteLine(locatorClass);
                        while (locatorClass.Contains("haschild"))
                        {
                            if (TestData.browser == "chrome" || TestData.browser == "ie")
                            {
                                ClickItemXpathByJS(xpath);
                            }
                            else
                            {
                                Actions builder = new Actions(WebDriver.driver);
                                builder.MoveToElement(WebDriver.driver.FindElement(By.XPath(xpath))).Build().Perform();
                            }
                            xpathNext = "/following-sibling::ul/li/a";
                            Console.WriteLine(xpathNext);
                            xpath = xpath + xpathNext;
                            Console.WriteLine(xpath);
                            locatorClass = WebDriver.driver.FindElement(By.XPath(xpath)).GetAttribute("class").ToString();
                            Console.WriteLine(locatorClass);
                        }
                        string text = WebDriver.driver.FindElement(By.XPath(xpath)).Text;
                        Console.WriteLine(text);
                        if (text.Equals("Overview") || text.Equals("Execution Dashboard"))
                        {
                            break;
                        }
                        else
                        {
                            if (TestData.browser == "chrome" || TestData.browser == "ie")
                            {
                                ClickItemXpathByJS(xpath);
                            }
                            else
                            {
                                ClickItemXpath(xpath);
                            }
                            PerformDelete();
                        }
                    }
                    pageIndex = pageIndex - 1;
                    Console.WriteLine(pageIndex);
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        public void goToPage(string path)
        {
            Sleep(1);
            string xpathNext = string.Empty;
            if (!(path.Contains("/")))
            {
                string xpath = string.Format("//a[.='{0}']", path);
                Console.WriteLine(xpath);
                Sleep(1);
                if (TestData.browser == "chrome" || TestData.browser == "ie")
                {
                    ClickItemXpathByJS(xpath);
                }
                else
                {
                    ClickItemXpath(xpath);
                }
            }
            else
            {
                string[] element = path.Split('/');
                string xpath = string.Format("//a[.='{0}']", element[0]);
                for (int i = 1; i < element.Length; i++)
                {
                    if (TestData.browser == "chrome" || TestData.browser == "ie")
                    {
                        ClickItemXpathByJS(xpath);
                    }
                    else
                    {
                        Actions builder = new Actions(WebDriver.driver);
                        builder.MoveToElement(WebDriver.driver.FindElement(By.XPath(xpath))).Build().Perform();
                    }
                    xpathNext = string.Format("/following-sibling::ul/li/a[.='{0}']", element[i]);
                    xpath = xpath + xpathNext;
                }
                if (TestData.browser == "chrome" || TestData.browser == "ie")
                {
                    ClickItemXpathByJS(xpath);
                }
                else
                {
                    ClickItemXpath(xpath);
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        public void Sleep(int second)
        {
            Thread.Sleep(second * 1000);
        }

        ///<summary>
        ///
        ///</summary>
        public void SelectItemByText(string locator, string value)
        {
            SelectElement selectcontrol = new SelectElement(FindWebElement(locator));
            selectcontrol.SelectByText(value);
        }

        /// <summary>
        /// 
        /// </summary>
        public void ClickItemXpathByJS(string locator)
        {
            IWebElement webElement = WebDriver.driver.FindElement(By.XPath(locator));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)WebDriver.driver;
            executor.ExecuteScript("arguments[0].click();", webElement);
        }

        ///<summary>
        ///
        ///</summar
        public void ClickItemXpath(string locator)
        {
            WebDriver.driver.FindElement(By.XPath(locator)).Click();
        }

        ///<summary>
        ///
        ///</summary>
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

        ///<summary>
        ///
        ///</summary>
        public string GetUserName()
        {
            Sleep(1);
            return GetText("user tab");
        }

        ///<summary>
        ///
        ///</summary>
        public string GetRepository()
        {
            Sleep(1);
            return GetText("repository label");
        }

        ///<summary>
        ///
        ///</summary>
        public string GetSecondPageName()
        {
            Sleep(1);
            return GetText("second page tab");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetPageNameOfPageOpened()
        {
            string titlename = WebDriver.driver.Title;
            titlename = titlename.Replace("TestArchitect ™ - ","");
            return titlename;
        }
        ///<summary>
        ///
        ///</summary>
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

        ///<summary>
        ///
        ///</summary>
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

        ///<summary>
        ///
        ///</summary>
        public void CheckPageDisplays(string pageName)
        {
            bool exist = DoesDynamicElementPresent("random page tab", pageName);
            Assert.IsTrue(exist);
        }

        ///<summary>
        ///
        ///</summary>
        public int CountComboboxChildren(string locator)
        {
            return WebDriver.driver.FindElements(By.XPath(locator)).Count;
        }

        ///<summary>
        ///
        ///</summary>
        public string GetSelectedValueInComboBox(string locator)
        {
            SelectElement selectedValue = new SelectElement(FindWebElement(locator));
            string wantedText = selectedValue.SelectedOption.Text;
            return wantedText;
        }

        ///<summary>
        ///Check message informs that user cannot delete page that has children.
        ///</summary>
        public void CheckDynamicTextDisplays(string dynamicExpectedText, string actualText)
        {
            string expectedMessage = string.Format("Can't delete page \"{0}\" since it has children page", dynamicExpectedText);
            Assert.AreEqual(expectedMessage, actualText);
        }
    }
}


