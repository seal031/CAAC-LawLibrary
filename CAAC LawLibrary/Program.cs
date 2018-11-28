//using CAAC_LawLibrary.BLL.Entity;
using CAAC_LawLibrary.BLL;
using CAAC_LawLibrary.BLL.Entity;
using CAAC_LawLibrary.DAL;
using CAAC_LawLibrary.Utity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAAC_LawLibrary
{
    static class Program
    {

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Global.user = new Entity.User();

            //验证网络是否可用
            RemoteWorker.checkInternet();
            //启动网络状态监测
            NetStateChecker ns = new Utity.NetStateChecker();
            Application.Run(new Login());
        }
    }
}
