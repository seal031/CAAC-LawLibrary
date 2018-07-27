using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAC_LawLibrary.Entity
{
    [Table("Law")]
    public class Law
    {
        public string Id { get; set; }
        public string version { get; set; }
        public string title { get; set; }
        public string buhao { get; set; }
        public string siju { get; set; }
        public string weijie { get; set; }
        public string yewu { get; set; }
        public string userLabel { get; set; }
        public string digest { get; set; }
        public string effectiveDate { get; set; }
        public string expiryDate { get; set; }
    }
}
