using CAAC_LawLibrary.Entity;
using CAAC_LawLibrary.Utity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAAC_LawLibrary.BLL.Entity
{
    /// <summary>
    /// 登陆响应对象
    /// </summary>
    public class LoginResponse:CommonResponse
    {
        public string code { get; set; }
        public string success { get; set; }
        public string msg { get; set; }
        public new dataItem data { get; set; }

        public class dataItem
        {
            public string jwt { get; set; }
            public string usrid { get; set; }
        }

        public void SetUserId()
        {
            if (string.IsNullOrEmpty(code))
            {
                return;
            }
            else if (code == "0")
            {
                MessageBox.Show(msg);
            }
            else
            {
                Global.user.Id = data.usrid;
            }
        }
    }
    /// <summary>
    /// 用户信息响应对象
    /// </summary>
    public class UserInfoResponse:CommonResponse
    {
        public new List<dataItem> data { get; set; }

        public string code { get; set; }
        public string msg { get; set; }
        public string success { get; set; }

        public UserInfoResponse()
        {
            data = new List<dataItem>();
        }

        public class dataItem
        {
            public string id { get; set; }
            public string xm { get; set; }
            public string sjjgmc { get; set; }
            public string jgqc { get; set; }
            public string sjhm { get; set; }
            public string dzyx { get; set; }
        }
        /// <summary>
        /// 设置当前登陆用户的信息
        /// </summary>
        public void setUserInfo()
        {
            if (data.Count > 0)
            {
                dataItem item = data[0];
                Global.user.Xm = item.xm;
                Global.user.Department = item.jgqc;
                Global.user.Phone = item.sjhm;
                Global.user.Email = item.dzyx;
            }
        }

        public List<User> ConvertToUsers()
        {
            List<User> list = new List<User>();
            foreach (dataItem item in data)
            {
                User user = new User();
                user.Id = item.id;
                user.Xm = item.xm;
                user.Department = item.jgqc;
                user.Phone = item.sjhm;
                user.Email = item.dzyx;
                list.Add(user);
            }
            return list;
        }
    }

    /// <summary>
    /// 提交征询post参数对象
    /// </summary>
    public class ConsultRequest
    {
        public string bookId { get; set; }
        public string userId { get; set; }
        public List<consultItem> consultList { get; set; }

        public ConsultRequest()
        {
            consultList = new List<consultItem>();
        }
        public class consultItem
        {
            public string nodeId { get; set; }
            public string text { get; set; }
            public string mark { get; set; }
        }

        public void ConvertFromSuggests(List<Suggest> suggests)
        {
            foreach (Suggest suggest in suggests)
            {
                this.bookId = suggest.lawId;
                this.userId = suggest.userId;
                this.consultList.Add(new consultItem() {
                    nodeId = suggest.nodeId,
                    text = suggest.suggest_content,
                    mark=suggest.remark
                });
            }
        }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 获取意见get参数对象
    /// </summary>
    public class OpinionRequest
    {
        public string bookId { get; set; }
    }

    /// <summary>
    /// 获取意见响应对象
    /// </summary>
    public class OpinionResponse:CommonResponse
    {
        public new dataItem data { get; set; }

        public OpinionResponse()
        {
            data = new dataItem();
        }
        public class dataItem
        {
            public List<opinionItem> list { get; set; }
            public dataItem()
            {
                list = new List<opinionItem>();
            }
        }

        public class opinionItem
        {
            public string bookId { get; set; }
            public long createTime { get; set; }
            public int id { get; set; }
            public string msg { get; set; }
            public int nodeId { get; set; }
            public string readerId { get; set; }
        }

        public List<Comment> ConverToComments()
        {
            List<Comment> comments = new List<Comment>();
            foreach (opinionItem opinion in this.data.list)
            {
            Comment comment = new Comment();
                comment.Id = opinion.id.ToString();
                comment.lawId = opinion.bookId;
                comment.nodeId = opinion.nodeId.ToString();
                comment.userId = opinion.readerId;
                comment.comment_date = UTC.ConvertIntDatetime(opinion.createTime).ToString("yyyy-MM-dd HH:mm:ss");
                comment.comment_content = opinion.msg;
                comments.Add(comment);
            }
            return comments;
        }
    }

    /// <summary>
    /// 提交用户意见post参数对象
    /// </summary>
    public class OpinionCommitRequest
    {
        public string bookId { get; set; }
        public string nodeId { get; set; }
        public string userId { get; set; }
        public string msg { get; set; }

        public void ConvertFromComment(Comment comment)
        {
            this.userId = comment.userId;
            this.bookId = comment.lawId;
            this.nodeId = comment.nodeId;
            this.msg = comment.comment_content;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 获取全部法规列表get参数对象
    /// </summary>
    public class AllBooksRequest
    {
        public int pageSize { get; set; }
        public int pageNum { get; set; }
        public bool history { get; set; }
    }
    /// <summary>
    /// 获取全部法规列表get响应对象
    /// </summary>
    public class AllBooksResponse:CommonResponse
    {
        public new dataItem data { get; set; }

        public AllBooksResponse()
        {
            data = new dataItem();
        }
        public class dataItem
        {
            public List<listItem> list { get; set; }
            public dataItem() { list = new List<listItem>(); }
        }
        public class listItem
        {
            public string title { get; set; }
            public string version { get; set; }
            /// <summary>
            /// 摘要
            /// </summary>
            public string abs { get; set; }
            /// <summary>
            /// 位阶类型
            /// </summary>
            public string bookType { get; set; }
            public string buhao { get; set; }
            public long startDate { get; set; }
            public long endDate { get; set; }
            public int id { get; set; }
            public string linghao { get; set; }
            /// <summary>
            /// 管理单位
            /// </summary>
            public string managerOrg { get; set; }
            /// <summary>
            /// 法规状态 1：提前发布 2：发布中
            /// </summary>
            public int status { get; set; }
            /// <summary>
            /// 最新版本的id 该字段一样代表是同一个法规
            /// </summary>
            public int lastversion { get; set; }
            /// <summary>
            /// 自定义关键字id
            /// </summary>
            public string tag { get; set; }
            /// <summary>
            /// 自定义关键字对象
            /// </summary>
            public List<tagItem> tagList { get; set; }
            /// <summary>
            /// 业务分类id
            /// </summary>
            public string biz { get; set; }
            /// <summary>
            /// 业务分类对象
            /// </summary>
            public List<bizItem> bizList { get; set; }
            /// <summary>
            /// 办文单位
            /// </summary>
            public string release { get; set; }
            /// <summary>
            /// 责罚
            /// </summary>
            public string punish { get; set; }
            /// <summary>
            /// 依赖
            /// </summary>
            public string related { get; set; }
            public listItem()
            {
                tagList = new List<tagItem>();
                bizList = new List<bizItem>();
            }
        }
        public class tagItem
        {
            public string id { get; set; }
            public string desc { get; set; }
        }
        public class bizItem
        {
            public string id { get; set; }
            public string desc { get; set; }
        }

        public List<Law> ConvertToLaws()
        {
            List<Law> laws = new List<Law>();
            foreach (listItem list in this.data.list)
            {
                Law law = new Law();
                law.userId = Global.user.Id;
                law.Id = list.id.ToString();
                law.title = list.title;
                law.version = list.version;
                law.digest = list.abs;
                law.weijie = list.bookType;
                law.buhao = list.buhao;
                law.effectiveDate = UTC.ConvertIntDatetime(list.startDate).ToString("yyyy-MM-dd HH:mm:ss");
                law.expiryDate = UTC.ConvertIntDatetime(list.endDate).ToString("yyyy-MM-dd HH:mm:ss");
                law.linghao = list.linghao;
                law.siju = list.managerOrg;
                law.status = list.status;
                law.lastversion = list.lastversion;
                law.zefa = list.punish;
                law.yilai = list.related;
                law.banwendanwei = list.release;
                law.userLabel = list.tag;//string.Join(",", list.tagList.Select(t => t.desc));
                law.yewu = list.biz;//string.Join(",", list.bizList.Select(b => b.desc));
                law.isLocal = "0";
                laws.Add(law);
            }
            return laws;
        }
    }
    /// <summary>
    /// 获取章节内容请求对象
    /// </summary>
    public class NodeDetailRequest
    {
        public string nodeIds { get; set; }
    }
    /// <summary>
    /// 获取章节内容响应对象
    /// </summary>
    public class NodeDetailResponse:CommonResponse
    {
        public new dataItem data { get; set; }

        public NodeDetailResponse()
        {
            data = new dataItem();
        }
        public class dataItem
        {
            public List<listItem> list { get; set; }
            public dataItem()
            {
                list = new List<listItem>();
            }
        }
        public class listItem
        {
            public int id { get; set; }
            public int bookId { get; set; }
            public string title { get; set; }
            /// <summary>
            /// 标题号
            /// </summary>
            public string nodeNumber { get; set; }
            public string content { get; set; }
            public string nodeClass { get; set; }
            public string nodeRef { get; set; }
            public string nodeDef { get; set; }
            public string nodeKey { get; set; }
        }

        public List<Node> ConvertToNodes()
        {
            List<Node> nodes = new List<Node>();
            foreach (listItem item in this.data.list)
            {
                Node node = new Node();
                node.Id = item.id.ToString();
                node.lawId = item.bookId.ToString();
                node.title = item.title;
                node.nodeNumber = item.nodeNumber;
                node.content = item.content;
                node.nodeClass = item.nodeClass;
                node.nodeDef = item.nodeDef;
                node.nodeKey = item.nodeKey;
                node.nodeRef = item.nodeRef;
                nodes.Add(node);
            }
            return nodes;
        }
    }
    /// <summary>
    /// 获取法规整体目录请求对象
    /// </summary>
    public class BookContentRequest
    {
        public int bookId { get; set; }
    }
    /// <summary>
    /// 获取法规整体目录响应对象
    /// </summary>
    public class BookContentResponse:CommonResponse
    {
        public new dataItem data { get; set; }

        public BookContentResponse()
        {
            data = new dataItem();
        }
        public class dataItem
        {
            public List<listItem> list { get; set; }
            public dataItem()
            {
                list = new List<listItem>();
            }
        }
        public class listItem
        {
            public int id { get; set; }
            public int bookId { get; set; }
            public string title { get; set; }
            public string nodeNumber { get; set; }
            public int nodeLevel { get; set; }
            public int nodeOrder { get; set; }
        }

        public List<Node> ConvertToNodes()
        {
            List<Node> nodes = new List<Node>();
            foreach (listItem item in this.data.list)
            {
                Node node = new CAAC_LawLibrary.Entity.Node();
                node.Id = item.id.ToString();
                node.lawId = item.bookId.ToString();
                node.title = item.title;
                node.nodeLevel = item.nodeLevel;
                node.nodeNumber = item.nodeNumber;
                node.nodeOrder = item.nodeOrder;
                nodes.Add(node);
            }
            return nodes;
        }
    }
    /// <summary>
    /// 获取章节子节点请求对象
    /// </summary>
    public class BookNodeCIdRequest
    {
        public int bookId { get; set; }
        /// <summary>
        /// 章节Id （如果是获得第一层级的目录则传0）
        /// </summary>
        public int nodeId { get; set; }
    }
    /// <summary>
    /// 获取章节子节点响应对象
    /// </summary>
    public class BookNodeCIdResponse:CommonResponse
    {
        public new dataItem data { get; set; }

        public BookNodeCIdResponse()
        {
            data = new dataItem();
        }
        public class dataItem
        {
            public List<listItem> list { get; set; }
            public dataItem()
            {
                list = new List<listItem>();
            }
        }
        public class listItem
        {
            public int id { get; set; }
            public int bookId { get; set; }
            public string title { get; set; }
            public string nodeNumber { get; set; }
            public int nodeLevel { get; set; }
            public int nodeOrder { get; set; }
        }

        public List<Node> ConvertToNodes()
        {
            List<Node> nodes = new List<CAAC_LawLibrary.Entity.Node>();
            foreach (listItem item in this.data.list)
            {
                Node node = new CAAC_LawLibrary.Entity.Node();
                node.Id = item.id.ToString();
                node.title = item.title;
                node.nodeLevel = item.nodeLevel;
                node.nodeNumber = item.nodeNumber;
                node.nodeOrder = item.nodeOrder;
                nodes.Add(node);
            }
            return nodes;
        }
    }
    /// <summary>
    /// 搜索法规或章节请求对象
    /// </summary>
    public class SearchRequest
    {
        public string bookName { get; set; }
        public string nodeName { get; set; }
        public string nodeNumber { get; set; }
    }
    /// <summary>
    /// 搜索法规或章节响应对象
    /// </summary>
    public class SearchResponse:CommonResponse
    {
        public new dataItem data { get; set; }

        public SearchResponse()
        {
            data = new dataItem();
        }
        public class dataItem
        {
            public List<listItem> list { get; set; }
            public dataItem()
            {
                list = new List<listItem>();
            }
        }
        public class listItem
        {
            public int id { get; set; }
            public int type { get; set; }
            public string title { get; set; }
            public string nodeNumber { get; set; }
            /// <summary>
            /// 章节版本
            /// </summary>
            public int nodeVersion { get; set; }
            /// <summary>
            /// 章节类型：章、节
            /// </summary>
            public string nodeType { get; set; }
            /// <summary>
            /// 预览
            /// </summary>
            public string preview { get; set; }
            /// <summary>
            /// id路径，如"1,3,345"
            /// </summary>
            public string idPath { get; set; }
            /// <summary>
            /// 描述路径，如"航空法,第一章,第三节"
            /// </summary>
            public string namePath { get; set; }
        }
    }
    /// <summary>
    /// 设置列表响应对象
    /// </summary>
    public class SetListResponse:CommonResponse
    {
        public new dataItem data { get; set; }

        public SetListResponse()
        {
            data = new dataItem();
        }
        public class dataItem
        {
            public List<listItem> biz { get; set; }
            public List<listItem> org { get; set; }
            public List<listItem> release { get; set; }
            public List<listItem> tag { get; set; }
            public List<listItem> type { get; set; }
            public List<listItem> buhao { get; set; }

            public dataItem()
            {
                biz = new List<listItem>();
                org = new List<listItem>();
                release = new List<listItem>();
                tag = new List<listItem>();
                type = new List<listItem>();
                buhao = new List<listItem>();
            }
        }
        public class listItem
        {
            public long createTime { get; set; }
            public string desc { get; set; }
            public int id { get; set; }
            public int order { get; set; }
            public string type { get; set; }
            public long updateTime { get; set; }
            public string value { get; set; }
        }

        public List<Code> ConvertToCodes()
        {
            List<Code> codes = new List<Code>();
            var allList = data.biz.Concat(data.org).Concat(data.release).Concat(data.tag).Concat(data.type).Concat(data.buhao);
            foreach (listItem item in allList)
            {
                Code code = new Code();
                code.Id = item.id.ToString();
                code.desc = item.desc;
                code.order = item.order;
                code.type = item.type;
                codes.Add(code);
            }
            return codes;
        }
    }

    public class HistoryResponse : CommonResponse
    {
        public new dataItem data { get; set; }

        public HistoryResponse()
        {
            data = new dataItem();
        }

        public class dataItem
        {
            public List<listItem> list { get; set; }
            public dataItem()
            {
                list = new List<listItem>();
            }
        }

        public class listItem
        {
            public string bookId { get; set; }
            public string version { get; set; }
        }

        public string ConvertToString()
        {
            string result = string.Empty;
            result = string.Join(Environment.NewLine, data.list.Select(d => d.version));
            return result;
        }
    }

    /// <summary>
    /// 通用返回对象
    /// </summary>
    public class CommonResponse
    {
        public string status { get; set; }
        public string errmsg { get; set; }
        public object data { get; set; }
    }

    public class TranslationWorker
    {
        /// <summary>
        /// 字符串转换为实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T ConvertStringToEntity<T>(string str) where T : class
        {
            try
            {
                var result = (T)(JsonConvert.DeserializeObject<T>(str));
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
