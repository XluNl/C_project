using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.Common;

namespace VirtualTrain
{
    public partial class ImageQuestionFrom : Form
    {
        public ImageQuestionFrom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ImageQuestionFrom_Load(object sender, EventArgs e)
        {
            cboMajorsInit(cboMajors);
        }

        private void pic_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "请选择图片";
            //file.InitialDirectory = "c";
            file.Multiselect = false;
            file.Filter = "图片文件|*.jpg";
            if (file.ShowDialog() == DialogResult.OK)
            {
                pic.Image = Image.FromFile(file.FileName);
                source_target[file.FileName] = pic.Tag.ToString();
            }
        }


        private static int questionId;
        private static List<string> optionList = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        private static int currentOption;

        private static int space = 30;
        private static int vspace = 30;
        private static int initX = 20;
        private static int initY = 20;

        public Dictionary<string, string> source_target = new Dictionary<string, string>();

        //图片复制字典
        public Dictionary<string, string> dictionary 
        {
            get
            {
                return source_target;
            }
        }
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
                        //File.Copy(file.FileName, @"C:\Image\" + id + ".jpg", true);
                        question.multiOption += pic.Tag.ToString().Trim() + ",";
                    }
                }
                question.answer = question.answer.Substring(0, question.answer.Length - 1);
                question.multiOption = question.multiOption.Substring(0, question.multiOption.Length - 1);

                question.major = cboMajors.Text.Trim();
                return question;
            }
            set
            {
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
                    questionId = value.id;
                    //根据Question对象的值，设置相应控件
                    txtQuestion.Text = value.question;
                    cboMajors.Text = value.major;
                    foreach (string str in value.multiOption.Split(','))
                    {
                        generatePicBox(questionId+ str);
                    }
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
            PictureBox pic = new PictureBox();
            pic.Image = VirtualTrain.Properties.Resources.add;
            pic.Width = 100;
            pic.Height = 100;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Tag = optionList[currentOption];
            pic.Click += new EventHandler(addPic);
            gb.Controls.Add(pic);
            pic.Location = new Point(X, Y);
            currentOption++;
        }

        private void addPic(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.Image = VirtualTrain.Properties.Resources.picgongdian;
            pic.Click += new EventHandler(pic_Click);
            generateCheckBox(pic.Tag.ToString(),pic.Location);
            generateAddBox((currentOption % 5) * (pic.Width + space)+initX, (currentOption > 4 ? 1 : 0) * (pic.Height + vspace)+initY);
        }

        private void generatePicBox(string info)
        {
            PictureBox pic = new PictureBox();
            pic.Image = Image.FromFile(@"C:\Image\" + info + ".jpg");
            pic.Width = 100;
            pic.Height = 100;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            string tag = info.Substring(info.Length - 1, 1);
            int index = optionList.IndexOf(tag);
            pic.Tag = tag;
            pic.Click += new EventHandler(pic_Click);
            gb.Controls.Add(pic);
            pic.Location = new Point((index % 5) * (pic.Width + space)+initX, (index> 4 ? 1 : 0) * pic.Height + vspace+initY);
            generateCheckBox(tag,pic.Location);
        }

        private void generateCheckBox(string tag,Point point)
        {
            CheckBox chk = new CheckBox();
            chk.Tag = tag;
            chk.Checked = false;
            chk.BringToFront();
            gb.Controls.Add(chk);
            chk.Location = new Point(point.X-20,point.Y+50);
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


        //获得专业的id
        public static int getMajorId(ComboBox comboBox)
        {
            object item = comboBox.SelectedItem;
            if (item != null)
            {
                Major major = item as Major;
                return major.id;
            }
            else
            {
                return -1;
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
            //判断innerSplitContainer.Panel2中控件是否为空
            bool isNull = true;
            foreach (Control con in gb.Controls)
            {
                if (con is CheckBox)
                {
                    CheckBox chk = con as CheckBox;
                    if (chk.Checked)
                    {
                        isNull = false;
                        break;
                    }
                }
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

        private void label2_Click(object sender, EventArgs e)
        {

        }


    }
}
