using System.Configuration;

namespace TADASHBOARRD.Common
{
    public class TestData : CommonActions
    {
        public static string browser = ConfigurationManager.AppSettings["browser"];
        public static string dashBoardURL = ConfigurationManager.AppSettings["url"];
        public static string validUsername = "administrator";
        public static string validPassword = "";
        public static string defaulRepository = "SampleRepository";
        public static string testRepository = "TestRepository";
        public static string invalidUsername = "abc";
        public static string invalidPassword = "abc";
        public static string errorLoginMessage = "Username or password is invalid";
        public static string testUsername = "test";
        public static string testUppercasePassword = "TEST";
        public static string testLowercasePassword = "test";
        public static string uppercaseUsername = "UPPERCASEUSERNAME";
        public static string lowercasePassword = "uppercaseusername";
        public static string lowercaseUsername = "uppercaseusername";
        public static string specialUsername = "specialCharsPassword";
        public static string specialCharactersPassword = "`!@^&*(+_=[{;'\",./<?";
        public static string specialCharactersUsername = "`~!@$^&()',.";
        public static string specialPassword = "specialCharsUser";
        public static string blankUsername = "";
        public static string blankPassword = "";
        public static string errorBlankUsernameLoginMessage = "Please enter username";
        public static string addPageName = "test123";
        public static string panelName = "test" + GetDateTime();
        //public static string pageName = CommonActions.GetDateTime();
        public static string defaultParentPage = "";
        public static string defaultNumberOfColumns = "";
        public static string defaultDisplayAfter = "";
        public static string statusNotPublic = "";
        public static string statusPublic = "public";
        public static string newPageName = "Test 1";
        public static string newNumberOfColumns = "3";
        public static string anotherValidUsername = "dieu.nguyen";
        public static string anotherValidPassword = "123";
        public static string errorMessageWhenCreateProfileWithoutName = "Please input profile name";
        public static string errorMessageWhenCreateProfileWithExitingName = "Data Profile name already exists";
        public static string profileName = "test" + GetDateTime();
        public static string defaultItemType = "";
        public static string defaultRelatedData = "";
        public static string duplicatedPanelName = "Duplicated panel"+ GetDateTime();
        public static string specialPanelName = "Logigear#$%";
        public static string panelSeries = "Name";
        public static string errorInvalidNamePanelPage = "Invalid display name. The name can't contain high ASCII characters or any of following characters: /:*?<>|\"#{[]{};";
        public static string errorDuplicatedNamePanelPage = "Duplicated panel already exists. Please enter a different name.";
        public static string errorMessageWhenEnterOutOfRule = "Panel height must be greater than or equal to 300 and less than or equal to 800.";
        public static string errorMessageWhenEnterCharacter = "Panel height must be an integer number";
        public static string errorInvalidNamePanelPage = " Invalid display name. The name can't contain high ASCII characters or any of following characters: /:*?<>|\"#{[]{};";
        public static string errorDuplicatedNamePanelPage = duplicatedPanelName + " already exists. Please enter a different name.";
        public static string [] chartTypeArray = {"Pie", "Single Bar", "Stacked Bar", "Group Bar", "Line"};
        public static string [] itemTypeArray = {"Test Modules", "Test Cases", "Test Objectives", "Data Sets", "Actions", "Interface Entities", "Test Results", "Test Case Results", "Test Suites", "Bugs" };
        public static string actionFinish = "finish";
        public static string actionNext = "next";
    }
}
