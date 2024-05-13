using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Sınıflar;

namespace TravelTripProje.Controllers
{
    public class DefaultController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var deger = c.Blogs.Take(6).ToList();
            //take kullanarak ilk 6  fotoğrafı getirdik.
            return View(deger);
        }
        public ActionResult About()
        {
            return View();
        }
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        public PartialViewResult Partial2()
        {
            var value = c.Blogs.ToList();
            return PartialView(value);
        }
        public PartialViewResult Partial3()
        {
            var value = c.Blogs.Take(3).ToList();
            return PartialView(value);
        }
        public PartialViewResult Partial4()
        {
            var deger = c.Blogs.Take(3).OrderByDescending(x =>x.ID).ToList();
            return PartialView(deger);
        }
    }
}