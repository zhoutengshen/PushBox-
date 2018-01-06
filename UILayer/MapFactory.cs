using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModeLayer;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using DataLayer;

namespace UILayer
{
    public partial class MapFactory : Form
    {
        /// <summary>
        /// 地图状态枚举
        /// </summary>
        public enum MapState
        {
            /// <summary>
            /// 路
            /// </summary>
            road = '*',
            /// <summary>
            /// 箱子
            /// </summary>
            box = '%',
            /// <summary>
            /// 角色
            /// </summary>
            role = '$',
            /// <summary>
            /// 目标
            /// </summary>
            target = '@',
            /// <summary>
            /// 墙
            /// </summary>
            wall = '#',
            /// <summary>
            /// 角色和目标重合
            /// </summary>
            target_role = '^',
            /// <summary>
            /// 箱子和目标重合
            /// </summary>
            taget_box = '~'

        };

        //构造函数
        public MapFactory()
        {
            InitializeComponent();
            //窗体位于桌面中间
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        int n = 6;//行
        int m = 6;//列
        int gezi = 60;
        Map map = null;
        Bitmap backBmp = null;//背景图
        Panel drawAre = null;//绘制地图所在的面板
        Image curentImg = null;//当前选择的地图图标
        MapState state = MapState.wall;//初始化当前选中墙图标

        //初始化必要的变量和注册必要的事件；
        private void MapFactory_Load(object sender, EventArgs e)
        {

            button1.Enabled = false;
            textBox1.Text = n + "";
            textBox2.Text = m + "";
        }

        /// <summary>
        /// 确定行列数后，在pannel上初始化地图格子大小；
        /// </summary>
        private void InitMap()
        {

            int x = n * gezi + splitContainer1.Panel2.Width > this.ClientSize.Width ? n * gezi + splitContainer1.Panel2.Width : this.ClientSize.Width;
            int y = m * gezi > splitContainer1.Panel2.Height ? m * gezi : this.ClientSize.Height;
            this.ClientSize = new Size(x, y);

            listMap = new List<Map>();
            curentImg = Properties.Resources.wall as Image;
            backBmp = new Bitmap(gezi * n, gezi * m);
            map = new Map(n, m);
            drawAre = new Panel();
            drawAre.Size = new Size(gezi * n, gezi * m);
            drawAre.Location = new Point(10, 10);
            drawAre.BackColor = Color.White;
            splitContainer1.Panel1.Controls.Add(drawAre);
            DrawLinesToBackBmp();

            drawAre.Paint += DrawAre_Paint;
            drawAre.MouseClick += DrawAre_MouseClick;
            drawAre.MouseDoubleClick += DrawAre_MouseDoubleClick;

            //this.FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        //移除
        private void DrawAre_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //获取鼠标点击的位置
            Point point = GetImgLoca(e.X, e.Y);
            int x = point.X / gezi;
            int y = point.Y / gezi;
            //这个位置不可移除（空白）
            if (map.LogicMap[y, x] == '\0')
            {
                return;
            }
            Graphics g = Graphics.FromImage(backBmp);
            Pen p = new Pen(Brushes.Black, 2);
            //用一个格子填充点击的位置
            g.FillRectangle(Brushes.White, new Rectangle(point, new Size(gezi, gezi)));
            g.DrawRectangle(p, new Rectangle(point, new Size(gezi, gezi)));
            drawAre.CreateGraphics().DrawImage(backBmp, 0, 0);
            //设置逻辑数组为空
            map.SetMapState(y, x, '\0');
        }

        //控制台测试数据；
        private void Prinft()
        {
            for (int i = 0; i < map.LogicMap.GetLength(0); i++)
            {
                for (int j = 0; j < map.LogicMap.GetLength(1); j++)
                {
                    Console.Write(map.LogicMap[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        //在地图上添加图标；
        private void DrawAre_MouseClick(object sender, MouseEventArgs e)
        {
            //获取点击的位置
            Point point = GetImgLoca(e.X, e.Y);
            int x = point.X / gezi;
            int y = point.Y / gezi;
            if (map.LogicMap[y, x] != '\0')
                return;
            //在所在的位置上绘制一个地图块
            Graphics g = Graphics.FromImage(backBmp);
            g.DrawImage(curentImg, new Rectangle(point, new Size(gezi, gezi)));
            drawAre.CreateGraphics().DrawImage(backBmp, 0, 0);

            //地图状态有所选的地图块决定，设置逻辑地图
            switch (state)
            {
                case MapState.road:
                    map.SetMapState(y, x, (char)state);
                    break;
                case MapState.box:
                    map.SetMapState(y, x, (char)state);
                    break;
                case MapState.role:
                    map.SetMapState(y, x, (char)state);
                    break;
                case MapState.target:
                    map.SetMapState(y, x, (char)state);
                    break;
                case MapState.wall:
                    map.SetMapState(y, x, (char)state);
                    break;
                case MapState.taget_box:
                    map.SetMapState(y, x, (char)state);
                    break;
                case MapState.target_role:
                    map.SetMapState(y, x, (char)state);
                    break;
                default:
                    break;
            }
            Prinft();

        }

        //获取每个单元格左上角坐标；
        private Point GetImgLoca(int x, int y)
        {
            int xx = x / gezi * gezi;
            int yy = y / gezi * gezi;
            return new Point(xx, yy);
        }

        //重绘事件；
        private void DrawAre_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(backBmp, 0, 0);
        }

        //在画布上画线
        private void DrawLinesToBackBmp()
        {
            Graphics g = Graphics.FromImage(backBmp);
            for (int i = 0; i <= n; i++)
            {
                g.DrawLine(new Pen(Color.Black, 2), 0, i * gezi, drawAre.Width, i * gezi);
            }
            for (int i = 0; i <= m; i++)
            {
                g.DrawLine(new Pen(Color.Black, 2), i * gezi, 0, i * gezi, drawAre.Height);
            }

        }

        //选择其他的地图图标；
        private void wall_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("");
            switch ((sender as Control).Tag.ToString())
            {
                case "路":
                    curentImg = roadImg.Image;
                    state = MapState.road;
                    break;
                case "角色":
                    curentImg = roleImg.Image;
                    state = MapState.role;
                    break;
                case "墙":
                    curentImg = wallImg.Image;
                    state = MapState.wall;
                    break;
                case "目标":
                    curentImg = targetImg.Image;
                    state = MapState.target;
                    break;
                case "箱子":
                    curentImg = boxImg.Image;
                    state = MapState.box;
                    break;
                case "角色_目标":
                    curentImg = roleImg.Image;
                    state = MapState.target_role;
                    break;
                case "箱子_目标":
                    curentImg = boxImg.Image;
                    state = MapState.taget_box;
                    break;
                default:
                    break;
            }
        }

        //
        private void button1_Click(object sender, EventArgs e)
        {
            //foreach (char item in map.LogicMap)
            //{
            //    //存在没有填充的区域；
            //    if (item == '\0')
            //    {
            //        MessageBox.Show("请补充完整地图");
            //        return;
            //    }
            //}
            SetMapImg();
            BinarySerialized();
            this.Close();
        }

        protected override void OnClosed(EventArgs e)
        {

            
            base.OnClosed(e);
        }

        private void SetMapImg()
        {
            //map.
            //设置为空节省储存空间
            //map.ReallMap = null;
            map.Road = roadImg.Image.Clone() as Bitmap;
            map.Role = roleImg.Image.Clone() as Bitmap;
            map.Tatget = targetImg.Image.Clone() as Bitmap;
            map.Wall = wallImg.Image.Clone() as Bitmap;
            map.Box = boxImg.Image.Clone() as Bitmap;
        }


        List<Map> listMap = null;
        //获取MapInfo文件里面的信息；
        private void ReadMapInofFile()
        {

            listMap = MapInfo.ReadMapInofFile();
            if (listMap == null)
            {
                MessageBox.Show("读取失败或者文件为空");
                listMap = new List<Map>();
            }
            //List<Map> listMapDal = null;
           

        }
        //序列化；
        private void BinarySerialized()
        {
            ReadMapInofFile();

            listMap.Add(map);

            if (!MapInfo.SaveMapInfoToMapInfoFile(listMap))
                MessageBox.Show("储存失败！");

         

        }
        //确定行列数
        private void button3_Click(object sender, EventArgs e)
        {
            int nn = 6;
            int mm = 6;

            if (int.TryParse(textBox1.Text, out nn) &&
            int.TryParse(textBox2.Text, out mm))
            {
                m = mm > 6 ? mm : 6;
                n = nn > 6 ? nn : 6;
                textBox2.Enabled = false;
                textBox1.Enabled = false;
                button3.Enabled = false;
                textBox1.Text = n + "";
                textBox2.Text = m + "";
                button3.Enabled = false;
                button1.Enabled = true;
            }
            else
            {
                return;
            }
            InitMap();
        }

        //根据数组创建一个画布
        public static Bitmap RealMapImgMaker(Map map)
        {
            int col = map.Row;
            int row = map.Col;

            char[,] logicMap = map.LogicMap;
            Bitmap mapImg = new Bitmap(row * 60, col * 60);

            return CreaImgByArray(map, logicMap, mapImg);
        }
        //根据二维数组创建地图画布
        public static Bitmap CreaImgByArray(Map map, char[,] logicMap, Bitmap mapImg)
        {
            Graphics g = Graphics.FromImage(mapImg);
            Bitmap img = null;
            for (int i = 0; i < logicMap.GetLength(0); i++)
            {
                for (int j = 0; j < logicMap.GetLength(1); j++)
                {
                    img = GetImgByMapstate((MapState)Enum.ToObject(typeof(MapState), logicMap[i, j]), map);
                    if (img != null)
                    {
                        Rectangle rec = new Rectangle(j * 60, i * 60, 60, 60);
                        g.DrawImage(img,rec );
                    }

                }
            }
            return mapImg;
        }

        //根据地图状态选中对应的图片；
        private static Bitmap GetImgByMapstate(MapState state,Map map)
        {
            Bitmap img = null;
            switch (state)
            {
                case MapState.road:
                    img = map.Road.Clone() as Bitmap;
                    break;
                case MapState.box:
                    img = map.Box.Clone() as Bitmap;
                    break;
                case MapState.role:
                    img = map.Role.Clone() as Bitmap;
                    break;
                case MapState.target:
                    img = map.Tatget.Clone() as Bitmap;
                    break;
                case MapState.wall:
                    img = map.Wall.Clone() as Bitmap;
                    break;
                case MapState.taget_box:
                    img = map.Box.Clone() as Bitmap;
                    break;
                case MapState.target_role:
                    img = map.Role.Clone() as Bitmap;
                    break;
                default:
                    break;
            }
            return img;
        }

        //选择图片
        private void roadImg_Click(object sender, EventArgs e)
        {
            switch ((sender as Control).Tag.ToString())
            {
                case "路":
                    curentImg = roadImg.Image;
                    state = MapState.road;
                    road.Checked = true;
                    break;
                case "角色":
                    curentImg = roleImg.Image;
                    state = MapState.role;
                    role.Checked = true;
                    break;
                case "墙":
                    curentImg = wallImg.Image;
                    state = MapState.wall;
                    wall.Checked = true;
                    break;
                case "目标":
                    curentImg = targetImg.Image;
                    state = MapState.target;
                    target.Checked = true;
                    break;
                case "箱子":
                    curentImg = boxImg.Image;
                    state = MapState.box;
                    myBox.Checked = true;
                    break;
                case "角色_目标":
                    curentImg = roleImg.Image;
                    state = MapState.target_role;
                    role_target.Checked = true;
                    break;
                case "箱子_目标":
                    curentImg = boxImg.Image;
                    state = MapState.taget_box;
                    box_target.Checked = true;
                    break;
                default:
                    break;
            }
        }


        #region 无边框窗体移动

        int currentPositionX = 0;
        int currentPositionY = 0;
        bool isdrow = false;
        private void MapFactory_MouseUp(object sender, MouseEventArgs e)
        {
            isdrow = false;
        }

        private void MapFactory_MouseMove(object sender, MouseEventArgs e)
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

        private void MapFactory_MouseLeave(object sender, EventArgs e)
        {
            //恢复起始状态
            currentPositionX = 0;
            currentPositionY = 0;
            isdrow = false;
        }

        private void MapFactory_MouseDown(object sender, MouseEventArgs e)
        {
            isdrow = true;
            currentPositionX = MousePosition.X;
            currentPositionY = MousePosition.Y;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
