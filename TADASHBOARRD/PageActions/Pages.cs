using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using TADASHBOARRD.PageActions.LoginPage;
using TADASHBOARRD.PageActions;
using TADASHBOARRD.Common;

namespace TADASHBOARRD.PageActions
{
  public class Pages
    {
        private static T GetPage<T>() where T: new()
        {
            var page = new T();
            return page;
        }

       
    }
}
