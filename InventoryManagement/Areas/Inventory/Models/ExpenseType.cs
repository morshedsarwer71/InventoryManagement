using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.Models
{
    public class ExpenseType
    {
        [Key]
        public int ExpenseTypeId { get; set; }
        public string ExpenseTypeName { get; set; }
        public int ExReportHead { get; set; }
        public int ConcernId { get; set; }
    }
}