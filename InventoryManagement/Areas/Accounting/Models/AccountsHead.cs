using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Accounting.Models
{
    public class AccountsHead
    {
        [Key]
        public int AccountsHeadId { get; set; }
        public string AccountsHeadNameEN { get; set; }
        public int ReportHeadId { get; set; }
        public int TransactionType { get; set; }
        public System.DateTime CreationDate { get; set; }
        public int CreatorId { get; set; }
        public int IsDelete { get; set; }
        public System.DateTime ModificationDate { get; set; }
        public int ModifierId { get; set; }
        public string AccountsHeadNameAR { get; set; }
        public int ConcernId { get; set; }
    }
}