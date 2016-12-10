using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VirtualTrain.common;
using VirtualTrain.model;
namespace VirtualTrain
{
    public delegate void call(script scr,int cenceid);
    public partial class AddScript : Form
    {
        ScriptDAL scDAL = new ScriptDAL();
        public AddScript()
        {
            InitializeComponent();
        }

        private call _call;

        public call Call
        {
            get { return _call; }
            set { _call = value; }
        }

        /// <summary>
        /// 保存标记0，添加，1修改
        /// </summary>
        private int _tg;

        public int Tg
        {
            get { return _tg; }
            set { _tg = value; }
        }

        /// <summary>
        /// 保存修改时候 传过来的场景模型
        /// </summary>
        private script scenc;

        public script Scenc
        {
            get { return scenc; }
            set { scenc = value; }
        }


        //事件执行标记
        private int loadtag;

        public int Loadtag
        {
            get { return loadtag; }
            set { loadtag = value; }
        }
        /// <summary>
        /// 保存场景对应的所有角色
        /// </summary>
        private List<script> _scRoles;

        public List<script> ScRoles
        {
            get { return _scRoles; }
            set { _scRoles = value; }
        }

        /// <summary>
        /// 店家添加按钮 添加一个场景
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
           
            // 添加场景到数据库
            script scp = new script();
            scp.Scencname = BoxName.Text;
            scp.Isonline = Boxonline.Checked ? 1 : 0;

            // 修改操作
            if (this.Tg == 1){
                scp.Id = this.Scenc.Id;
                scDAL.editSenceWith(scp,this.ScRoles);

            }else {//添加操作
                // 获取所有选中的checkbox
                List<script> scencScripts = new List<script>();
                foreach (CheckBox box in this.panel1.Controls){
                    VR_Role ro = (VR_Role)box.Tag;
                    if (box.Checked){
                        script sc = new script();
                        sc.Screncscriptid = ro.Id;
                        sc.Screncscriptname = box.Text;
                        scencScripts.Add(sc);
                    }
                }

                int senceid;
                if (scDAL.addScript(scp, scencScripts, out senceid)){

                    this.Call(scp, senceid);
                };
            }
            // 关闭窗口
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddScript_Load(object sender, EventArgs e)
        {
            // 1、加载全部角色
            ScriptDAL scrDAL = new ScriptDAL();
            List<VR_Role> scrs = scrDAL.getRolesWith();

            // 2、如果是修改，则记载对应场景的全部角色
            if (this.Tg == 1) {
                this.ScRoles = scrDAL.getAllScencRoleWithScencid(this.scenc.Id);
            }
            
            // 3、根据数据 布局UI
            loadRolesWithRoleList(scrs);
            // 01、修改时，要将之前保存的角色选中

            // 02、添加时，直接加载全部的角色
            // 03、修改时，本来选中的角色，要被取消，则要判断这个角色有没有被使用
            
        }

        private void loadRolesWithRoleList(List<VR_Role> listRole) {

            int num = 5; //个数
            int org = 10;//间隙
            int with = this.panel1.Width; //父控件with
            double check_w = (with - ((num + 1) * org)) / num;//计算控件with
            int check_h = 20;
            int i = 0;
            foreach (VR_Role ro in listRole)
            {
                int row = i / num;
                int colum = i % num;
                double check_X = (colum * (check_w + org)) + org;
                CheckBox check = new CheckBox();
                check.Text = ro.Name;
                check.Tag = ro;
                check.Location = new Point((int)check_X, org + row * (check_h + org));
                check.BackColor = Color.Gray;
                // 如果是修改一个场景 那么需要加载的时候，选中已经存储的角色
                if(this.Tg==1){
                    check.CheckedChanged += valueCheckedChanged;
                    foreach(script sc in this.ScRoles){
                        if (sc.Screncscriptid == ro.Id)
                        {
                            check.Checked=true;
                        }
                    }

                    this.BoxName.Text = this.Scenc.Scencname;
                    this.Boxonline.Checked = this.Scenc.Isonline > 0;
                }
                this.panel1.AutoScroll = true;
                this.panel1.Controls.Add(check);
                i++;
            }

            this.Loadtag = 1;
        }

        private void check_TabIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("当前角色使用中，不能删除！");
        }

        private void check_MouseClick(object sender, MouseEventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            bool bb = box.Checked;
            VR_Role ro = (VR_Role)box.Tag;

            MessageBox.Show("check_MouseClick");
        }

        /// <summary>
        /// 点击chenboX时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void valueCheckedChanged(object sender, EventArgs e)
        {
            if(this.Loadtag!=1)return;

            CheckBox box = (CheckBox)sender;
            VR_Role ro = (VR_Role)box.Tag;

            script sc = new script();
            sc.Id = this.Scenc.Id;
            sc.Screncscriptid = ro.Id;
            //1、bb为true 则要移除(移除则要，先查看数据库里面当前角色是否有在使用)
            if (!box.Checked)
            {

                if (!scDAL.checkRoleOnScencIsNotWith(this.Scenc.Id, ro.Id))
                {
                    foreach (script sp in this.ScRoles)
                    {

                        if (sp.Screncscriptid == sc.Screncscriptid)
                        {
                            this.ScRoles.Remove(sp);
                            break;
                        }
                    }

                }
                else
                { //说明 这个角色在当前任务里面有使用 不能删除

                    MessageBox.Show("当前角色使用中，不能删除！");
                    box.Checked = true;
                }

            }
            else
            {
                //添加一个
                this.ScRoles.Add(sc);
            }
            
        }

    }
}
