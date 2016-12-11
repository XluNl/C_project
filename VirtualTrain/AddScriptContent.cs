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


        // 修改时 保存选中的任务id
        private int curSelectTaskid;

        public int CurSelectTaskid
        {
            get { return curSelectTaskid; }
            set { curSelectTaskid = value; }
        }
        public AddScriptContent()
        {
            InitializeComponent();
        }


        ResouresDAL resDAL = new ResouresDAL();
        /// <summary>
        /// 点击确定 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            
            // 组织一条任务
            // 获取角色id
            int roleID = this.jolesBOX.SelectedIndex;
            Role ro = listrole[roleID];

            //1、通知主编及面板创建一个任务的模型、将任务ID传过去,将任务对应的角色编号传过去
            if (this.Tag1 == 1) {//修改
                this.Taskmode.Taskroleid = ro.id;
                this.Taskmode.Senceid = this.Senceid;
                if (this.curSelectTaskid>1)
                {
                    this.Taskmode.Taskid = this.curSelectTaskid;
                }
                this.Call(this.Taskmode, this.Tag1);
            }else { //添加、插入
                // 判断用户是否选择资源
                if (this.curSelectTaskid < 1)//添加
                {
                    MessageBox.Show("请选择一条任务");
                    return;
                }
                TaskModel taskmo = new TaskModel();
                taskmo.Senceid = this.Senceid;
                taskmo.Taskroleid = ro.id;
                taskmo.Taskid = this.curSelectTaskid;
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
            //将信息保存
            this.listrole = dal.getAllRoleWithSenceID(this.Senceid);

            this.jolesBOX.Items.Clear();
            this.jolesBOX.SelectedValueChanged += ValueChanged;
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

            // 2、加载资源数据
            this.dataGridView1.DataSource = resDAL.getAllResources();
            this.dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
           
        }

        void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
            int selecttaskid = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[0].Value;

            this.curSelectTaskid= selecttaskid;

            if (this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[0].Value.ToString() == "")
            {
                MessageBox.Show("请选择一项进行删除");
            } 
        }

        /// <summary>
        /// comboBox 被选中时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValueChanged(object sender, EventArgs e)
        {
            int index = this.jolesBOX.SelectedIndex;
        }

    }
}
