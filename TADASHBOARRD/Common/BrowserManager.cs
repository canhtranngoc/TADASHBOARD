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
                    default:
                        WebDriver.driver = new FirefoxDriver();
                        WebDriver.driver.Manage().Window.Maximize();
                        break;
                }
            }
            
        }
        public static void CloseBrowser()
        {
            WebDriver.driver.Manage().Cookies.DeleteAllCookies();
            WebDriver.driver.Quit();
            foreach (Process process in Process.GetProcessesByName("iexplore"))
            {
                process.Kill();
            }

        }
    }
}
