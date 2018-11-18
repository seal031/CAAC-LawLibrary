using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAC_LawLibrary.Utity
{
    /// <summary>
    /// 查询参数
    /// </summary>
    public class QueryParam
    {
        /// <summary>
        /// 部号
        /// </summary>
        public string buhao { get; set; }
        /// <summary>
        /// 司局
        /// </summary>
        public string siju { get; set; }
        /// <summary>
        /// 位阶
        /// </summary>
        public string weijie { get; set; }
        /// <summary>
        /// 业务
        /// </summary>
        public string yewu { get; set; }
        /// <summary>
        /// 自定义标签
        /// </summary>
        public string zidingyi { get; set; }
        /// <summary>
        /// 只显示已下载
        /// </summary>
        public string downloaded { get; set; }
        /// <summary>
        /// 法规id
        /// </summary>
        public string lawId { get; set; }
        /// <summary>
        /// 章节id
        /// </summary>
        public string nodeId { get; set; }
        /// <summary>
        /// 排序方式
        /// </summary>
        public int sort { get; set; }
        /// <summary>
        /// 下载任务的排序方式
        /// </summary>
        public int sortDownload { get; set; }
        /// <summary>
        /// 是否在下载任务中
        /// </summary>
        public int? downloadState { get; set; }

        /// <summary>
        /// 最后版本，用于查找修订令
        /// </summary>
        public int? lastVersion { get; set; }
    }
}
