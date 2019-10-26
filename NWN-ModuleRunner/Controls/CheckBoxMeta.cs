using NWN_ModuleRunner.Services;
using System;
using System.Windows.Forms;

namespace NWN_ModuleRunner.Controls
{
    public class CheckBoxMeta : CheckBox
    {
        public Click ClickObj { get; set; }

        public CheckBoxMeta(Click click)
        {
            if (click == null)
                throw new ArgumentNullException(nameof(click));

            ClickObj = click;
        }
    }
}
