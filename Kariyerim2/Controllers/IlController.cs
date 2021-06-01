using Kariyerim2.Models;
using Kariyerim2.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kariyerim2.Controllers
{
    public class IlController : Controller
    {
        KARIYER k = new KARIYER();
        // GET: Il
        public ActionResult Index()
        {
            List<il> eg = k.ils.ToList();

            ViewBag.il = eg;
            return View(eg);
        }
        [HttpPost]
        [MyCustomAuthorize(Roles = "a")]
        public string IlSil(int id)
        {
            il eg = k.ils.FirstOrDefault(x => x.il_kodu == id);
            k.ils.Remove(eg);
            try
            {
                k.SaveChanges();
                return "tamam";
            }
            catch (Exception)
            {
                return "hata";
            }

        }
        [MyCustomAuthorize(Roles = "a")]
        public ActionResult IlEkle()
        {
            il d = new il();
            return View(d);
        }
        [HttpPost]
        [MyCustomAuthorize(Roles = "a")]
        public ActionResult IlEkle(il eg)
        {
            il varmi = k.ils.FirstOrDefault(x => x.il_kodu == eg.il_kodu);
            if (varmi == null)
            {
                k.ils.Add(eg);
            }
            else
            {
                varmi.il_adi = eg.il_adi;
            }
            k.SaveChanges();
            return RedirectToAction("Index");
        }
        [MyCustomAuthorize(Roles = "a")]
        public ActionResult IlGuncelle(int id)
        {
            il eg = k.ils.FirstOrDefault(x => x.il_kodu == id);
            return View("IlEkle", eg);
        }
    }
}