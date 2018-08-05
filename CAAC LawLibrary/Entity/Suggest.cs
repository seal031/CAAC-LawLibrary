using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAC_LawLibrary.Entity
{
    [Table("Suggest")]
    public class Suggest
    {
        [Key]
        public string Id { get; set; }
        public string lawId { get; set; }
        public string userId { get; set; }
        public string suggest_content { get; set; }
        public string remark { get; set; }
    }
}
