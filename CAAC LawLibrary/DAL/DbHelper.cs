using CAAC_LawLibrary.BLL;
using CAAC_LawLibrary.Entity;
using CAAC_LawLibrary.Utity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAAC_LawLibrary.DAL
{
    public class DbHelper
    {
        /// <summary>
        /// 通过法规id获取法规
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Law getLawById(string id)
        {
            using (SqliteContext context = new SqliteContext())
            {
                return context.Law.FirstOrDefault(l => l.lawId == id && l.userId == Global.user.Id);
            }
        }

        /// <summary>
        /// 获取法规
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<Law> getLaws(QueryParam param)
        {
            using (SqliteContext context = new SqliteContext())
            {
                int? buhaoMin = 0, buhaoMax = 99999;
                if (param.buhao != null)
                {
                    var buhao = context.Code.FirstOrDefault(c => c.Id == param.buhao);
                    if (buhao != null)
                    {
                        buhaoMin = buhao.valueMin;
                        buhaoMax = buhao.valueMax;
                    }
                }
                var list = (from law in context.Law
                            where law.userId == Global.user.Id
                            && (param.siju == null ? 1 == 1 : law.siju == param.siju)
                            && ((param.banwendanwei == "不限办文单位"||param.banwendanwei==null) ? 1 == 1 : law.banwendanwei == param.banwendanwei)
                            && (param.weijie == null ? 1 == 1 : law.weijie == param.weijie)
                            && (param.yewu == null ? 1 == 1 : law.yewu == param.yewu)
                            && (param.zidingyi == null ? 1 == 1 : law.userLabel.Contains(param.zidingyi))
                            && (param.lawId == null ? 1 == 1 : law.lawId == param.lawId)
                            && (param.downloaded != "1" ? 1 == 1 : law.isLocal == param.downloaded)
                            && (param.downloadState.HasValue ? law.downloadPercent == param.downloadState : 1 == 1)
                            && (param.lastVersion.HasValue ? law.lastversion == param.lastVersion : 1 == 1)
                            select law).ToList();
                List<Law> returnList = new List<Law>();
                if (param.buhao != null)
                {
                    foreach (Law law in list)
                    {
                        string buhaoStr = law.buhao;
                        if (string.IsNullOrEmpty(buhaoStr) == false)
                        {
                            int buhao = int.Parse(buhaoStr.Split(new string[] { "*" }, StringSplitOptions.RemoveEmptyEntries)[1]);
                            if (buhao >= buhaoMin && buhao <= buhaoMax)
                            {
                                returnList.Add(law);
                            }
                        }
                    }
                }
                else
                {
                    returnList = list;
                }
                return returnList.OrderBy(l => param.sort == 2 ? l.pinyin : l.effectiveDate).ToList();
            }
        }
        /// <summary>
        /// 保存法规
        /// </summary>
        /// <param name="law"></param>
        /// <returns></returns>
        public bool saveLaw(Law law)
        {
            using (SqliteContext context = new SqliteContext())
            {
                try
                {
                    var old = context.Law.FirstOrDefault(l => l.lawId == law.lawId && l.userId == Global.user.Id);
                    if (old == null)
                    {
                        context.Law.Add(law);
                    }
                    else
                    {
                        old.name = law.name;
                        old.buhao = law.buhao;
                        old.digest = law.digest;
                        old.effectiveDate = law.effectiveDate;
                        old.expiryDate = law.expiryDate;
                        old.keyword = law.keyword;
                        old.lastversion = law.lastversion;
                        old.linghao = law.linghao;
                        old.siju = law.siju;
                        old.status = law.status;
                        old.title = law.title;
                        old.userLabel = law.userLabel;
                        old.version = law.version;
                        old.weijie = law.weijie;
                        old.xiudingling = law.xiudingling;
                        old.yewu = law.yewu;
                        old.yilai = law.yilai;
                        old.zefa = law.zefa;
                        old.downloadPercent = law.downloadPercent;
                        old.downloadDate = law.downloadDate;
                        old.downloadNodeCount = law.downloadNodeCount;
                        old.isLocal = law.isLocal;
                    }
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 刷新法规
        /// </summary>
        /// <param name="laws"></param>
        /// <returns></returns>
        public bool refreshLaw(List<Law> laws)
        {
            using (SqliteContext context = new SqliteContext())
            {
                try
                {
                    int updateLawCount = 0;
                    foreach (Law law in laws.OrderBy(l=>l.lawId))
                    {
                        var currentLaw = context.Law.FirstOrDefault(l => l.lawId == law.lawId && l.userId == Global.user.Id);
                        if (currentLaw == null)//如果没有就新增
                        {
                            law.userId = Global.user.Id;
                            //如果是更新版本的法规（且法规旧版本已下载至本地），将更新信息保存至自动更新历史记录表，同时自动下载新版本法规内容
                            var oldLaw = context.Law.FirstOrDefault(l => l.lastversion == law.lastversion && l.isLocal == "1" && l.userId == Global.user.Id);
                            if (oldLaw != null)
                            {
                                List<Node> nodes = RemoteWorker.getBookContent(law.lawId);
                                RemoteWorker.getNodeDetail(nodes.Select(n => n.Id).ToList());
                                law.isLocal = "1";
                                law.downloadPercent = 100;
                                law.downloadNodeCount = nodes.Count;
                                law.downloadDate = DateTime.Now.ToString("yyyy-MM-dd");
                                UpdateHistory updateHistory = new UpdateHistory();
                                updateHistory.LawId = law.lawId;
                                updateHistory.LawTitle = law.title;
                                updateHistory.UpdateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                updateHistory.UserId = Global.user.Id;
                                updateHistory.Version = law.version;
                                updateHistory.Id = Guid.NewGuid().ToString();
                                addUpdateHistory(updateHistory);
                                updateLawCount++;
                            }
                            context.Law.Add(law);
                        }
                        else//如果有就更新基本信息，但不更新是否下载到本地、下载时间、下载进度、用户id等本地信息。
                        {
                            currentLaw.name = law.name;
                            currentLaw.buhao = law.buhao;
                            currentLaw.digest = law.digest;
                            currentLaw.effectiveDate = law.effectiveDate;
                            currentLaw.expiryDate = law.expiryDate;
                            currentLaw.keyword = law.keyword;
                            currentLaw.lastversion = law.lastversion;
                            currentLaw.linghao = law.linghao;
                            currentLaw.siju = law.siju;
                            currentLaw.status = law.status;
                            currentLaw.title = law.title;
                            currentLaw.userLabel = law.userLabel;
                            currentLaw.version = law.version;
                            currentLaw.weijie = law.weijie;
                            currentLaw.xiudingling = law.xiudingling;
                            currentLaw.yewu = law.yewu;
                            currentLaw.yilai = law.yilai;
                            currentLaw.zefa = law.zefa;
                        }
                        context.SaveChanges();
                    }
                    //context.SaveChanges();
                    MessageBox.Show("新版法规自动更新完成，本次共更新了"+updateLawCount.ToString()+"个法规的新版本");
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 从本地库移除(islocal=0,downloadData=null)
        /// </summary>
        /// <param name="law"></param>
        /// <returns></returns>
        public bool removeLawFromLocal(Law law)
        {
            using (SqliteContext context = new SqliteContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        //var currentLaw = context.Law.FirstOrDefault(l => l.Id == law.Id && l.userId == law.userId);
                        var laws = context.Law.Where(l => l.lastversion == law.lastversion && l.userId == law.userId);
                        foreach (Law currentLaw in laws)
                        {
                            if (currentLaw != null)
                            {
                                currentLaw.downloadDate = null;
                                currentLaw.downloadPercent = null;
                                currentLaw.isLocal = "0";
                                currentLaw.downloadNodeCount = null;
                            }
                        }

                        //不清空node内容，因为node是多用户共用的
                        //var list = context.Node.Where(n => n.lawId == law.Id && law.userId == Global.user.Id);
                        //foreach (var node in list)
                        //{
                        //    node.content = string.Empty;
                        //}
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                        return false;
                    }
                }
            }
        }
        /// <summary>
        /// 通过法规id获取章节
        /// </summary>
        /// <param name="lawId"></param>
        /// <returns></returns>
        public List<Node> getNodeByLawId(string lawId)
        {
            using (SqliteContext context = new SqliteContext())
            {
                try
                {
                    var law = context.Law.FirstOrDefault(l => l.lawId == lawId && l.userId == Global.user.Id);
                    if (law == null) return new List<Node>();
                    else
                    {
                        return context.Node.Where(n => n.lawId == law.lawId).OrderBy(n => n.nodeOrder).ToList();
                    }
                }
                catch (Exception)
                {
                    return new List<Node>();
                }
            }
        }
        /// <summary>
        /// 通过章节id获取章节
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public Node getNodeById(string nodeId)
        {
            using (SqliteContext context = new SqliteContext())
            {
                try
                {
                    return context.Node.FirstOrDefault(n => n.Id==nodeId);

                }
                catch (Exception)
                {
                    return new Node();
                }
            }
        }
        /// <summary>
        /// 通过法规id、章节级别获取章节
        /// </summary>
        /// <param name="lawId"></param>
        /// <param name="nodeLevel"></param>
        /// <returns></returns>
        public List<Node> getNodeByLawIdAndLevel(string lawId,int nodeLevel)
        {
            using (SqliteContext context = new SqliteContext())
            {
                try
                {
                    var law = context.Law.FirstOrDefault(l => l.lawId == lawId && l.userId == Global.user.Id);
                    if (law == null) return new List<Node>();
                    else
                    {
                        return context.Node.Where(n => n.lawId == law.lawId && n.nodeLevel == nodeLevel).OrderBy(n => n.nodeOrder).ThenBy(n => n.nodeOrder).ToList();
                    }
                }
                catch (Exception)
                {
                    return new List<Node>();
                }
            }
        }
        /// <summary>
        /// 通过父节点获取章节
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public List<Node> getNodeByParentNode(Node node)
        {
            using (SqliteContext context = new SqliteContext())
            {
                try
                {
                    return context.Node.Where(n => n.lawId == node.Id && n.nodeLevel == node.nodeLevel+1).OrderBy(n => n.nodeOrder).ThenBy(n => n.nodeOrder).ToList();
                }
                catch (Exception)
                {
                    return new List<Node>();
                }
            }
        }
        /// <summary>
        /// 保存章节
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool saveNode(Node node)
        {
            using (SqliteContext context = new SqliteContext())
            {
                try
                {
                    var old = context.Node.FirstOrDefault(c => c.Id == node.Id);
                    if (old == null)
                    {
                        context.Node.Add(node);
                    }
                    else
                    {
                        old = node;
                    }
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 刷新章节
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="parentNode"></param>
        /// <param name="detailOnly"></param>
        /// <returns></returns>
        public bool refreshNode(List<Node> nodes,Node parentNode=null,bool detailOnly=false)
        {
            using (SqliteContext context = new CAAC_LawLibrary.SqliteContext())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (Node node in nodes)
                        {
                            var currentNode = context.Node.FirstOrDefault(n => n.Id == node.Id);
                            if (currentNode == null)
                            {
                                context.Node.Add(node);
                            }
                            else
                            {
                                if (detailOnly)
                                {
                                    currentNode.content = node.content;
                                    if (string.IsNullOrEmpty(currentNode.offlineContent))
                                    {
                                        currentNode.offlineContent = node.offlineContent;
                                    }
                                    currentNode.nodeClass = node.nodeClass;
                                    currentNode.nodeKey = node.nodeKey;
                                    currentNode.nodeDef = node.nodeDef;
                                    currentNode.nodeRef = node.nodeRef;
                                }
                                else
                                {
                                    currentNode.lawId = node.lawId;
                                    currentNode.nodeLevel = node.nodeLevel;
                                    currentNode.nodeNumber = node.nodeNumber;
                                    currentNode.nodeOrder = node.nodeOrder;
                                    currentNode.title = node.title;
                                    currentNode.nodeClass = node.nodeClass;
                                    currentNode.nodeKey = node.nodeKey;
                                    currentNode.nodeDef = node.nodeDef;
                                    currentNode.nodeRef = node.nodeRef;
                                }
                                if (parentNode != null) currentNode.parentNodeId = parentNode.Id;
                            }
                        }
                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }
        /// <summary>
        /// 获取指定种类的设置
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Code> getCode(string type)
        {
            using (SqliteContext context = new CAAC_LawLibrary.SqliteContext())
            {
                try
                {
                    return context.Code.Where(c => c.type == type).OrderBy(c => c.order).ToList();
                }
                catch (Exception ex)
                {
                    return new List<Code>();
                }
            }
        }
        /// <summary>
        /// 获取设置
        /// </summary>
        /// <returns></returns>
        public List<Code> getCode()
        {
            using (SqliteContext context = new CAAC_LawLibrary.SqliteContext())
            {
                try
                {
                    return context.Code.OrderBy(c => c.order).ToList();
                }
                catch (Exception ex)
                {
                    return new List<Code>();
                }
            }
        }
        /// <summary>
        /// 保存设置
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool saveCode(Code code)
        {
            using (SqliteContext context = new SqliteContext())
            {
                try
                {
                    var old = context.Code.FirstOrDefault(c => c.Id == code.Id);
                    if (old == null)
                    {
                        context.Code.Add(code);
                    }
                    else
                    {
                        old = code;
                    }
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 刷新设置
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public bool refreshCode(List<Code> codes)
        {
            using (SqliteContext context = new SqliteContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (Code code in codes)
                        {
                            var currentCode = context.Code.FirstOrDefault(c => c.Id == code.Id);
                            if (currentCode == null)
                            {
                                context.Code.Add(code);
                            }
                            else
                            {
                                currentCode.desc = code.desc;
                                currentCode.order = code.order;
                                currentCode.type = code.type;
                                currentCode.valueMax = code.valueMax;
                                currentCode.valueMin = code.valueMin;
                            }
                        }
                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
        /// <summary>
        /// 获取浏览历史
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<ViewHistory> getViewHistory(QueryParam param)
        {
            using (SqliteContext context = new SqliteContext())
            {
                var laws = from law in context.Law
                           where (param.buhao == null ? 1 == 1 : law.buhao == param.buhao)
                           && (param.siju == null ? 1 == 1 : law.siju == param.siju)
                           && (param.weijie == null ? 1 == 1 : law.weijie == param.weijie)
                           && (param.yewu == null ? 1 == 1 : law.yewu == param.yewu)
                           && (param.lawId == null ? 1 == 1 : law.lawId == param.lawId)
                           && (param.downloaded != "1" ? 1 == 1 : law.isLocal == param.downloaded)
                           select law;
                var list = from vh in context.ViewHistory.Where(v => v.UserID == Global.user.Id)
                           from law in laws
                           where vh.LawID==law.lawId && vh.UserID==law.userId
                           orderby vh.ViewDate descending
                           select vh;
                return list.ToList();
            }
        }
        /// <summary>
        /// 保存浏览历史
        /// </summary>
        /// <param name="history"></param>
        /// <returns></returns>
        public bool saveHistory(ViewHistory history)
        {
            using (SqliteContext context = new SqliteContext())
            {
                try
                {
                    var tempViewHistory = context.ViewHistory.FirstOrDefault(v => v.LawID == history.LawID && v.UserID == Global.user.Id);
                    if (tempViewHistory == null)
                    {
                        context.ViewHistory.Add(history);
                    }
                    else
                    {
                        tempViewHistory.ViewDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 情况浏览记录
        /// </summary>
        /// <returns></returns>
        public bool clearHistory()
        {
            using (SqliteContext context = new SqliteContext())
            {
                try
                {
                    context.Database.ExecuteSqlCommand("delete from ViewHistory");
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 清空本地库
        /// </summary>
        /// <returns></returns>
        public bool clearLocal()
        {
            using (SqliteContext context = new CAAC_LawLibrary.SqliteContext())
            {
                try
                {
                    context.Database.ExecuteSqlCommand("update Law set isLocal=null,downloadDate=null,downloadPercent=null where userId='"+Global.user.Id+"'");
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 查询征询（远程获取）
        /// </summary>
        /// <param name="lawId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Suggest> getSuggests(string lawId,string userId)
        {
            using (SqliteContext context = new SqliteContext())
            {
                return context.Suggest.Where(s => s.lawId == lawId && s.userId == userId && s.isLocal!="1").ToList();
            }
        }
        /// <summary>
        /// 查询征询（本地未提交）
        /// </summary>
        /// <param name="lawId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Suggest> getLocalSuggests(string lawId, string userId)
        {
            using (SqliteContext context = new SqliteContext())
            {
                return context.Suggest.Where(s => s.lawId == lawId && s.userId == userId && s.isLocal == "1").ToList();
            }
        }


        /// <summary>
        /// 临时保存征询
        /// </summary>
        /// <param name="suggest"></param>
        /// <returns></returns>
        public bool saveSuggest(Suggest suggest)
        {
            using (SqliteContext context = new SqliteContext())
            {
                var old = context.Suggest.FirstOrDefault(s=>s.Id==suggest.Id);
                try
                {
                    if (old == null)
                    {
                        context.Suggest.Add(suggest);
                    }
                    else
                    {
                        old = suggest;
                    }
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 删除征询
        /// </summary>
        /// <param name="lawId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool deleteSuggest(string lawId,string userId)
        {
            using (SqliteContext context = new SqliteContext())
            {
                try
                {
                    //var list = context.Suggest.Where(s => s.lawId == lawId && s.userId == userId);
                    //foreach (var l in list)
                    //{
                    //    context.Suggest.Remove(l);
                    //}
                    context.Suggest.RemoveRange(context.Suggest);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 刷新评论
        /// </summary>
        /// <param name="comments"></param>
        /// <returns></returns>
        public bool refreshComment(List<Comment> comments)
        {
            using (SqliteContext context = new CAAC_LawLibrary.SqliteContext())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (Comment comment in comments)
                        {
                            var currentComment = context.Comment.FirstOrDefault(c => c.Id == comment.Id);
                            if (currentComment == null)
                            {
                                context.Comment.Add(comment);
                            }
                            else
                            {
                                currentComment.lawId = comment.lawId;
                                currentComment.nodeId = comment.nodeId;
                                currentComment.userId = comment.userId;
                                currentComment.comment_content = comment.comment_content;
                                currentComment.comment_date = comment.comment_date;
                            }
                        }
                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
        /// <summary>
        /// 查询评论
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<Comment> getComment(QueryParam param)
        {
            using (SqliteContext context = new CAAC_LawLibrary.SqliteContext())
            {
                var list = (from comment in context.Comment
                            join user in context.User on comment.userId equals user.Id
                            where (param.lawId == null ? 1 == 1 : comment.lawId == param.lawId) &&
                            (param.nodeId == null ? 1 == 1 : comment.nodeId == param.nodeId)
                            orderby comment.comment_date
                            select new
                            {
                                comment_content = comment.comment_content,
                                userName = user.Xm,
                                department = user.Department,
                                comment_date = comment.comment_date,
                                nodeId = comment.nodeId,
                                lawId = comment.lawId
                            }).ToList().Select(x => new Comment()
                            {
                                comment_content = x.comment_content,
                                comment_date = x.comment_date,
                                userName = x.userName,
                                department = x.department,
                                nodeId = x.nodeId,
                                lawId = x.lawId
                            });
                List<Comment> resultList = list.ToList();
                return resultList;
            }
        }

        public User getUserById(string id)
        {
            using (SqliteContext context = new CAAC_LawLibrary.SqliteContext())
            {
                try
                {
                    return context.User.FirstOrDefault(u => u.Id == id);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool saveUser(User user)
        {
            using (SqliteContext context = new CAAC_LawLibrary.SqliteContext())
            {
                try
                {
                    var tempUser = context.User.FirstOrDefault(u => u.Id == user.Id);
                    if (tempUser == null)//不存在则新增
                    {
                        context.User.Add(user);
                    }
                    else//已存在则更新
                    {
                        if(string.IsNullOrEmpty(tempUser.Name))
                            tempUser.Name = user.Name;
                        if (string.IsNullOrEmpty(tempUser.Password))
                            tempUser.Password = user.Password;
                        tempUser.Xm = user.Xm;
                        tempUser.Department = user.Department;
                        tempUser.Phone = user.Phone;
                        if (user.Preload == "1")
                        {
                            tempUser.Preload = "1";
                        }
                        else
                        {
                            tempUser.Preload = "0";
                        }
                    }
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public List<UpdateHistory> getUpdateHistorys()
        {
            using (SqliteContext context = new CAAC_LawLibrary.SqliteContext())
            {
                var list = context.UpdateHistory.Where(u => u.UserId == Global.user.Id).OrderByDescending(u=>u.UpdateDate);
                return list.ToList();
            }
        }

        public bool addUpdateHistory(UpdateHistory updateHistory)
        {
            using (SqliteContext context = new CAAC_LawLibrary.SqliteContext())
            {
                try
                {
                    context.UpdateHistory.Add(updateHistory);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 离线登陆验证
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool login(string username, string password)
        {
            using (SqliteContext context = new CAAC_LawLibrary.SqliteContext())
            {
                var user = context.User.FirstOrDefault(u => u.Name == username && u.Password == password);
                if (user == null)
                    return false;
                else
                    Global.user = user;
                    return true;
            }
        }

        /// <summary>
        /// 离线搜索
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<string> offLineSearch(QueryParam param, string keyword)
        {
            using (SqliteContext context = new CAAC_LawLibrary.SqliteContext())
            {
                List<Law> allLaws = getLaws(param);
                var laws = from l in allLaws
                           from n in context.Node
                           where n.lawId == l.lawId
                           && ((l.isLocal == "1" && (l.title.Contains(keyword) || n.title.Contains(keyword) || n.content.Contains(keyword))) || l.title.Contains(keyword))
                           && l.userId == Global.user.Id
                           select l.lawId;
                List<string> returnList = laws.Distinct().ToList();
                return returnList;
            }
        }
    }
}
