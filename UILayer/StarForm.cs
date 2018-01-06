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
    public partial class StarForm : Form
    {
        public StarForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void StarForm_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MapFactory mf = new MapFactory();
            mf.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainform = new MainForm();
            mainform.Show();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        #region 无边框窗体移动

        int currentPositionX = 0;
        int currentPositionY = 0;
        bool isdrow = false;
        private void StarForm_MouseDown(object sender, MouseEventArgs e)
        {
            isdrow = true;
            currentPositionX = MousePosition.X;
            currentPositionY = MousePosition.Y;
        }

        private void StarForm_MouseUp(object sender, MouseEventArgs e)
        {
            isdrow = false;
        }

        private void StarForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isdrow)
            {
                //根据鼠标的移动大小，移动窗口
                this.Left += MousePosition.X - currentPositionX;
                this.Top += MousePosition.Y - currentPositionY;
                currentPositionY = MousePosition.Y;
                currentPositionX = MousePosition.X;

            }
        }

        private void StarForm_Leave(object sender, EventArgs e)
        {
            //恢复起始状态
            currentPositionX = 0;
            currentPositionY = 0;
            isdrow = false;
        }
        #endregion

    }
}
