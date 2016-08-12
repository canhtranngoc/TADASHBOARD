﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TADASHBOARRD.Common;

namespace TADASHBOARRD.PageActions.PanelsPage
{
    public class NewPanelDialog: GeneralPage.GeneralPage
    {
        public void AddNewPanel(string name, string series)
        {
            System.Threading.Thread.Sleep(1000);
            EnterValue("display name textbox", name);
            EnterValueDropdownList("series dropdown list", name);
            Click("ok button");
        }
       
    }
}
