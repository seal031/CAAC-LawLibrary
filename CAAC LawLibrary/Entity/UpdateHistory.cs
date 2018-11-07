using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAC_LawLibrary.Entity
{
    [Table("UpdateHistory")]
    public class UpdateHistory:BaseEntity
    {
        public string LawId { get; set; }
        public string LawTitle { get; set; }
        public string Version { get; set; }
        public string UpdateDate { get; set; }
        public string UserId { get; set; }

        public string Id { get; set; }
    }
}
