using Common.model;
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
    public delegate void call(script scr);
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
        private static int AllowRolesNum = 10;
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
            // 名称不能为null
            if (BoxName.Text.Length < 1)
            {
                MessageBox.Show("名称不能为空！", "提示！");
                return;
            }
            // 添加场景到数据库
            script scp = new script();
            scp.Scencname = BoxName.Text;
            scp.Isonline = Boxonline.Checked ? 1 : 0;

            // 修改操作
            if (this.Tg == 1){

                if (this.ScRoles.Count<1)
                {
                    MessageBox.Show("请选择角色！", "提示！");
                    return;
                }
                scp.Id = this.Scenc.Id;
                scDAL.editSenceWith(scp,this.ScRoles);
                // 回调
                this.Call(scp);

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
                if (scencScripts.Count<1)
                {
                    MessageBox.Show("请选择角色！", "提示！");
                    return;
                }
                int senceid;
                if (scDAL.addScript(scp, scencScripts, out senceid)){
                    scp.Id = senceid;
                    this.Call(scp);
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
            if (this.Tg == 1)
            {
                this.BoxName.Text = this.Scenc.Scencname;
                this.ScRoles = scrDAL.getAllScencRoleWithScencid(this.scenc.Id);
            }
            else {
                this.ScRoles = new List<script>();
            }
            
            // 3、根据数据 布局Role_UI
            loadRolesWithRoleList(scrs);
            
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
                check.CheckedChanged += valueCheckedChanged;
                if(this.Tg==1){
                    //check.CheckedChanged += valueCheckedChanged;
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
            // 修改的时候才回传过来场景id
            if (this.Tg==1)
            {
                sc.Id = this.Scenc.Id;
            }
            sc.Screncscriptid = ro.Id;
            // 删除(移除则要，先查看数据库里面当前角色是否有在使用)
            if (!box.Checked)
            {
                if (this.Tg==1)
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

                        MessageBox.Show("当前角色使用中，不能删除！", "提示！");
                        this.Loadtag = 0;
                        box.Checked = true;
                        this.Loadtag = 1;
                    }
                }
                else
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

            }else
            {
                if (this.ScRoles.Count < AllowRolesNum)
                {
                    //添加一个
                    this.ScRoles.Add(sc);
                }
                else {
                    MessageBox.Show("角色数量建议不要超过10个！","提示！");
                    box.Checked = false;
                    return;
                }
               
            }
            
        }

    }
}
