using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.Models
{
    public class ExpenseName
    {
        [Key]
        public int ExpenseNameId { get; set; }
        public int ConcerInId { get; set; }
        public DateTime CreationDate { get; set; }
        public int Creator { get; set; }
        public string ExpenseHead { get; set; }
        public int ExpenseTypeId { get; set; }
        public decimal Payment { get; set; }
    }
}