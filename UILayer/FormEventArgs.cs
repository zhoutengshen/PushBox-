using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UILayer
{
    /// <summary>
    /// 窗体传值的类
    /// </summary>
    public class FormEventArgs : EventArgs
    {
        public int Flag { get; set; }

        public object Obj { get; set; }
    }
}
