using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerseApp.Models;
using VerseApp.Services.Business;
using VerseApp.Services.Utility;

namespace VerseApp.Controllers
{
    public class VerseController : Controller
    {
        private static MyLogger logger = MyLogger.GetInstance();
        // GET: Verse
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateVerse()
        {
            return View();

        }

        [HttpPost]
        public ActionResult CreateVerse(VerseModel v)
        {

            logger.Info("Entering VerseController.CreateVerse() with " + v);
            if (ModelState.IsValid)
            {
                VerseBusinessService bs = new VerseBusinessService();
                bool result = bs.CreateVerse(v);
                string message;
                if (result)
                    message = "Verse successfully inserted";
                else
                    message = "Verse insertion failed.";

                logger.Info("Exiting VerseController.CreateVerse() with " + message);
                return View("Index");
            }
            else
                return View();
        }


        [HttpGet]
        public ActionResult SearchVerse()
        {
            return View("SearchVerse");
        }

        [HttpPost]
        public ActionResult SearchVerse(VerseModel v)
        {
            logger.Info("Entering VerseController.SearchVerse() with " + v);
            if (ModelState.IsValid)
            {
                VerseBusinessService bs = new VerseBusinessService();
                VerseModel result = bs.SearchVerse(v);

                logger.Info("Exiting VerseController.OnSearchVerse() with " + result);
                return View("~/Views/Verse/SearchResult.cshtml", result);
            }
            else
                return View();
        }
    }
}