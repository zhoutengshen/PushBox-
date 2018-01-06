using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using ModeLayer;
using DataLayer;
using System.Threading;

namespace UILayer
{
    public partial class MainForm : Form
    {
        //游戏管理者
        GameManager manager = null;
        //游戏菜单窗体
        GameMenuForm gmf = null;

        public MainForm()
        {
            InitializeComponent();
            //窗体位于桌面中间
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        //由游戏的行列数动态改变窗体的大小
        private void ChangeFormSize()
        {
            int width = manager.Gezi * manager.CurentMapRow;
            int height = manager.Gezi * manager.CurentMapCol;
            this.Size = new Size(height, width);
            //MessageBox.Show ("");
        }
        //窗体最小化
        private void MinSizeForm()
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //关闭窗体
        private void CloseForm()
        {
            Application.Exit();
        }
       //改变窗体的背景
        private void ChangeBackImg()
        {
            Bitmap Img = manager.CurentBmp;
            if (Img == null) return;
            Bitmap originalBmp = (Bitmap)Img.Clone();

            int n = 20;

            Bitmap currentBmp = new Bitmap(originalBmp.Width, originalBmp.Height);
            //Graphics gCurrentBmp = Graphics.FromImage(currentBmp);
            //gCurrentBmp.FillRectangle(Brushes.White, new Rectangle(0, 0, currentBmp.Width, currentBmp.Height));
            //gCurrentBmp.Dispose();

            Graphics gPictureBox =panel1.CreateGraphics();

            int width = originalBmp.Width; // 表示每一块百叶窗的宽度
            int heightPerSlice = originalBmp.Height / n; // 表示每块百叶窗的高度 = 图片高度 / 百叶窗数目
            for (int i = 0; i < heightPerSlice; i++) // (for i...)循环处理每一页百叶窗的第i行，从第0行到第heightPerSlice - 1行
            {
                for (int k = 0; k < n; k++) // 循环k表示依次处理n页百叶窗，从第0到第n-1页
                {
                    for (int j = 0; j < width; j++) // 循环枚举每一页百叶窗的第j列
                    {
                        currentBmp.SetPixel(j, k * heightPerSlice + i,
                            originalBmp.GetPixel(j, k * heightPerSlice + i));
                    }
                }
                // 将currentBmp按拉伸图像的方式画回pictureBox1上。
                gPictureBox.DrawImage(currentBmp,
                    new Rectangle(0, 0, panel1.Width, panel1.Height), // 表示目标画板(pictureBox1）的绘图范围
                    new Rectangle(0, 0, currentBmp.Width, currentBmp.Height),  // 表示图片源(currentBmp)的绘图范围
                    GraphicsUnit.Pixel);
                System.Threading.Thread.Sleep(3); // 挂起线程，即让程序停顿100毫秒，再继续执行for循环。
            }
            gPictureBox.Dispose();
            originalBmp.Dispose();
            currentBmp.Dispose();

        }

        //加载
        private void MainForm_Load(object sender, EventArgs e)
        {
           //窗体传值用的委托
            Action actChangeFormSize = new Action(ChangeFormSize);//改变窗体大小的委托
            Action actChangeImg = new Action(ChangeBackImg);//改变窗体背景的委托
            Action actMinForm = new Action(MinSizeForm);//窗体最小化的委托
            Action actCloseForm = new Action(CloseForm);//关闭窗体的委托

            manager = new GameManager(panel1);//初始化一个游戏管理者
            panel1.Invalidate();


            //获取第i关的高和宽
            int width = manager.Gezi * manager.CurentMapRow;
            int height = manager.Gezi * manager.CurentMapCol;
            this.Size = new Size(width, height);

            //菜单窗体
            gmf = new GameMenuForm(manager);

            //注册委托
            gmf.MinSizeForm1 = actMinForm;
            gmf.CloseForm = actCloseForm;

            //gmf.ChangeMainFormSize = act;
            manager.ChangeMainFormSize = actChangeFormSize;
            manager.ChangeBackImg = actChangeImg;

            gmf.Width = this.ClientSize.Width / 5;
            gmf.Height = this.ClientSize.Height;
            gmf.Show();
            gmf.TopMost = true;
            //gmf.Hide();
            gmf.Opacity = 0.5;

            //菜单窗体停靠在主窗体左边
            int top = this.ClientRectangle.Top;
            int left = this.ClientRectangle.Left;
            Point poin = this.PointToScreen(new Point(left, top));
            gmf.Location = poin;


        }
        //重回时间
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(manager.CurentBmp, panel1.ClientRectangle);
        }

        //按下按钮触发
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            manager.keyDownOrreStep = true;
            manager.RoleTryTo(e);

        }

        protected override void OnClosed(EventArgs e)
        {

            base.OnClosed(e);
            //结束整个程序
            Application.Exit();
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {

            //窗体移动
            if (isdrow)
            {
                //根据鼠标的移动大小，移动窗口
                this.Left += MousePosition.X - currentPositionX;
                this.Top += MousePosition.Y - currentPositionY;
                currentPositionY = MousePosition.Y;
                currentPositionX = MousePosition.X;

            }




            //菜单栏隐藏
            int top = this.ClientRectangle.Top;
            int left = this.ClientRectangle.Left;
            Point poin = this.PointToScreen(new Point(left, top));
            gmf.Location = poin;
            if (e.X < this.Width / 5 && e.X > 10)
            {
                gmf.Show();
            }
            else
            {
                gmf.Hide();
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                gmf.Width = 130;
                gmf.Height = this.ClientSize.Height;
                //panel1.Invalidate();
            }
            catch (Exception)
            {
            }

        }

        private void MainForm_Move(object sender, EventArgs e)
        {
            if (gmf == null)
            {
                return;
            }
            int top = this.ClientRectangle.Top;
            int left = this.ClientRectangle.Left;
            Point poin = this.PointToScreen(new Point(left, top));
            gmf.Location = poin;
        }




        #region 无边款窗体移动
        int currentPositionX = 0;
        int currentPositionY = 0;
        bool isdrow = false;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isdrow = true;
            currentPositionX = MousePosition.X;
            currentPositionY = MousePosition.Y;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            //恢复起始状态
            currentPositionX = 0;
            currentPositionY = 0;
            isdrow = false;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isdrow = false;
        }
        #endregion

    }
}
