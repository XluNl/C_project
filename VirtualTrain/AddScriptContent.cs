using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VirtualTrain.model;
using VirtualTrain.common;
namespace VirtualTrain
{
    public delegate  void Call(TaskModel ta,int tag);
    public partial class AddScriptContent : Form
    {

        TaskDAL dal = new TaskDAL();
        ResouresDAL resDAL = new ResouresDAL();


        List<Role> listrole = new List<Role>();
       
        private Call _call;

        public Call Call
        {
            get { return _call; }
            set { _call = value; }
        }
        // 存储场景页面 传过来的场景ID
        private int _senceid;

        public int Senceid
        {
            get { return _senceid; }
            set { _senceid = value; }
        }

        // 存储标记（添加0、1修改、2插入）
        private int _tag;

        public int Tag1
        {
            get { return _tag; }
            set { _tag = value; }
        }

        // 保存修改时 传过来的MOde
        private TaskModel _taskmode;

        public TaskModel Taskmode
        {
            get { return _taskmode; }
            set { _taskmode = value; }
        }

        public AddScriptContent()
        {
            InitializeComponent();
        }


        
        /// <summary>
        /// 点击确定 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.jolesBOX.SelectedIndex < 0)
            {
                MessageBox.Show("请指定角色！");
                return;
            }

            int roleID = this.jolesBOX.SelectedIndex;
            Role ro = listrole[roleID];

            //1、通知主编及面板创建一个任务的模型、将任务ID传过去,将任务对应的角色编号传过去
            if (this.Tag1 == 1) {//修改
                this.Taskmode.Taskroleid = ro.id;
                this.Taskmode.Senceid = this.Senceid;
                if (dataGridView1.SelectedRows.Count >0)//有修改，则取新值
                {
                    this.Taskmode.Taskid = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[0].Value;
                }
                this.Call(this.Taskmode, this.Tag1);
            }else { //添加、插入
                if (dataGridView1.SelectedRows.Count < 1)
                {
                    MessageBox.Show("请选择一条任务！");
                    return;
                }
                TaskModel taskmo = new TaskModel();
                taskmo.Senceid = this.Senceid;
                taskmo.Taskroleid = ro.id;
                taskmo.Taskid = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[0].Value;
                this.Call(taskmo, this.Tag1);
            }
            
           this.Close();
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 初始化  加载角色数据
        /// </summary>
        /// <param name="sender">场景ID</param>
        /// <param name="e"></param>
        private void AddScriptContent_Load(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            //将信息保存
            this.listrole = dal.getAllRoleWithSenceID(this.Senceid);
            this.jolesBOX.Items.Clear();
            int index = 0;
            foreach (Role ro in listrole)
            {
                this.jolesBOX.Items.Add(ro.name);

                if (this.Tag1 == 1)
                {
                    if (ro.id == this.Taskmode.Taskroleid)
                    {
                        this.jolesBOX.SelectedIndex = index;
                    }
                }
                index++;
            }

            this.comboBox1.SelectedIndex = 3;
        }

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.comboBox1.SelectedIndex;

            // 0文字、1图像、2视频、3全部
            // 2、加载资源数据
            this.dataGridView1.AutoGenerateColumns = false;//禁止自动生成列
            this.dataGridView1.DataSource = resDAL.getAllResources(index);
            this.dataGridView1.SelectedRows[0].Selected = false;
            this.dataGridView1.Columns[0].FillWeight = 20;
            this.dataGridView1.Columns[1].FillWeight = 90;
            this.dataGridView1.Columns[3].FillWeight = 120;
            if (index==0)
            {
                this.dataGridView1.Columns[2].Visible = true;
                this.dataGridView1.Columns[3].Visible = false;
                this.dataGridView1.Columns[4].Visible = false;
                this.dataGridView1.Columns[5].Visible = false;
            }else if(index==1){
                this.dataGridView1.Columns[2].Visible = true;
                this.dataGridView1.Columns[3].Visible = true;
                this.dataGridView1.Columns[4].Visible = false;
                this.dataGridView1.Columns[5].Visible = false;
            }
            else if (index == 2)
            {
                this.dataGridView1.Columns[2].Visible = false;
                this.dataGridView1.Columns[3].Visible = true;
                this.dataGridView1.Columns[4].Visible = true;
                this.dataGridView1.Columns[5].Visible = true;
            }
            else {
                this.dataGridView1.Columns[2].Visible = true;
                this.dataGridView1.Columns[3].Visible = true;
                this.dataGridView1.Columns[4].Visible = true;
                this.dataGridView1.Columns[5].Visible = true;

                this.dataGridView1.Columns[3].FillWeight = 150;
            }
        }

        
    }
}
