using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TADASHBOARRD.Common;
using TADASHBOARRD.PageActions.DataProfilesPage;
using TADASHBOARRD.PageActions.GeneralPage;
using TADASHBOARRD.PageActions.LoginPage;

namespace TADASHBOARRD.Testcases
{
    [TestClass]
    public class DataProfilesTestCases : BaseTest
    {
        [TestMethod]
        public void DA_DP_TC069_Verify_that_user_is_unable_to_proceed_to_next_step_or_finish_creating_data_profile_if_Name_field_is_left_empty()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            GeneralPage generalPage = new GeneralPage();
            generalPage.OpenDataProfilesPage();
            DataProfilesPage dataProfilesPage = new DataProfilesPage();
            dataProfilesPage.OpenCreateProfilePageFromDataProfilesPage();
            GeneralSettingsPage generalSettingsPage = new GeneralSettingsPage();
            generalSettingsPage.ClickNextWithoutName();
            string actualMessage1 = generalPage.GetTextPopup();
            // VP: 
            CheckTextDisplays(TestData.errorMessageWhenCreateProfileWithoutName, actualMessage1);
            generalSettingsPage.AcceptAlert();
            generalSettingsPage.ClickFinishWithoutName();
            // VP: 
            string actualMessage2 = generalPage.GetTextPopup();
            CheckTextDisplays(TestData.errorMessageWhenCreateProfileWithoutName, actualMessage2);
            generalSettingsPage.AcceptAlert();
            generalPage.Logout();

        }

        [TestMethod]
        public void DA_DP_TC071_Verify_that_Data_Profile_names_are_not_case_sensitive()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            GeneralPage generalPage = new GeneralPage();
            generalPage.OpenDataProfilesPage();
            DataProfilesPage dataProfilesPage = new DataProfilesPage();
            dataProfilesPage.OpenCreateProfilePageFromDataProfilesPage();
            // Pre-Condition: Creata a Profile
            GeneralSettingsPage generalSettingsPage = new GeneralSettingsPage();
            generalSettingsPage.CreateNewProfile(TestData.profileName,"","");
            dataProfilesPage.OpenCreateProfilePageFromDataProfilesPage();
            generalSettingsPage.CreateNewProfile(TestData.profileName, "", "");
            // VP:
            string actualMessage= generalPage.GetTextPopup();
            CheckTextDisplays(TestData.errorMessageWhenCreateProfileWithExitingName,actualMessage);
            generalSettingsPage.AcceptAlert();
            generalPage.Logout();
        }
    }
}
