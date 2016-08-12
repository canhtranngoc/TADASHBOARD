using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TADASHBOARRD.PageActions.GeneralPage;
using TADASHBOARRD.PageActions;

namespace TADASHBOARRD.PageActions.LoginPage
{
    public class LoginPage : GeneralPage.GeneralPage
    {
        public void Login(string repository, string username, string password)
        {
            //WaitForElementLoad(_cboRepository, 3);
            SelectItemByText("repository combobox", repository);
            EnterValue("username textbox", username);
            EnterValue("password textbox", password);
          //  Click("login button");
            FindWebElements("login button").Click();

        }



    }
}
