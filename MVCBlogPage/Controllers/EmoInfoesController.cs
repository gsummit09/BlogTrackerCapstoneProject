using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCBlogPage.Models;

namespace MVCBlogPage.Controllers
{
    public class EmoInfoesController : Controller
    {
        private BlogDbEntities db = new BlogDbEntities();

        // GET: EmoInfoes
        public ActionResult Index()
        {
            return View(db.EmoInfoes.ToList());
        }

        // GET: EmoInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmoInfo emoInfo = db.EmoInfoes.Find(id);
            if (emoInfo == null)
            {
                return HttpNotFound();
            }
            return View(emoInfo);
        }

        // GET: EmoInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmoInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpId,EmailId,Name,DateOfJoining,PassCode")] EmoInfo emoInfo)
        {
            if (ModelState.IsValid)
            {
                db.EmoInfoes.Add(emoInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emoInfo);
        }

        // GET: EmoInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmoInfo emoInfo = db.EmoInfoes.Find(id);
            if (emoInfo == null)
            {
                return HttpNotFound();
            }
            return View(emoInfo);
        }

        // POST: EmoInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpId,EmailId,Name,DateOfJoining,PassCode")] EmoInfo emoInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emoInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emoInfo);
        }

        // GET: EmoInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmoInfo emoInfo = db.EmoInfoes.Find(id);
            if (emoInfo == null)
            {
                return HttpNotFound();
            }
            return View(emoInfo);
        }

        // POST: EmoInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmoInfo emoInfo = db.EmoInfoes.Find(id);
            db.EmoInfoes.Remove(emoInfo);
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
        [HttpGet]
        public ActionResult BlogList()
        {
            return View(db.BlogInfoes.ToList());
        }
        [HttpGet]
        public ActionResult SaveBlog()
        {
            return View(new BlogInfo());
        }
    }
}
