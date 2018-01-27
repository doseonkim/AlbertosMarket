using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlbertosMarket.DAL;
using AlbertosMarket.Models;
using PagedList;
using System.Data.Entity.Infrastructure;

namespace AlbertosMarket.Controllers
{
    public class MarketController : Controller
    {
        private MarketContext db = new MarketContext();

        // GET: Market
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "Name";
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "date_asc" : "";
            ViewBag.NameSortParm = sortOrder == "name_asc" ? "name_desc" : "name_asc";
            ViewBag.TitleSortParm = sortOrder == "title_asc" ? "title_desc" : "title_asc";
            ViewBag.PriceSortParm = sortOrder == "price_asc" ? "price_desc" : "price_asc";
            ViewBag.OptionSortParm = sortOrder == "option_asc" ? "option_desc" : "option_asc";


            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var markets = from s in db.Markets
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                markets = markets.Where(s => s.Author.Contains(searchString)
                                       || s.Title.Contains(searchString)
                                       || s.Post.Contains(searchString)
                                       || s.Option.ToString().Contains(searchString));
            }
            switch (sortOrder)
            {
                case "option_desc":
                    markets = markets.OrderByDescending(s => s.Option);
                    break;
                case "option_asc":
                    markets = markets.OrderBy(s => s.Option);
                    break;
                case "price_desc":
                    markets = markets.OrderByDescending(s => s.Price);
                    break;
                case "price_asc":
                    markets = markets.OrderBy(s => s.Price);
                    break;
                case "title_desc":
                    markets = markets.OrderByDescending(s => s.Title);
                    break;
                case "title_asc":
                    markets = markets.OrderBy(s => s.Title);
                    break;
                case "name_desc":
                    markets = markets.OrderByDescending(s => s.Author);
                    break;
                case "name_asc":
                    markets = markets.OrderBy(s => s.Author);
                    break;
                case "date_asc":
                    markets = markets.OrderBy(s => s.PostDate);
                    break;
                default:
                    markets = markets.OrderByDescending(s => s.PostDate);
                    break;
            }


            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(markets.ToPagedList(pageNumber, pageSize));
        }

        // GET: Market/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Market market = db.Markets.Find(id);
            if (market == null)
            {
                return HttpNotFound();
            }
            return View(market);
        }

        // GET: Market/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Market/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Author,PostDate,Option,Price,Title,Post")] Market market)
        {
            try
            {
                    if (ModelState.IsValid)
                {
                    db.Markets.Add(market);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(market);
        }

        // GET: Market/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Market market = db.Markets.Find(id);
            if (market == null)
            {
                return HttpNotFound();
            }
            return View(market);
        }

        // POST: Market/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Author,PostDate,Option,Price,Title,Post")] Market market)
        {
            if (ModelState.IsValid)
            {
                db.Entry(market).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(market);
        }*/

          
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var market = db.Markets.Find(id);
            if (TryUpdateModel(market))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            } 
            return View(market);
        }

        // GET: Market/Delete/5
        /*public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Market market = db.Markets.Find(id);
            if (market == null)
            {
                return HttpNotFound();
            }
            return View(market);
        }*/


        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Market market = db.Markets.Find(id);
            if (market == null)
            {
                return HttpNotFound();
            }
            return View(market);
        }

        // POST: Market/Delete/5
        /*[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Market market = db.Markets.Find(id);
            db.Markets.Remove(market);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Market market = db.Markets.Find(id);
                db.Markets.Remove(market);
                db.SaveChanges();
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
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
