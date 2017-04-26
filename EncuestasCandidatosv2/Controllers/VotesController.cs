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
    public class VotesController : Controller
    {
        private CANDIDATE1Entities db = new CANDIDATE1Entities();

        // GET: Votes
        public ActionResult Index()
        {
            var vote = db.Vote.Include(v => v.Candidate).Include(v => v.Place).Include(v => v.Position);
            return View(vote.ToList());
        }

        // GET: Votes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vote vote = db.Vote.Find(id);
            if (vote == null)
            {
                return HttpNotFound();
            }
            return View(vote);
        }

        // GET: Votes/Create
        public ActionResult Create()
        {
            ViewBag.ID_Candidate = new SelectList(db.Candidate, "ID_Candidate", "NA_FirstName");
            ViewBag.ID_Place = new SelectList(db.Place, "ID_Place", "NA_State");
            ViewBag.ID_Position = new SelectList(db.Position, "ID_Position", "NA_Position");
            return View();
        }

        // POST: Votes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Vote,ID_Candidate,ID_Place,ID_Position,DOC_VoteForm")] Vote vote)
        {
            if (ModelState.IsValid)
            {
                db.Vote.Add(vote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Candidate = new SelectList(db.Candidate, "ID_Candidate", "NA_FirstName", vote.ID_Candidate);
            ViewBag.ID_Place = new SelectList(db.Place, "ID_Place", "NA_State", vote.ID_Place);
            ViewBag.ID_Position = new SelectList(db.Position, "ID_Position", "NA_Position", vote.ID_Position);
            return View(vote);
        }

        // GET: Votes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vote vote = db.Vote.Find(id);
            if (vote == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Candidate = new SelectList(db.Candidate, "ID_Candidate", "NA_FirstName", vote.ID_Candidate);
            ViewBag.ID_Place = new SelectList(db.Place, "ID_Place", "NA_State", vote.ID_Place);
            ViewBag.ID_Position = new SelectList(db.Position, "ID_Position", "NA_Position", vote.ID_Position);
            return View(vote);
        }

        // POST: Votes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Vote,ID_Candidate,ID_Place,ID_Position,DOC_VoteForm")] Vote vote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Candidate = new SelectList(db.Candidate, "ID_Candidate", "NA_FirstName", vote.ID_Candidate);
            ViewBag.ID_Place = new SelectList(db.Place, "ID_Place", "NA_State", vote.ID_Place);
            ViewBag.ID_Position = new SelectList(db.Position, "ID_Position", "NA_Position", vote.ID_Position);
            return View(vote);
        }

        // GET: Votes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vote vote = db.Vote.Find(id);
            if (vote == null)
            {
                return HttpNotFound();
            }
            return View(vote);
        }

        // POST: Votes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vote vote = db.Vote.Find(id);
            db.Vote.Remove(vote);
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
