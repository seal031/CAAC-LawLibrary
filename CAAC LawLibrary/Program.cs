﻿using System;
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
            //Application.Run(new LibraryList());
            //Application.Run(new LawView());
            Application.Run(new Login());
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
