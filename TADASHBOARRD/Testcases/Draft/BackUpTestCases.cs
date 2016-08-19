using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TADASHBOARRD.Common;
using TADASHBOARRD.PageActions.GeneralPage;
using TADASHBOARRD.PageActions.LoginPage;
using TADASHBOARRD.PageActions.PanelsPage;
using TADASHBOARRD.PageActions.DataProfilesPage;


namespace TADASHBOARRD.Testcases.Draft
{
    class BackUpTestCases: BaseTest
    {
        private LoginPage loginPage;
        private GeneralPage generalPage;
        private PanelsPage panelsPage;
        private NewPanelDialog newPanelDialog;
        private NewPageDialog newPageDialog;
        private DataProfilesPage dataProfilesPage;
        private GeneralSettingsPage generalSettingsPage;
        private DisplayFieldsPage displayFieldsPage;

        public void DA_LOGIN_TC008_Verify_that_password_with_special_characters_is_working_correctly()
        {
            loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.specialUsername, TestData.specialCharactersPassword);
            generalPage = new GeneralPage();
            string actualUsername = generalPage.GetUserName();
            // VP: Verify that Dashboard Mainpage appears
            CheckTextDisplays(TestData.specialUsername, actualUsername);
            // Post-Condition
            generalPage.Logout();
        }
        public void DA_MP_TC012_Verify_that_user_is_able_to_add_additional_pages_besides_Overview_page_successfully()
        {
            loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            generalPage = new GeneralPage();
            generalPage.OpenAddPageDialog();
            newPageDialog = new NewPageDialog();
            string pageName = CommonActions.GetDateTime();
            newPageDialog.CreateNewPage(pageName, TestData.defaultParentPage, TestData.defaultNumberOfColumns, TestData.defaultDisplayAfter, TestData.statusNotPublic);
            string actualPageName = generalPage.GetSecondPageName();
            // VP: Check "Test" page is displayed besides "Overview" page
            CheckTextDisplays(pageName, actualPageName);
            // Post-Condition
            generalPage.DeleteAllPages();
            generalPage.Logout();
        }

        public void DA_MP_TC014_Verify_that_Public_pages_can_be_visible_and_accessed_by_all_users_of_working_repository()
        {
            loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            generalPage = new GeneralPage();
            generalPage.OpenAddPageDialog();
            newPageDialog = new NewPageDialog();
            string pageName = CommonActions.GetDateTime();
            newPageDialog.CreateNewPage(pageName, TestData.defaultParentPage, TestData.defaultNumberOfColumns, TestData.defaultDisplayAfter, TestData.statusPublic);
            generalPage.Logout();
            loginPage.Login(TestData.defaulRepository, TestData.anotherValidUsername, TestData.anotherValidPassword);
            // VP: Check newly added page is visibled
            generalPage.CheckPageDisplays(pageName);
            // Post-Condition
            generalPage.Logout();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            generalPage.DeleteAllPages();
            generalPage.Logout();
        }
        public void DA_PANEL_TC030_Verify_that_no_special_character_is_allowed_to_be_inputted_into_Display_Name_field()
        {
            loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            generalPage = new GeneralPage();
            // wait for Panel Page link displays
            Thread.Sleep(1000);
            generalPage.OpenPanelsPage();
            panelsPage = new PanelsPage();
            panelsPage.OpenNewPanelDialog();
            newPanelDialog = new NewPanelDialog();
            newPanelDialog.AddNewPanel(TestData.specialPanelName, TestData.panelSeries);
            string actualInvalidNameMessage = newPanelDialog.GetErrorMessage();
            // VP: Message "Invalid display name. The name can't contain high ASCII characters or any of following characters: /:*?<>|"#{[]{};" is displayed
            CheckTextDisplays(actualInvalidNameMessage, TestData.errorInvalidNamePanelPage);
        }

        

        public void DA_PANEL_TC037_Verify_that_Category_Series_and_Caption_field_are_enabled_and_disabled_correctly_corresponding_to_each_type_of_the_Chart_Type()
        {
            loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            generalPage = new GeneralPage();
            generalPage.DeleteAllPages();
            generalPage.OpenAddPageDialog();
            newPageDialog = new NewPageDialog();
            string pageName = CommonActions.GetDateTime();
            newPageDialog.CreateNewPage(pageName, TestData.blankParentPage, TestData.blankNumberOfColumns, TestData.blankDisplayAfter, TestData.statusNotPublic);
            generalPage.OpenNewPanelDialogFromChoosePanels();
            newPanelDialog = new NewPanelDialog();
            //Select 'Pie' Chart Type
            newPanelDialog.selectChartType(TestData.chartTypeArray[0]);
            // VP: Check that 'Category' and 'Caption' are disabled, 'Series' is enabled
            newPanelDialog.checkStatuses("Stacked Bar");
        }

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
            generalSettingsPage.CreateNewProfile(TestData.profileName, TestData.defaultItemType, TestData.defaultRelatedData, TestData.actionFinish);
            dataProfilesPage.OpenCreateProfilePageFromDataProfilesPage();
            generalSettingsPage.CreateNewProfile(TestData.profileName, TestData.defaultItemType, TestData.defaultRelatedData, TestData.actionFinish);
            string actualMessage = generalPage.GetTextPopup();
            generalSettingsPage.AcceptAlert();
            generalSettingsPage.OpenDataProfilesPage();
            // Post-Condition
            dataProfilesPage.DeleteProfile(TestData.profileName);
            generalPage.Logout();
            // VP: Check dialog message "Data Profile name already exists"
            CheckTextDisplays(TestData.errorMessageWhenCreateProfileWithExitingName, actualMessage);
        }
    }
}
