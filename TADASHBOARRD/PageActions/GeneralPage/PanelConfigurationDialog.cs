using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TADASHBOARRD.PageActions.GeneralPage
{
    class PanelConfigurationDialog:GeneralPage
    {
        public void EnterValueToHeighThenClickOk(string value)
        {
            Sleep(1);
            EnterValue("height textbox", value);
            Click("ok button");
        }

        public void CancelPanelConfigurationDialog()
        {
            Sleep(1);
            Click("cancel button");
        }
    }
}
