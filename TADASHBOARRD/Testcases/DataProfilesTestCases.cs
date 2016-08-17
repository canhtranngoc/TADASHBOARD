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
        private LoginPage loginPage;
        private GeneralPage generalPage;
        private DataProfilesPage dataProfilesPage;
        private GeneralSettingsPage generalSettingsPage;
        private DisplayFieldsPage displayFieldsPage;
        [TestMethod]
        public void DA_DP_TC069_Verify_that_user_is_unable_to_proceed_to_next_step_or_finish_creating_data_profile_if_Name_field_is_left_empty()
        {
            loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            generalPage = new GeneralPage();
            generalPage.OpenDataProfilesPage();
            dataProfilesPage = new DataProfilesPage();
            dataProfilesPage.OpenCreateProfilePageFromDataProfilesPage();
            generalSettingsPage = new GeneralSettingsPage();
            generalSettingsPage.ClickNextWithoutName();
            string actualMessage1 = generalPage.GetTextPopup();
            generalSettingsPage.AcceptAlert();
            generalSettingsPage.ClickFinishWithoutName();
            string actualMessage2 = generalPage.GetTextPopup();
            generalSettingsPage.AcceptAlert();
            // Post-Condition
            generalPage.Logout();
            // VP: Check dialog message "Please input profile name" appears
            CheckTextDisplays(TestData.errorMessageWhenCreateProfileWithoutName, actualMessage1);
            // VP: Check dialog message "Please input profile name" appears
            CheckTextDisplays(TestData.errorMessageWhenCreateProfileWithoutName, actualMessage2);
        }

        [TestMethod]
        public void DA_DP_TC071_Verify_that_Data_Profile_names_are_not_case_sensitive()
        {
            loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            generalPage = new GeneralPage();
            generalPage.OpenDataProfilesPage();
            dataProfilesPage = new DataProfilesPage();
            dataProfilesPage.OpenCreateProfilePageFromDataProfilesPage();
            // Pre-Condition: Create a Profile
            generalSettingsPage = new GeneralSettingsPage();
            generalSettingsPage.CreateNewProfile(TestData.profileName,TestData.defaultItemType,TestData.defaultRelatedData, TestData.actionFinish);
            dataProfilesPage.OpenCreateProfilePageFromDataProfilesPage();
            generalSettingsPage.CreateNewProfile(TestData.profileName, TestData.defaultItemType, TestData.defaultRelatedData, TestData.actionFinish);
            string actualMessage= generalPage.GetTextPopup();
            generalSettingsPage.AcceptAlert();
            generalSettingsPage.OpenDataProfilesPage();
            // Post-Condition
            dataProfilesPage.DeleteProfile(TestData.profileName);
            generalPage.Logout();
            // VP: Check dialog message "Data Profile name already exists"
            CheckTextDisplays(TestData.errorMessageWhenCreateProfileWithExitingName, actualMessage);
        }

        [TestMethod]
        public void DA_DP_TC072_Verify_that_all_data_profile_types_are_listed_under_Item_Type_dropped_down_menu()
        {
            loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            generalPage = new GeneralPage();
            generalPage.OpenDataProfilesPage();
            dataProfilesPage = new DataProfilesPage();
            dataProfilesPage.OpenCreateProfilePageFromDataProfilesPage();
            generalSettingsPage = new GeneralSettingsPage();
            // VP: Check all data profile types are listed under "Item Type" dropped down menu in create profile page
            generalSettingsPage.CheckItemTypeOptions();
            generalSettingsPage.CancelGeneralSettings();
            //Post-Condition
            dataProfilesPage.Logout();
        }

        [TestMethod]
        public void DA_DP_TC079_Verify_that_Check_All_Uncheck_All_Links_are_working_correctly()
        {
            loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            generalPage = new GeneralPage();
            generalPage.OpenDataProfilesPage();
            dataProfilesPage = new DataProfilesPage();
            dataProfilesPage.OpenCreateProfilePageFromDataProfilesPage();
            generalSettingsPage = new GeneralSettingsPage();
            generalSettingsPage.CreateNewProfile(TestData.profileName, TestData.defaultItemType, TestData.defaultRelatedData, TestData.actionNext);
            displayFieldsPage = new DisplayFieldsPage();
            displayFieldsPage.ClickCheckAllLink();
            // VP: Verify that all checkbox is checked
            Assert.IsTrue(displayFieldsPage.AreAllCheckboxChecked());
            displayFieldsPage.ClickUnCheckAllLink();
            // VP: Verify that all checkbox is unchecked
            Assert.IsTrue(displayFieldsPage.AreAllCheckboxUnChecked());

        }
    }
}
