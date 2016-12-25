using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.Common;
using System.Configuration;
using VirtualTrain.model;
using VirtualTrain.common;
using Common.model;

namespace VirtualTrain
{
    public partial class ImageQuestionFrom : Form
    {
        public ImageQuestionFrom()
        {
            InitializeComponent();
        }

        private void ImageQuestionFrom_Load(object sender, EventArgs e)
        {
            cboMajorsInit(cboMajors);
        }

        private void pic_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = i_path;
            file.Title = "请选择图片";
            //file.InitialDirectory = "c";
            file.Multiselect = false;
            file.Filter = "图片文件|*.jpg";
            if (file.ShowDialog() == DialogResult.OK)
            {
                if (!Path.GetDirectoryName(file.FileName).Equals(i_path))
                {

                    MessageBox.Show("请选择" + i_path + "下的图片文件！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                pic.Load(file.FileName);


            }
        }


        private static string i_path = ConfigurationManager.AppSettings["img_net_path"];
        private static int questionId;
        private static List<string> optionList = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        private static int currentOption = 0;

        private static int space = 30;
        private static int vspace = 30;
        private static int initX = 20;
        private static int initY = 20;


        //问题信息
        public Question question
        {
            get
            {
                //根据各控件的值，生成一个Question类的实例并返回
                Question question = new Question();
                question.id = questionId;
                question.question = txtQuestion.Text;
                question.type = "true";
                foreach (Control con in gb.Controls)
                {
                    if (con is CheckBox)
                    {
                        CheckBox chk = con as CheckBox;
                        if (chk.Checked)
                        {
                            question.answer += chk.Tag.ToString().Trim() + ",";
                        }
                    }
                    if (con is PictureBox)
                    {
                        PictureBox pic = con as PictureBox;
                        if (pic.Tag != null)
                        {
                            question.multiOption.Add(Path.GetFileName(pic.ImageLocation));
                        }

                    }
                }
                question.answer = question.answer.Substring(0, question.answer.Length - 1);

                question.major = cboMajors.Text.Trim();
                return question;
            }
            set
            {
                currentOption = 0;

                //根据Question对象的值，设置相应控件
                if (value == null)
                {
                    //如果Question对象为空，则清空各控件
                    txtQuestion.Text = "";
                    cboMajors.Text = "";
                    gb.Controls.Clear();
                    generateAddBox(initX, initY);
                }
                else
                {
                    gb.Controls.Clear();
                    questionId = value.id;
                    //根据Question对象的值，设置相应控件
                    txtQuestion.Text = value.question;
                    cboMajors.Text = value.major;
                    foreach (string fileName in value.multiOption)
                    {
                        generatePicBox(fileName);
                    }
                    //在当前currentOption添加addbox
                    generateAddBox((currentOption % 5) * (100 + space) + initX, (currentOption > 4 ? 1 : 0) * (100 + vspace) + initY);
                    string[] answers = value.answer.Split(',');
                    List<string> answerList = new List<string>(answers);
                    foreach (Control con in gb.Controls)
                    {
                        if (con is CheckBox)
                        {
                            CheckBox chk = con as CheckBox;
                            string tag = chk.Tag.ToString().Trim();

                            if (answerList.Contains(tag))
                            {
                                chk.Checked = true;
                            }
                        }
                    }
                }
            }
        }

        private void generateAddBox(int X, int Y)
        {
            if (currentOption > 10)
            {
                return;
            }
            PictureBox pic = new PictureBox();
            pic.Image = VirtualTrain.Properties.Resources.add;
            pic.Width = 100;
            pic.Height = 100;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Click += new EventHandler(addPic);
            gb.Controls.Add(pic);
            pic.Location = new Point(X, Y);

        }


        private void addPic(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.Image = VirtualTrain.Properties.Resources.picgongdian;
            pic.Tag = optionList[currentOption];
            currentOption++;
            pic.Click -= new EventHandler(addPic);
            pic.Click += new EventHandler(pic_Click);

            pic_Click(pic, null);
            generateCheckBox(pic.Tag.ToString(), pic.Location);
            generateAddBox((currentOption % 5) * (pic.Width + space) + initX, (currentOption > 4 ? 1 : 0) * (pic.Height + vspace) + initY);

        }

        private void generatePicBox(string fileName)
        {
            PictureBox pic = new PictureBox();
            pic.Tag = optionList[currentOption];
          
            pic.Load(i_path + @"\" + fileName);
            pic.Width = 100;
            pic.Height = 100;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;

            pic.Click += new EventHandler(pic_Click);
            gb.Controls.Add(pic);
            pic.Location = new Point((currentOption % 5) * (pic.Width + space) + initX, (currentOption > 4 ? 1 : 0) * (pic.Height + vspace) + initY);
            currentOption++;
            generateCheckBox(pic.Tag.ToString(), pic.Location);
        }

        private void generateCheckBox(string tag, Point point)
        {
            CheckBox chk = new CheckBox();
            chk.Tag = tag;
            chk.Checked = false;
            chk.BringToFront();
            gb.Controls.Add(chk);
            chk.Location = new Point(point.X - 20, point.Y + 50);
        }


        public static void cboMajorsInit(ComboBox cboMajors)
        {
            cboMajors.Items.Clear();
            DBHelper db = new DBHelper();
            string sql = "select * from majors";
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        Major major = new Major();
                        major.id = (int)reader["id"];
                        major.name = (string)reader["name"];
                        cboMajors.Items.Add(major);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!checkInput())
            {
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private bool checkInput()
        {
            if (txtQuestion.Text.Trim() == "")
            {
                MessageBox.Show("请输入问题！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboMajors.Text.Trim() == "")
            {
                MessageBox.Show("请选择题目所属专业！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //判断gb中控件是否为空
            bool isNull = true;
            bool isPicNull = false;
            foreach (Control con in gb.Controls)
            {
                if (con is CheckBox)
                {
                    CheckBox chk = con as CheckBox;
                    if (chk.Checked)
                    {
                        isNull = false;
                    }
                }

                if (con is PictureBox)
                {
                    PictureBox pic = con as PictureBox;
                    if (pic.Tag == null)
                    {
                        continue;
                    }
                    if (pic.ImageLocation == null)
                    {
                        isPicNull = true;
                        break;
                    }
                }
            }
            if (isPicNull)
            {
                MessageBox.Show("请选择上传图片！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (isNull)
            {
                MessageBox.Show("请选择选择题答案！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
