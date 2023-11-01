using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TatilSeyahatProje.Models.Siniflar;

namespace TatilSeyahatProje.Controllers
{
    public class HomeController : Controller
    {
        Context c = new Context();
        public class Temp
        {
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public string Mail { get; set; }
            public string Konu { get; set; }
            public string Ileti { get; set; }
        }
        public ActionResult Index()
        {
            var degerler = c.blogs.OrderByDescending(x => x.ID).Take(4).ToList();
            return View(degerler);
        }

        public ActionResult About()
        {
            /*ViewBag.Message = "Your application description page.";*/

            return View();
        }
        [HttpGet]
        public ActionResult Iletisim()
        {
            /*ViewBag.Message = "Your contact page.";*/
            /*var konular = new List<string>() { "Sorun Bildir","Öneri Paylaş","Müşteri Hizmetleri","Diğer"};
            ViewBag.konular = konular;*/
            return View();
        }
        [HttpPost]
        public ActionResult Iletisim(Temp i)
        {
        /*ViewBag.Message = "Your contact page.";*/
        Iletisim ornek = new Iletisim();
            ornek.AdSoyad = (i.Ad +" "+ i.Soyad);
            ornek.Mail = i.Mail;
            ornek.Konu = i.Konu;
            ornek.Mesaj = i.Ileti;
            c.iletisims.Add(ornek);
            c.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        public PartialViewResult Partial1()
        {
            var degerler = c.blogs.OrderByDescending(x=>x.ID).Take(2).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Partial2()
        {
            var deger = c.blogs.Where(x=>x.ID==1).ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial3()
        {
            var deger = c.blogs.Take(10).ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial4()
        {
            var deger = c.blogs.Take(4).ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial5()
        {
            var deger = c.blogs.OrderByDescending(x => x.ID).Take(4).ToList();
            return PartialView(deger);
        }
    }
}