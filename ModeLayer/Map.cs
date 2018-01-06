using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ModeLayer
{
    [Serializable]
    public class Map : IDisposable,ICloneable 
    {

        /// <summary>
        /// 深拷贝；
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Map(Col, Row)
            {
                _logicMap = DeepCopyLogicMap(),
                _col = Col,
                _row = _row,

                //_reallMap = _reallMap.Clone() as Bitmap,
                //_box = _box.Clone() as Bitmap,
                //_road = _road.Clone() as Bitmap,
                //_role = _role.Clone() as Bitmap,
                //_target = _target.Clone() as Bitmap,
                //_wall = _wall.Clone() as Bitmap

            };

        }


        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            _box.Dispose();
            //_reallMap.Dispose();
            _road.Dispose();
            _role.Dispose();
            _target.Dispose();
            _wall.Dispose();
        }

        public char[,] DeepCopyLogicMap()
        {
            char[,] ch = new char[_row, _col];
            for (int i = 0; i < _row; i++)
            {
                for (int j = 0; j < _col; j++)
                {
                    ch[i, j] = _logicMap[i, j];
                }
            }
            return ch;
        }


        char[,] _logicMap;
        //默认值；
        private int _col = 6;//行
        private int _row = 6;//列
        //private Bitmap _reallMap = null;//地图画布；
        private static Bitmap _box = null;//路障；
        private static Bitmap _road = null;//路；
        private static Bitmap _role = null;//角色；
        private static Bitmap _target = null;//目标；
        private static Bitmap _wall = null;//墙


        /// <summary>
        /// 设置这个位置的状态；
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="ch"></param>
        public void SetMapState(int x, int y, char ch)
        {
            _logicMap[x, y] = ch;

        }

        /// <summary>
        /// 使用默认值构建地图；大小为6*6
        /// </summary>
        public Map()
        {
            InitImg();
        }

        private void InitImg()
        {
            ResourceManager rsm = Properties.Resources.ResourceManager;
            _role = new Bitmap((rsm.GetObject("role") as Image), new Size(60, 60));
            _box = new Bitmap((rsm.GetObject("box") as Image), new Size(60, 60));
            _road = new Bitmap((rsm.GetObject("road") as Image), new Size(60, 60));
            _target = new Bitmap((rsm.GetObject("target") as Image), new Size(60, 60));
            _wall = new Bitmap((rsm.GetObject("Wall") as Image), new Size(60, 60));
            //_reallMap = new Bitmap(60 * _row, 60 * _col);

        }

        /// <summary>
        /// 自定义地图；
        /// </summary>
        /// <param name="col">列</param>
        /// <param name="row">行</param>
        public Map(int col, int row)
        {
            _col = col;
            _row = row;
            _logicMap = new char[_row, _col];
            InitImg();
        }

        /// <summary>
        /// 获取逻辑地图
        /// </summary>
        public char[,] LogicMap
        {
            get
            {
                return _logicMap;
            }

        }
        /// <summary>
        ///  获取逻辑地图的列数
        /// </summary>
        public int Col
        {
            get
            {
                return _col;
            }

        }
        /// <summary>
        /// 获取逻辑地图的行数；
        /// </summary>
        public int Row
        {
            get
            {
                return _row;
            }

        }
        ///// <summary>
        ///// 真是的地图
        ///// </summary>
        //public Bitmap ReallMap
        //{

        //    get
        //    {
        //        return _reallMap;
        //    }

        //    set
        //    {
        //        _reallMap = value;
        //    }
        //}
        /// <summary>
        /// 障碍物
        /// </summary>
        public Bitmap Box
        {
            get
            {
                return _box;
            }

            set
            {
                _box = value;
            }
        }
        /// <summary>
        /// 路
        /// </summary>
        public Bitmap Road
        {
            get
            {
                return _road;
            }

            set
            {
                _road = value;
            }
        }
        /// <summary>
        /// 人物
        /// </summary>
        public Bitmap Role
        {
            get
            {
                return _role;
            }

            set
            {
                _role = value;
            }
        }
        /// <summary>
        /// 目标
        /// </summary>
        public Bitmap Tatget
        {
            get
            {
                return _target;
            }

            set
            {
                _target = value;
            }
        }
        /// <summary>
        /// 墙；
        /// </summary>
        public Bitmap Wall
        {
            get
            {
                return _wall;
            }

            set
            {
                _wall = value;
            }
        }


    }
}
