using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Accounting.Models
{
    public class ReportHead
    {
        [Key]
        public int ReportHeadId { get; set; }
        public string ReportHeadNameEN { get; set; }
        public int ReportType { get; set; }
        public string ReportHeadNameAR { get; set; }
        public System.DateTime CreationDate { get; set; }
        public int CreatorId { get; set; }
        public int IsDelete { get; set; }
        public System.DateTime ModificationDate { get; set; }
        public int ModifierId { get; set; }
    }
}