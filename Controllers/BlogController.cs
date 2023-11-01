using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TatilSeyahatProje.Models.Siniflar;

namespace TatilSeyahatProje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BlogDetay(int ID) 
        {
            if (c.blogs.Find(ID) != null)
            {
                by.Deger1 = c.blogs.Where(x=>x.ID == ID).ToList();
                by.Deger2 = c.yorumlars.Where(x=> x.BlogID == ID).Where(x => x.Gorunurluk == true).OrderByDescending(x=> x.ID).ToList();
                return View(by);
            }
            else 
            {
                if (ID > 0)
                {
                    return RedirectToAction("BlogDetay/" + (ID - 1).ToString(), "Blog");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

        }
        public PartialViewResult Partial1()
        {
            by.Deger2 = c.yorumlars.Where(x => x.Gorunurluk == true).OrderByDescending(x => x.ID).Take(3).ToList();
            by.Deger3 = c.blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(by);
        }
        [HttpGet]
        public PartialViewResult YorumYap(int ID)
        {
            ViewBag.deger = ID;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            c.yorumlars.Add(y);
            c.SaveChanges();

            return PartialView();
        }        
        int sayi = 5;
        bool fazla = true;
        [HttpGet]
        public PartialViewResult Partial2()
        {
            //var bloglar = c.blogs.ToList();
            by.Deger1 = c.blogs.Take(sayi).ToList();
            ViewBag.Fazlalik = fazla;
            return PartialView(by);
        }

        [HttpPost]
        public PartialViewResult Partial2(bool x)
        {
            //var bloglar = c.blogs.ToList();
            if ((c.blogs.Count() - sayi) > 5)
            {
                sayi += 5;
                return PartialView();
            }
            else if (c.blogs.Count() - sayi > 0)
            {
                sayi = c.blogs.Count();
                ViewBag.Fazlalik = false;
                return PartialView();
            }
            else
            {
                return PartialView();
            }
        }
    }
}