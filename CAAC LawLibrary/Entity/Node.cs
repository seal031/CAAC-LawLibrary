using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAC_LawLibrary.Entity
{
    [Table("Node")]
    public class Node : BaseEntity
    {
        [Key]
        public string Id { get; set; }
        public string lawId { get; set; }
        public string title { get; set; }
        public string nodeNumber { get; set; }
        public int nodeLevel { get; set; }
        public int nodeOrder { get; set; }
        public string content { get; set; }
        public string parentNodeId { get; set; }
    }
}
