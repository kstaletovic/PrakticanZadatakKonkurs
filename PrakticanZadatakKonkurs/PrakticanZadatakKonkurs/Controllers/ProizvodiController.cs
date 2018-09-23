﻿using Newtonsoft.Json;
using PrakticanZadatakKonkurs.Models;
using PrakticanZadatakKonkurs.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrakticanZadatakKonkurs.Controllers
{
    public class ProizvodiController : Controller
    {
        AppContext db = new AppContext();
        // GET: Proizvodi
        public ActionResult Index()
        {
            //Pravljenje StreamReader objekta za iscitavanje podataka iz JSON fajla
            List<Proizvod> proizvodiJSON;
            using (StreamReader sr = new StreamReader(Server.MapPath("~/Content/Proizvodi.json")))
            {
                proizvodiJSON = JsonConvert.DeserializeObject<List<Proizvod>>(sr.ReadToEnd());
            }

            List<Proizvod> proizvodiBaza = db.Proizvodi.ToList();

            var proizvodi = new ProizvodiViewModel()
            {
                ProizvodiJSON = proizvodiJSON,
                ProizvodiBaza = proizvodiBaza
            };

            return View(proizvodi);
        }
    }
}