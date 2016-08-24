using System;
using TADASHBOARRD.Common;

namespace TADASHBOARRD.PageActions.LoginPage
{
    public class LoginPage: GeneralPage.GeneralPage
    {
        #region Methods

        /// <summary>
        /// Method to login TA Dashboard site
        /// </summary>
        public void Login(string repository, string username, string password)
        {
            SelectItemByText("repository combobox", repository);
            EnterValue("username textbox", username);
            EnterValue("password textbox", password);
            Click("login button");
            WaitInSpecificTime(10);
        }

        #endregion
    }
}
