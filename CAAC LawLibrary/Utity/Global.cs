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
using System.Text.RegularExpressions;
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
        public static string LoginUrl = ConfigWorker.GetConfigValue("LoginUrl");
        public static string WorkerInfoUrl = ConfigWorker.GetConfigValue("WorkerInfoUrl");
        public static string WorkerRulesUrl = ConfigWorker.GetConfigValue("WorkerRules");
        public static string ConsultCommitApi = RemoteUrl + ConfigWorker.GetConfigValue("ConsultCommit");
        public static string OpinionListApi = RemoteUrl + ConfigWorker.GetConfigValue("OpinionList");
        public static string OpinionCommitApi = RemoteUrl + ConfigWorker.GetConfigValue("OpinionCommit");
        public static string AllBooksApi = RemoteUrl + ConfigWorker.GetConfigValue("AllBooks");
        public static string NodeDetailApi = RemoteUrl + ConfigWorker.GetConfigValue("NodeDetail");
        public static string BookContentApi = RemoteUrl + ConfigWorker.GetConfigValue("BookContent");
        public static string BookNodeCldApi = RemoteUrl + ConfigWorker.GetConfigValue("BookNodeCld");
        public static string SearchApi = RemoteUrl + ConfigWorker.GetConfigValue("Search");
        public static string SetListApi = RemoteUrl + ConfigWorker.GetConfigValue("SetList");
        public static string HistoryApi = RemoteUrl + ConfigWorker.GetConfigValue("History");

        public static List<DictionaryEntry> SortSource = new List<DictionaryEntry>();
        public static List<DictionaryEntry> DownloadState = new List<DictionaryEntry>();
        public static List<Code> siju = new List<Code>();
        public static List<Code> banwendanwei = new List<Code>();
        public static List<Code> yewu = new List<Code>();
        public static List<Code> buhao = new List<Code>();
        public static List<Code> zidingyi = new List<Code>();
        public static List<Code> weijie = new List<Code>();
        public static List<Code> allCode = new List<Code>();
        public static List<DictionaryEntry> tag = new List<DictionaryEntry>();
        static DbHelper db = new DbHelper();

        public static User user { get; set; }

        static Global()
        {
            SortSource.Add(new DictionaryEntry(1, "时间倒序（默认）"));
            SortSource.Add(new DictionaryEntry(2, "首字母拼音排序"));

            DownloadState.Add(new DictionaryEntry(0, "全部任务"));
            DownloadState.Add(new DictionaryEntry(1, "下载中"));
            DownloadState.Add(new DictionaryEntry(2, "已完成"));

            tag.Add(new DictionaryEntry("全", "全部"));
            tag.Add(new DictionaryEntry("定", "定义"));
            tag.Add(new DictionaryEntry("类", "业务分类"));
            tag.Add(new DictionaryEntry("键", "关键字"));
            tag.Add(new DictionaryEntry("依", "依赖"));
            tag.Add(new DictionaryEntry("罚", "罚则"));
            tag.Add(new DictionaryEntry("政", "行政罚则"));
            tag.Add(new DictionaryEntry("律", "纪律处分"));
            tag.Add(new DictionaryEntry("手", "行政手段"));
            tag.Add(new DictionaryEntry("他", "其他责任"));
            tag.Add(new DictionaryEntry("信", "信用手段"));
            tag.Add(new DictionaryEntry("许", "许可手段"));
            tag.Add(new DictionaryEntry("强", "行政强制"));

            siju = db.getCode("org");
            siju.Insert(0, new Code() { Id = null, desc = "不限司局" });
            banwendanwei = db.getCode("release");
            banwendanwei.Insert(0, new Code() { Id = null, desc = "不限办文单位" });
            yewu = db.getCode("biz");
            yewu.Insert(0, new Code() { Id = null, desc = "不限业务分类" });
            buhao = db.getCode("buhao");
            buhao.Insert(0, new Code() { Id = null, desc = "不限部号范围" });
            zidingyi = db.getCode("tag");
            zidingyi.Insert(0, new Code() { Id = null, desc = "不限自定义标签" });
            weijie = db.getCode("type");
            weijie.Insert(0, new Code() { Id = null, desc = "不限位阶范围" });

        }

        public static string GetCodeValueById(string Id)
        {
            if (allCode.Count == 0)
            {
                allCode = db.getCode();
            }
            if (Id.Contains(","))
            {
                var idList = Id.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                var list = allCode.Where(c => idList.Contains(c.Id)).Select(c => c.desc);
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

        /// <summary>
        /// 数字转小写汉字，用于修订令
        /// </summary>
        /// <param name="numberStr"></param>
        /// <returns></returns>
        public static string NumberToChinese(string numberStr)
        {
            string numStr = "0123456789";
            string chineseStr = "零一二三四五六七八九";
            char[] c = numberStr.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                int index = numStr.IndexOf(c[i]);
                if (index != -1)
                    c[i] = chineseStr.ToCharArray()[index];
            }
            numStr = null;
            chineseStr = null;
            return new string(c);
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
            try
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
            catch (WebException we)
            {
                MessageBox.Show("获取数据超时："+we.Message);
                Global.online = false;
                return "error";
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取数据失败："+ex.Message);
                Global.online = false;
                return "error";
            }
        }

        public static string PostJson(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "text/html;charset=utf-8";
            //request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
            request.Headers.Add("X-Appid", Global.Appid);
            request.Headers.Add("X-CurTime", UTC.ConvertDateTimeInt(DateTime.Now).ToString());
            request.Headers.Add("X-CheckSum", GetMD5String(Global.Appkey+ UTC.ConvertDateTimeInt(DateTime.Now).ToString()));
            
            Stream myRequestStream = request.GetRequestStream();
            StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("utf-8"));
            myStreamWriter.Write(postDataStr);
            myStreamWriter.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            
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
            try
            {
                string result = "";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "POST";
                //req.ContentType = "application/x-www-form-urlencoded";
                req.ContentType = "application/json";
                req.Headers.Add("X-Appid", Global.Appid);
                req.Headers.Add("X-CurTime", UTC.ConvertDateTimeInt(DateTime.Now).ToString());
                req.Headers.Add("X-CheckSum", GetMD5String(Global.Appkey + UTC.ConvertDateTimeInt(DateTime.Now).ToString()));

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
            catch (WebException we)
            {
                MessageBox.Show("提交数据超时" + we.Message);
                Global.online = false;
                return "error";
            }
            catch (Exception ex)
            {
                MessageBox.Show("提交数据失败" + ex.Message);
                Global.online = false;
                return "error";
            }
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
        /// <summary>
        /// 保存文件到本地，路径为/IMAGE/用户ID/法规id/文件名
        /// </summary>
        /// <param name="url"></param>
        /// <param name="lawId"></param>
        /// <returns></returns>
        public static bool SaveImg(string url,string lawId)
        {
            try
            {
                WebClient wc = new WebClient();
                string fileName = getFileNameFromUri(url);
                string path = Path.Combine(Environment.CurrentDirectory, "Image", Global.user.Id , lawId);
                checkDir(path);
                wc.DownloadFile(url, Path.Combine(path, fileName));

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 检查指定目录是否存在,如不存在则创建
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool checkDir(string path)
        {
            try
            {
                if (!Directory.Exists(path))//如果不存在就创建file文件夹　　             　　              
                    Directory.CreateDirectory(path);//创建该文件夹　　            
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string getFileNameFromUri(string uri)
        {
            string str = string.Empty;
            int pos1 = uri.LastIndexOf('/');
            int pos2 = uri.LastIndexOf('\\');
            int pos = Math.Max(pos1, pos2);
            if (pos < 0)
                str = uri;
            else
                str = uri.Substring(pos + 1);
            return str;
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
            if (cfa.AppSettings.Settings.AllKeys.Contains(key))
            {
                cfa.AppSettings.Settings[key].Value = value;
            }
            else
            {
                cfa.AppSettings.Settings.Add(key, value);
            }
            cfa.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static List<string> GetUserInfoConfig()
        {
            List<string> list = new List<string>();
            string[] arrayKeys= ConfigurationManager.AppSettings.AllKeys;
            for (int i = arrayKeys.Length - 1; i >= 0; i--)
            {
                if (arrayKeys[i] == "ClientSettingsProvider.ServiceUri")//以此项为分界，之后的都是用户登录记录。添加系统配置项时要加到此项前面去
                {
                    break;
                }
                else
                {
                    list.Add(arrayKeys[i]);
                }
            }
            return list;
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

    public class HtmlCleaner
    {
        private static string reg = @"[<].*?[>]";
        private static string regEx_space = "\\s*|\t|\r|\n";
        private static string reg_Image = @"<img.*?src=""(?<src>[^""]*)""[^>]*>";

        public static string clean(string content)
        {
            return Regex.Replace(Regex.Replace(content, reg, ""), regEx_space, "");
        }
        /// <summary>
        /// 将正文内容中的图片网络地址替换为本地地址
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string ChangeImageUrlToLocalPath(string content,string lawId)
        {
            List<string> urls = GetImageUrl(content);
            foreach (string url in urls)
            {
                string fileName = HttpWorker.getFileNameFromUri(url);
                string localPath = Path.Combine("CurrentApplicationPath", "Image", "CurrentLoginUser" ,lawId, fileName);
                content = content.Replace(url,localPath);
            }
            return content;
        }


        /// <summary>
        /// 从html中提取所有img的url
        /// </summary>
        /// <param name="conent"></param>
        /// <returns></returns>
        public static List<string> GetImageUrl(string content)
        {
            List<string> list = new List<string>();
            Regex reg = new Regex(reg_Image, RegexOptions.IgnoreCase);
            MatchCollection mc = reg.Matches(content);
            foreach (Match m in mc)
            {
                list.Add(m.Groups["src"].Value);
            }
            return list;
        }
    }
    
    public static class ChineseToPinYin
    {
        private static readonly Dictionary<int, string> CodeCollections = new Dictionary<int, string> {
{ -20319, "a" }, { -20317, "ai" }, { -20304, "an" }, { -20295, "ang" }, { -20292, "ao" }, { -20283, "ba" }, { -20265, "bai" },
{ -20257, "ban" }, { -20242, "bang" }, { -20230, "bao" }, { -20051, "bei" }, { -20036, "ben" }, { -20032, "beng" }, { -20026, "bi" }
, { -20002, "bian" }, { -19990, "biao" }, { -19986, "bie" }, { -19982, "bin" }, { -19976, "bing" }, { -19805, "bo" },
{ -19784, "bu" }, { -19775, "ca" }, { -19774, "cai" }, { -19763, "can" }, { -19756, "cang" }, { -19751, "cao" }, { -19746, "ce" },
{ -19741, "ceng" }, { -19739, "cha" }, { -19728, "chai" }, { -19725, "chan" }, { -19715, "chang" }, { -19540, "chao" },
{ -19531, "che" }, { -19525, "chen" }, { -19515, "cheng" }, { -19500, "chi" }, { -19484, "chong" }, { -19479, "chou" },
{ -19467, "chu" }, { -19289, "chuai" }, { -19288, "chuan" }, { -19281, "chuang" }, { -19275, "chui" }, { -19270, "chun" },
{ -19263, "chuo" }, { -19261, "ci" }, { -19249, "cong" }, { -19243, "cou" }, { -19242, "cu" }, { -19238, "cuan" },
{ -19235, "cui" }, { -19227, "cun" }, { -19224, "cuo" }, { -19218, "da" }, { -19212, "dai" }, { -19038, "dan" }, { -19023, "dang" },
{ -19018, "dao" }, { -19006, "de" }, { -19003, "deng" }, { -18996, "di" }, { -18977, "dian" }, { -18961, "diao" }, { -18952, "die" }
, { -18783, "ding" }, { -18774, "diu" }, { -18773, "dong" }, { -18763, "dou" }, { -18756, "du" }, { -18741, "duan" },
{ -18735, "dui" }, { -18731, "dun" }, { -18722, "duo" }, { -18710, "e" }, { -18697, "en" }, { -18696, "er" }, { -18526, "fa" },
{ -18518, "fan" }, { -18501, "fang" }, { -18490, "fei" }, { -18478, "fen" }, { -18463, "feng" }, { -18448, "fo" }, { -18447, "fou" }
, { -18446, "fu" }, { -18239, "ga" }, { -18237, "gai" }, { -18231, "gan" }, { -18220, "gang" }, { -18211, "gao" }, { -18201, "ge" },
{ -18184, "gei" }, { -18183, "gen" }, { -18181, "geng" }, { -18012, "gong" }, { -17997, "gou" }, { -17988, "gu" }, { -17970, "gua" }
, { -17964, "guai" }, { -17961, "guan" }, { -17950, "guang" }, { -17947, "gui" }, { -17931, "gun" }, { -17928, "guo" },
{ -17922, "ha" }, { -17759, "hai" }, { -17752, "han" }, { -17733, "hang" }, { -17730, "hao" }, { -17721, "he" }, { -17703, "hei" },
{ -17701, "hen" }, { -17697, "heng" }, { -17692, "hong" }, { -17683, "hou" }, { -17676, "hu" }, { -17496, "hua" },
{ -17487, "huai" }, { -17482, "huan" }, { -17468, "huang" }, { -17454, "hui" }, { -17433, "hun" }, { -17427, "huo" },
{ -17417, "ji" }, { -17202, "jia" }, { -17185, "jian" }, { -16983, "jiang" }, { -16970, "jiao" }, { -16942, "jie" },
{ -16915, "jin" }, { -16733, "jing" }, { -16708, "jiong" }, { -16706, "jiu" }, { -16689, "ju" }, { -16664, "juan" },
{ -16657, "jue" }, { -16647, "jun" }, { -16474, "ka" }, { -16470, "kai" }, { -16465, "kan" }, { -16459, "kang" }, { -16452, "kao" },
{ -16448, "ke" }, { -16433, "ken" }, { -16429, "keng" }, { -16427, "kong" }, { -16423, "kou" }, { -16419, "ku" }, { -16412, "kua" }
, { -16407, "kuai" }, { -16403, "kuan" }, { -16401, "kuang" }, { -16393, "kui" }, { -16220, "kun" }, { -16216, "kuo" },
{ -16212, "la" }, { -16205, "lai" }, { -16202, "lan" }, { -16187, "lang" }, { -16180, "lao" }, { -16171, "le" }, { -16169, "lei" },
{ -16158, "leng" }, { -16155, "li" }, { -15959, "lia" }, { -15958, "lian" }, { -15944, "liang" }, { -15933, "liao" },
{ -15920, "lie" }, { -15915, "lin" }, { -15903, "ling" }, { -15889, "liu" }, { -15878, "long" }, { -15707, "lou" }, { -15701, "lu" },
{ -15681, "lv" }, { -15667, "luan" }, { -15661, "lue" }, { -15659, "lun" }, { -15652, "luo" }, { -15640, "ma" }, { -15631, "mai" },
{ -15625, "man" }, { -15454, "mang" }, { -15448, "mao" }, { -15436, "me" }, { -15435, "mei" }, { -15419, "men" },
{ -15416, "meng" }, { -15408, "mi" }, { -15394, "mian" }, { -15385, "miao" }, { -15377, "mie" }, { -15375, "min" },
{ -15369, "ming" }, { -15363, "miu" }, { -15362, "mo" }, { -15183, "mou" }, { -15180, "mu" }, { -15165, "na" }, { -15158, "nai" },
{ -15153, "nan" }, { -15150, "nang" }, { -15149, "nao" }, { -15144, "ne" }, { -15143, "nei" }, { -15141, "nen" }, { -15140, "neng" }
, { -15139, "ni" }, { -15128, "nian" }, { -15121, "niang" }, { -15119, "niao" }, { -15117, "nie" }, { -15110, "nin" },
{ -15109, "ning" }, { -14941, "niu" }, { -14937, "nong" }, { -14933, "nu" }, { -14930, "nv" }, { -14929, "nuan" }, { -14928, "nue" }
, { -14926, "nuo" }, { -14922, "o" }, { -14921, "ou" }, { -14914, "pa" }, { -14908, "pai" }, { -14902, "pan" }, { -14894, "pang" },
{ -14889, "pao" }, { -14882, "pei" }, { -14873, "pen" }, { -14871, "peng" }, { -14857, "pi" }, { -14678, "pian" },
{ -14674, "piao" }, { -14670, "pie" }, { -14668, "pin" }, { -14663, "ping" }, { -14654, "po" }, { -14645, "pu" }, { -14630, "qi" },
{ -14594, "qia" }, { -14429, "qian" }, { -14407, "qiang" }, { -14399, "qiao" }, { -14384, "qie" }, { -14379, "qin" },
{ -14368, "qing" }, { -14355, "qiong" }, { -14353, "qiu" }, { -14345, "qu" }, { -14170, "quan" }, { -14159, "que" },
{ -14151, "qun" }, { -14149, "ran" }, { -14145, "rang" }, { -14140, "rao" }, { -14137, "re" }, { -14135, "ren" }, { -14125, "reng" }
, { -14123, "ri" }, { -14122, "rong" }, { -14112, "rou" }, { -14109, "ru" }, { -14099, "ruan" }, { -14097, "rui" }, { -14094, "run" }
, { -14092, "ruo" }, { -14090, "sa" }, { -14087, "sai" }, { -14083, "san" }, { -13917, "sang" }, { -13914, "sao" }, { -13910, "se" }
, { -13907, "sen" }, { -13906, "seng" }, { -13905, "sha" }, { -13896, "shai" }, { -13894, "shan" }, { -13878, "shang" },
{ -13870, "shao" }, { -13859, "she" }, { -13847, "shen" }, { -13831, "sheng" }, { -13658, "shi" }, { -13611, "shou" },
{ -13601, "shu" }, { -13406, "shua" }, { -13404, "shuai" }, { -13400, "shuan" }, { -13398, "shuang" }, { -13395, "shui" },
{ -13391, "shun" }, { -13387, "shuo" }, { -13383, "si" }, { -13367, "song" }, { -13359, "sou" }, { -13356, "su" },
{ -13343, "suan" }, { -13340, "sui" }, { -13329, "sun" }, { -13326, "suo" }, { -13318, "ta" }, { -13147, "tai" }, { -13138, "tan" },
{ -13120, "tang" }, { -13107, "tao" }, { -13096, "te" }, { -13095, "teng" }, { -13091, "ti" }, { -13076, "tian" },
{ -13068, "tiao" }, { -13063, "tie" }, { -13060, "ting" }, { -12888, "tong" }, { -12875, "tou" }, { -12871, "tu" },
{ -12860, "tuan" }, { -12858, "tui" }, { -12852, "tun" }, { -12849, "tuo" }, { -12838, "wa" }, { -12831, "wai" }, { -12829, "wan" }
, { -12812, "wang" }, { -12802, "wei" }, { -12607, "wen" }, { -12597, "weng" }, { -12594, "wo" }, { -12585, "wu" }, { -12556, "xi" }
, { -12359, "xia" }, { -12346, "xian" }, { -12320, "xiang" }, { -12300, "xiao" }, { -12120, "xie" }, { -12099, "xin" },
{ -12089, "xing" }, { -12074, "xiong" }, { -12067, "xiu" }, { -12058, "xu" }, { -12039, "xuan" }, { -11867, "xue" },
{ -11861, "xun" }, { -11847, "ya" }, { -11831, "yan" }, { -11798, "yang" }, { -11781, "yao" }, { -11604, "ye" }, { -11589, "yi" },
{ -11536, "yin" }, { -11358, "ying" }, { -11340, "yo" }, { -11339, "yong" }, { -11324, "you" }, { -11303, "yu" },
{ -11097, "yuan" }, { -11077, "yue" }, { -11067, "yun" }, { -11055, "za" }, { -11052, "zai" }, { -11045, "zan" },
{ -11041, "zang" }, { -11038, "zao" }, { -11024, "ze" }, { -11020, "zei" }, { -11019, "zen" }, { -11018, "zeng" },
{ -11014, "zha" }, { -10838, "zhai" }, { -10832, "zhan" }, { -10815, "zhang" }, { -10800, "zhao" }, { -10790, "zhe" },
{ -10780, "zhen" }, { -10764, "zheng" }, { -10587, "zhi" }, { -10544, "zhong" }, { -10533, "zhou" }, { -10519, "zhu" },
{ -10331, "zhua" }, { -10329, "zhuai" }, { -10328, "zhuan" }, { -10322, "zhuang" }, { -10315, "zhui" }, { -10309, "zhun" },
{ -10307, "zhuo" }, { -10296, "zi" }, { -10281, "zong" }, { -10274, "zou" }, { -10270, "zu" }, { -10262, "zuan" }, { -10260, "zui" }
, { -10256, "zun" }, { -10254, "zuo" } };
        ///   <summary> 
        ///   汉字转拼音 
        ///   </summary> 
        ///   <param   name="txt"> 需要转换的汉字 </param> 
        ///   <returns> 返回汉字对应的拼音 </returns> 
        public static string ToPinYin(string txt)
        {
            txt = txt.Trim();
            byte[] arr = new byte[2];   //每个汉字为2字节 
            StringBuilder result = new StringBuilder();//使用StringBuilder优化字符串连接
            int charCode = 0;
            int arr1 = 0;
            int arr2 = 0;
            char[] arrChar = txt.ToCharArray();
            for (int j = 0; j < arrChar.Length; j++)   //遍历输入的字符 
            {
                arr = System.Text.Encoding.Default.GetBytes(arrChar[j].ToString());//根据系统默认编码得到字节码 
                if (arr.Length == 1)//如果只有1字节说明该字符不是汉字，结束本次循环 
                {
                    result.Append(arrChar[j].ToString());
                    continue;

                }
                arr1 = (short)(arr[0]);   //取字节1 
                arr2 = (short)(arr[1]);   //取字节2 
                charCode = arr1 * 256 + arr2 - 65536;//计算汉字的编码 

                if (charCode > -10254 || charCode < -20319)  //如果不在汉字编码范围内则不改变 
                {
                    result.Append(arrChar[j]);
                }
                else
                {
                    //根据汉字编码范围查找对应的拼音并保存到结果中 
                    //由于charCode的键不一定存在，所以要找比他更小的键上一个键
                    if (!CodeCollections.ContainsKey(charCode))
                    {
                        for (int i = charCode; i <= 0; --i)
                        {
                            if (CodeCollections.ContainsKey(i))
                            {
                                result.Append(" " + CodeCollections[i] + " ");
                                break;
                            }
                        }
                    }
                    else
                    {
                        result.Append(" " + CodeCollections[charCode] + " ");
                    }
                }
            }
            return result.ToString();
        }
    }


    public sealed class Base64
    {
        
        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="codeName">解密采用的编码方式，注意和加密时采用的方式一致</param>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string DecodeBase64(Encoding encode, string result)
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(result);
            try
            {
                decode = encode.GetString(bytes);
            }
            catch
            {
                decode = result;
            }
            return decode;
        }

        /// <summary>
        /// Base64解密，采用utf8编码方式解密
        /// </summary>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string DecodeBase64(string result)
        {
            return DecodeBase64(Encoding.UTF8, result);
        }
    }
}
