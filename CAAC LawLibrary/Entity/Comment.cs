using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAC_LawLibrary.Entity
{
    /// <summary>
    /// 注释表
    /// </summary>
    [Table("Comment")]
    public class Comment : BaseEntity
    {
        [Key]
        public string Id { get; set; }
        public string lawId { get; set; }
        public string nodeId { get; set; }
        public string userId { get; set; }
        public string comment_content { get; set; }
        public string comment_date { get; set; }
        [NotMapped]
        public string nodeName { get; set; }
        [NotMapped]
        public string userName { get; set; }
        [NotMapped]
        public string department { get; set; }
    }
}
