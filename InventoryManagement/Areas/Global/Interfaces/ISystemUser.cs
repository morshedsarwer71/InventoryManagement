﻿using InventoryManagement.Areas.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Areas.Global.Interfaces
{
    public interface ISystemUser
    {
        void AddUser(int userId,int concernId, SystemUser systemUser);
        IEnumerable<SystemUser> Users(int concernId);
    }
}
