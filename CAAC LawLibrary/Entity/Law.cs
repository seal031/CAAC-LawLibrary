using CAAC_LawLibrary.Utity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAC_LawLibrary.Entity
{
    [Table("Law")]
    public class Law:BaseEntity
    {
        [Key]
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 法规id
        /// </summary>
        public string lawId { get; set; }
        /// <summary>
        /// 法规版本
        /// </summary>
        public string version { get; set; }
        /// <summary>
        /// 法规摘要
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 法规部号
        /// </summary>
        public string buhao { get; set; }
        /// <summary>
        /// 主管司局
        /// </summary>
        public string siju { get; set; }
        /// <summary>
        /// 位阶
        /// </summary>
        public string weijie { get; set; }
        /// <summary>
        /// 所属业务
        /// </summary>
        public string yewu { get; set; }
        /// <summary>
        /// 用户自定义标签
        /// </summary>
        public string userLabel { get; set; }
        public string digest { get; set; }
        /// <summary>
        /// 生效日期
        /// </summary>
        public string effectiveDate { get; set; }
        /// <summary>
        /// 失效日期
        /// </summary>
        public string expiryDate { get; set; }
        /// <summary>
        /// 是否已下载到本地 0or1 not null
        /// </summary>
        public string isLocal { get; set; }
        /// <summary>
        /// 法规名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 法规下载日期
        /// </summary>
        public string downloadDate { get; set; }
        /// <summary>
        /// 所属用户id
        /// </summary>
        public string userId { get; set; }
        /// <summary>
        /// 下载进度，isLocal=0&&downloadPercent=null时表示未添加至下载任务;isLocal=1&&downloadPercent=null表示已下载且下载任务已删除；不为null时表示正在下载;isLocal=1&&downloadPercent=100表示已下载完成
        /// </summary>
        public int? downloadPercent { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        public string keyword { get; set; }
        /// <summary>
        /// 令号
        /// </summary>
        public string linghao { get; set; }
        /// <summary>
        /// 修订令
        /// </summary>
        public string xiudingling { get; set; }
        /// <summary>
        /// 依赖
        /// </summary>
        public string yilai { get; set; }
        /// <summary>
        /// 责罚
        /// </summary>
        public string zefa { get; set; }
        /// <summary>
        /// 最新版本的id
        /// </summary>
        public int? lastversion { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int? status { get; set; }
        /// <summary>
        /// 办文机构
        /// </summary>
        public string banwendanwei { get; set; }

        [NotMapped]
        public string pinyin
        {
            get { return ChineseToPinYin.ToPinYin(title); }
        }
        [NotMapped]
        public int? versionNumber
        {
            get
            {
                try
                {
                    return int.Parse(version.Replace("R", ""));
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }
        [NotMapped]
        public DateTime orderDate
        {
            get
            {
                try
                {
                    return DateTime.Parse(effectiveDate);
                }
                catch (Exception)
                {
                    return DateTime.Now;
                }
            }
        }
        /// <summary>
        /// 已下载的章节数量，用于重新打开程序后的继续下载
        /// </summary>
        public int? downloadNodeCount { get; set; }
    }
}
