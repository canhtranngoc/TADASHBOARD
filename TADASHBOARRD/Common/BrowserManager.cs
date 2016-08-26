using System.Diagnostics;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using Fenton.Selenium.SuperDriver;
using System.Collections.Generic;
using System.Linq;

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
            if (TestData.runtype.ToUpper() == "LOCAL")
            {
                switch (browsername.ToUpper())
                {
                    case "FIREFOX":
                        WebDriver.driver = new FirefoxDriver();
                        WebDriver.driver.Manage().Window.Maximize();
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
                    case "SUPERWEBDRIVER":
                        WebDriver.driver = GetDriver(Browser.SuperWebDriver);
                        WebDriver.driver.Manage().Window.Maximize();
                        break;
                    default:
                        WebDriver.driver = new FirefoxDriver();
                        WebDriver.driver.Manage().Window.Maximize();
                        break;
                }
            }
            else if (TestData.runtype.ToUpper() == "GRID")
            {
                switch (browsername.ToUpper())
                {
                    case "FIREFOX":
                        DesiredCapabilities capabilities = DesiredCapabilities.Firefox();
                        capabilities.SetCapability(CapabilityType.BrowserName, "firefox");
                        capabilities.SetCapability(CapabilityType.Version, TestData.firefoxVersion);
                        capabilities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
                        WebDriver.driver = new RemoteWebDriver(new Uri(TestData.hub), capabilities);
                        WebDriver.driver.Manage().Window.Maximize();
                        break;
                    case "CHROME":
                        WebDriver.driver = new RemoteWebDriver(new Uri(TestData.hub), DesiredCapabilities.Chrome());
                        WebDriver.driver.Manage().Window.Maximize();
                        break;
                    case "IE":
                        WebDriver.driver = new RemoteWebDriver(new Uri(TestData.hub), DesiredCapabilities.InternetExplorer());
                        WebDriver.driver.Manage().Window.Maximize();
                        break;
                    case "EDGE":
                        WebDriver.driver = new RemoteWebDriver(new Uri(TestData.hub), DesiredCapabilities.Edge());
                        WebDriver.driver.Manage().Window.Maximize();
                        break;
                    case "SUPERWEBDRIVER":
                        break;
                    default:
                        WebDriver.driver = new RemoteWebDriver(new Uri(TestData.hub), DesiredCapabilities.Chrome());
                        WebDriver.driver.Manage().Window.Maximize();
                        break;
                }
            }

           
        }

        /// <summary>
        /// 
        /// </summary>
        public static IWebDriver GetDriver(Browser browser)
        {
            IWebDriver driver = null;
            switch (browser)
            {
                case Browser.SuperWebDriver:
                    driver = new SuperWebDriver(GetDriverSuite());
                    break;
                case Browser.Chrome:
                    driver = new ChromeDriver();
                    break;
                case Browser.InternetExplorer:
                    driver = new InternetExplorerDriver(new InternetExplorerOptions() { IntroduceInstabilityByIgnoringProtectedModeSettings = true });
                    break;
                default:
                    driver = new FirefoxDriver();
                    break;
            }

            return driver;
        }

        public static IList<IWebDriver> GetDriverSuite()
        {
            // Allow some degree of parallelism when creating drivers, which can be slow
            IList<IWebDriver> drivers = new List<Func<IWebDriver>>
            {
                () => { return GetDriver(Browser.Chrome); },
                () => { return GetDriver(Browser.Firefox); },
                () => { return GetDriver(Browser.InternetExplorer); },
            }.AsParallel().Select(d => d()).ToList();

            return drivers;
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
