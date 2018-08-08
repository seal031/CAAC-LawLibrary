using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAC_LawLibrary.BLL.Entity
{
    /// <summary>
    /// 提交征询post参数对象
    /// </summary>
    public class ConsultRequest
    {
        public string bookId { get; set; }
        public string userId { get; set; }
        public string nodeId { get; set; }
        public string text { get; set; }
        public string mark { get; set; }
    }

    /// <summary>
    /// 获取意见get参数对象
    /// </summary>
    public class OpinionRequest
    {
        public string bookId { get; set; }
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
    }

    /// <summary>
    /// 获取法规列表get参数对象
    /// </summary>
    public class AllBooksRequest
    {
        public int pageSize { get; set; }
        public int pageNum { get; set; }
        public bool history { get; set; }
    }


    /// <summary>
    /// 通用返回对象
    /// </summary>
    public class CommonResponse
    {
        public string status { get; set; }
        public string errmsg { get; set; }
        public string data { get; set; }
    }
}
