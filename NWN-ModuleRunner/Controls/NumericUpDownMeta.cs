using NWN_ModuleRunner.Services;
using System;
using System.Windows.Forms;

namespace NWN_ModuleRunner.Controls
{
    public class NumericUpDownMeta : NumericUpDown
    {
        public Click Click { get; set; }

        public NumericUpDownMeta(Click click)
        {
            if (click == null)
                throw new ArgumentNullException(nameof(click));

            Click = click;
        }
    }
}
