using Kariyerim2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kariyerim2.Controllers
{
    public class IsIsciController : Controller
    {
        KARIYER k = new KARIYER();
        public ActionResult Index()
        {
        user isim2 = k.users.FirstOrDefault(x => x.kadi.Equals(HttpContext.User.Identity.Name));
        List<isisci> isi = k.isiscis.Where(x => x.kid == isim2.kid).ToList();
        return View(isi);
        }
    }
}