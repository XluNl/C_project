using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace VirtualTrain
{
    public class MyNumericUpDown : NumericUpDown
    {
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            //暂存一下当前的值
            decimal value = this.Value;
            //设置一个与当前的值不相等的新值
            if (value != this.Minimum)
                this.Value = this.Minimum;
            else
                this.Value = this.Maximum;
            //还原当前值
            this.Value = value;
        }
    }
}
