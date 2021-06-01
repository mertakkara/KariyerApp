using Kariyerim2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kariyerim2.Controllers
{
    public class PozisyonController : Controller
    {
        KARIYER k = new KARIYER();
        // GET: Pozisyon
        public ActionResult Index()
        {
            List<pozisyon> poz = k.pozisyons.ToList();

            ViewBag.pozisyon = poz;
            return View(poz);
        }
        public ActionResult PozisyonSil(int id)
        {
            pozisyon poz = k.pozisyons.FirstOrDefault(x => x.pozisyon_id == id);

            return View(poz);
        }
        [HttpPost]
        public ActionResult PozisyonSil(pozisyon p)
        {
            pozisyon poz = k.pozisyons.FirstOrDefault(x => x.pozisyon_id == p.pozisyon_id);
            k.pozisyons.Remove(poz);
            k.SaveChanges();

            return RedirectToAction("Index");
            
        }
        [Authorize]
        public ActionResult PozisyonEkle()
        {
            pozisyon p = new pozisyon();


            return View(p);
        }
        [HttpPost]
        public ActionResult PozisyonEkle(pozisyon poz)
        {
            pozisyon varmi = k.pozisyons.FirstOrDefault(x => x.pozisyon_id == poz.pozisyon_id);
            if (varmi == null)
             {
                 k.pozisyons.Add(poz);
             }
             else
             {

                 varmi.pozisyon_adi = poz.pozisyon_adi;
                 
             }
          //  k.pozisyons.AddOrUpdate(kat);

            k.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult PozisyonGuncelle(int id)
        {
            pozisyon kat = k.pozisyons.FirstOrDefault(x => x.pozisyon_id == id);

            return View("PozisyonEkle", kat);
        }
    }
}