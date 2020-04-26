using Activity3.Models;
using Activity3.Services.Business;
using Activity3.Services.Utility;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Caching;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Activity3.Controllers {

    public class BibleController : Controller {

        // GET: Home page
        public ActionResult Index() {
            return View("HomePage");
        }
        // GET: add page
        public ActionResult Add() {
            return View("AddVerse");
        }        
        // GET: Search page
        public ActionResult Search() {
            return View("SearchForVerse");
        }

        //method used to create a new verse
        [HttpPost]
        public ActionResult addVerse(BibleVerse bibleVerse) {

            //put an item in the log file stateting you've entered this method
            MyLogger.GetInstance().Info("");
            MyLogger.GetInstance().Info("Entering the BibleController. addVerse() method");
            try {

                //Call the Security Business Service createVerse() method from the addVerse() method
                //and save the results of the method call in a local variable: success

                SecurityService securityService = new SecurityService();
                Boolean success = securityService.createVerse(bibleVerse);

                if (success) {
                    MyLogger.GetInstance().Info("Exiting the addVerse() in BibleController. Add Success!");

                    return View("AddVerseSuccess");
                } else {
                    MyLogger.GetInstance().Info("Exiting the BibleController. Login Failure");

                    return View("AddVerseFail");
                }
            } catch (Exception e) {
                MyLogger.GetInstance().Error("Exception!" + e.Message);

                return Content("Exception in addVerse" + e.Message);
            }
        }

        //Method used to search for a verse 
        [HttpPost]
        public ActionResult searchVerse(BibleVerse bibleVerse) {
            Debug.WriteLine(bibleVerse.ChapterNumber);

            //put an item in the log file stateting you've entered this method
            MyLogger.GetInstance().Info("");
            MyLogger.GetInstance().Info("Entering the BibleController. searchVerse() method");
            try {

                //Call the Security Business Service findVerse() method from the searchVerse() method
                //and save the results of the method call in a local variable: returnedVerse

                SecurityService securityService = new SecurityService();
                BibleVerse returnedVerse = securityService.findVerse(bibleVerse);
                Debug.WriteLine("controller return: " + returnedVerse.VerseText);

                if (returnedVerse.VerseText == "") {
                    MyLogger.GetInstance().Info("Exiting the BibleController. searchVerse Failure");

                    return View("SearchVerseFail");
                } else {
                    MyLogger.GetInstance().Info("Exiting the searchVerse() in BibleController. searchVerse Success!");

                    return View("SearchVerseResult", returnedVerse);
                }
            } catch (Exception e) {
                MyLogger.GetInstance().Error("Exception!" + e.Message);

                return Content("Exception in searchVerse" + e.Message);
            }
        }




    }
}