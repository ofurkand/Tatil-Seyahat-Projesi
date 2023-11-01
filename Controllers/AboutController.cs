﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TatilSeyahatProje.Models.Siniflar;

namespace TatilSeyahatProje.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.hakkimizda.ToList();
            return View(degerler);
        }
    }
}