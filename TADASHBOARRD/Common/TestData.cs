using System.Configuration;

namespace TADASHBOARRD.Common
{
    public class TestData : CommonActions
    {
        public static string runtype = ConfigurationManager.AppSettings["run type"];
        public static string browser = ConfigurationManager.AppSettings["browser"];
        public static string dashBoardURL = ConfigurationManager.AppSettings["url"];
        public static string firefoxVersion = ConfigurationManager.AppSettings["firefox version"];
        public static string firefoxPlatform = ConfigurationManager.AppSettings["firefox platform"];
        public static string validUsername = "administrator";
        public static string validPassword = "";
        public static string defaulRepository = "SampleRepository";
        public static string invalidUsername = "abc";
        public static string invalidPassword = "abc";
        public static string errorLoginMessage = "Username or password is invalid";
        public static string testRepository = "TestRepository";    
        public static string testUsername = "test";
        public static string testUppercasePassword = "TEST";
        public static string testLowercasePassword = "test";
        public static string overviewPage = "Overview";
        public static string defaultParentPage = "";
        public static string defaultNumberOfColumns = "";
        public static string defaultDisplayAfter = "";
        public static string statusNotPublic = "";
        public static string statusPublic = "public";
        public static string profileName = "test" + GetDateTime();
        public static string defaultItemType = "";
        public static string defaultRelatedData = "";
        public static string duplicatedPanelName = "Duplicated panel" + GetDateTime();
        public static string panelSeries = "Name";
        public static string numberLessThan300 = "299";
        public static string numberMoreThan800 = "801";
        public static string decimalNumber = "3.1";
        public static string negativeNumber = "-5";
        public static string character = "abc";
        public static string errorMessageWhenEnterOutOfRule = "Panel height must be greater than or equal to 300 and lower than or equal to 800";
        public static string errorMessageWhenEnterCharacter = "Panel height must be an integer number";
        public static string errorInvalidNamePanelPage = "Invalid display name. The name can't contain high ASCII characters or any of following characters: /:*?<>|\"#{[]{};";
        public static string errorDuplicatedNamePanelPage = duplicatedPanelName + " already exists. Please enter a different name.";
        public static string[] chartTypeArray = { "Pie", "Single Bar", "Stacked Bar", "Group Bar", "Line" };
        public static string[] itemTypeArray = { "Test Modules", "Test Cases", "Test Objectives", "Data Sets", "Actions", "Interface Entities", "Test Results", "Test Case Results", "Test Suites", "Bugs" };
        public static string actionFinish = "finish";
        public static string actionNext = "next";
        public static string displayFields = "Display Fields";
        public static string sortFields = "Sort Fields";
        public static string filterFields = "Filter Fields";
        public static string statisticFields = "Statistic Fields";
        public static string displaySubFields = "Display Sub-Fields";
        public static string sortSubFields = "Sort Sub-Fields";
        public static string filterSubFields = "Filter Sub-Fields";
        public static string statisticSubFields = "Statistic Sub-Fields";
        public static int levelZero = 0;
        public static int levelOne = 1;

        //public static string uppercaseUsername = "UPPERCASEUSERNAME";
        //public static string lowercasePassword = "uppercaseusername";
        //public static string lowercaseUsername = "uppercaseusername";
        //public static string specialUsername = "specialCharsPassword";
        //public static string specialCharactersPassword = "`!@^&*(+_=[{;'\",./<?";
        //public static string specialCharactersUsername = "`~!@$^&()',.";
        // public static string specialPassword = "specialCharsUser";
        //public static string blankUsername = "";
        //public static string blankPassword = "";
        //public static string errorBlankUsernameLoginMessage = "Please enter username";
        //public static string addPageName = "Test 1 " + GetDateTime();
        //public static string editPageName = "Test 1 Edit "+ GetDateTime();
        //public static string addPageName2 = "Test 2 " + GetDateTime();
        //public static string editPageName2 = "Test 2 Edit " + GetDateTime();
        //public static string panelName = "test" + GetDateTime();
        //public static string pageName = CommonActions.GetDateTime();
        //public static string blankParentPage = "";
        //public static string blankNumberOfColumns = "";
        //public static string blankDisplayAfter = "";
        //public static string newPageName = "Test 1" + GetDateTime();
        //public static string newNumberOfColumns = "3";
        //public static string anotherValidUsername = "dieu.nguyen";
        //public static string anotherValidPassword = "123";
        //public static string errorMessageWhenCreateProfileWithoutName = "Please input profile name";
        //public static string errorMessageWhenCreateProfileWithExitingName = "Data Profile name already exists";
        //public static string specialPanelName = "Logigear#$%";
    }
}
