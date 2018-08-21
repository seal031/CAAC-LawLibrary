using CAAC_LawLibrary.DAL;
using CAAC_LawLibrary.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAC_LawLibrary.Utity
{
    public static class Global
    {
        public static List<DictionaryEntry> SortSource = new List<DictionaryEntry>();
        public static List<Code> siju = new List<Code>();
        public static List<Code> yewu = new List<Code>();
        public static List<Code> buhao = new List<Code>();
        public static List<Code> zidingyi = new List<Code>();
        public static List<Code> weijie = new List<Code>();
        public static List<Code> allCode = new List<Code>();

        public static User user { get; set; }

         static Global()
        {
            SortSource.Add(new DictionaryEntry(1,"时间倒序（默认）"));
            SortSource.Add(new DictionaryEntry(2, "首字母拼音排序"));

            DbHelper db = new DbHelper();
            siju = db.getCode("org");
            yewu = db.getCode("biz");
            buhao = db.getCode("buhao");
            zidingyi = db.getCode("zidingyi");
            weijie = db.getCode("weijie");

            allCode = db.getCode();
        }

        public static string GetCodeValueById(string Id)
        {
            int id;
            if (int.TryParse(Id, out id) == false) { return string.Empty; }
            else
            {
                var code = allCode.FirstOrDefault(c => c.Id == id);
                if (code == null) { return string.Empty; }
                else
                {
                    return code.desc;
                }
            }
        }
    }

    public class UTC
    {
        public static int ConvertDateTimeInt(System.DateTime time)
        {
            double intResult = 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            intResult = (time - startTime).TotalSeconds;
            return (int)intResult;
        }

        public static DateTime ConvertIntDatetime(double utc)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            startTime = startTime.AddSeconds(utc);
            startTime = startTime.AddHours(8);//转化为北京时间(北京时间=UTC时间+8小时 )    
            return startTime;
        }
    }
}
