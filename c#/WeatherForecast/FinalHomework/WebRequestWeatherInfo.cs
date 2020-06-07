using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;
using System.Collections;
using System.Data;
using System.Xml.Linq;
using System.Net;
using Newtonsoft.Json;


namespace Stu.Zzr.FinalHomework
{
    public class WebRequestWeatherInfo
    {
        //请求网页获取天气信息
        public WebRequestWeatherInfo GetWeatherInfo(string city)
        {
            //通过聚合数据获取信息
            string http = "http://v.juhe.cn/weather/index?";
            string tmp = "cityname=" + city + "&format=2";
            http += (tmp + "&key=4f2e721fdb5f8b778095e80ed0ffe104");

            Encoding encoding = Encoding.UTF8;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(http);

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            httpWebRequest.Timeout = 20000;

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(),Encoding.GetEncoding("utf-8"));
            string responseContent = streamReader.ReadToEnd();

            httpWebResponse.Close();
            streamReader.Close();

            //json反序列化
            WebRequestWeatherInfo weatherinfo = JsonConvert.DeserializeObject<WebRequestWeatherInfo>(responseContent);
            return weatherinfo;
        }

        public string resultcode
        {
            get;set;
        }
        public string reason
        {
            get; set;
        }
        public WeatherModel result
        {
            get; set;
        }
        public string error_code
        {
            get;set;
        }
        public class WeatherModel
        {
            public skinfo sk
            {
                get;set;
            }
            public todayinfo today
            {
                get;set;
            }
            List<futureinfo> futuref = new List<futureinfo>();
            public List<futureinfo> future
            {
                get { return futuref; }
                set { futuref = value; }
            }
        }
        public class skinfo
        {
            public string temp { get; set; }
            public string wind_direction { get; set; }
            public string wind_strength { get; set; }
            public string humidity { get; set; }//湿度
            public string time { get; set; }
        }
        public class todayinfo
        {
            public string temperature { get; set; }
            public string weather { get; set; }
            public weatherid weather_id { get; set; }
            public string wind { get; set; }
            public string week { get; set; }
            public string city { get; set; }
            public string date_y { get; set; }
            public string dressing_index { get; set; }
            public string dressing_advice { get; set; }
            public string uv_index { get; set; }
            public string comfort_index { get; set; }
            public string wash_index { get; set; }
            public string travel_index { get; set; }
            public string exercise_index { get; set; }
            public string drying_index { get; set; }
        }
        public class futureinfo
        {
            public string temperature { get; set; }
            public string weather { get; set; }
            public weatherid weather_id { get; set; }
            public string wind { get; set; }
            public string week { get; set; }
            public string date { get; set; }
        }
        public class weatherid
        {
            public string fa { get; set; }
            public string fb { get; set; }
        }

    }
}
