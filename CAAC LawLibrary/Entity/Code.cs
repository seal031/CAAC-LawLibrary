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
        [Key]
        public string Id { get; set; }
        public string codeTyte { get; set; }
        public string codeName { get; set; }
    }
}
