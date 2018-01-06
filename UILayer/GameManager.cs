using DataLayer;
using ModeLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UILayer
{
    //这个结构体用于返回前一步操作
    public struct BackStep
    {
        //用户按下的按钮
        public char keyDown;
        //目标的状态
        public char targetState;
        //目标的目标的状态
        public char target_targetState;
        //方向
        public Point direct;
        //当前的位置
        public Point curentLocation;

    }

    public class GameManager
    {
        //游戏进行的控件
        Control _control = null;


        /// <summary>
        ///  需要一个控件，游戏的界面界面将在这里显示；
        /// </summary>
        /// <param name="obj">控件名</param>
        public GameManager(object obj)
        {
            //游戏运行所在的控件
            _control = obj as Control;
            //初始化游戏界面
            IniteMapInfo();
        }

        /// <summary>
        /// 初始化第一个地图的数据；
        /// </summary>
        private void IniteMapInfo()
        {
            //填充父容器
            _control.Dock = DockStyle.Fill;

            //读取文件里面的ListMap,ListMap这是个大资源，但是我们只需要一部分，所以要获取需要的释放不需要的；
            //读取第一个地图；
            g_map = ReadMapInfoFile(g_curentPassIndex);

            //获取第一个地图的背景图
            g_curentBmp = MapFactory.RealMapImgMaker(g_map).Clone() as Bitmap;
            //第一个地图的hanglie
            g_curentMapRow = g_map.Row;
            g_curentMapCol = g_map.Col;

            //coletrol控件无效，重绘
            _control.Invalidate();

            g_curentRolePosition = FindRolePosition();
            //初始化一个全局画布；
            g_gra = Graphics.FromImage(g_curentBmp);
            //这个是用来记录按下的按钮；
            g_oldStep = new Stack<BackStep>();
            Prinft();

        }



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

        //全局地图
        Map g_map = null;
       //全局当前要操作的画布
        Bitmap g_curentBmp = null;
        //全局画图工具
        Graphics g_gra = null;
        //当前role位置
        Point g_curentRolePosition = new Point(-1, -1);
        int g_curentMapRow = 6;//初始化行为6
        int g_curentMapCol = 6;//初始化列为6
        int g_gezi = 60;//单元格子大小
        int g_curentPassIndex = 0;//角色当前位置
        int g_allPassSum = 0;//所有的关卡数量
        Action g_changeMainFormSize = null;//窗体最小化委托
        Action g_changeBackImg = null;//用来改变背景的委托，

        Stack<BackStep>g_oldStep = null;//栈，用来储存以前所走的步骤

        /// <summary>
        /// 最小化委托注册的函数
        /// </summary>
        public Action ChangeMainFormSize
        {
            set
            {
                g_changeMainFormSize = value;
            }
        }

        //第几关属性
        public int CurentPassIndex
        {
            get
            {
                return g_curentPassIndex;
            }

            set
            {
                g_curentPassIndex = value;
            }
        }
        //属性
        public Bitmap CurentBmp
        {
            get
            {
                return g_curentBmp;
            }

            set
            {
                g_curentBmp = value;
            }
        }
        //属性
        public Control Control_
        {
            get
            {
                return _control;
            }

            set
            {
                _control = value;
            }
        }
        //属性
        public int CurentMapRow
        {
            get
            {
                return g_curentMapRow;
            }

            set
            {
                g_curentMapRow = value;
            }
        }
        //属性
        public int CurentMapCol
        {
            get
            {
                return g_curentMapCol;
            }

            set
            {
                g_curentMapCol = value;
            }
        }
        //属性
        public int Gezi
        {
            get
            {
                return g_gezi;
            }

            set
            {
                g_gezi = value;
            }
        }
        //属性
        public Action ChangeBackImg
        {

            set
            {
                g_changeBackImg = value;
            }
        }

        //属性
        public Map G_map
        {
            get
            {
                return g_map;
            }

            set
            {
                g_map = value;
            }
        }
        //属性
        public Stack<BackStep> G_oldStep
        {
            get
            {
                return g_oldStep;
            }

        }

        //用户当前按下的按钮
        char g_keyDown;
        //当前的方向
        Point dir;
        //是进行按下还是后退操作
        public bool keyDownOrreStep = false;

        /// <summary>
        /// 尝试把角色移动到e所在的位置
        /// </summary>
        /// <param name="e"></param>
        public void RoleTryTo(KeyEventArgs e)
        {
            //MessageBox.Show(((char)e.KeyValue).ToString());

            int x = g_curentRolePosition.X;
            int y = g_curentRolePosition.Y;

            #region 用户按下的按钮和方向
            Point directP = new Point(0, 0);
            if (e.KeyCode == Keys.W)
            {
                g_keyDown = 'S';
                directP.Y -= 1;
                g_map.Role = Properties.Resources.Uprole;
            }
            else if (e.KeyCode == Keys.A)
            {
                directP.X -= 1;
                g_keyDown = 'D';
                g_map.Role = Properties.Resources.Lrole;
            }
            else if (e.KeyCode == Keys.S)
            {
                directP.Y += 1;
                g_keyDown = 'W';
                g_map.Role = Properties.Resources.Downrole;
            }
            else if (e.KeyCode == Keys.D)
            {
                directP.X += 1;
                g_keyDown = 'A';
                g_map.Role = Properties.Resources.Rrole;
            }
            else
            {
                return;
            }
            dir = directP;
            #endregion

            int indX = x + directP.Y;
            int indY = y + directP.X;
            #region 排除部分不合法去向（走法）
            //保证下标不越界；
            if (indX < 0 || indX >= g_curentMapRow || indY < 0 || indY >= g_curentMapCol)
                return;
            char targetChar = g_map.LogicMap[indX, indY];
            MapState targetState = (MapState)Enum.ToObject(typeof(MapState), targetChar);
            //目的地不可去；
            if (targetState == MapState.wall)
                return;
            //箱子下一步不可到
            if (targetState == MapState.box)
            {
                indX += directP.Y;
                indY += directP.X;
                //判断箱子下一步是否越界
                if (indY >= g_curentMapCol || indX >= g_curentMapRow || indX < 0 || indY < 0)
                    return;
                //箱子被阻碍
                if (g_map.LogicMap[indX, indY] != (char)MapState.road && g_map.LogicMap[indX, indY] != (char)MapState.target)
                {
                    return;
                }
            }

            #endregion

            //用户移动到目标位置
            DrawToCurentBmp(x, y, targetState, directP);
            //扫描数组，看看是否已经把箱子全部推到目标位置
            if (ScanArray())
            {
                //MessageBox.Show("You are Winner");
                if (g_curentPassIndex + 1 >= g_allPassSum)
                {
                    return;
                }
                //切换到下一关
                CurentPass(++g_curentPassIndex);

            }
            //控制台测试
            Prinft();
        }

        /// <summary>
        /// 目标位置可以到达，绘出相应的图片
        /// </summary>
        /// <param name="xx"></param>
        /// <param name="yy"></param>
        /// <param name="targetState"></param>
        /// <param name="direct"></param>
        public void DrawToCurentBmp(int xx, int yy, MapState targetState, Point direct)
        {
            //上一步的信息
            BackStep oldStep = new BackStep();
            oldStep.curentLocation = this.g_curentRolePosition;
            oldStep.keyDown = g_keyDown;
            oldStep.targetState = (char)targetState;
            oldStep.direct = dir;
            //数组可能越界
            try
            {
                oldStep.target_targetState = g_map.LogicMap[xx + direct.Y * 2, yy + direct.X * 2];
            }
            catch (Exception)
            {
            }

            Bitmap orImg = g_map.Road;
            MapState orState = MapState.road;
            //判断当前位置的状态是否为‘^’
            if (g_map.LogicMap[xx, yy] == (char)MapState.target_role)
            {
                orImg = g_map.Tatget;
                orState = MapState.target;
            }

            if (targetState == MapState.road)//路
            {
                //原始位置
                g_gra.DrawImage(orImg, yy * g_gezi, xx * g_gezi, g_gezi, g_gezi);
                //目标位置
                g_gra.DrawImage(g_map.Role, (yy + direct.X) * g_gezi, (xx + direct.Y) * g_gezi, g_gezi, g_gezi);
                _control.CreateGraphics().DrawImage(g_curentBmp, _control.ClientRectangle);
                //panel1.Invalidate();
                g_map.LogicMap[xx, yy] = (char)orState;
                g_map.LogicMap[xx + direct.Y, yy + direct.X] = (char)MapState.role;
                //改变角色所在位置；
                g_curentRolePosition = new Point(xx + direct.Y, yy + direct.X);
            }
            if (targetState == MapState.target)
            {

                g_gra.DrawImage(orImg, yy * g_gezi, xx * g_gezi, g_gezi, g_gezi);
                g_gra.DrawImage(g_map.Role, (yy + direct.X) * g_gezi, (xx + direct.Y) * g_gezi, g_gezi, g_gezi);
                _control.CreateGraphics().DrawImage(g_curentBmp, _control.ClientRectangle);
                //panel1.Invalidate();
                g_map.LogicMap[xx, yy] = (char)orState;
                g_map.LogicMap[xx + direct.Y, yy + direct.X] = (char)MapState.target_role;//
                g_curentRolePosition = new Point(xx + direct.Y, yy + direct.X);
            }
            if (targetState == MapState.box)
            {
                //越界
                try
                {
                    if (g_map.LogicMap[xx + direct.Y * 2, yy + direct.X * 2] == (char)MapState.wall)
                    {
                        return;
                    }
                }
                catch (Exception)
                {

                    return;
                }


                MapState nextNextState = MapState.box;
                //箱子到达的位置是目标位置；
                if (g_map.LogicMap[xx + direct.Y * 2, yy + direct.X * 2] == (char)MapState.target)
                {
                    nextNextState = MapState.taget_box;
                }

                g_gra.DrawImage(orImg, yy * g_gezi, xx * g_gezi, g_gezi, g_gezi);
                g_gra.DrawImage(g_map.Role, (yy + direct.X) * g_gezi, (xx + direct.Y) * g_gezi, g_gezi, g_gezi);
                g_gra.DrawImage(g_map.Box, (yy + direct.X * 2) * g_gezi, (xx + direct.Y * 2) * g_gezi, g_gezi, g_gezi);
                g_map.LogicMap[xx, yy] = (char)orState;
                g_map.LogicMap[xx + direct.Y, yy + direct.X] = (char)MapState.role;
                g_map.LogicMap[xx + direct.Y * 2, yy + direct.X * 2] = (char)nextNextState;
                g_curentRolePosition = new Point(xx + direct.Y, yy + direct.X);
                _control.CreateGraphics().DrawImage(g_curentBmp, _control.ClientRectangle);
                //panel1.Invalidate();
            }
            if (targetState == MapState.taget_box)
            {

                try
                {
                    if (g_map.LogicMap[xx + direct.Y * 2, yy + direct.X * 2] == (char)MapState.wall)
                    {
                        return;
                    }
                }
                catch (Exception)
                {
                    return;
                }


                MapState nextNextState = MapState.box;
                //箱子到达的位置是目标位置；
                if (g_map.LogicMap[xx + direct.Y * 2, yy + direct.X * 2] == (char)MapState.target)
                {
                    nextNextState = MapState.taget_box;
                }


                g_gra.DrawImage(orImg, yy * g_gezi, xx * g_gezi, g_gezi, g_gezi);
                g_gra.DrawImage(g_map.Role, (yy + direct.X) * g_gezi, (xx + direct.Y) * g_gezi, g_gezi, g_gezi);
                g_gra.DrawImage(g_map.Box, (yy + direct.X * 2) * g_gezi, (xx + direct.Y * 2) * g_gezi, g_gezi, g_gezi);
                g_map.LogicMap[xx, yy] = (char)orState;
                //这里角色和目标重合
                g_map.LogicMap[xx + direct.Y, yy + direct.X] = (char)MapState.target_role;

                g_map.LogicMap[xx + direct.Y * 2, yy + direct.X * 2] = (char)nextNextState;
                g_curentRolePosition = new Point(xx + direct.Y, yy + direct.X);
                _control.CreateGraphics().DrawImage(g_curentBmp, _control.ClientRectangle);
                //panel1.Invalidate();

            }
            //用户按下按钮记录步数
            if (keyDownOrreStep)
            {
                g_oldStep.Push(oldStep);
            }

          
        }

        /// <summary>
        /// 读取序列化文件；
        /// </summary>
        /// <param name="pass">guanqia</param>
        /// <returns>关卡的MapInfo</returns>
        public Map ReadMapInfoFile(int pass)
        {

            List<Map> listMap = null;
            #region 冗余
            //try
            //{
            //    FileStream fs = new FileStream("MapInfo.bin", FileMode.Open, FileAccess.Read);
            //    BinaryFormatter fb = new BinaryFormatter();
            //    listMap = fb.Deserialize(fs) as List<Map>;
            //    allPassSum = listMap.Count;

            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("反序列化失败");
            //    return null;
            //}
            #endregion

            listMap = MapInfo.ReadMapInofFile();
            if (listMap == null)
            {
                return null; ;
            }
            g_allPassSum = listMap.Count;
            if (pass >= listMap.Count)
            {
                return null;
            }
            //实现ICloneable接口实现深拷贝
            return listMap[pass].Clone() as Map;
            //MessageBox.Show((map == listMap[2]).ToString());

        }

        public void Prinft()
        {
            for (int i = 0; i < g_map.LogicMap.GetLength(0); i++)
            {
                for (int j = 0; j < g_map.LogicMap.GetLength(1); j++)
                {
                    Console.Write(g_map.LogicMap[i, j] + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 寻找Role的位置
        /// </summary>
        /// <returns></returns>
        public Point FindRolePosition()
        {
            //Point p;
            for (int i = 0; i < g_map.LogicMap.GetLength(0); i++)
            {
                for (int j = 0; j < g_map.LogicMap.GetLength(1); j++)
                {
                    if (g_map.LogicMap[i, j] == '$')
                        return new Point(i, j);
                }
            }
            return new Point(-1, -1);
        }


        /// <summary>
        /// 当前关卡
        /// </summary>
        /// <param name="passIndex"></param>
        /// <returns>词关卡是否可以玩</returns>
        public bool CurentPass(int passIndex)
        {
            if (passIndex >= g_allPassSum || passIndex < 0)
                return false;
            //获取这个一关地图的信息
            g_oldStep.Clear();
            g_map = ReadMapInfoFile(passIndex).Clone() as Map;
            g_curentBmp = MapFactory.RealMapImgMaker(g_map).Clone() as Bitmap;
            //_control.CreateGraphics().DrawImage(_curentBmp, 0, 0);
            //新一关的画布
            g_gra = Graphics.FromImage(g_curentBmp);
            //新一关的行列
            g_curentMapRow = g_map.Row;
            g_curentMapCol = g_map.Col;
            //获取新一关的角色的开始位置
            g_curentRolePosition = FindRolePosition();

            //用于根据画布大小改变窗体大小
            if (g_changeMainFormSize != null)
            {
                g_changeMainFormSize();
            }

            if (g_changeBackImg != null)
            {
                g_changeBackImg();
            }
            //通知窗体重绘
            //_control.Invalidate();
            return true;
        }

        public void ChosePass()
        {
            //获取文件里面的地图数组；
            //并且把相应的数组状态转换为相应的图片；
            //存到listImg里面；
            List<Bitmap> listImg = new List<Bitmap>();
            foreach (Map item in MapInfo.ReadMapInofFile())
            {
                listImg.Add(MapFactory.RealMapImgMaker(item));
            }
            ChosePassForm cpf = new ChosePassForm(listImg);
            cpf.TopMost = true;
            cpf.ShowDialog();
            int index = Convert.ToInt32(cpf.Tag);
            CurentPass(index);
        }

        /// <summary>
        /// 判断全部目标是否都被箱子填充
        /// </summary>
        /// <returns></returns>
        public bool ScanArray()
        {

            foreach (char item in g_map.LogicMap)
            {

                if (item == (char)MapState.target || item == (char)MapState.target_role)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
