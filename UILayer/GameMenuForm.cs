using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UILayer
{
    public partial class GameMenuForm : Form
    {

        //游戏管理者
        GameManager g_manager = null;
        Action changeMainFormSize = null;
        //用来管理组窗体变化的几个委托
        public Action ChangeMainFormSize
        {
            set
            {
                changeMainFormSize = value;
            }
        }
        public Action MinSizeForm1
        {

            set
            {
                _minSizeForm = value;
            }
        }
        public Action CloseForm
        {
            set
            {
                _closeForm = value;
            }
        }
        Action _minSizeForm = null;
        Action _closeForm= null;


        //构造函数
        public GameMenuForm(GameManager manager)
        {
            g_manager = manager;
            InitializeComponent();
        }

        //下一关
        private void btnNextPass_Click(object sender, EventArgs e)
        {

            //下一关
            if (g_manager.CurentPass(g_manager.CurentPassIndex + 1))
                g_manager.CurentPassIndex++;
            //下一关地图大小会变化，通知主窗体大小改变
            if (changeMainFormSize != null)
            {
                changeMainFormSize();
            }
        }

        //上一关
        private void btnPrePass_Click(object sender, EventArgs e)
        {
            if (g_manager.CurentPass(g_manager.CurentPassIndex - 1))
                g_manager.CurentPassIndex--;
            if (changeMainFormSize != null)
            {
                changeMainFormSize();
            }
        }

        //窗体最小化
        private void btnChosePass_Click(object sender, EventArgs e)
        {
            this.Hide();
            g_manager.ChosePass();
            if (changeMainFormSize != null)
            {
                changeMainFormSize();
            }
        }

        //隐藏菜单窗体
        private void GameMenuForm_MouseLeave(object sender, EventArgs e)
        {
            this.Hide();
        }

        //重新开始
        private void button4_Click(object sender, EventArgs e)
        {
            g_manager.CurentPass(g_manager.CurentPassIndex);
        }

        //后退
        //将前面的走法存到一个栈里面；
        private void button3_Click(object sender, EventArgs e)
        {
            g_manager.keyDownOrreStep = false;
            if (g_manager.G_oldStep.Count > 0)
            {
                BackStep oldStep = g_manager.G_oldStep.Pop();
                Keys key = (Keys)Enum.ToObject(typeof(Keys), oldStep.keyDown);
                KeyEventArgs ke = new KeyEventArgs(key);
                g_manager.RoleTryTo(ke);

                g_manager.G_map.LogicMap[oldStep.curentLocation.X + oldStep.direct.Y
                    , oldStep.curentLocation.Y + oldStep.direct.X] = oldStep.targetState;
                try
                {
                    g_manager.G_map.LogicMap[oldStep.curentLocation.X + oldStep.direct.Y * 2
                    , oldStep.curentLocation.Y + oldStep.direct.X * 2] = oldStep.target_targetState;
                }
                catch (Exception)
                {

                }
            }
            //还原前一步的画布
            MapFactory.CreaImgByArray(g_manager.G_map, g_manager.G_map.LogicMap, g_manager.CurentBmp);
        }

        //最笑话游戏
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.Hide();
                if (_minSizeForm!=null)
                {
                    _minSizeForm();
                }
            }
        }
        //关闭游戏
        private void button1_Click(object sender, EventArgs e)
        {
            if (_closeForm != null)
            {
                _closeForm();
            }
        }
    }
}
