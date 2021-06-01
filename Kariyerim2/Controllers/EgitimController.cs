using Kariyerim2.Models;
using Kariyerim2.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kariyerim2.Controllers
{
    public class EgitimController : Controller
    {
        KARIYER k = new KARIYER();
        // GET: Egitim
        public ActionResult Index()
        {

            List<egitim> eg = k.egitims.ToList();

            ViewBag.egitim = eg;
            return View(eg);
        }
        [HttpPost]
        [MyCustomAuthorize(Roles = "a")]
        public string EgitimSil(int id)
        {
            egitim eg = k.egitims.FirstOrDefault(x => x.egitim_id == id);
            k.egitims.Remove(eg);
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
        public ActionResult EgitimEkle()
        {
            egitim d = new egitim();
            return View(d);
        }
        [HttpPost]
        [MyCustomAuthorize(Roles = "a")]
        public ActionResult EgitimEkle(egitim eg)
        {
            egitim varmi = k.egitims.FirstOrDefault(x => x.egitim_id == eg.egitim_id);
            if (varmi == null)
            {
                k.egitims.Add(eg);
            }
            else
            {
                varmi.egitim_adi = eg.egitim_adi;
                varmi.egitim_tanimi = eg.egitim_tanimi;
            }
            k.SaveChanges();
            return RedirectToAction("Index");
        }
        [MyCustomAuthorize(Roles = "a")]
        public ActionResult EgitimGuncelle(int id)
        {
            egitim eg = k.egitims.FirstOrDefault(x => x.egitim_id == id);

            return View("EgitimEkle", eg);
        }

    }
}