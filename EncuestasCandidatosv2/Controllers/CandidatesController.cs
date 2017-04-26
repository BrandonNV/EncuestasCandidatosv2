using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EncuestasCandidatosv2;

namespace EncuestasCandidatosv2.Controllers
{
    public class CandidatesController : Controller
    {
        private CANDIDATE1Entities db = new CANDIDATE1Entities();

        // GET: Candidates
        public ActionResult Index()
        {
            var candidate = db.Candidate.Include(c => c.Party);
            return View(candidate.ToList());
        }

        // GET: Candidates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidate.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // GET: Candidates/Create
        public ActionResult Create()
        {
            ViewBag.ID_Party = new SelectList(db.Party, "ID_Party", "NA_Party");
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Candidate,NA_FirstName,NA_LastName,NA_MothersMaidenName,DA_Birth,NA_Sex,NA_Address,NU_SocialSecurity,NA_Education,NA_Religion,NA_Ethnicity,NA_ActualPosition,ID_Party")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                db.Candidate.Add(candidate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Party = new SelectList(db.Party, "ID_Party", "NA_Party", candidate.ID_Party);
            return View(candidate);
        }

        // GET: Candidates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidate.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Party = new SelectList(db.Party, "ID_Party", "NA_Party", candidate.ID_Party);
            return View(candidate);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Candidate,NA_FirstName,NA_LastName,NA_MothersMaidenName,DA_Birth,NA_Sex,NA_Address,NU_SocialSecurity,NA_Education,NA_Religion,NA_Ethnicity,NA_ActualPosition,ID_Party")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Party = new SelectList(db.Party, "ID_Party", "NA_Party", candidate.ID_Party);
            return View(candidate);
        }

        // GET: Candidates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidate.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Candidate candidate = db.Candidate.Find(id);
            db.Candidate.Remove(candidate);
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
