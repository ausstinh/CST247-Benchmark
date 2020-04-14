using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VerseApp.Models;
using VerseApp.Services.Utility;
using VerseApp.Services.Data;

namespace VerseApp.Services.Business
{
    public class VerseBusinessService
    {
        private static MyLogger logger = MyLogger.GetInstance();

        public bool CreateVerse(VerseModel v)
        {
            logger.Info("Entering VerseBusinessService.CreateVerse() with " + v);
            VerseDataService ds = new VerseDataService();
            bool result = ds.Create(v);
            logger.Info("Exiting VerseBusinessService.CreateVerse() with " + result);
            return result;
        }

        public VerseModel SearchVerse(VerseModel v)
        {
            logger.Info("Entering VerseBusinessService.SearchVerse() with " + v);
            VerseDataService ds = new VerseDataService();
            VerseModel result = ds.Read(v);
            logger.Info("Exiting VerseBusinessService.SearchVerse() with " + result);
            return result;
        }
    }
}