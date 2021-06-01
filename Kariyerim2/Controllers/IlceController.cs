using Kariyerim2.Models;
using Kariyerim2.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kariyerim2.Controllers
{
    public class IlceController : Controller
    {
        KARIYER k = new KARIYER();
        // GET: Ilce
        public ActionResult Index()
        {

            List<ilce> eg = k.ilces.ToList();
            List<il> eg2 = k.ils.ToList();

            ViewBag.ilce = eg;
            ViewBag.il = eg2;
            return View(eg);
        }
        [MyCustomAuthorize(Roles = "a")]
        public ActionResult IlceSil(int id)
        {
            ilce i = k.ilces.FirstOrDefault(x => x.ilce_kodu == id);

            return View(i);
        }
        [HttpPost]
        [MyCustomAuthorize(Roles = "a")]
        public ActionResult IlceSil(ilce i)
        {
            ilce isim = k.ilces.FirstOrDefault(x => x.ilce_kodu == i.ilce_kodu);
            k.ilces.Remove(isim);
            k.SaveChanges();

            return RedirectToAction("Index");
        }
        [MyCustomAuthorize(Roles = "a")]
        public ActionResult IlceEkle()
        {
            List<ilce> eg = k.ilces.ToList();
            List<il> eg2 = k.ils.ToList();

            ViewBag.ilce = eg;
            ViewBag.il = eg2;
            
            return View();
        }
        [HttpPost]
        [MyCustomAuthorize(Roles = "a")]
        public ActionResult IlceEkle(ilce eg)
        {

            k.ilces.Add(eg);
            k.SaveChanges();

            return RedirectToAction("Index");
        }
      
        [MyCustomAuthorize(Roles = "a")]
        public ActionResult IlceGuncelle(int id)
        {
            List<ilce> eg = k.ilces.ToList();
            List<il> eg2 = k.ils.ToList();

            ViewBag.ilce = eg;
            ViewBag.il = eg2;
            ilce isim = k.ilces.FirstOrDefault(x => x.ilce_kodu == id);


            return View(isim);
        }
        [MyCustomAuthorize(Roles = "a")]
        [HttpPost]
        public ActionResult IlceGuncelle(ilce u)
        {
            ilce urun = k.ilces.FirstOrDefault(x => x.ilce_kodu == u.ilce_kodu);
            if (urun == null)
            {

            }
            else
            {
                urun.ilce_adi = u.ilce_adi;
                urun.il_kodu = u.il_kodu;
           
            }


            k.SaveChanges();
            return RedirectToAction("Index");
        }
    
}
}