using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Global.Models
{
    public class SystemUser
    {
        [Key]
        public int UserID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int IsDisabled { get; set; }
        public DateTime LoginDate { get; set; }
        public string EmailAddress { get; set; }
        public int LoginFailedCount { get; set; }
        public string Language { get; set; }
        public DateTime ActivationDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string HashSalt { get; set; }
        public int CreatorId { get; set; }
        public int ConcernID { get; set; }
        public int IsDelete { get; set; }
    }
}