using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Global.Models
{
    public class Concern
    {
        [Key]
        public int ConcernId { get; set; }
        public string ConcernNameAR { get; set; }
        public string ConcernNameEN { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatorId { get; set; }
        public int IsDelete { get; set; }
        public DateTime ModificationDate { get; set; }
        public int ModifierId { get; set; }
    }
}