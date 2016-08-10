using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TADASHBOARRD.Common;

namespace TADASHBOARRD.Testcases
{
    [TestClass]
    public class BaseTest
    {
        [AssemblyInitialize]
        public static void AssemblyInitializeMeThod(TestContext testContext)
        {
            BrowserManager.OpenBrowser("firefox");
        }
        [AssemblyCleanup]
        public static void AssemblyCleapUpMethod()
        {
            BrowserManager.CloseBrowser();
        }
        [TestCleanup]
        public void CleanUp()
        {
            Driver.driver.Manage().Cookies.DeleteAllCookies();
        }

    }
}
