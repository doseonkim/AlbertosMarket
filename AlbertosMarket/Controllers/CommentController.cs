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
using System.Web.Routing;
using Microsoft.AspNet.Identity;

namespace AlbertosMarket.Controllers
{
    public class CommentController : Controller
    {
        private MarketContext db = new MarketContext();

        // GET: Comment
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.Author).Include(c => c.Market);
            return View(comments.ToList());
        }

        // GET: Comment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }


        [Authorize(Roles = "Author, Admin")]
        // GET: Comment/Create
        public ActionResult Create(int id)
        {
            ViewBag.MarketID = id;
            return View();
        }

        // POST: Comment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Author, Admin")]
        public ActionResult Create([Bind(Include = "CommentID,MarketID,Content")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.CommentDate = DateTime.Now;
                comment.AuthorID = User.Identity.GetUserId();
                //comment.Author = db.Authors.Find(comment.AuthorID);
                db.Comments.Add(comment);
                db.SaveChanges();
                // return RedirectToAction("Index");
                return RedirectToAction("Details", "Market", new { id = comment.MarketID });
            }

            ViewBag.AuthorID = new SelectList(db.Authors, "ID", "Name", comment.AuthorID);
            ViewBag.MarketID = new SelectList(db.Markets, "ID", "Title", comment.MarketID);
            return View(comment);
        }

        // GET: Comment/Edit/5
        [Authorize(Roles = "Author")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            if (!comment.AuthorID.Equals(User.Identity.GetUserId()))
            {
                return View("~/Views/Shared/NotOwner.cshtml");
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "Name", comment.AuthorID);
            ViewBag.MarketID = new SelectList(db.Markets, "ID", "Title", comment.MarketID);
            return View(comment);
        }

        // POST: Comment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuthorID,CommentID,MarketID,CommentDate,Content")] Comment comment)
        {
            if (!User.Identity.GetUserId().Equals(comment.AuthorID))
            {
                return View("~/Views/Shared/NotOwner.cshtml");
            }
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Market", new { id = comment.MarketID });
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "Name", comment.AuthorID);
            ViewBag.MarketID = new SelectList(db.Markets, "ID", "Title", comment.MarketID);
            return View(comment);
        }

        // GET: Comment/Delete/5
        [Authorize(Roles = "Author")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            if (!comment.AuthorID.Equals(User.Identity.GetUserId()))
            {
                return View("~/Views/Shared/NotOwner.cshtml");
            }
            return View(comment);
        }

        // POST: Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Author")]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            if (!comment.AuthorID.Equals(User.Identity.GetUserId()))
            {
                return View("~/Views/Shared/NotOwner.cshtml");
            }
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Details", "Market", new { id = comment.MarketID });
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