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

        public static User user { get; set; }

         static Global()
        {
            SortSource.Add(new DictionaryEntry(1,"时间倒序（默认）"));
            SortSource.Add(new DictionaryEntry(2, "首字母拼音排序"));
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
