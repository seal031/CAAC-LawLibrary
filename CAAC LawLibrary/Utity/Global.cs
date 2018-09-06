using CAAC_LawLibrary.DAL;
using CAAC_LawLibrary.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAAC_LawLibrary.Utity
{
    public static class Global
    {
        public static bool online = true;

        public static string Appid = ConfigWorker.GetConfigValue("Appid");
        public static string Appkey = ConfigWorker.GetConfigValue("Appkey");
        public static string RemoteUrl = ConfigWorker.GetConfigValue("RemoteUrl");
        public static string ConsultCommitApi = RemoteUrl + ConfigWorker.GetConfigValue("ConsultCommit");
        public static string OpinionListApi= RemoteUrl + ConfigWorker.GetConfigValue("OpinionList");
        public static string OpinionCommitApi= RemoteUrl + ConfigWorker.GetConfigValue("OpinionCommit");
        public static string AllBooksApi= RemoteUrl + ConfigWorker.GetConfigValue("AllBooks");
        public static string NodeDetailApi= RemoteUrl + ConfigWorker.GetConfigValue("NodeDetail");
        public static string BookContentApi= RemoteUrl + ConfigWorker.GetConfigValue("BookContent");
        public static string BookNodeCldApi= RemoteUrl + ConfigWorker.GetConfigValue("BookNodeCld");
        public static string SearchApi= RemoteUrl + ConfigWorker.GetConfigValue("Search");
        public static string SetListApi= RemoteUrl + ConfigWorker.GetConfigValue("SetList");

        public static List<DictionaryEntry> SortSource = new List<DictionaryEntry>();
        public static List<Code> siju = new List<Code>();
        public static List<Code> yewu = new List<Code>();
        public static List<Code> buhao = new List<Code>();
        public static List<Code> zidingyi = new List<Code>();
        public static List<Code> weijie = new List<Code>();
        public static List<Code> allCode = new List<Code>();

        public static User user { get; set; }

         static Global()
        {
            SortSource.Add(new DictionaryEntry(1,"时间倒序（默认）"));
            SortSource.Add(new DictionaryEntry(2, "首字母拼音排序"));

            DbHelper db = new DbHelper();
            siju = db.getCode("org");
            yewu = db.getCode("biz");
            buhao = db.getCode("buhao");
            zidingyi = db.getCode("tag");
            weijie = db.getCode("release");

            allCode = db.getCode();
        }

        public static string GetCodeValueById(string Id)
        {
            if (Id.Contains(","))
            {
                var idList = Id.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                var list = allCode.Where(c=>idList.Contains(c.Id)).Select(c=>c.desc);
                return string.Join(",", list.ToList());
            }
            else
            {
                var code = allCode.FirstOrDefault(c => c.Id == Id);
                if (code == null) { return string.Empty; }
                else
                {
                    return code.desc;
                }
            }
        }
    }

    public class UTC
    {
        public static double ConvertDateTimeInt(System.DateTime time)
        {
            double intResult = 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            intResult = (time - startTime).TotalMilliseconds;
            return intResult;
        }

        public static DateTime ConvertIntDatetime(double utc)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            startTime = startTime.AddMilliseconds(utc);
            //startTime = startTime.AddHours(8);//转化为北京时间(北京时间=UTC时间+8小时 )    
            return startTime;
        }
    }

    public class HttpWorker
    {
        private static string GetMD5String(string str)
        {
            MD5 md5 = MD5.Create();
            byte[] data = Encoding.UTF8.GetBytes(str);
            byte[] data2 = md5.ComputeHash(data);

            return GetbyteToString(data2).ToLower();
            //return BitConverter.ToString(data2).Replace("-", "").ToLower();
        }
        private static string GetbyteToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public static string HttpGet(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Timeout = 1000 * 30;
            request.ReadWriteTimeout = 1000 * 30;
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            request.Headers.Add("X-Appid", Global.Appid);
            request.Headers.Add("X-CurTime", UTC.ConvertDateTimeInt(DateTime.Now).ToString());
            request.Headers.Add("X-CheckSum", GetMD5String(Global.Appkey + UTC.ConvertDateTimeInt(DateTime.Now).ToString()));

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        public static string PostJson(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
            request.Headers.Add("X-Appid", Global.Appid);
            request.Headers.Add("X-CurTime", UTC.ConvertDateTimeInt(DateTime.Now).ToString());
            request.Headers.Add("X-CheckSum", GetMD5String(Global.Appkey+ UTC.ConvertDateTimeInt(DateTime.Now).ToString()));
            //request.CookieContainer = cookie;
            Stream myRequestStream = request.GetRequestStream();
            StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
            myStreamWriter.Write(postDataStr);
            myStreamWriter.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //response.Cookies = cookie.GetCookies(response.ResponseUri);
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        /// <summary>
        /// 指定Post地址使用Get 方式获取全部字符串
        /// </summary>
        /// <param name="url">请求后台地址</param>
        /// <param name="content">Post提交数据内容(utf-8编码的)</param>
        /// <returns></returns>
        public static string PostStr(string url, string content)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";

            #region 添加Post 参数
            byte[] data = Encoding.UTF8.GetBytes(content);
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        /// <summary>
        /// 指定Post地址使用Get 方式获取全部字符串
        /// </summary>
        /// <param name="url">请求后台地址</param>
        /// <returns></returns>
        public static string PostDic(string url, Dictionary<string, string> dic)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            #region 添加Post 参数
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var item in dic)
            {
                if (i > 0)
                    builder.Append("&");
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                i++;
            }
            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
    }

    public class ConfigWorker
    {
        public static string GetConfigValue(string key)
        {
            if (System.Configuration.ConfigurationManager.AppSettings[key] != null)
                return System.Configuration.ConfigurationManager.AppSettings[key];
            else

                return string.Empty;
        }

        public static void SetConfigValue(string key, string value)
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfa.AppSettings.Settings[key].Value = value;
            cfa.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
    }

    public class BalloonBox
    {
        static DevComponents.DotNetBar.Balloon box = new DevComponents.DotNetBar.Balloon();
        static BalloonBox()
        {

        }

        public static void showBox(Form form, Control control, string caption, string content)
        {
            box.Owner = form;
            box.CaptionText = caption;
            box.Text = content;
            box.Style = DevComponents.DotNetBar.eBallonStyle.Alert;
            box.AlertAnimation = DevComponents.DotNetBar.eAlertAnimation.None;
            box.AutoResize();
            box.AutoClose = true;
            box.AutoCloseTimeOut = 3;
            box.Show(control,false);
        }
    }
}
