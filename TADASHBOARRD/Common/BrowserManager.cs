using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace TADASHBOARRD.Common
{
    class BrowserManager
    {
        public static void OpenBrowser(string browsername)
        {
            switch (browsername.ToUpper())
            {
                case "FIREFOX":
                    Driver.driver = new FirefoxDriver();
                    Driver.driver.Manage().Window.Maximize();
                    break;
                case "CHROME":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("--disable-extensions");
                    Driver.driver = new ChromeDriver(options);
                    Driver.driver.Manage().Window.Maximize();
                    break;
                case "IE":
                    Driver.driver = new InternetExplorerDriver();
                    Driver.driver.Manage().Window.Maximize();
                    break;
                case "EDGE":
                    Driver.driver = new EdgeDriver();
                    Driver.driver.Manage().Window.Maximize();
                    break;
                default:
                    Driver.driver = new FirefoxDriver();
                    Driver.driver.Manage().Window.Maximize();
                    break;
            }
        }
        public static void CloseBrowser()
        {
            Driver.driver.Manage().Cookies.DeleteAllCookies();
            Driver.driver.Quit();
            foreach (Process process in Process.GetProcessesByName("iexplore"))
            {
                process.Kill();
            }

        }
    }
}
