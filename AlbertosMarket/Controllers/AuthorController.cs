﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlbertosMarket.DAL;
using AlbertosMarket.Models;
using AlbertosMarket.ViewModels;
using Microsoft.AspNet.Identity;

namespace AlbertosMarket.Controllers
{
    public class AuthorController : Controller
    {
        private MarketContext db = new MarketContext();

        // GET: Author
        /*public ActionResult Index()
        {
            return View(db.Authors.ToList());
        }*/

        public ActionResult Index(string id)
        {
            var viewModel = new AuthorIndexData();
            viewModel.Authors = db.Authors
                .Include(i => i.Markets)
                .Include(i => i.Comments)
                .OrderBy(i => i.JoinDate);

            if (id != null)
            {
                ViewBag.AuthorID = id.ToString();
                viewModel.Markets = viewModel.Authors.Where(
                    i => i.ID.Equals(id.ToString())).Single().Markets;

                viewModel.Comments = viewModel.Authors.Where(
                    i => i.ID.Equals(id.ToString())).Single().Comments;
            }

            return View(viewModel);
        }

        // GET: Author/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Author/Create
        [AdminAuthorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "ID,Name,JoinDate,location")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Authors.Add(author);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Author/Edit/5
        [Authorize(Roles = "Author")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            if (!id.Equals(User.Identity.GetUserId()))
            {
                return View("~/Views/Shared/NotOwner.cshtml");
            }
            return View(author);
        }

        // POST: Author/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Author")]
        public ActionResult Edit([Bind(Include = "ID,Name,JoinDate,location")] Author author)
        {
            if (!author.ID.Equals(User.Identity.GetUserId()))
            {
                return View("~/Views/Shared/NotOwner.cshtml");
            }
            if (ModelState.IsValid)
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Author/Delete/5
        [AdminAuthorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Author/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(string id)
        {
            Author author = db.Authors.Find(id);
            db.Authors.Remove(author);
            db.SaveChanges();
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