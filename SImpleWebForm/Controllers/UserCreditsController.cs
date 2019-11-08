using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SimpleWebForm.Models;

namespace SimpleWebForm.Controllers
{
    public class UserCreditsController : Controller
    {
        private readonly DrawFiveEntities _db = new DrawFiveEntities();

        // GET: UserCredits
        public ActionResult Index()
        {
            return View(_db.UserCredits.ToList());
        }

        // GET: UserCredits/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCredit userCredit = _db.UserCredits.Find(id);
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


            var userExists = _db.UserCredits.Find(userCredit.UserId);
                if (userExists != null)
                {
                 TempData["UserExists"] = true;
                return RedirectToAction("Create");
                }
  

            if (ModelState.IsValid)
            {
                _db.UserCredits.Add(userCredit);
                _db.SaveChanges();
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
            UserCredit userCredit = _db.UserCredits.Find(id);
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
                _db.Entry(userCredit).State = EntityState.Modified;
                _db.SaveChanges();
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
            UserCredit userCredit = _db.UserCredits.Find(id);
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
            UserCredit userCredit = _db.UserCredits.Find(id);
            _db.UserCredits.Remove(userCredit ?? throw new InvalidOperationException());
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
