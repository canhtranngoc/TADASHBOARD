using Fenton.Selenium.SuperDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TADASHBOARRD.Testcases.Test
{
    class RemoteDriver1
    {
        public static IWebDriver GetDriverGrid(Browser browser)
        {
            IWebDriver driver = GetCapabilityFor(browser);
            driver.Manage().Window.Maximize();
        //    driver.Manage().Cookies.DeleteAllCookies();
            return driver;
        }

        public static IWebDriver GetCapabilityFor(Browser browser)
        {
            var uri = new Uri(ConfigurationManager.AppSettings["hub"]);
            IWebDriver driver;
            switch (browser)
            {
                case Browser.SuperWebDriver:
                    driver = new SuperWebDriver(GetDriverSuite());
                    break;
                case Browser.Chrome:
                    driver = new RemoteWebDriver(uri, DesiredCapabilities.Chrome());
                    break;
                case Browser.InternetExplorer:
                    driver = new RemoteWebDriver(uri, DesiredCapabilities.InternetExplorer());
                    break;
                case Browser.MicrosoftEdge:
                    driver = new RemoteWebDriver(uri, DesiredCapabilities.Edge());
                    break;
                default:
                    driver = new RemoteWebDriver(uri, DesiredCapabilities.Firefox());
                    break;
            }
            return driver;
        }

        public static IList<IWebDriver> GetDriverSuite()
        {
            // Allow some degree of parallelism when creating drivers, which can be slow
            IList<IWebDriver> drivers = new List<Func<IWebDriver>>
            {
                () =>  { return GetCapabilityFor(Browser.Chrome); },
                () =>  { return GetCapabilityFor(Browser.Firefox); },
                () => { return GetCapabilityFor(Browser.InternetExplorer); },
                () => { return GetCapabilityFor(Browser.MicrosoftEdge); },
            }.AsParallel().Select(d => d()).ToList();

            return drivers;
        }
    }
}
