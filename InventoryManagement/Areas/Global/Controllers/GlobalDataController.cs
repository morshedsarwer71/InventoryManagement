using InventoryManagement.Areas.Global.Interfaces;
using InventoryManagement.Areas.Global.Models;
using InventoryManagement.Areas.Global.Password;
using InventoryManagement.Areas.Global.ViewModels;
using InventoryManagement.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement.Areas.Global.Controllers
{
    public class GlobalDataController : Controller
    {
        private readonly DataContext _context;
        private readonly ISystemUser _system;
        public GlobalDataController(DataContext context, ISystemUser system)
        {
            _context = context;
            _system = system;
        }
        // GET: Global/GlobalData
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(SystemUser systemUser)
        {

            return RedirectToAction("Index", "Home");
        }
        //[HttpPost]
        //public JsonResult LogIn(SystemUser systemUser)
        //{
        //    return Json(new { redirectUrl = Url.Action("Index", "Home"), isRedirect = true });
        //}
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        public ActionResult Users()
        {
            var user = _system.Users(1);
            SystemUserViewModels viewModels = new SystemUserViewModels()
            {
                SystemUsers=user
            };
            return View(viewModels);
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddUser(SystemUser systemUser)
        {
            var chkUser = (from s in _context.SystemUsers where s.EmailAddress == systemUser.EmailAddress select s).FirstOrDefault();
            if (chkUser == null)
            {
                Helper helper = new Helper();
                var hashSalt = helper.GenerateRandomSalt();
                var password = helper.HashPasswordUsingSHA2(systemUser.Password, hashSalt);
                systemUser.Password = password;
                systemUser.CreatorId = 1;
                systemUser.ConcernID = 1;
                //systemUser.CreationDate = DateTime.Now;
                systemUser.HashSalt = hashSalt;
                _context.SystemUsers.Add(systemUser);
                _context.SaveChanges();
                return Json("added successfully", JsonRequestBehavior.AllowGet);
            }
            return Json("all ready exists",JsonRequestBehavior.AllowGet);
        }
    }
}