using Kariyerim2.Models;
using Kariyerim2.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kariyerim2.Controllers
{
    public class DepartmanController : Controller
    {
        KARIYER k = new KARIYER();
        // GET: Departman
        public ActionResult Index()
        {
            List<departman> dep = k.departmen.ToList();

            ViewBag.departman = dep;
            return View(dep);
        }
        [HttpPost]
        [MyCustomAuthorize(Roles = "a")]
        public string DepartmanSil(int id)
        {
            departman dep = k.departmen.FirstOrDefault(x => x.departman_id == id);
            k.departmen.Remove(dep);
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
        public ActionResult DepartmanEkle()
        {
            departman d = new departman();


            return View(d);
        }
        [HttpPost]
        [MyCustomAuthorize(Roles = "a")]
        public ActionResult DepartmanEkle(departman dep)
        {
            departman varmi = k.departmen.FirstOrDefault(x => x.departman_id == dep.departman_id);
            if (varmi == null)
            {
                k.departmen.Add(dep);
            }
            else
            {

                varmi.departman_adi = dep.departman_adi;
                varmi.departman_tanimi = dep.departman_tanimi;

            }
            //  k.pozisyons.AddOrUpdate(kat);

            k.SaveChanges();
            return RedirectToAction("Index");
        }
        [MyCustomAuthorize(Roles = "a")]
        public ActionResult DepartmanGuncelle(int id)
        {
            departman dep = k.departmen.FirstOrDefault(x => x.departman_id == id);

            return View("DepartmanEkle", dep);
        }

    }
}