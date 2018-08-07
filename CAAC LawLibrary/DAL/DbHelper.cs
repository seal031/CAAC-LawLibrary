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
                var list = context.Law.ToList();

                return list;
            }
        }

        public bool saveLaw(Law law)
        {
            using (SqliteContext context = new SqliteContext())
            {

                try
                {
                    var old = context.Law.FirstOrDefault(l => l.Id == law.Id);
                    if (old == null)
                    {
                        context.Law.Add(law);
                    }
                    else
                    {
                        old = law;
                    }
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool saveCode(Code code)
        {
            using (SqliteContext context = new SqliteContext())
            {
                try
                {
                    var old = context.Code.FirstOrDefault(c => c.Id == code.Id);
                    if (old == null)
                    {
                        context.Code.Add(code);
                    }
                    else
                    {
                        old = code;
                    }
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool saveHistory(ViewHistory history)
        {
            using (SqliteContext context = new SqliteContext())
            {
                try
                {
                    context.ViewHistory.Add(history);
                    context.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool clearHistory()
        {
            using (SqliteContext context = new SqliteContext())
            {
                try
                {
                    context.Database.ExecuteSqlCommand("delete from ViewHistory");
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool saveSuggest(Suggest suggest)
        {
            using (SqliteContext context = new SqliteContext())
            {
                var old = context.Suggest.FirstOrDefault(s=>s.Id==suggest.Id);
                try
                {
                    if (old == null)
                    {
                        context.Suggest.Add(suggest);
                    }
                    else
                    {
                        old = suggest;
                    }
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool deleteSuggest(string lawId,string userId)
        {
            using (SqliteContext context = new SqliteContext())
            {
                try
                {
                    var list = context.Suggest.Where(s => s.lawId == lawId && s.userId == userId);
                    foreach (var l in list)
                    {
                        context.Suggest.Remove(l);
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
