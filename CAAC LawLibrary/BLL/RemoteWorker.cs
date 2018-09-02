using CAAC_LawLibrary.BLL.Entity;
using CAAC_LawLibrary.DAL;
using CAAC_LawLibrary.Utity;
using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAAC_LawLibrary.BLL
{
    /// <summary>
    /// 用于与远程接口交互
    /// </summary>
    public class RemoteWorker
    {
        private static DbHelper db = new DbHelper();

        public static bool checkInternet()
        {
            try
            {
                Uri uri = new Uri(Global.RemoteUrl);
                Ping objPingSender = new Ping();
                PingOptions objPinOptions = new PingOptions();
                objPinOptions.DontFragment = true;
                string data = "";
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                int intTimeout = 1000*5;
                PingReply objPinReply = objPingSender.Send(uri.Authority.Substring(0,uri.Authority.IndexOf(":")),intTimeout, buffer, objPinOptions);
                string strInfo = objPinReply.Status.ToString();
                if (strInfo == "Success")
                {
                    Global.online = true;
                }
                else
                {
                    Global.online = false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show("请检查远程端口设置", "远程端口设置不正确", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //List<string> urlList = Global.RemoteUrl.Split(new string[] { "://", ":" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            //if (urlList.Count > 2)
            //{ 
            //    IPAddress ip = IPAddress.Parse(urlList[1]);
            //    IPEndPoint point = new IPEndPoint(ip, int.Parse(urlList[2]));
            //    try
            //    {
            //        TcpClient tcp = new TcpClient();
            //        tcp.Connect(point);
            //        Global.online = true;
            //    }
            //    catch (Exception)
            //    {
            //        Global.online = false;
            //    }
            //    return true;
            //}
            //else
            //{
            //    MessageBoxEx.Show("请检查远程端口设置","远程端口设置不正确",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //    return false;
            //}
        }

        /// <summary>
        /// 获取设置列表
        /// </summary>
        public static void getSetResponse()
        {
            string sets = HttpWorker.HttpGet(Global.SetListApi, "");
            SetListResponse setListResponse = TranslationWorker.ConvertStringToEntity<SetListResponse>(sets);
            db.refreshCode(setListResponse.ConvertToCodes());
        }

        /// <summary>
        /// 获取法规列表
        /// </summary>
        public static void getLawResponse()
        {
            string laws = HttpWorker.HttpGet(Global.AllBooksApi, "beginTime=" + UTC.ConvertDateTimeInt(new DateTime(2010, 01, 01)).ToString());
            AllBooksResponse allBookResponse = TranslationWorker.ConvertStringToEntity<AllBooksResponse>(laws);
            db.refreshLaw(allBookResponse.ConvertToLaws());
        }

        /// <summary>
        /// 获取意见列表
        /// </summary>
        /// <param name="bookId"></param>
        public static void getOpinionList(string bookId)
        {
            string opinions = HttpWorker.HttpGet(Global.OpinionListApi, "bookId="+bookId);
            OpinionResponse opinionResponse = TranslationWorker.ConvertStringToEntity<OpinionResponse>(opinions);
            db.refreshComment(opinionResponse.ConverToComments());
        }
    }
}
