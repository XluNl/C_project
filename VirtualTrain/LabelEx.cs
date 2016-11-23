using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualTrain
{
    internal class LabelEx : System.Windows.Forms.Label
    {
        public LabelEx()
            : base()
        {
            //关闭AutoSize
            this.AutoSize = false;
            //捕捉事件
            this.TextChanged += new EventHandler(LabelEx_TextChanged);
        }
        /// <summary>
        /// 重写AutoSize属性，防止AutoSize再被打开
        /// </summary>
        public override bool AutoSize
        {
            get
            {
                return false;
            }
        }

        void LabelEx_TextChanged(object sender, EventArgs e)
        {
            //文字变化了，那就改变一下当前的大小
            System.Drawing.Size ps = GetPreferredSize(this.Size);
            //这里构造一个新的Size对象，目的是使用原始的宽度。原因嘛，见上面
            this.Size = new System.Drawing.Size(this.Width, ps.Height);
        }
    }
}
