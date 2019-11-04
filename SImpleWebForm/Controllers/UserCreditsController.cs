using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimpleWebForm.Models;

namespace SimpleWebForm.Controllers
{
    public class UserCreditsController : Controller
    {
        private DrawFiveEntities db = new DrawFiveEntities();

        // GET: UserCredits
        public ActionResult Index()
        {
            return View(db.UserCredits.ToList());
        }

        // GET: UserCredits/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCredit userCredit = db.UserCredits.Find(id);
            if (userCredit == null)
            {
                return HttpNotFound();
            }
            return View(userCredit);
        }

        // GET: UserCredits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserCredits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Credits")] UserCredit userCredit)
        {

            TempData["UserExists"] = false;


            var userExists = db.UserCredits.Find(userCredit.UserId);
                if (userExists != null)
                {
                 TempData["UserExists"] = true;
                return RedirectToAction("Create");
                }
  

            if (ModelState.IsValid)
            {
                db.UserCredits.Add(userCredit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userCredit);
        }

        // GET: UserCredits/Edit/Player1 (example)
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCredit userCredit = db.UserCredits.Find(id);
            if (userCredit == null)
            {
                return HttpNotFound();
            }
            return View(userCredit);
        }

        // POST: UserCredits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Credits")] UserCredit userCredit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userCredit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userCredit);
        }

        // GET: UserCredits/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCredit userCredit = db.UserCredits.Find(id);
            if (userCredit == null)
            {
                return HttpNotFound();
            }
            return View(userCredit);
        }

        // POST: UserCredits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserCredit userCredit = db.UserCredits.Find(id);
            db.UserCredits.Remove(userCredit);
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
