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
                PingReply objPinReply = objPingSender.Send(uri.Authority, intTimeout, buffer, objPinOptions);
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
                //MessageBox.Show(ex.Message);
                //MessageBox.Show(ex.StackTrace);
                //MessageBoxEx.Show("请检查远程端口设置", "远程端口设置不正确", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Global.online = false;
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
            if (responseStr == "error")
            {
                return false;
            }
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
            if (sets == "error")
            {
                return;
            }
            SetListResponse setListResponse = TranslationWorker.ConvertStringToEntity<SetListResponse>(sets);
            db.refreshCode(setListResponse.ConvertToCodes());
        }

        /// <summary>
        /// 获取全部法规列表
        /// </summary>
        public static void getLawResponse()
        {
            string laws = HttpWorker.HttpGet(Global.AllBooksApi, "beginTime=" + UTC.ConvertDateTimeInt(new DateTime(2010, 01, 01)).ToString());
            if (laws == "error")
            {
                return;
            }
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
            if (opinions == "error")
            {
                return;
            }
            OpinionResponse opinionResponse = TranslationWorker.ConvertStringToEntity<OpinionResponse>(opinions);
            db.refreshComment(opinionResponse.ConverToComments());
            //获取评论后获取评论人的信息
            List<User> userList = getUserInfoList(opinionResponse.data.list.Select(d => d.readerId).ToList());
            foreach (User user in userList)
            {
                db.saveUser(user);
            }
        }

        /// <summary>
        /// 获取某一法规的整体目录
        /// </summary>
        /// <param name="bookId"></param>
        //public static Tuple<List<Node>, List<Node>> getBookContent(string bookId)
        //{
        //    string bookContents = HttpWorker.HttpGet(Global.BookContentApi, "bookId=" + bookId);
        //    BookContentResponse bookContentResponse = TranslationWorker.ConvertStringToEntity<BookContentResponse>(bookContents);
        //    List<Node> nodes = bookContentResponse.ConvertToNodes();
        //    db.refreshNode(nodes);
        //    List<Node> details = getNodeDetail(nodes.Select(n => n.Id).ToList());
        //    return new Tuple<List<Node>, List<Node>>(nodes, details);
        //}

        /// <summary>
        /// 获取某一法规的整体目录
        /// </summary>
        /// <param name="bookId"></param>
        public static List<Node> getBookContent(string bookId)
        {
            try
            {
                string bookContents = HttpWorker.HttpGet(Global.BookContentApi, "bookId=" + bookId);
                BookContentResponse bookContentResponse = TranslationWorker.ConvertStringToEntity<BookContentResponse>(bookContents);
                List<Node> nodes = bookContentResponse.ConvertToNodes();
                db.refreshNode(nodes);
                return nodes;
            }
            catch (Exception)
            {
                MessageBox.Show("操作超时");
                return new List<Node>();
            }
        }

        /// <summary>
        /// 一次性获取多个章节内容
        /// </summary>
        /// <param name="nodeIdList"></param>
        public static bool getNodeDetail(List<string> nodeIdList, bool downloadImage = false)
        {
            try
            {
                string nodeDetails = HttpWorker.HttpGet(Global.NodeDetailApi, "nodeIds=" + string.Join(",", nodeIdList));
                NodeDetailResponse nodeDtailResponse = TranslationWorker.ConvertStringToEntity<NodeDetailResponse>(nodeDetails);
                List<Node> nodes = nodeDtailResponse.ConvertToNodes();
                if (downloadImage)
                {
                    foreach (Node node in nodes)//下载图片到本地，并生成离线内容
                    {
                        List<string> urls = HtmlCleaner.GetImageUrl(node.content);
                        foreach (string url in urls)
                        {
                            HttpWorker.SaveImg(url, node.lawId);
                        }
                        node.offlineContent = HtmlCleaner.ChangeImageUrlToLocalPath(node.content, node.lawId);
                    }
                }
                db.refreshNode(nodes, detailOnly: true);
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("操作超时");
                return false;
            }
        }
        /// <summary>
        /// 获取一个章节的内容
        /// </summary>
        /// <param name="nodeId"></param>
        public static void getNodeDetail(string nodeId)
        {
            string nodeDetails = HttpWorker.HttpGet(Global.NodeDetailApi, "nodeIds=" + nodeId);
            if (nodeDetails == "error")
            {
                return;
            }
            NodeDetailResponse nodeDtailResponse = TranslationWorker.ConvertStringToEntity<NodeDetailResponse>(nodeDetails);
            List<Node> nodes = nodeDtailResponse.ConvertToNodes();
            foreach (Node node in nodes)//下载图片到本地，并生成离线内容
            {
                List<string> urls = HtmlCleaner.GetImageUrl(node.content);
                foreach (string url in urls)
                {
                    HttpWorker.SaveImg(url, node.lawId);
                }
                node.offlineContent = HtmlCleaner.ChangeImageUrlToLocalPath(node.content,node.lawId);
            }
            db.refreshNode(nodes, detailOnly: true);
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
            if (historyResult == "error")
            {
                return result;
            }
            HistoryResponse history = TranslationWorker.ConvertStringToEntity<HistoryResponse>(historyResult);
            result = string.Join(Environment.NewLine, history.data.list.Select(l => l.version));
            return result;
        }

        /// <summary>
        /// 获取搜索结果
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<string> getSearch(string keyword)
        {
            string result = string.Empty;
            result = HttpWorker.HttpGet(Global.SearchApi, "bookName=" + keyword);
            if (result == "error")
            {
                return new List<string>();
            }
            SearchResponse response = TranslationWorker.ConvertStringToEntity<SearchResponse>(result);
            List<string> lawIdList = new List<string>();
            if (response != null)
            {
                if (response.status == "200")
                {
                    lawIdList = response.data.list.Select(l => l.id.ToString()).ToList();
                }
            }
            return lawIdList;
        }
        /// <summary>
        /// 获取预下载法规id
        /// </summary>
        /// <returns></returns>
        public static List<string> getPreloadLaw()
        {
            string result = HttpWorker.HttpGet(Global.WorkerRulesUrl, "usrid=" + Global.user.Id);
            if (result == "error")
            {
                return new List<string>();
            }
            WorkerRulesResponse response = TranslationWorker.ConvertStringToEntity<WorkerRulesResponse>(result);
            List<string> lawIdList = new List<string>();
            if (response != null)
            {
                if (response.status == "200")
                {
                    lawIdList = response.data.Select(l => l.jcyjid).ToList();
                }
            }
            return lawIdList;
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
            catch (Exception ex)
            {
                MessageBox.Show("提交评论失败，请重试。原因："+ex.Message);
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
                result = HttpWorker.PostStr(Global.ConsultCommitApi, consult.ToJson());
            }
            catch (Exception ex)
            {
                MessageBox.Show("提交征询意见失败，请重试。原因："+ex.Message);
            }
            return result;
        }
        #endregion
    }



}
