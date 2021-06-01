using Kariyerim2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kariyerim2.Controllers
{
    public class IsBasvuruController : Controller
    {
        KARIYER k = new KARIYER();
        // GET: IsBasvuru
        public ActionResult Index()
        {

            List<isi> isi = k.isis.ToList();
            List<pozisyon> poz = k.pozisyons.ToList();
            List<departman> dep = k.departmen.ToList();
            List<egitim> eg = k.egitims.ToList();
            List<isyeri> isye = k.isyeris.ToList();
            List<il> il = k.ils.ToList();
            List<ilce> ilce = k.ilces.ToList();


            ViewBag.isi = isi;
            ViewBag.pozisyon = poz;
            ViewBag.departman = dep;
            ViewBag.egitim = eg;
            ViewBag.isyeri = isye;
            ViewBag.il = il;
            ViewBag.ilce = ilce;

            return View(isi);
        }
        public ActionResult IseBasvur(int id)
        {
            isi i = k.isis.FirstOrDefault(x => x.is_id == id);
            return View(i);
        }
        [HttpPost]
        public ActionResult IseBasvur(isi i, string ad)
        {
            isisci isim = new isisci();
            user isim2 = k.users.FirstOrDefault(x => x.kadi.Equals(ad));
            isim.is_id = i.is_id;
            isim.kid = isim2.kid;
            isisci deneme = k.isiscis.FirstOrDefault(x => x.is_id == isim.is_id);
            isisci deneme2 = k.isiscis.FirstOrDefault(x => x.kid == isim.kid);
            if (deneme != null && deneme2 != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                k.isiscis.Add(isim);
                k.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult BasvuruFiltrele(int pozisyon_id,int departman_id, int egitim_id,int il_kodu,int ilce_kodu)
        {
            List<pozisyon> poz = k.pozisyons.ToList();
            List<departman> dep = k.departmen.ToList();
            List<egitim> eg = k.egitims.ToList();
            List<isyeri> isye = k.isyeris.ToList();
            List<il> il = k.ils.ToList();
            List<ilce> ilce = k.ilces.ToList();
            List<isi> isi = k.isis.Where(x => x.pozisyon_id == pozisyon_id && x.departman_id == departman_id && x.egitim_id == egitim_id && x.isyeri.ilce.il.il_kodu == il_kodu && x.isyeri.ilce.ilce_kodu == ilce_kodu).ToList();
            ViewBag.isi = isi;
            ViewBag.pozisyon = poz;
            ViewBag.departman = dep;
            ViewBag.egitim = eg;
            ViewBag.isyeri = isye;
            ViewBag.il = il;
            ViewBag.ilce = ilce;
            return View(isi);
        }
    }
}