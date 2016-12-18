using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VirtualTrain.common;

namespace VirtualTrain
{
    public partial class TeacherForm : Form
    {
        public TeacherForm()
        {
            InitializeComponent();
        }

        private static TeacherWelcomeForm _tchWelcome;
        public static TeacherWelcomeForm tchWelcome
        {
            get
            {
                return _tchWelcome;
            }
        }

        private static TeacherFunctionForm _tchFunction;
        public static TeacherFunctionForm tchFunction
        {
            get
            {
                return _tchFunction;
            }
        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            ViewHelper.size = this.Size;

            _tchFunction = new TeacherFunctionForm();
            tchFunction.MdiParent = this;
            tchFunction.Show();

            _tchWelcome = new TeacherWelcomeForm();
            tchWelcome.MdiParent = this;
            tchWelcome.Show();
            this.Opacity = 100D;
        }
    }
}
