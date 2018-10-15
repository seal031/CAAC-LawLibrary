using CAAC_LawLibrary.BLL.Entity;
using CAAC_LawLibrary.DAL;
using CAAC_LawLibrary.Entity;
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
                int intTimeout = 1000 * 5;
                PingReply objPinReply = objPingSender.Send(uri.Authority.Substring(0, uri.Authority.IndexOf(":")), intTimeout, buffer, objPinOptions);
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
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
                MessageBoxEx.Show("请检查远程端口设置", "远程端口设置不正确", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        public static bool getloginResponse(string username, string password)
        {
            string responseStr = HttpWorker.HttpGet(Global.LoginUrl, "yhm=" + username + "&mm=" + password);
            LoginResponse response = TranslationWorker.ConvertStringToEntity<LoginResponse>(responseStr);
            response.SetUserId();
            if (response.code == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获取登陆用户信息
        /// </summary>
        public static void getUserInfo()
        {
            string userInfoStr = HttpWorker.HttpGet(Global.WorkerInfoUrl, "usrid=" + Global.user.Id);
            UserInfoResponse userInfo = TranslationWorker.ConvertStringToEntity<UserInfoResponse>(userInfoStr);
            userInfo.setUserInfo();
        }
        /// <summary>
        /// 获取评论用户信息
        /// </summary>
        /// <param name="userIdList">评论用户id列表</param>
        /// <returns></returns>
        public static List<User> getUserInfoList(List<string> userIdList)
        {
            string userInfoStr = HttpWorker.HttpGet(Global.WorkerInfoUrl, "usrid=" + string.Join(",", userIdList));
            UserInfoResponse userInfo = TranslationWorker.ConvertStringToEntity<UserInfoResponse>(userInfoStr);
            return userInfo.ConvertToUsers();
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

        /// <summary>
        /// 获取法规整体目录
        /// </summary>
        /// <param name="bookId"></param>
        public static Tuple<List<Node>, List<Node>> getBookContent(string bookId)
        {
            string bookContents = HttpWorker.HttpGet(Global.BookContentApi, "bookId=" + bookId);
            BookContentResponse bookContentResponse = TranslationWorker.ConvertStringToEntity<BookContentResponse>(bookContents);
            List<Node> nodes = bookContentResponse.ConvertToNodes();
            db.refreshNode(nodes);
            List<Node> details = getNodeDetail(nodes.Select(n => n.Id).ToList());
            return new Tuple<List<Node>, List<Node>>(nodes, details);
        }

        /// <summary>
        /// 获取章节内容
        /// </summary>
        /// <param name="nodeIdList"></param>
        public static List<Node> getNodeDetail(List<string> nodeIdList)
        {
            string nodeDetails = HttpWorker.HttpGet(Global.NodeDetailApi, "nodeIds=" + string.Join(",", nodeIdList));
            NodeDetailResponse nodeDtailResponse = TranslationWorker.ConvertStringToEntity<NodeDetailResponse>(nodeDetails);
            List<Node> nodes = nodeDtailResponse.ConvertToNodes();
            db.refreshNode(nodes,detailOnly:true);
            return nodes;
        }
        /// <summary>
        /// 获取修订列表内容
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public static string getHistory(string bookId)
        {
            string result = string.Empty;
            string historyResult = HttpWorker.HttpGet(Global.HistoryApi, "bookId=" + bookId);
            return result;
        }

        #region post
        /// <summary>
        /// 提交评论
        /// </summary>
        /// <param name="opinion"></param>
        /// <returns></returns>
        public static string postOpinion(OpinionCommitRequest opinion)
        {
            string result = string.Empty;
            try
            {
                //result= HttpWorker.PostJson(Global.OpinionCommitApi, opinion.ToJson());
                result = HttpWorker.PostStr(Global.OpinionCommitApi, opinion.ToJson());
            }
            catch (Exception)
            {
                MessageBox.Show("提交评论失败，请重试");
            }
            return result;
        }
        /// <summary>
        /// 提交意见征询
        /// </summary>
        /// <param name="consult"></param>
        /// <returns></returns>
        public static string postCommit(ConsultRequest consult)
        {
            string result = string.Empty;
            try
            {
                result = HttpWorker.PostJson(Global.ConsultCommitApi, consult.ToJson());
                MessageBox.Show("提交成功");
            }
            catch (Exception)
            {
                MessageBox.Show("提交征询意见失败，请重试");
            }
            return result;
        }
        #endregion
    }
}
