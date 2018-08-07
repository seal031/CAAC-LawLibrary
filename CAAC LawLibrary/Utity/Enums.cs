using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAC_LawLibrary.Utity
{
    /// <summary>
    /// 下载状态
    /// </summary>
    public enum DownloadState
    {
        [Description("未下载")]
        notDownload = 0,
        [Description("下载中")]
        downloading = 1,
        [Description("暂停下载")]
        parsed = 2,
        [Description("已下载")]
        downloaded = 3,
    }
}
