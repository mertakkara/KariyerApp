using Kariyerim2.Models;
using Kariyerim2.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kariyerim2.Controllers
{
    public class SektorController : Controller
    {
        KARIYER k = new KARIYER();
        // GET: Sektor
        public ActionResult Index()
        {
            List<sektor> sek = k.sektors.ToList();
            ViewBag.sektor = sek;
            return View(sek);
        }
        [HttpPost]
        [MyCustomAuthorize(Roles = "a")]
        public string SektorSil(int id)
        {
            sektor sek = k.sektors.FirstOrDefault(x => x.sektor_id == id);
            k.sektors.Remove(sek);
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
        public ActionResult SektorEkle()
        {
            sektor d = new sektor();
            return View(d);
        }
        [HttpPost]
        [MyCustomAuthorize(Roles = "a")]
        public ActionResult SektorEkle(sektor sek)
        {
            sektor varmi = k.sektors.FirstOrDefault(x => x.sektor_id == sek.sektor_id);
            if (varmi == null)
            {
                k.sektors.Add(sek);
            }
            else
            {
                varmi.sektor_adi = sek.sektor_adi;
                varmi.sektor_tanimi = sek.sektor_tanimi;

            }
            k.SaveChanges();
            return RedirectToAction("Index");
        }
        [MyCustomAuthorize(Roles = "a")]
        public ActionResult SektorGuncelle(int id)
        {
            sektor sek = k.sektors.FirstOrDefault(x => x.sektor_id == id);
            return View("SektorEkle", sek);
        }
    }
}