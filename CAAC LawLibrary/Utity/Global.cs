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
}
