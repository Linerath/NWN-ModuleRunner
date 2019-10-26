using NWN_ModuleRunner.Services;
using System;
using System.Windows.Forms;

namespace NWN_ModuleRunner.Controls
{
    public class ButtonMeta : Button
    {
        public Click ClickObject { get; set; }

        public ButtonMeta(Click click)
        {
            if (click == null)
                throw new ArgumentNullException(nameof(click));

            ClickObject = click;
        }
    }
}
