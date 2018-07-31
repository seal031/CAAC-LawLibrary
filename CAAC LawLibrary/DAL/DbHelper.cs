using CAAC_LawLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAC_LawLibrary.DAL
{
    public class DbHelper
    {

        public Law getLawById(string id)
        {
            using (SqliteContext context = new SqliteContext())
            {
                return context.Law.FirstOrDefault(l => l.Id == id);
            }
        }

        public List<Law> getLaws()
        {
            using (SqliteContext context = new SqliteContext())
            {
                var list = context.Law.ToList() ;

                return list;
            }
        }
    }
}
