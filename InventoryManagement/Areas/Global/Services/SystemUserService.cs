﻿using InventoryManagement.Areas.Global.Interfaces;
using InventoryManagement.Areas.Global.Models;
using InventoryManagement.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Global.Services
{
    public class SystemUserService : ISystemUser
    {
        private readonly DataContext _context;
        public SystemUserService(DataContext context)
        {
            _context = context;
        }
        public void AddUser(int userId, int concernId, SystemUser systemUser)
        {
            systemUser.ConcernID = concernId;
            systemUser.CreatorId = userId;
            systemUser.CreationDate = DateTime.Now;
            _context.SystemUsers.Add(systemUser);
        }

        public IEnumerable<SystemUser> Users(int concernId)
        {
            return _context.SystemUsers.Where(m=>m.ConcernID==concernId && m.IsDelete==0);
        }
    }
}