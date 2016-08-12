using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TADASHBOARRD.Common;

namespace TADASHBOARRD.Testcases
{
    [TestClass]
    public class BaseTest : CommonActions
    {
        [AssemblyInitialize]
        public static void AssemblyInitializeMeThod(TestContext testContext)
        {
            BrowserManager.OpenBrowser(TestData.browser);
        }
        [AssemblyCleanup]
        public static void AssemblyCleapUpMethod()
        {
           BrowserManager.CloseBrowser();
        }

        [TestInitialize]
        public void TestInit()
        {
            NavigateTADashboard();
        }
        [TestCleanup]
        public void CleanUp()
        {
            WebDriver.driver.Manage().Cookies.DeleteAllCookies();
        }

    }
}
