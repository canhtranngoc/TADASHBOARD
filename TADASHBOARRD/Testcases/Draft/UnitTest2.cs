using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TADASHBOARRD.Common;
using TADASHBOARRD.PageActions.DataProfilesPage;
using TADASHBOARRD.PageActions.GeneralPage;
using TADASHBOARRD.PageActions.LoginPage;

namespace TADASHBOARRD.Testcases.Draft
{
    [TestClass]
    public class UnitTest2:BaseTest
    {
        private LoginPage loginPage;
        private GeneralPage generalPage;
        private DataProfilesPage dataProfilesPage;
        private GeneralSettingsPage generalSettingsPage;
        private DisplayFieldsPage displayFieldsPage;
        [TestMethod]
        public void CanhTest()
        {
            loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            generalPage = new GeneralPage();
            generalPage.OpenDataProfilesPage();
            //dataProfilesPage = new DataProfilesPage();
            //dataProfilesPage.OpenCreateProfilePageFromDataProfilesPage();
            dataProfilesPage = new DataProfilesPage();
            //generalSettingsPage = new GeneralSettingsPage();
            //generalSettingsPage.CreateNewProfile(TestData.profileName, TestData.defaultItemType, TestData.defaultRelatedData, TestData.actionFinish);
            //dataProfilesPage.DeleteProfile("123");
            dataProfilesPage.DeleteAllProfiles();
        }
    }
}
