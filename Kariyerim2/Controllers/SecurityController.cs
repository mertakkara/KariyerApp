using Kariyerim2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Kariyerim2.Controllers
{
    public class SecurityController : Controller
    {
        KARIYER k = new KARIYER();
        // GET: Security
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(user u)
        {
            user us = k.users.FirstOrDefault(x => x.kadi == u.kadi && x.parola == u.parola);
            if(us != null)
            {
                FormsAuthentication.SetAuthCookie(us.kadi,false);
                return RedirectToAction("Index", "Is");
            }
            else
            {
                ViewBag.mesaj = "Kullanıcı adı veya şifre hatalı";
                return View();
                FormsAuthentication.SetAuthCookie(us.kadi, false);
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult KullaniciEkle()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult KullaniciEkle(string kadi, string parola,string rol)
        {
            user us = k.users.FirstOrDefault(x => x.kadi == kadi);
            if (us != null)
            {
                ViewBag.mesaj = "Böyle bir kullanıcı adı mevcut";
                return View();
            }
            else
            {
                user u = new user();
                u.kadi = kadi;
                u.parola = parola;
                u.rol =rol;
                k.users.Add(u);
            }
            k.SaveChanges();
            return RedirectToAction("Login", "Security");
        }
    }
}