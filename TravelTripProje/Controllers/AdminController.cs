using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Sınıflar;

namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var value = c.Blogs.ToList(); 
            return View(value);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View(); //Sayfada herhangi bir şey yaptırmaz sadece ekrana getirir
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogSil(int id)
        {
            var icardi = c.Blogs.Find(id);
            c.Blogs.Remove(icardi);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var bl = c.Blogs.Find(id);
            return View("BlogGetir", bl);
        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var mertens = c.Blogs.Find(b.ID);
            mertens.Aciklama = b.Aciklama;
            mertens.Baslik=b.Baslik;
            mertens.BlogImage = b.BlogImage;
            mertens.Tarih=b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumListesi()
        {
            var yorum = c.Yorumlars.ToList();
            return View(yorum);
        }
        public ActionResult YorumSil(int id)
        {
            var b = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public ActionResult YorumGetir(int id)
        {
            var yr = c.Yorumlars.Find(id);
            return View("YorumGetir", yr);
        }
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var mertens = c.Yorumlars.Find(y.ID);
            mertens.KullaniciAdi = y.KullaniciAdi;
            mertens.Yorum = y.Yorum;
            mertens.Mail = y.Mail; 
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}