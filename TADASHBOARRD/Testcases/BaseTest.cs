using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TADASHBOARRD.Common;

namespace TADASHBOARRD.Testcases
{
    [TestClass]
    public class BaseTest : CommonActions
    {
        public TestContext TestContext { get; set; }
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
        public void TestInitializeMothod()
        {
            NavigateTADashboard();
        }

        [TestCleanup]
        public void TestCleanupMothod()
        {
        WebDriver.driver.Manage().Cookies.DeleteAllCookies();
        }

    }
}
