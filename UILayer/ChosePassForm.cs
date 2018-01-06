using ModeLayer;
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
    public partial class ChosePassForm : Form
    {

        private List<Bitmap> listImg = null;
        Bitmap arowL = null;
        Bitmap arowR = null;

        public ChosePassForm(object obj)
        {
            //加载所有的游戏图片
            listImg = obj as List<Bitmap>;
            if (listImg != null)
            {
                curentImg = listImg[curentIndx];
            }
            InitializeComponent();
            //窗体位于桌面中间
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        //当前的背景图片
        Bitmap curentImg = null;
        //当前关卡
        int curentIndx = 0;
        //重绘
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            if (curentImg == null)
            {
                return;
            }
            e.Graphics.DrawImage(curentImg, panel1.ClientRectangle);
        }


        //用户提示箭头
        private void ChosePassForm_Load(object sender, EventArgs e)
        {
            arowR = Properties.Resources.arowR;
            arowL = Properties.Resources.arowL;
        }
        //切换关卡
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {

            //if (listImg.Count+1 <= curentIndx || curentIndx-1 > 0)
            //{
            //    return;
            //}

            if (e.X > 4 * panel1.Width / 5&& listImg.Count  > curentIndx+1)
            {
                curentIndx++;
                curentImg = listImg[curentIndx];
                panel1.Invalidate();

            }
            if (e.X < panel1.Width / 5&& curentIndx - 1 >= 0)
            {
                curentIndx--;
                curentImg = listImg[curentIndx];
                panel1.Invalidate();
            }
            
        }


        //bool flag = true;
        int currentPositionX = 0;
        int currentPositionY = 0;
        bool isdrow = false;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            //arowL.MakeTransparent();
            if (e.X > 4 * panel1.Width / 5)
            {
                //flag = true;
                panel1.CreateGraphics().DrawImage(arowR, new Rectangle(panel1.Width * 4 / 5, panel1.Height / 2 - panel1.Height / 10, panel1.Width / 5, panel1.Height / 5));
            }
            else if (e.X < panel1.Width / 5)
            {
                //flag = true;
                panel1.CreateGraphics().DrawImage(arowL, new Rectangle(0, panel1.Height / 2 - panel1.Height / 10, panel1.Width / 5, panel1.Height / 5));
            }
            else
            {

                if (isdrow)
                {
                    //根据鼠标的移动大小，移动窗口
                    this.Left += MousePosition.X - currentPositionX;
                    this.Top += MousePosition.Y - currentPositionY;
                    currentPositionY = MousePosition.Y;
                    currentPositionX = MousePosition.X;

                }
                panel1.CreateGraphics().DrawImage(curentImg, panel1.ClientRectangle);
            }
        }
        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            //恢复起始状态
            currentPositionX = 0;
            currentPositionY = 0;
            isdrow = false;


            panel1.CreateGraphics().DrawImage(curentImg, panel1.ClientRectangle);
        }
        //选择关卡
        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.X<panel1.Width/5||e.X>panel1.Width*4/5)
            {
                return;
            }
            this.Tag = curentIndx;
            Close();
        }
        //无边框窗体移动
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isdrow = false;
        }
        /// <summary>
        /// 用于无边框窗体移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isdrow = true;
            currentPositionX = MousePosition.X;
            currentPositionY = MousePosition.Y;
        }
        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
