using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelTripProje.Models.Sınıflar;

namespace TravelTripProje.Controllers
{
    public class GirisYapController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var value = c.Admins.FirstOrDefault(x=>x.Kullanici == admin.Kullanici && x.Sifre==admin.Sifre);
            if(value != null)
            {
                FormsAuthentication.SetAuthCookie(value.Kullanici,false);
                Session["Kullanıcı"] = value.Kullanici.ToString();
                return RedirectToAction("Index","Admin");
            }
            else
            {
                return View();
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "GirisYap");
        }

    }
}