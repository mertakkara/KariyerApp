using Kariyerim2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kariyerim2.Controllers
{
    public class MesajController : Controller
    {
        KARIYER k = new KARIYER();
        // GET: Mesaj
        public ActionResult Index()
        {
            List<mesaj> poz = k.mesajs.ToList();

            ViewBag.mesaj = poz;
            return View(poz);
        }
      
        [AllowAnonymous]
        public ActionResult MesajGonder(string name, string title, string message)
        {

            mesaj mesajm = new mesaj();
            mesajm.name = name;
            mesajm.title = title;
            mesajm.message = message;
            return View(mesajm);

        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult MesajGonder(mesaj mesajm)
        {
            
            k.mesajs.Add(mesajm);
            k.SaveChanges();

            return RedirectToAction("Index","Is");

        }
        public ActionResult MesajSil(int id)
        {
            mesaj m = k.mesajs.FirstOrDefault(x => x.mesaj_id == id);

            return View(m);
        }
        [HttpPost]
        public ActionResult MesajSil(mesaj m)
        {
            mesaj mes = k.mesajs.FirstOrDefault(x => x.mesaj_id == m.mesaj_id);
            k.mesajs.Remove(mes);
            k.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}