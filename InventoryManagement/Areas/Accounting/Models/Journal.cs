using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Accounting.Models
{
    public class Journal
    {
        [Key]
        public int JournalId { get; set; }
        public int ConcernId { get; set; }
        public int CreditAccountsHeadId { get; set; }
        public decimal CreditJournalAmount { get; set; }
        public int DebitAccountsHeadId { get; set; }
        public decimal DebitJournalAmount { get; set; }
        public string Description { get; set; }
        public DateTime JournalEntryDate { get; set; }
        public int IsDelete { get; set; }
        public DateTime JournalCreationDate { get; set; }
        public int JournalCreator { get; set; }
        public DateTime JournalModificationDate { get; set; }
        public int JournalModifierId { get; set; }
    }
}