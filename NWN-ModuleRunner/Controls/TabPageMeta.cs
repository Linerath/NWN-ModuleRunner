using NWN_ModuleRunner.Services;
using System;
using System.Windows.Forms;

namespace NWN_ModuleRunner.Controls
{
    public class TabPageMeta : TabPage
    {
        public Click ClickObj { get; set; }

        public TabPageMeta(Click click, String text)
            : base(text)
        {
            if (click == null)
                throw new ArgumentNullException(nameof(click));

            ClickObj = click;
        }
    }
}
