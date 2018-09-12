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
            //selectDb();
            //initDb();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //验证网络是否可用
            if (RemoteWorker.checkInternet())
            {
                Global.user = new Entity.User() { Id = "1" };//todo 替换真实user
                //RemoteWorker.getSetResponse();
                RemoteWorker.getLawResponse();
                Application.Run(new Login());
            }
            else
            {

            }
        }

        private static void initDb()
        {
            using (SqliteContext context = new CAAC_LawLibrary.SqliteContext())
            {
                //context.User.Add(new Entity.User() { Id = Guid.NewGuid().ToString(), Name = "seal", Password = "123456" });
                context.Law.Add(new Entity.Law() { Id=Guid.NewGuid().ToString(),effectiveDate=DateTime.Now.ToString("yyyy-MM-dd")});
                context.SaveChanges();
            }
        }

        private static void selectDb()
        {
            using (SqliteContext context = new CAAC_LawLibrary.SqliteContext())
            {
                //var a = context.User.First(u => u.Id == "02954944-57ab-4571-9b1e-0062ef04fef2");
                var a = context.Law.First(l => DateTime.Parse( l.effectiveDate)>DateTime.Parse("2018-07-27"));
            }
        }
       
    }
}
