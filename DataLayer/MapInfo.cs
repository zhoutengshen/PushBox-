using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeLayer;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DataLayer
{
    public static class MapInfo
    {
        /// <summary>
        /// 获取MapInfo文件里面的信息；
        /// </summary>
        /// <returns></returns>
         public static List<Map> ReadMapInofFile()
        {
            List<Map> listMapDal = null;
            if (!File.Exists("MapInfo.bin"))
                return null;
            try
            {
                using (FileStream fs = new FileStream("MapInfo.bin", FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    listMapDal = bf.Deserialize(fs) as List<Map>;
                    if (listMapDal == null)
                    {
                        //MessageBox.Show("listMap==null");
                        return null;
                    }

                }
            }
            catch (Exception)
            {
                //MessageBox.Show("读取文件失败");
                throw;
            }
            return listMapDal;
        }

        /// <summary>
        /// 存储ListMap
        /// </summary>
        /// <param name="listMap"></param>
        /// <returns></returns>
        public static bool SaveMapInfoToMapInfoFile(List<Map> listMap)
        {
            bool mark = true;
            try
            {
                using (FileStream fs = new FileStream("MapInfo.bin", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, listMap);
                }
            }
            catch (Exception)
            {
                mark = false;
            }
            return mark;
        }
    }

}
