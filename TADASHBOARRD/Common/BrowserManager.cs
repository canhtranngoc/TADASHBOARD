using System.Diagnostics;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;

namespace TADASHBOARRD.Common
{
    class BrowserManager
    {
        #region Methods

        /// <summary>
        /// Method to open the specific browser
        /// </summary>
        public static void OpenBrowser(string browsername)
        {
            switch (browsername.ToUpper())
            {
                case "FIREFOX":
                    if (TestData.runtype.ToUpper() == "LOCAL")
                    {
                        WebDriver.driver = new FirefoxDriver();
                        WebDriver.driver.Manage().Window.Maximize();
                    }
                    else if (TestData.runtype.ToUpper() == "GRID")
                    {
                        DesiredCapabilities capabilities = DesiredCapabilities.Firefox();
                        capabilities.SetCapability(CapabilityType.BrowserName, "firefox");
                        capabilities.SetCapability(CapabilityType.Version, TestData.firefoxVersion);
                        capabilities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
                        WebDriver.driver = new RemoteWebDriver(new Uri("http://192.168.190.158:4444/wd/hub/"), capabilities);
                        WebDriver.driver.Manage().Window.Maximize();
                    }
                    break;

                case "CHROME":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("--disable-extensions");
                    WebDriver.driver = new ChromeDriver(options);
                    WebDriver.driver.Manage().Window.Maximize();
                    break;
                case "IE":
                    WebDriver.driver = new InternetExplorerDriver();
                    WebDriver.driver.Manage().Window.Maximize();
                    break;
                case "EDGE":
                    WebDriver.driver = new EdgeDriver();
                    WebDriver.driver.Manage().Window.Maximize();
                    break;
                default:
                    WebDriver.driver = new FirefoxDriver();
                    WebDriver.driver.Manage().Window.Maximize();
                    break;
            }
        }

        /// <summary>
        /// Method to close the browser. If IE, kill process to close the browser
        /// </summary>
        public static void CloseBrowser()
        {
            WebDriver.driver.Manage().Cookies.DeleteAllCookies();
            WebDriver.driver.Quit();
            foreach (Process process in Process.GetProcessesByName("iexplore"))
            {
                process.Kill();
            }
        }

        #endregion
    }
}
