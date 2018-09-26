using CAAC_LawLibrary.Entity;
using CAAC_LawLibrary.Utity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAC_LawLibrary.DAL
{
    public class DbHelper
    {

        public Law getLawById(string id)
        {
            using (SqliteContext context = new SqliteContext())
            {
                return context.Law.FirstOrDefault(l => l.Id == id);
            }
        }

        public List<Law> getLaws(QueryParam param)
        {
            using (SqliteContext context = new SqliteContext())
            {
                var list = (from law in context.Law
                            where (param.buhao == null ? 1 == 1 : law.buhao == param.buhao)
                            && (param.siju == null ? 1 == 1 : law.siju == param.siju)
                            && (param.weijie == null ? 1 == 1 : law.weijie == param.weijie)
                            && (param.yewu == null ? 1 == 1 : law.yewu == param.yewu)
                            && (param.lawId == null ? 1 == 1 : law.Id == param.lawId)
                            select law).ToList();
                return list.ToList() ;
            }
        }

        public bool saveLaw(Law law)
        {
            using (SqliteContext context = new SqliteContext())
            {
                try
                {
                    var old = context.Law.FirstOrDefault(l => l.Id == law.Id);
                    if (old == null)
                    {
                        context.Law.Add(law);
                    }
                    else
                    {
                        old = law;
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

        public bool refreshLaw(List<Law> laws)
        {
            using (SqliteContext context = new SqliteContext())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        //context.Law.RemoveRange(context.Law);
                        //foreach (Law law in laws)
                        //{
                        //    context.Law.Add(law);
                        //}
                        foreach (Law law in laws)
                        {
                            var currentLaw = context.Law.FirstOrDefault(l => l.Id == law.Id);
                            if (currentLaw == null)//如果没有就新增
                            {
                                law.userId = Global.user.Id;
                                context.Law.Add(law);
                            }
                            else//如果有就更新，但不更新是否下载到本地、下载时间、下载进度、用户id等本地信息。
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
        /// 从本地库移除
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
                        law.downloadDate = null;
                        law.downloadPercent = null;
                        law.isLocal = "0";

                        var list = context.Node.Where(n => n.lawId == law.Id && law.userId == Global.user.Id);
                        foreach (var node in list)
                        {
                            node.content = string.Empty;
                        }
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

        public List<Node> getNodeByLawId(string lawId)
        {
            using (SqliteContext context = new SqliteContext())
            {
                try
                {
                    var law = context.Law.FirstOrDefault(l => l.Id == lawId && l.userId == Global.user.Id);
                    if (law == null) return new List<Node>();
                    else
                    {
                        return context.Node.Where(n => n.lawId == law.Id).OrderBy(n => n.nodeOrder).ToList();
                    }
                }
                catch (Exception)
                {
                    return new List<Node>();
                }
            }
        }

        public List<Node> getNodeByLawIdAndLevel(string lawId,int nodeLevel)
        {
            using (SqliteContext context = new SqliteContext())
            {
                try
                {
                    var law = context.Law.FirstOrDefault(l => l.Id == lawId && l.userId == Global.user.Id);
                    if (law == null) return new List<Node>();
                    else
                    {
                        return context.Node.Where(n => n.lawId == law.Id && n.nodeLevel == nodeLevel).OrderBy(n => n.nodeOrder).ThenBy(n => n.nodeOrder).ToList();
                    }
                }
                catch (Exception)
                {
                    return new List<Node>();
                }
            }
        }

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
                                }
                                else
                                {
                                    currentNode.lawId = node.lawId;
                                    currentNode.nodeLevel = node.nodeLevel;
                                    currentNode.nodeNumber = node.nodeNumber;
                                    currentNode.nodeOrder = node.nodeOrder;
                                    currentNode.title = node.title;
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

        public bool refreshCode(List<Code> codes)
        {
            using (SqliteContext context = new SqliteContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Code.RemoveRange(context.Code);
                        foreach (Code code in codes)
                        {
                            context.Code.Add(code);
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

        public List<ViewHistory> getViewHistory(QueryParam param)
        {
            using (SqliteContext context = new SqliteContext())
            {
                var laws = from law in context.Law
                           where (param.buhao == null ? 1 == 1 : law.buhao == param.buhao)
                           && (param.siju == null ? 1 == 1 : law.siju == param.siju)
                           && (param.weijie == null ? 1 == 1 : law.weijie == param.weijie)
                           && (param.yewu == null ? 1 == 1 : law.yewu == param.yewu)
                           && (param.lawId == null ? 1 == 1 : law.Id == param.lawId)
                           select law;
                var list = from vh in context.ViewHistory.Where(v => v.UserID == Global.user.Id)
                           from law in laws
                           where vh.LawID==law.Id && vh.UserID==law.userId
                           orderby vh.ViewDate descending
                           select vh;
                return list.ToList();
            }
        }

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


        public List<Suggest> getSuggests(string lawId,string userId)
        {
            using (SqliteContext context = new SqliteContext())
            {
                return context.Suggest.Where(s => s.lawId == lawId && s.userId == userId && s.isLocal!="1").ToList();
            }
        }

        public List<Suggest> getLocalSuggests(string lawId, string userId)
        {
            using (SqliteContext context = new SqliteContext())
            {
                return context.Suggest.Where(s => s.lawId == lawId && s.userId == userId && s.isLocal == "1").ToList();
            }
        }

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

        public List<Comment> getComment(QueryParam param)
        {
            using (SqliteContext context = new CAAC_LawLibrary.SqliteContext())
            {
                var list = from comment in context.Comment
                           where (param.lawId == null ? 1 == 1 : comment.lawId == param.lawId) &&
                           (param.nodeId == null ? 1 == 1 : comment.nodeId == param.nodeId)
                           orderby comment.comment_date
                           select comment;
                return list.ToList();
            }
        }
    }
}
