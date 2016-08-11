using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TADASHBOARRD.Common;
using TADASHBOARRD.PageActions;

namespace TADASHBOARRD.PageActions.GeneralPage
{
    public class NewPageDialog : GeneralPage
    {
        public void CreateNewPage(string pageName)
        {
            Thread.Sleep(2000);
            //string parentPage, string numberOfColumns, string displayAfter
            EnterValue("pagename textbox", pageName);


        }
    }
}
