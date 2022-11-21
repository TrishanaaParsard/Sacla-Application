using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SaclaApplication.Models;

namespace SaclaApplication.Controllers
{
    [Authorize(Roles = "Author")]
    public class PapersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //GET: MyPapers
        public ActionResult MyPapers() 
        {
            var papers = db.Papers
               .Where(x => x.PaperAuthor == User.Identity.Name)
               .OrderBy(t => t.PaperTitle);

            return View(papers);
        }

        [AllowAnonymous]
        // GET: Papers
        public ActionResult Index()
        {
            return View(db.Papers.ToList());
        }

        // GET: Papers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Papers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaperId,PaperTitle,PaperAbstract,PaperAuthor,PaperDateSubmitted,TopicId")] Paper paper)
        {
            if (ModelState.IsValid)
            {
                paper.PaperAuthor = User.Identity.Name;
                paper.PaperDateSubmitted = DateTime.Now;
                db.Papers.Add(paper);
                db.SaveChanges();
                TempData["Referrer"] = "Create";
                return RedirectToAction("MyPapers");
            }

            return View(paper);
        }

        // GET: Papers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paper paper = db.Papers.Find(id);
            if (paper == null)
            {
                return HttpNotFound();
            }
            return View(paper);
        }

        // POST: Papers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaperId,PaperTitle,PaperAbstract,PaperAuthor,PaperDateSubmitted,TopicId")] Paper paper)
        {
            if (ModelState.IsValid)
            {
                paper.PaperAuthor = User.Identity.Name;
                paper.PaperDateSubmitted = DateTime.Now;
                db.Entry(paper).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Referrer"] = "Edit";
                return RedirectToAction("MyPapers");
            }
            return View(paper);
        }

        // POST: Papers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Paper paper = db.Papers.Find(id);
            db.Papers.Remove(paper);
            db.SaveChanges();
            TempData["Referrer"] = "Delete";
            return RedirectToAction("MyPapers");
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
