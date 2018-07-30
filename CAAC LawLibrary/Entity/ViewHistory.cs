using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAC_LawLibrary.Entity
{
    [Table("ViewHistory")]
    public class ViewHistory
    {
        public string LawID { get; set; }
        public string ViewDate { get; set; }
        public string UserID { get; set; }
    }
}
