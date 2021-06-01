using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kariyerim2.Models;
using Kariyerim2.Security;

namespace Kariyerim2.Controllers
{
    public class IsyeriController : Controller
    {
        KARIYER k = new KARIYER();

        // GET: Isyeri
        public ActionResult Index()
        {
            List<isyeri> isyeri = k.isyeris.ToList();
            List<ilce> ilce = k.ilces.ToList();
            List<sektor> sek = k.sektors.ToList();
            
            ViewBag.isyeri = isyeri;
            ViewBag.ilce = ilce;
            ViewBag.sek = sek;
            return View(isyeri);
        }
        [MyCustomAuthorize(Roles = "a")]
        public ActionResult IsyeriSil(int id)
        {
            isyeri i = k.isyeris.FirstOrDefault(x => x.is_yeri_id == id);

            return View(i);
        }
        [HttpPost]
        [MyCustomAuthorize(Roles = "a")]
        public ActionResult IsyeriSil(isyeri i)
        {
            isyeri isim = k.isyeris.FirstOrDefault(x => x.is_yeri_id == i.is_yeri_id);
            k.isyeris.Remove(isim);
            k.SaveChanges();

            return RedirectToAction("Index");
        }
        [MyCustomAuthorize(Roles = "a")]
        public ActionResult IsyeriEkle()
        {
            List<isyeri> isyeri = k.isyeris.ToList();
            List<ilce> ilce = k.ilces.ToList();
            List<sektor> sektor = k.sektors.ToList();

            ViewBag.isyeri = isyeri;
            ViewBag.ilce = ilce;
            ViewBag.sektor = sektor;

            return View();
        }
        [HttpPost]
        [MyCustomAuthorize(Roles = "a")]
        public ActionResult IsyeriEkle(isyeri iy)
        {

            k.isyeris.Add(iy);
            k.SaveChanges();

            return RedirectToAction("Index");
        }

        [MyCustomAuthorize(Roles = "a")]
        public ActionResult IsyeriGuncelle(int id)
        {
            List<isyeri> eg = k.isyeris.ToList();
            List<ilce> eg2 = k.ilces.ToList();
            List<sektor> sek = k.sektors.ToList();
            ViewBag.isyeri = eg;
            ViewBag.ilce = eg2;
            ViewBag.sektor = sek;
            isyeri isim = k.isyeris.FirstOrDefault(x => x.is_yeri_id == id);


            return View(isim);
        }
        [MyCustomAuthorize(Roles = "a")]
        [HttpPost]
        public ActionResult IsyeriGuncelle(isyeri u)
        {
            isyeri urun = k.isyeris.FirstOrDefault(x => x.is_yeri_id == u.is_yeri_id);
            if (urun == null)
            {

            }
            else
            {
                urun.is_yeri_adi = u.is_yeri_adi;
                urun.sektor_id = u.sektor_id;
                urun.ilce_id = u.ilce_id;
            }


            k.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
