using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TatilSeyahatProje.Models.Siniflar;
namespace TatilSeyahatProje.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogSil(int ID)
        {
            var b = c.blogs.Find(ID);
            var y = c.yorumlars.Where(x => x.BlogID == ID);
            foreach (var item in y)
            {
                var y2 = c.yorumlars.Find(item.ID);
                c.yorumlars.Remove(y2);
            }
            c.blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int ID)
        {
            var bul = c.blogs.Find(ID);
            return View("BlogGetir",bul);
        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = c.blogs.Find(b.ID);
            blg.Aciklama = b.Aciklama;
            blg.Baslik = b.Baslik;
            blg.BlogIMG = b.BlogIMG;
            blg.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YorumListesi()
        {
            //var yorumlar = c.yorumlars.OrderByDescending(x=>x.Blog.Baslik).ToList();
            var yorumlar = c.yorumlars.ToList();
            return View(yorumlar);
        }
        public ActionResult YorumSil(int ID)
        {
            var b = c.yorumlars.Find(ID);
            c.yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

        public ActionResult YorumGetir(int ID)
        {
            var yrm = c.yorumlars.Find(ID);
            return View(yrm);
        }

        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = c.yorumlars.Find(y.ID);
            yrm.KullaniciAdi = y.KullaniciAdi;
            yrm.Mail = y.Mail;
            yrm.Yorum = y.Yorum;
            yrm.Gorunurluk = y.Gorunurluk;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

        public ActionResult YorumOnayla(int ID)
        {
            var yrm = c.yorumlars.Find(ID);
            yrm.Gorunurluk = true;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public ActionResult Iletisim()
        {
            var iletisim = c.iletisims.ToList();
            return View(iletisim);
        }
        public ActionResult IletisimSil(int ID)
        {
            var b = c.iletisims.Find(ID);
            c.iletisims.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Iletisim");
        }

        public ActionResult IletisimGetir(int ID)
        {
            var i = c.iletisims.Find(ID);
            return View(i);
        }
        [HttpPost]
        public ActionResult IletisimGuncelle(Iletisim b)
        {
            var i = c.iletisims.Find(b.ID);
            i.Mesaj = b.Mesaj;
            i.Konu = b.Konu;
            i.AdSoyad = b.AdSoyad;
            i.Mail = b.Mail;
            c.SaveChanges();
            return RedirectToAction("Iletisim");
        }
    }
}