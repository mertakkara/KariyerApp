using Kariyerim2.Models;
using Kariyerim2.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kariyerim2.Controllers
{
    public class IsController : Controller
    {
        KARIYER k = new KARIYER();
        // GET: Is
        public ActionResult Index()
        {
            List<isi> isi = k.isis.ToList();
            List<pozisyon> poz = k.pozisyons.ToList();
            List<departman> dep = k.departmen.ToList();
            List<egitim> eg = k.egitims.ToList();
            List<isyeri> isye = k.isyeris.ToList();
            ViewBag.isi = isi;
            ViewBag.pozisyon = poz;
            ViewBag.departman = dep;
            ViewBag.egitim = eg;
            ViewBag.isyeri = isye;
            return View(isi);
        }
        [MyCustomAuthorize(Roles = "a")]
        public ActionResult IsSil(int id)
        {
            isi i = k.isis.FirstOrDefault(x => x.is_id == id);

            return View(i);
        }
        [HttpPost]
        [MyCustomAuthorize(Roles = "a")]
        public ActionResult IsSil(isi i)
        {
            isi isim = k.isis.FirstOrDefault(x => x.is_id == i.is_id);
            k.isis.Remove(isim);
            k.SaveChanges();

            return RedirectToAction("Index");
        }
        [MyCustomAuthorize(Roles = "a,i")]
        public ActionResult IsEkle()
        {
            ViewBag.isi = k.isis.ToList();
            ViewBag.pozisyon = k.pozisyons.ToList();
            ViewBag.departman = k.departmen.ToList();
            ViewBag.egitim = k.egitims.ToList();
            ViewBag.isyeri = k.isyeris.ToList();

            return View();
        }
        [HttpPost]
        [MyCustomAuthorize(Roles = "a,i")]
        public ActionResult IsEkle(isi i)
        {

            k.isis.Add(i);
            k.SaveChanges();

            return RedirectToAction("Index");
        }
        [MyCustomAuthorize(Roles = "a")]
        public ActionResult IsGuncelle(int id)
        {
            ViewBag.isi = k.isis.ToList();
            ViewBag.pozisyon = k.pozisyons.ToList();
            ViewBag.departman = k.departmen.ToList();
            ViewBag.egitim = k.egitims.ToList();
            ViewBag.isyeri = k.isyeris.ToList();
            isi isim = k.isis.FirstOrDefault(x => x.is_id == id);
            return View(isim);
        }
        [MyCustomAuthorize(Roles = "a")]
        [HttpPost]
        public ActionResult IsGuncelle(isi u)
        {
            isi urun = k.isis.FirstOrDefault(x => x.is_id == u.is_id);
            urun.pozisyon_id = u.pozisyon_id;
            urun.departman_id = u.departman_id;
            urun.egitim_id = u.egitim_id;
            urun.is_yeri_id = u.is_yeri_id;
            k.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BasvuruFiltrele(string name)
        {
             List<isi> isi = k.isis.Where(x => x.isyeri.is_yeri_adi.Contains(name)).ToList();
            List<pozisyon> poz = k.pozisyons.ToList();
            List<departman> dep = k.departmen.ToList();
            List<egitim> eg = k.egitims.ToList();
            List<isyeri> isye = k.isyeris.ToList();
            ViewBag.isi = isi;
            ViewBag.pozisyon = poz;
            ViewBag.departman = dep;
            ViewBag.egitim = eg;
            ViewBag.isyeri = isye;
            return View(isi);
        }
    }
}