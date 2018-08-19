using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAC_LawLibrary.Entity
{
    [Table("Code")]
    public class Code: BaseEntity
    {
        public int Id { get; set; }
        public string type { get; set; }
        public string desc { get; set; }
        public int order { get; set; }
    }
}
