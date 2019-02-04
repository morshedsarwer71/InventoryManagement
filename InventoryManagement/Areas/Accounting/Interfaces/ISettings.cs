﻿using InventoryManagement.Areas.Accounting.Models;
using InventoryManagement.Areas.Accounting.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Areas.Accounting.Interfaces
{
    public interface ISettings
    {
        void AddAccountHead(AccountsHead accountsHead, int userId, int concernId);
        void AddReportHead(ReportHead reportHead, int userId, int concernId);
        IEnumerable<AccountsHead> AccountsHeads(int concernId);
        IEnumerable<ReportHead> ReportHeads(int concernId);
        IEnumerable<ResponseAccountHeads> ResponseAccountHeads(string culture, int page, int concernId);
    }
}
