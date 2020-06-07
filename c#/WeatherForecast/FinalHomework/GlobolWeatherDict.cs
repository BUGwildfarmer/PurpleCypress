using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stu.Zzr.FinalHomework
{
    public class GlobalWeatherDict//用于存图片查询字典的类
    {
        //天气字符串对应imagelist里的下标
        public static Dictionary<string, int> weatherpict = new Dictionary<string, int>();

        //城市字符串对应imagelist里的下标
        public static Dictionary<string, int> citypict = new Dictionary<string, int>();

        //开放接口
        public static Dictionary<string, int> Weatherpict
        {
            get
            {
                return weatherpict;
            }
            set
            {
                weatherpict = value;
            }
        }

        //开放接口
        public static Dictionary<string, int> Citypict
        {
            get
            {
                return citypict;
            }
            set
            {
                citypict = value;
            }
        }
    }
}
