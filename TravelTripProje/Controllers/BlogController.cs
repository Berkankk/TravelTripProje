using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Sınıflar;

namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
       Context c = new Context();   
        public ActionResult Index()
        {
            //var deger = c.Blogs.ToList();
            a.Deger1= c.Blogs.ToList();
            
            a.Deger3 = c.Blogs.OrderBy(x => x.Tarih).Take(3).ToList();
            return View(a);
        }

        Blogyorum a = new Blogyorum();
        public ActionResult BlogDetay(int id)
        {
            
            //var value  = c.Blogs.Where(x=>x.ID == id).ToList();

            a.Deger1=c.Blogs.Where(x=>x.ID==id).ToList();
            a.Deger2=c.Yorumlars.Where(x=> x.ID==id).ToList();  


            return View(a);
        }
        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            c.Yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();
        }
    }
}