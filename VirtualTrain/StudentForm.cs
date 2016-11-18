using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VirtualTrain
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        private static StudentWelcomeForm _stuWelcome;
        public static StudentWelcomeForm stuWelcome
        {
            get
            {
                return _stuWelcome;
            }
        }

        private static StudentFunctionForm _stuFunction;
        public static StudentFunctionForm stuFunction
        {
            get
            {
                return _stuFunction;
            }
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            ViewHelper.size = this.Size;

            _stuFunction = new StudentFunctionForm();
            stuFunction.MdiParent = this;
            stuFunction.Show();

            _stuWelcome = new StudentWelcomeForm();
            stuWelcome.MdiParent = this;
            stuWelcome.Show();
            this.Opacity = 100D;
        }

    }
}
