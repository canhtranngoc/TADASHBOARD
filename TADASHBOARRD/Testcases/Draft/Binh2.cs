using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TADASHBOARRD.PageActions.LoginPage;
using TADASHBOARRD.PageActions.GeneralPage;
using TADASHBOARRD.Common;

namespace TADASHBOARRD.Testcases.Draft
{
    [TestClass]
    public class Binh2:BaseTest
    {   
        public void testbinh()
        {
            NavigateTADashboard();
            LoginPage loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            GeneralPage generalPage = new GeneralPage();
            generalPage.goToPage("Overview/binh");
            generalPage.PerformDelete();
            
            string c = "binh";
            string actualMessage = generalPage.GetTextPopup();
            Console.WriteLine(actualMessage);
            string a = string.Format("Cannot delete page '{0}' since it has child page(s).",c);
            CheckTextDisplays(a, actualMessage);
            generalPage.AcceptAlert();
            generalPage.DeleteAllPages();
        }
    }
}
