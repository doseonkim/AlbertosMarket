using AlbertosMarket.DAL;
using AlbertosMarket.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlbertosMarket.Controllers
{
    public class HomeController : Controller
    {
        private MarketContext db = new MarketContext();

        public ActionResult Index()
        {
            return View();
        }

        /*public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }*/

        public ActionResult About()
        {
            IQueryable<TradeOptionGroup> data = from market in db.Markets
                                                   group market by market.Option into dateGroup
                                                   select new TradeOptionGroup()
                                                   {
                                                       Option = dateGroup.Key,
                                                       TradeCount = dateGroup.Count()
                                                   };
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


    }
}