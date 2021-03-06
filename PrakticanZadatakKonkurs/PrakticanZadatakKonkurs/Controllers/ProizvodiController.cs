﻿using Newtonsoft.Json;
using PrakticanZadatakKonkurs.Models;
using PrakticanZadatakKonkurs.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
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

        //GET
        public ActionResult Dodaj()
        {
            return View();
        }

        /// <summary>
        /// Metoda vrsi dodavanje novog proizvoda u bazu
        /// </summary>
        /// <param name="proizvod"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Dodaj(Proizvod proizvod)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    db.Proizvodi.Add(proizvod);
                    db.SaveChanges();

                    ViewBag.Poruka = "Uspeh";
                    ModelState.Clear();
                    return View();
                }
                catch (Exception)
                {
                    ViewBag.Poruka = "Greska";
                    ModelState.Clear();
                    return View();
                }
            }
            ViewBag.Poruka = "Greska";
            ModelState.Clear();
            return View();
        }

        //GET
        public ActionResult Izmeni(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proizvod proizvod = db.Proizvodi.Find(id);
            if(proizvod==null)
            {
                return HttpNotFound();
            }
            return View(proizvod);
        }

        /// <summary>
        /// Metoda vrsi izmenu postojeceg proizvoda u bazi
        /// </summary>
        /// <param name="proizvod"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Izmeni(Proizvod proizvod)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    db.Entry(proizvod).State = EntityState.Modified;
                    db.SaveChanges();

                    ViewBag.Poruka = "Uspeh";
                    return View();
                }
                catch (Exception)
                {
                    ViewBag.Poruka = "Greska";
                    return View();
                }
            }
            ViewBag.Poruka = "Greska";
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}